using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Server.Classes.Nodes
{
  public class NodeCredentials
  {
    private string IP, RSA;
    private DateTime Date;
    public NodeCredentials(string ip, string rsa, DateTime Date)
    {
      this.IP = ip;
      this.RSA = rsa;
      this.Date = Date;
    }

    public string GetIP()
    {
      return this.IP;
    }

    public string GetRSA()
    {
      return this.RSA;
    }

    public string GetDate()
    {
      return this.Date.ToString();
    }

    public List<string> GetAllNodeCredentials()
    {
      List<string> temp = new List<string>(){
        GetIP(), 
        GetRSA(), 
        GetDate()
      };
      return temp;
    }
  }
}