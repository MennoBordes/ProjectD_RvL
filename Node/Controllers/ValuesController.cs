using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Node.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase {

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get () {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet ("{id}")]
    public ActionResult<string> Get (int id) {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post ([FromBody] string value) {
      System.Console.WriteLine (value);
    }

    // PUT api/values/5
    [HttpPut ("{id}")]
    public void Put (int id, [FromBody] string value) { }

    // DELETE api/values/5
    [HttpDelete ("{id}")]
    public void Delete (int id) { }
  }
}