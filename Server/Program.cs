using System;
using System.Collections.Generic;
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

namespace Server {
    public class Program {
        private static readonly HttpClient client = new HttpClient ();

        public static void Main (string[] args) {
            // GetNodeInfo ("5000");
            CreateWebHostBuilder (args).Build ().Run ();
        }

        // static async void GetNodeInfo (string port) {
        //     var responseString = await client.GetStringAsync ("http://localhost:" + port + "/api/node");
        //     JObject nodeInfo = JObject.Parse (responseString);
        //     System.Console.WriteLine (nodeInfo.ToString ());
        // }

        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ();
    }
}