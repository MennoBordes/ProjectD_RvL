using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Classes;
using BlockChainData = Server.Classes.NewBlock.Data;

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
