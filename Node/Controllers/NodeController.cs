using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Node.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class NodeController : ControllerBase {
    // GET api/node
    [HttpGet ()]
    public string Get () {
      string parentOfStartupPath = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
      string text = System.IO.File.ReadAllText (parentOfStartupPath + "/node.json");
      JObject result = JObject.Parse (text);
      return result.ToString ();
    }
  }
}