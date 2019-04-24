using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers {

    [Route ("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase {
        // GET: api/data
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get () {
            return new string[] { "Zeehondjes" };
        }

        [HttpPost ("createblock")]
        public Block Post ([FromBody] Data data) {
            return new Block ("304940940", "493493493", null, null, data);
        }

    }
}