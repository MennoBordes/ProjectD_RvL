using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Classes.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Server.Controllers.RunningNodes
{
  [Route("api/[controller]")]
  [ApiController]
  public class NodesController : Controller
  {
    Node nodes = new Node();
    // GET: api/nodes
    [HttpGet]
    public ActionResult<int> Get()
    {
      return 200;
    }

    // GET api/nodes/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value: " + id;
    }

    // POST: api/nodes
    [HttpPost]
    public string Post([FromBody] NodeCredentials Credentials)
    {
      return Credentials.GetRSA();
    }

    // PUT: api/nodes/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpGet("Test")]
    public JsonResult Test()
    {
      return Json("To show all running nodes");
    }

    [HttpGet("ttt")]
    public void ttt()
    {
      WorkingNodes.timekeeper();
    }

    [HttpPut("runningNodes")]
    public JsonResult runningNodes([FromBody] NodeCredentials NodeCredentials)
    {
      return Json(NodeCredentials.GetAllNodeCredentials());
    }
    private static string SavedNodesLocation = CommonNodeVariables.SavedNodesLocation;


    [HttpGet("runningNodes")]
    public JsonResult runningNodes()
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

    [HttpPut("nodes")]

    public async void SaveRunningNodes()
    {
      // get all running nodes from file
      var tempp = new WorkingNodes();

      string serverloc = "https://localhost:5001/api/values";
      System.Net.Http.HttpResponseMessage response = await tempp.IsNodeRunningAsync(serverloc);
      // var res = new WorkingNodes().IsNodeRunningAsync(serverloc);
      // var res = new WorkingNodes().CheckNodeRunning(serverloc);
      // check if each node is still running
      // save the nodes that replied within 2 secs

      // ↓ Needs the actual running nodes
      var VerifiedRunningNodes = new Node();

      // ↓ Works ↓
      WorkingNodes.SaveRunningNodes(VerifiedRunningNodes);
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
