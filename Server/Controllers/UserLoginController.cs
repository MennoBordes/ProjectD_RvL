using Microsoft.AspNetCore.Mvc;
using Server.Classes.Nodes;
using Server.Classes.Users;
using System.Collections;

namespace Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserLoginController : ControllerBase
  {
    // GET: api/UserLogin
    [HttpGet]
    public ActionResult<int> Get()
    {
      return 200;
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value: " + id;
    }

    // POST: api/UserLogin
    [HttpPost]
    public string Post([FromBody] NodeCredentials Credentials)
    {
      return Credentials.GetRSA();
    }

    // PUT: api/UserLogin/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // PUT: api/UserLogin/user
    [HttpPut("{user}")]
    public ActionResult<IEnumerable> Put(string user, [FromBody] UserCredentials UserCredentials)
    {
      return new string[] {UserCredentials.GetInstantieNaam(), UserCredentials.GetInstantieRechten().ToString()};
    }    

    // PUT: api/UserLogin/node
    // Is used to get credentials form the child node's
    [HttpPut("{node}")]
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
