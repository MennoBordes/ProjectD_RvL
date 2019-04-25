using Microsoft.AspNetCore.Mvc;
using Server.Classes.Nodes;
using System.Collections;

namespace Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NodeLoginController : Controller
  {
    // GET: api/nodeLogin
    [HttpGet]
    public ActionResult<int> Get()
    {
      return 200;
    }

    // GET api/nodelogin/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value: " + id;
    }

    // POST: api/nodeLogin
    [HttpPost]
    public string Post([FromBody] NodeCredentials Credentials)
    {
      return Credentials.GetRSA();
    }

    // PUT: api/nodeLogin/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }  

    // PUT: api/nodeLogin/node
    // Is used to get credentials form the child node's
    [HttpPut]
    public ActionResult<IEnumerable> Put([FromBody] NodeCredentials NodeCredentials)
    {
      return new string[] {NodeCredentials.GetIP(), NodeCredentials.GetRSA(), NodeCredentials.GetDate()};
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
