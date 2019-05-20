using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Node.Classes.Decryption;
using Server.Classes.Maybe;

namespace Node.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase {
        // GET api/data
        [HttpGet ()]
        public JObject Post ([FromBody] Tupl2 tuple2) {
            // if (tuple2.newdata["Naam"].ToString ().Length > 100) {
            //     LetsDecrypt LetsDecrypt = new LetsDecrypt (tuple2.newdata, tuple2.keys);
            //     return LetsDecrypt.showDecrypted ();
            // }
            string parentOfStartupPath = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
            string text = System.IO.File.ReadAllText (parentOfStartupPath + "/node.json");
            JObject result = JObject.Parse (text);
            return result;
        }

    }
}