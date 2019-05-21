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
        [HttpPost ()]
        public JObject Post ([FromBody] Tupl2 tuple2) {
            string privateKey = "<RSAKeyValue><Modulus>vR/y8Z+LblM64thdCBkayA/lb5n2VPitqnQ8kxMEDS1YhxDqH2cl1/UhKpXDkTwKWYTZzaXafUq2P+QnJycnq3uNuRi0R/9ujMuoOLrHEpoDXEgZoEpMQcbxSMmRbialoo5EQV25vk1WUPEsOblTN87olDy6v5eny8KWhlvk7Ak=</Modulus><Exponent>AQAB</Exponent><P>7oMAs+b6KBMkYEWbi6riISi5diy81X6TuAE0tPbzmYIUuHNLJ9HhCBc4rIZcurwoVcApJlezO66SFhRwNr07IQ==</P><Q>yv3tHsx1yv8/4zxzXOAWvsJHx4WqA8tp7bdhGH5rgBJmu54tliS1pTbffBvnnOssIFFY4nJ7Q2g6JJOPoVm76Q==</Q><DP>Ssu6RLCCcl7OYYJyrPIBx/RFdNHCxhDTsjhulvF6owEwDkfZobsnnqnpk/Du04B+BaYlQWjvRCASn+n45rGhAQ==</DP><DQ>VjPlWZnsP+uLfv1x5DQJlLK+dr2NiJT+hAPHCPbOwhGObQhsRYGLXgDigTr8bcf08jh5bZi+Pc7qOhQr/5Iy2Q==</DQ><InverseQ>AFbQk1ouaSRQ+phbX1GpLWYMGyM6dUlmet2BSqJwjNEoP2ytOgvH5JcrTDNbXz08LzY4J7HXH6u/kJXJlib64Q==</InverseQ><D>ReepROZUA1OAUJjoyjV9ULWPeNDP3FiO2JJeUX6V4MkCD+qQn0rhEhHpUHRK9UPcD3qrhvfm6qjS9IrAbhhq8LRpRjl51mG7LsAkWxD6ZggDOKN/xBuhWs1sx7uoI2gRDwMAAmgLGnpsj5CQbcLMZhxQYsoQAZGzBsCXyeCuIAE=</D></RSAKeyValue>";
            string parentOfStartupPath = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
            string text = System.IO.File.ReadAllText (parentOfStartupPath + "/node.json");
            JObject result = JObject.Parse (text);
            JArray currentData = (JArray) result["node"]["CHAIN_COPY"];
            foreach (JObject block in currentData) {
                LetsDecrypt LetsDecrypt = new LetsDecrypt ((JObject) block["data"], privateKey);
                System.Console.WriteLine ((JObject) block["data"]);
                block["data"] = LetsDecrypt.showDecrypted ();
            }
            return result;
        }

    }
}