using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Node.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NodeController : ControllerBase
  {
    // GET api/node
    [HttpGet()]
    public string Get()
    {
        string text = System.IO.File.ReadAllText("C:/Users/Admin/Documents/ProjectD_RvL/Node/node.json");  
        JObject result = JObject.Parse(text);
        return result.ToString();
    }
  }
}
