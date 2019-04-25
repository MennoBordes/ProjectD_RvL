using Microsoft.AspNetCore.Mvc;
using Server.Classes.Nodes;
using System.Collections;

namespace Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NodeLoginController : Controller
  {
    Node nodes = new Node();
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

    [HttpPut("Test")]
    public JsonResult Test([FromBody] NodeCredentials NodeCredentials)
    {
      return Json(NodeCredentials.GetAllNodeCredentials());
    }

    [HttpPut("nodes")]
    public JsonResult ExistingNodes([FromBody] NodeCredentials Credentials)
    {
      nodes.AddNode(Credentials);
      nodes.AddNode(Credentials);
      nodes.AddNode(Credentials);
      nodes.AddNode(Credentials);
      nodes.AddNode(Credentials);
      var t = nodes.GetAllNodes();
      return Json(data: t);
    }

    [HttpGet("About")]
    public JsonResult About()
    {
      var res = new { result = "An API for validating node login." };
      return Json(res);
    }

    // PUT: api/nodeLogin
    // Is used to get credentials form the child node's
    [HttpPut]
    public ActionResult<IEnumerable> Put([FromBody] NodeCredentials NodeCredentials)
    {
      return new string[] { NodeCredentials.GetIP(), NodeCredentials.GetRSA(), NodeCredentials.GetDate() };
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
