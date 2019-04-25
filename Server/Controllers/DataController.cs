using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Classes;

namespace Server.Controllers {

    [Route ("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase {

        // GET: api/data
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get () {
            return new string[] { "Zeehondjes" };
        }

        // GET: api/getkeys
        [HttpGet ("getkeys/{choice}")]
        public string Get (int choice) {
            if (choice == 0) {
                GenerateKeyPair keys = new GenerateKeyPair ();
                return keys.showBoth ();
            }
            return "error";
        }

        // POST: api/data/crypto - takes input in Data class form,
        // encrypts or decrypts data
        [HttpPost ("crypto")]
        public DataObject Post ([FromBody] Tupl2 tuple2) {

            if (tuple2.data.Aanhoudingen.Length > 100) {
                LetsDecrypt LetsDecrypt = new LetsDecrypt (tuple2.data, tuple2.keys);
                return LetsDecrypt.showDecrypted ();
            }
            LetsEncrypt LetsEncrypt = new LetsEncrypt (tuple2.data, tuple2.keys);
            return LetsEncrypt.showEncrypted ();
        }

    }
}