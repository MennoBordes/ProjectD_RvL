using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Timers;
using Newtonsoft.Json;

namespace Server.Classes.Nodes
{
  public class WorkingNodes
  {
    private static string SavedNodesLocation = CommonNodeVariables.SavedNodesLocation;
    public dynamic GetAllRunningNodesFromFile()
    {
      using (StreamReader reader = new StreamReader(SavedNodesLocation))
      {
        string json = reader.ReadToEnd();
        dynamic array = JsonConvert.DeserializeObject(json);
        return array;
      }
    }

    // public async System.Threading.Tasks.Task<bool> IsNodeRunningAsync(string NodeAddress)
    public async System.Threading.Tasks.Task<HttpResponseMessage> IsNodeRunningAsync(string url)
    {
      using (HttpClient client = new HttpClient())
      {
        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        // var response = await client.GetAsync(url);

        // response.EnsureSuccessStatusCode();
        // if(!Convert.ToBoolean(await response.Content.ReadAsStringAsync()))
        //   throw new Exception("Response from webserver was invalid.");
        // return response;
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
        var response = await client.SendAsync(httpRequest);
        // if(response != null)
        //   return true;

        // HttpWebRequest request = HttpWebRequest.CreateHttp(url);
        // request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        // return false;
        return await client.SendAsync(request: httpRequest);
      }
    }

    public static void timekeeper()
    {
      // Get all presumed running nodes

      // Check if nodes are still running

      // Remove node from running nodes if not running

      // Rerun after x seconds
      int testIndex = 0;
      RefreshTimer();
      // Werkt iig 33 minuten achter elkaar
      void RefreshTimer()
      {
        var refreshtimer = new Timer(1000);
        refreshtimer.Elapsed += new ElapsedEventHandler(connectionResetEvent);
        refreshtimer.AutoReset = true;
        refreshtimer.Enabled = true;
      }
      void connectionResetEvent(object source, ElapsedEventArgs e)
      {
        testIndex++;
        writetofile(testIndex);
      }
      void writetofile(int i)
      {
        string text = $"This is round: {i}";
        File.WriteAllText(@"D:\Temp\test" + i.ToString() + ".txt", text);
      }
    }

    public bool CheckNodeRunning(string NodeAddress)
    {
      try
      {
        System.Net.WebClient client = new System.Net.WebClient();
        string result = client.DownloadString(NodeAddress);
        return true;
      }
      catch { return false; }

    }

    public static void SaveRunningNodes(Node Node)
    {
      string jsonData = JsonConvert.SerializeObject(Node, Formatting.Indented);
      System.IO.File.WriteAllText(SavedNodesLocation, jsonData);
    }
  }
}