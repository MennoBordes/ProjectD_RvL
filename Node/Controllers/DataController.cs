using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Node.Classes;
using Node.Classes.Decryption;
using Server.Classes.Maybe;

namespace Node.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase {

        private string portOfNode = "4001";
        // GET api/data
        [HttpGet ("getdecryptednode")]
        public JObject getDecryptedNode () {
            string parentOfStartupPath = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
            string node_id = System.IO.File.ReadAllText (parentOfStartupPath + "/node.json");
            string instanties = System.IO.File.ReadAllText (parentOfStartupPath + "/privateKey.json");

            JObject result = JObject.Parse (node_id);
            JObject instanties_parsed = JObject.Parse (instanties);
            JArray instanties_array = (JArray) instanties_parsed["instanties"];
            foreach (JObject instantie in instanties_array) {
                System.Console.WriteLine ("instantieport " + (string) instantie["port"]);
                if (portOfNode == (string) instantie["port"]) {
                    JArray currentData = (JArray) result["node"]["CHAIN_COPY"];
                    foreach (JObject block in currentData) {
                        LetsDecrypt LetsDecrypt = new LetsDecrypt ((JObject) block["data"], (string) instantie["private"]);
                        block["data"] = LetsDecrypt.showDecrypted ();
                    }
                }
            }

            return result;
        }

        // GET api/data
        [HttpGet ("getencryptednode")]
        public JObject getencryptednode () {
            string parentOfStartupPath = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
            string node_id = System.IO.File.ReadAllText (parentOfStartupPath + "/node.json");

            JObject result = JObject.Parse (node_id);

            JArray currentData = (JArray) result["node"]["CHAIN_COPY"];

            JObject zuc = new JObject (
                new JProperty ("node", portOfNode),
                new JProperty ("chain", currentData)
            );

            return zuc;
        }

        [HttpPost ("saveblock")]
        public void saveBlock ([FromBody] JObject json) {

            string parentOfStartupPath = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
            string current_identity = System.IO.File.ReadAllText (parentOfStartupPath + "/node.json");
            JObject node = JObject.Parse (current_identity);
            // System.Console.WriteLine (node);

            JArray chain_copy = (JArray) node["node"]["CHAIN_COPY"];
            foreach (JObject incomingBlock in json["chain"]) {

                System.Console.WriteLine ("timestamp is valid: " + Node.Classes.Validation.validateBlock (incomingBlock, chain_copy));
                try {
                    if (Node.Classes.Validation.validateBlock (incomingBlock, chain_copy)) {
                        chain_copy.Add (incomingBlock);
                    }
                } catch { }

            }
            // System.Console.WriteLine (node);
            System.IO.File.WriteAllText (parentOfStartupPath + "/node.json", node.ToString ());
        }

        [HttpPost ("overrideblock")]
        public void overrideBlock ([FromBody] JObject json) {

            string parentOfStartupPath = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
            string current_identity = System.IO.File.ReadAllText (parentOfStartupPath + "/node.json");
            JObject node = JObject.Parse (current_identity);
            // System.Console.WriteLine (node);

            JArray chain_copy = (JArray) node["node"]["CHAIN_COPY"];
            chain_copy = (JArray) json["CHAIN_COPY"];
            // System.Console.WriteLine (node);
            System.IO.File.WriteAllText (parentOfStartupPath + "/node.json", node.ToString ());
        }
    }
}