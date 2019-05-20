using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Node {
    public class Program {
        private static readonly HttpClient client = new HttpClient ();

        public static void Main (string[] args) {

            // configureIdentity ();
            CreateWebHostBuilder (args).Build ().Run ();
        }

        static async void configureIdentity () {
            // Ophalen meest recente blockchain
            string parentOfStartupPath = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
            System.Console.WriteLine (parentOfStartupPath);

            var responseString = await client.GetStringAsync ("https://localhost:8080/api/data/getcurrentchain");
            string current_identity = File.ReadAllText (parentOfStartupPath + "/node.json");

            JObject current_identity_parsed = JObject.Parse (current_identity);
            JObject node = (JObject) current_identity_parsed["node"];

            Random random = new Random ();
            node["ID"] = random.Next (903900).ToString ();
            JObject blockchain = JObject.Parse (responseString);
            JArray incomingChain = (JArray) blockchain["current_blockchain"]["chain"];
            System.Console.WriteLine (incomingChain);
            node["CHAIN_COPY"] = new JArray ();
            JArray item = (JArray) node["CHAIN_COPY"];
            foreach (JObject items in incomingChain) {
                item.Add (items);
            }
            File.WriteAllText (parentOfStartupPath + "/node.json", current_identity_parsed.ToString ());
        }

        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseUrls ("https://localhost:" + (args.Length > 0 ? args[0] : "4000"))
            .UseStartup<Startup> ();

    }
}