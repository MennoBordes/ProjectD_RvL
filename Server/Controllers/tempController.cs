using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Server.Classes.Queue;
using Server.Classes.Nodes;
using Server.Classes.Encryption;
using BlockChainData = Server.Classes.NewBlock.Block;

namespace Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TempController : ControllerBase
  {
    [HttpGet]
    public string Get()
    {
      var sb = new StringBuilder();
      foreach (var item in PushQueue.Queue)
      {
        sb.Append(item.ToString());
        sb.Append(" ");
      }
      return sb.ToString();
    }

    // POST api/values
    [HttpPost]
    public string Post([FromBody] BlockChainData data)
    {
      PushQueue.Queue.Enqueue(data);
      var sb = new StringBuilder();
      foreach (var item in PushQueue.Queue)
      {
        sb.Append(item.ToString());
        sb.Append(" ");
      }
      return sb.ToString();
    }
  }
}
