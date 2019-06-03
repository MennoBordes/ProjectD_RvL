using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
// using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server.Classes.Encryption;
using Server.Classes.NewBlock;

namespace Server.Controllers {

  [Route ("api/[controller]")]
  [ApiController]
  [EnableCors (origins: "*", headers: "*", methods: "*")]
  public class DataController : ControllerBase {
    HttpClient httpClient = new HttpClient ();

    // GET: api/data
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get () {
      return new string[] { "Zeehondjes" };
    }

    // GET: api/data/getkeys
    [HttpGet ("getkeys/{choice}")]
    public string Get (int choice) {
      if (choice == 0) {
        GenerateKeyPair keys = new GenerateKeyPair ();
        return keys.showBoth ();
      }
      return "error";
    }

    List<string> NodeUrls = new List<string> () {
      "http://localhost:4001/api/",
      "http://localhost:4002/api/",
      "http://localhost:4003/api/",
      "http://localhost:4004/api/"
    };

    [HttpPost ("client")]
    public void PushToNode ([FromBody] JObject newdata) {
      // For ignoring SSL
      ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
      ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

      string apiLoc = "data/saveblock";

      // Get the previous hash
      // Create hash from all data in current block

      // Add hash to block
      // Add previous hash to block

      // Pass data to all nodes for further validation

      // In order to send the chain to all nodes
      foreach (var item in NodeUrls) {
        // In case the node isn't running
        try {
          // The url of the api
          string url = item + apiLoc;
          WebRequest req = WebRequest.Create (url);

          // Converting data to char array
          var data = System.Text.Encoding.ASCII.GetBytes (newdata.ToString ());

          // Assigning request method
          req.Method = "POST";

          req.ContentType = "application/json; charset=utf-8";
          req.ContentLength = data.Length;

          // Adding data to pusher
          using (var streamPost = req.GetRequestStream ()) {
            streamPost.Write (data, 0, data.Length);
          }

          // Push data to client
          req.GetResponse ();
        } catch (Exception e) {
          Console.WriteLine (e);
        }
      }
    }

    [HttpGet ("client")]
    public async Task<JObject> client () {
      List<string> ports = new List<string> ();
      JArray resultChains = new JArray ();
      int totalNodesCheckedCounter = 0;

      ports.Add ("http://localhost:4001/api/data/getencryptednode"); // politie
      ports.Add ("http://localhost:4002/api/data/getencryptednode"); // gemeente
      ports.Add ("http://localhost:4003/api/data/getencryptednode"); //reclassering
      ports.Add ("http://localhost:4004/api/data/getencryptednode"); // OM

      foreach (var url in ports) {
        try {
          // For ignoring SSL

          ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
          ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

          // Creating Webrequest
          WebRequest req = WebRequest.Create (url);

          // Assigning request method
          req.Method = "GET";

          // Retrieving response from api
          WebResponse resp = req.GetResponse ();

          // Converting to stream
          Stream stream = resp.GetResponseStream ();

          // Reading stream
          StreamReader re = new StreamReader (stream);

          // Casting to JObject
          JObject objec = JObject.Parse (re.ReadToEnd ());
          resultChains.Add (objec);
        } catch (Exception e) {
          Console.WriteLine (e);
        }

      }

      List<string> chosenOnes = new List<string> ();
      List<string> correctNodes = new List<string> ();

      var countPortUsed = new Dictionary<string, int> ();
      var cnt = new Dictionary<string, int> ();
      foreach (JObject value in resultChains) {
        string addedHashes = "";
        string nodePort = (string) value["node"];

        foreach (JObject item in (JArray) value["chain"]) {
          addedHashes += (string) item["hash_code"];
          // if item == last item add that hash to chosenones instead of whole chain
        }
        if (cnt.ContainsKey (addedHashes)) {
          cnt[addedHashes]++;
          JArray chain = (JArray) value["chain"];
          string hashOfLastBlockInChain = (string) chain.Last["hash_code"];
          chosenOnes.Add (hashOfLastBlockInChain);
          correctNodes.Add (nodePort);
          // of if this is active, add the last hash of the value data object to chosenones instead of whole chain
        } else {
          cnt.Add (addedHashes, 1);
        }
        totalNodesCheckedCounter += 1;
      }
      string mostCommonValue = "";
      int highestCount = 0;

      foreach (KeyValuePair<string, int> pair in cnt) {
        if (pair.Value > highestCount) {
          mostCommonValue = pair.Key;
          highestCount = pair.Value;
        }
      }
      System.Console.WriteLine (correctNodes.ElementAt (0));
      JArray validChain = new JArray ();
      foreach (var value in resultChains) {
        string nodePort = (string) value["node"];
        if (nodePort == correctNodes.ElementAt (0)) {
          validChain = (JArray) value["chain"];
          break;
        }
      }

      // Returning objec
      return new JObject (
        new JProperty ("totalNodesChecked", totalNodesCheckedCounter),
        new JProperty ("nodesThatWhereValid", highestCount),
        new JProperty ("acceptedLatestHash", chosenOnes.ElementAt (0)),
        new JProperty ("CHAIN_COPY", validChain)

      );

      // List<string> ports = new List<string> ();
      // JArray resultChains = new JArray ();
      // int totalNodesCheckedCounter = 0;

      // ports.Add ("http://localhost:4001/api/data/overrideblock"); // politie
      // ports.Add ("http://localhost:4002/api/data/overrideblock"); // gemeente
      // ports.Add ("http://localhost:4003/api/data/overrideblock"); //reclassering
      // ports.Add ("http://localhost:4004/api/data/overrideblock"); // OM

      // foreach (var url in ports) {
      //   try {
      //     // For ignoring SSL

      //     ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
      //     ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

      //     // Creating Webrequest
      //     WebRequest req = WebRequest.Create (url);

      //     // Assigning request method
      //     req.Method = "POST";

      //     // Retrieving response from api
      //     WebResponse resp = req.GetResponse ();

      //     // Converting to stream
      //     Stream stream = resp.GetResponseStream ();

      //     // Reading stream
      //     StreamReader re = new StreamReader (stream);

      //     // Casting to JObject
      //     JObject objec = JObject.Parse (re.ReadToEnd ());
      //     resultChains.Add (objec);
      //   } catch (Exception e) {
      //     Console.WriteLine (e);
      //   }

    }

    // POST: api/data/crypto - takes input in Data class form,
    // encrypts or decrypts data
    [HttpPost ("encryptdata")]
    public JObject Post ([FromBody] JObject newdata) {
      string parentOfStartupPathKeys = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../tempKeys"));
      string keys_of_instanced = System.IO.File.ReadAllText (parentOfStartupPathKeys + "/keys.json");
      JObject keys_of_instanced_parsed = JObject.Parse (keys_of_instanced);
      System.Console.WriteLine (keys_of_instanced_parsed);

      LetsEncrypt LetsEncrypt = new LetsEncrypt ((JObject) newdata["newdata"], keys_of_instanced_parsed);
      return LetsEncrypt.showEncrypted ();
    }

  }
}