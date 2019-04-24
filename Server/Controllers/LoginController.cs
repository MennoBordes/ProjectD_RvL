﻿using Microsoft.AspNetCore.Mvc;
using Server.Classes.Nodes;
using Server.Classes.Users;
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
    public string Post([FromBody] NodeCredentials Credentials)
    {
      return Credentials.GetRSA();
    }

    // PUT: api/Login/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // PUT: api/Login/user
    [HttpPut("{user}")]
    public ActionResult<IEnumerable> Put(string user, [FromBody] UserCredentials UserCredentials)
    {
      return new string[] {UserCredentials.GetInstantieNaam(), UserCredentials.GetInstantieRechten().ToString()};
    }    

    // PUT: api/Login/node
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
