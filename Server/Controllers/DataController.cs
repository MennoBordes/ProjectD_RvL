using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
// using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server.Classes.Encryption;
using Server.Classes.NewBlock;

namespace Server.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class DataController : ControllerBase
  {
    HttpClient httpClient = new HttpClient();

    // GET: api/data
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "Zeehondjes" };
    }

    // GET: api/data/getkeys
    [HttpGet("getkeys/{choice}")]
    public string Get(int choice)
    {
      if (choice == 0)
      {
        GenerateKeyPair keys = new GenerateKeyPair();
        return keys.showBoth();
      }
      return "error";
    }

    //api/data/getcurrentchain
    [HttpGet("getcurrentchain")]
    public JObject getcurrentchain()
    {
      string parentOfStartupPath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
      string current_identity = System.IO.File.ReadAllText(parentOfStartupPath + "/chainExample.json");
      JObject current_identity_parsed = JObject.Parse(current_identity);
      return current_identity_parsed;
    }

    [HttpPost("client")]
    public void PushToNode([FromBody] JObject newdata)
    {
      // The Url of the api
      var url = "http://localhost:4000/api/data/saveblock";

      // For ignoring SSL
      ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
      ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

      // Creating Webrequest
      WebRequest req = WebRequest.Create(url);

      // Converting data to char array
      var data = System.Text.Encoding.ASCII.GetBytes(newdata.ToString());

      // Assigning request method
      req.Method = "POST";

      req.ContentType = "application/json; charset=utf-8";
      req.ContentLength = data.Length;

      // Adding data to pusher
      using (var streamPost = req.GetRequestStream())
      {
        streamPost.Write(data, 0, data.Length);
      }

      // Push data to client
      req.GetResponse();
    }


    [HttpGet("client")]
    public async Task<JObject> client()
    {
      // The url of the api
      var url = "http://localhost:4000/api/data/getdecryptednode";

      // For ignoring SSL
      ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
      ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

      // Creating Webrequest
      WebRequest req = WebRequest.Create(url);

      // Assigning request method
      req.Method = "GET";

      // Specifying valid return types
      req.ContentType = "application/json; charset=utf-8";

      // Retrieving response from api
      WebResponse resp = req.GetResponse();

      // Converting to stream
      Stream stream = resp.GetResponseStream();

      // Reading stream
      StreamReader re = new StreamReader(stream);

      // Casting to JObject
      JObject objec = JObject.Parse(re.ReadToEnd());

      // Returning objec
      return objec;
    }

    // POST: api/data/crypto - takes input in Data class form,
    // encrypts or decrypts data
    [HttpPost("encryptdata")]
    public JObject Post([FromBody] JObject newdata)
    {
      string parentOfStartupPathKeys = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"../../../tempKeys"));
      string keys_of_instanced = System.IO.File.ReadAllText(parentOfStartupPathKeys + "/keys.json");
      JObject keys_of_instanced_parsed = JObject.Parse(keys_of_instanced);
      System.Console.WriteLine(keys_of_instanced_parsed);

      LetsEncrypt LetsEncrypt = new LetsEncrypt((JObject)newdata["newdata"], keys_of_instanced_parsed);
      return LetsEncrypt.showEncrypted();
    }

  }
}