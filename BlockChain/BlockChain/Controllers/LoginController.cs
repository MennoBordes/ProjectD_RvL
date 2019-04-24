using Microsoft.AspNetCore.Mvc;
using BlockChain.Classes;
using System.Collections;

namespace BlockChain.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    // GET: api/Login
    [HttpGet]
    public ActionResult<int> Get()
    {
      return 200;
    }

    // GET: api/Login/5/Jan
    [HttpGet("{id}/{Name}", Name = "Get")]
    public ActionResult<IEnumerable> Get(int id, string Name)
    {
      return new string[] { $"value: {id}", $"name: {Name}"};
    }

    // POST: api/Login
    [HttpPost]
    public string Post([FromBody] LoginCredentials Credentials)
    {
      return Credentials.GetRSA();
    }

    // PUT: api/Login/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // PUT: api/Login
    [HttpPut]
    public string Put([FromBody] LoginCredentials Credentials)
    {
      return Credentials.GetIP();
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
