using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server.Classes.Encryption;
using Server.Classes.NewBlock;

namespace Server.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
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


    [HttpGet("client")]
    // public async ActionResult<string> Post()
    public async Task<JObject> client()
    {

      // var url = "http://localhost:4000/api/values";
      // Used to get the entire chain
      var url = "http://localhost:4000/api/data/getdecryptednode";

      ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
      ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

      WebRequest req = WebRequest.Create(url);

      req.Method = "GET";

      req.ContentType = "application/json; charset=utf-8";

      WebResponse resp = req.GetResponse();

      Stream stream = resp.GetResponseStream();

      StreamReader re = new StreamReader(stream);

      // String json = re.ReadToEnd();
      JObject objec = JObject.Parse(re.ReadToEnd());

      // System.Console.WriteLine("JSON IS DIT=======" + json);
      return objec;
      // return null;
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