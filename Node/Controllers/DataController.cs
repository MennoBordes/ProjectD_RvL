using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Node.Classes.Decryption;
using Server.Classes.Maybe;

namespace Node.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DataController : ControllerBase
  {
    // GET api/data
    [HttpGet("getdecryptednode")]
    public JObject getDecryptedNode()
    {
      string parentOfStartupPath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
      string node_id = System.IO.File.ReadAllText(parentOfStartupPath + "/node.json");
      string instanties = System.IO.File.ReadAllText(parentOfStartupPath + "/privateKey.json");

      JObject result = JObject.Parse(node_id);
      JObject instanties_parsed = JObject.Parse(instanties);
      JArray instanties_array = (JArray)instanties_parsed["instanties"];
      foreach (JObject instantie in instanties_array)
      {
        System.Console.WriteLine("instantieport " + (string)instantie["port"]);
        if ("4001" == (string)instantie["port"])
        {
          JArray currentData = (JArray)result["node"]["CHAIN_COPY"];
          foreach (JObject block in currentData)
          {
            LetsDecrypt LetsDecrypt = new LetsDecrypt((JObject)block["data"], (string)instantie["private"]);
            block["data"] = LetsDecrypt.showDecrypted();
          }
        }
      }

      return result;
    }

    [HttpPost("saveblock")]
    public void saveBlock([FromBody] JObject json)
    {

      string parentOfStartupPath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
      string current_identity = System.IO.File.ReadAllText(parentOfStartupPath + "/node.json");
      JObject node = JObject.Parse(current_identity);
      // System.Console.WriteLine (node);

      JArray chain_copy = (JArray)node["node"]["CHAIN_COPY"];
      foreach (JObject incomingBlock in json["chain"])
      {
        chain_copy.Add(incomingBlock);
      }
      // System.Console.WriteLine (node);
      System.IO.File.WriteAllText(parentOfStartupPath + "/node.json", node.ToString());

    }

  }

}