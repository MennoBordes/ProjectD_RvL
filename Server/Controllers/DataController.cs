using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
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
    public async Task<string> client()
    {
      var url = "https://localhost:4050/api/values";
      //   var url = "http://localhost:4000/api/values";
      //   var url = "http://localhost:5001/api/values";
      //   var url = "http://www.contoso.com/";
      using (HttpClient client = new HttpClient())
      {
        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        try
        {
          var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);

          var response = await client.SendAsync(request: httpRequest);
          //   response.EnsureSuccessStatusCode();
          //   string responseBody = await response.Content.ReadAsStringAsync();
          //   Console.WriteLine("\nResponse: {0}\n", responseBody);

          return response.ToString();
          // return await client.SendAsync(httpRequest).ToString();
        }
        catch (HttpRequestException e)
        {
          Console.WriteLine("\nException Caught!");
          Console.WriteLine("Message: {0} \n", e.Message);
          return e.Message;
        }
      }

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