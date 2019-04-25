using Microsoft.AspNetCore.Mvc;
using Server.Classes.Users;
using System.Collections;

namespace Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserLoginController : Controller
  {
    // GET: api/UserLogin
    [HttpGet]
    public ActionResult<int> Get()
    {
      return 200;
    }

    // GET api/UserLogin/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value: " + id;
    }

    // POST: api/UserLogin
    [HttpPost]
    public string Post([FromBody] UserCredentials Credentials)
    {
      return Credentials.GetInstantieNaam();
    }

    // PUT: api/UserLogin/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // PUT: api/UserLogin
    // Is used to get credentials form the users
    [HttpPut]
    public ActionResult<IEnumerable> Put(string user, [FromBody] UserCredentials UserCredentials)
    {
      return new string[] { UserCredentials.GetInstantieNaam(), UserCredentials.GetInstantieRechten() };
    }

    [HttpPut("Test")]
    public JsonResult Test([FromBody] UserCredentials UserCredentials)
    {
      return Json(UserCredentials.GetAllUserCredentials());
    }

    [HttpGet("About")]
    public ContentResult About()
    {
      return Content("An API for validating user login.");
    }

    [HttpGet("Info")]
    public JsonResult Info()
    {
      var pet = new { Age = 10, Name = "Fluffy" };
      return Json(pet);
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
