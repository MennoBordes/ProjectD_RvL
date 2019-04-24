using Microsoft.AspNetCore.Mvc;
using Server.Classes;
using System.Collections;

namespace Server.Controllers
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

    // PUT: api/Login/node
    [HttpPut("{node}")]
    public void Put(string node, [FromBody] LoginCredentials value)
    {
    }

    // PUT: api/Login/user
    [HttpPut("{user}")]
    public void Put(string user, [FromBody] string value)
    {
    }
    

    // PUT: api/Login
    // Is used to get credentials form the child node's
    [HttpPut]
    public ActionResult<IEnumerable> Put([FromBody] LoginCredentials Credentials)
    {
      return new string[] {Credentials.GetIP(), Credentials.GetRSA(), Credentials.GetDate()};
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
