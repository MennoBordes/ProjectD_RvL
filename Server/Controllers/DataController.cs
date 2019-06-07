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
using System.Security.Cryptography;
using System.Text;
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
    List<string> NodeUrls = new List<string> () {
      "http://localhost:4001/api/",
      "http://localhost:4002/api/",
      "http://localhost:4003/api/",
      "http://localhost:4004/api/"
    };

    [HttpPost ("client")]
    public void PushToNode ([FromBody] JObject newdata) {
      string TimeStamp = DateTime.Now.ToString ();
      // For ignoring SSL
      ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
      ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

      // Hash the input
      string parentOfStartupPathKeys = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../tempKeys"));
      string keys_of_instanced = System.IO.File.ReadAllText (parentOfStartupPathKeys + "/keys.json");
      JObject keys_of_instanced_parsed = JObject.Parse (keys_of_instanced);

      LetsEncrypt LetsEncrypt = new LetsEncrypt ((JObject) newdata["newdata"], keys_of_instanced_parsed);

      JObject EncryptedData = LetsEncrypt.showEncrypted ();
      // ENCRYPTING WORKS

      // Create hash from all encrypted data in current block
      SHA256 sha256 = SHA256.Create ();
      byte[] inputBytes = Encoding.ASCII.GetBytes ($"{TimeStamp}-{(JObject)EncryptedData["data"]}");
      byte[] outputBytes = sha256.ComputeHash (inputBytes);

      string BlockHash = Convert.ToBase64String (outputBytes);

      // Get the previous hash
      WebRequest webreq = WebRequest.Create ("http://localhost:5005/api/data/client");
      // Request method
      webreq.Method = "GET";

      var resp = webreq.GetResponse ();

      Stream stream = resp.GetResponseStream ();
      StreamReader re = new StreamReader (stream);

      string Previous_hash = (string) JObject.Parse (re.ReadToEnd ()) ["acceptedLatestHash"];

      JObject obj = new JObject ();
      // Add hash to block
      obj.Add ("hash_code", BlockHash);
      // Add previous hash to block
      obj.Add ("previous_hash", Previous_hash);
      obj.Add ("timestamp", TimeStamp);
      obj.Add ("data", (JObject) EncryptedData["data"]);

      JObject obj2 = new JObject (
        new JProperty ("chain", new JArray (obj))
      );

      // Pass data to all nodes for further validation

      // *************WORKS*************
      string apiLoc = "data/saveblock";
      // In order to send the chain to all nodes
      foreach (var item in NodeUrls) {
        // In case the node isn't running
        try {
          // The url of the api
          string url = item + apiLoc;
          WebRequest req = WebRequest.Create (url);

          // Converting data to char array
          var data = System.Text.Encoding.ASCII.GetBytes (obj2.ToString ());

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
      // *************WORKS*************

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
        JArray chain = (JArray) value["chain"];
        if (cnt.ContainsKey (chain.ToString ())) {
          cnt[chain.ToString ()]++;
          string hashOfLastBlockInChain = (string) chain.Last["hash_code"];
          chosenOnes.Add (hashOfLastBlockInChain);
          correctNodes.Add (nodePort);
          // of if this is active, add the last hash of the value data object to chosenones instead of whole chain
        } else {
          cnt.Add (chain.ToString (), 1);
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

      if (!correctNodes.Any ()) {
        correctNodes.Add (null);

      }

      // System.Console.WriteLine(correctNodes.ElementAt(0));
      JArray validChain = new JArray ();
      foreach (var value in resultChains) {
        string nodePort = (string) value["node"];
        if (nodePort == correctNodes.ElementAt (0)) {
          validChain = (JArray) value["chain"];
          break;
        }
      }

      // Returning objec

      // System.Console.WriteLine("1111111");
      JObject chain_copy = new JObject (new JProperty ("CHAIN_COPY", validChain));
      List<string> overridePorts = new List<string> ();

      overridePorts.Add ("http://localhost:4001/api/data/overrideblock"); // politie
      overridePorts.Add ("http://localhost:4002/api/data/overrideblock"); // gemeente
      overridePorts.Add ("http://localhost:4003/api/data/overrideblock"); //reclassering
      overridePorts.Add ("http://localhost:4004/api/data/overrideblock"); // OM

      bool mustOverride = true;

      if (!chosenOnes.Any ()) {
        // System.Console.WriteLine (resultChains[0]);
        JArray chain_array = (JArray) resultChains[0]["chain"];
        var lastInChain = chain_array.Last;
        string oneHash = (string) lastInChain["hash_code"];
        // System.Console.WriteLine("ONEHASH" + oneHash);
        chosenOnes.Add (oneHash);
        highestCount = 0;
        mustOverride = false;
      }

      if (highestCount == 4) {
        mustOverride = false;
      }

      foreach (var url in overridePorts) {
        try {
          // For ignoring SSL

          ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
          ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

          // Creating Webrequest
          WebRequest req = WebRequest.Create (url);

          // Converting data to char array
          var data = System.Text.Encoding.ASCII.GetBytes (new JObject (
            new JProperty ("totalNodesChecked", totalNodesCheckedCounter),
            new JProperty ("nodesThatWhereValid", highestCount),
            new JProperty ("acceptedLatestHash", chosenOnes.ElementAt (0)),
            new JProperty ("CHAIN_COPY", validChain),
            new JProperty ("override", mustOverride)
          ).ToString ());

          // Assigning request method
          req.Method = "POST";

          req.ContentType = "application/json; charset=utf-8";
          req.ContentLength = data.Length;

          // Adding data to pusher
          using (var streamPost = req.GetRequestStream ()) {
            streamPost.Write (data, 0, data.Length);
          }

          // Push data to client
          // System.Console.WriteLine("pushded");
          req.GetResponse ();
        } catch (Exception e) {
          Console.WriteLine (e);
        }
      }

      return new JObject (
        new JProperty ("totalNodesChecked", totalNodesCheckedCounter),
        new JProperty ("nodesThatWhereValid", highestCount),
        new JProperty ("acceptedLatestHash", chosenOnes.ElementAt (0)),
        new JProperty ("CHAIN_COPY", validChain),
        new JProperty ("override", mustOverride)
      );
    }

    // POST: api/data/crypto - takes input in Data class form,
    // encrypts or decrypts data
    [HttpPost ("encryptdata")]
    public JObject Post ([FromBody] JObject newdata) {
      System.Console.WriteLine ("COMINGIN" + newdata.ToString ());
      string parentOfStartupPathKeys = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../tempKeys"));
      string keys_of_instanced = System.IO.File.ReadAllText (parentOfStartupPathKeys + "/keys.json");
      JObject keys_of_instanced_parsed = JObject.Parse (keys_of_instanced);
      // System.Console.WriteLine(keys_of_instanced_parsed);

      LetsEncrypt LetsEncrypt = new LetsEncrypt ((JObject) newdata["newdata"], keys_of_instanced_parsed);
      return LetsEncrypt.showEncrypted ();
    }

  }
}