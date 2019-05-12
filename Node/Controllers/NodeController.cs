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

namespace Node.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class NodeController : ControllerBase {
    private string myAddress = "localhost:5001";
    private string master = "localhost:5000"


    public string[] getAllNodesFromMain(){
      //connect to main server and get all the living nodes
      //returns list of adjacent nodes

      return ["127.0.0.1:5002", "127.0.0.1:5003" ];
    }

    public async Task<Object> SendMessage(string message, string address){
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(address);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync(path);

        if (response.IsSuccessStatusCode){
            product = await response.Content.ReadAsAsync<Product>();
        }
        return product;

    }

    public void AlertMaster(){
        string msg = {address : myAddress, name:"jessin rodenburg", key: "ioweuHFD"}
        SendMessage(msg, master)
    }

    // GET api/node
    [HttpGet ()]
    public string Get () {
      string parentOfStartupPath = Path.GetFullPath (Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
      string text = System.IO.File.ReadAllText (parentOfStartupPath + "/node.json");
      JObject result = JObject.Parse (text);
      return result.ToString ();
    }
  }
}