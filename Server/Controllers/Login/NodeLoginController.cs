using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Classes.Nodes;
// using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

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

    private static string SavedNodesLocation = CommonNodeVariables.SavedNodesLocation;

    // Add current node to the list of active nodes
    [HttpPut("savenodes")]
    public ActionResult<int> saveNodes([FromBody] NodeCredentials Credentials)
    {
      nodes.AddNode(Credentials);

      WorkingNodes.SaveRunningNodes(nodes);

      return 200;
    }

    [HttpPut("savenode")]
    public ActionResult<int> saveNode()
    {
      WorkingNodes.SaveRunningNodes(nodes);
      return 200;
    }

    [HttpGet("getnodes")]
    public JsonResult ExistingNodes()
    {
      // Creates a reader for the json file
      using (StreamReader reader = new StreamReader(SavedNodesLocation))
      {
        // Read file to end and save
        string json = reader.ReadToEnd();
        // Convert string to json
        List<NodeCredentials> Nodes = JsonConvert.DeserializeObject<List<NodeCredentials>>(json);
        // Return data
        return Json(data: Nodes);
      }

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
