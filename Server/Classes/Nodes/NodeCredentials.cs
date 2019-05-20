using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Server.Classes.Nodes
{
  public class NodeCredentials
  {
    public string IP, RSA;
    public DateTime Date;
    public int Port;
    public NodeCredentials(string ip, int Port, string rsa, DateTime Date)
    {
      this.IP = ip;
      this.RSA = rsa;
      this.Date = Date;
      this.Port = Port;
    }

    public string GetIP()
    {
      return this.IP;
    }

    public string GetPort()
    {
      return this.Port.ToString();
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
        GetPort(),
        GetRSA(),
        GetDate()
      };
      return temp;
    }
  }
}