using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Node
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public static void Main(string[] args)
        {

            GetCurrentChain();
            CreateWebHostBuilder(args).Build().Run();
        }


        static async void GetCurrentChain()
        {
            // Ophalen meest recente blockchain
            var responseString = await client.GetStringAsync("http://localhost:8080/api/blockchain");
            string text = File.ReadAllText("C:/Users/Admin/Documents/ProjectD_RvL/Node/node.json");  
            JObject result = JObject.Parse(text);
            JObject node = (JObject)result["node"];
            JArray blockhain = JArray.Parse(responseString);
            JArray item = (JArray)node["CHAIN_COPY"];
            foreach (JObject items in blockhain)
            {
                item.Add(items);
            }
            File.WriteAllText("C:/Users/Admin/Documents/ProjectD_RvL/Node/node.json", result.ToString());
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
