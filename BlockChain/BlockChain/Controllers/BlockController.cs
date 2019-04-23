
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlockChain.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BlockController : ControllerBase
  {
    // GET api/block
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "block1", "block2" };
    }

    // GET api/block/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "block"+id;
    }

    // POST api/block
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/block/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/block/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}