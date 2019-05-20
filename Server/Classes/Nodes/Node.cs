using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Server.Classes.Nodes
{
  public class Node
  {
    public List<NodeCredentials> nodes;
    public Node()
    {
      this.nodes = new List<NodeCredentials>()
      {
        new NodeCredentials("NodeIp1", 2001,"RSA1",new DateTime(2019,04,15,05,55,15)),
        new NodeCredentials("NodeIp2", 2002,"RSA2",new DateTime(2019,04,15,05,55,15)),
        new NodeCredentials("NodeIp3", 2003,"RSA3",new DateTime(2019,04,15,05,55,15)),
        new NodeCredentials("NodeIp4",2004,"RSA4",new DateTime(2019,04,15,05,55,15)),
      };
    }

    public void AddNode(NodeCredentials credentials)
    {
      nodes.Add(credentials);
    }

    public void RemoveNode(string RSA)
    {
      var ResultNode = nodes.Where(node => node.GetRSA() == RSA).FirstOrDefault();
      nodes.Remove(ResultNode);
    }

    public List<List<string>> GetAllNodesList()
    {
      List<List<string>> temp = new List<List<string>>();
      foreach (var node in nodes)
      {
        temp.Add(node.GetAllNodeCredentials());
      }
      return temp;
    }

    public List<NodeCredentials> GetAllNodesClass()
    {
      List<Object> temp = new List<Object>();
      foreach (var node in nodes)
      {
        var obj = new NodeCredentials(node.GetIP(), int.Parse(node.GetPort()), node.GetRSA(), DateTime.Parse(node.GetDate()));
        temp.Add(obj);
      }
      var result = new { ip = this.nodes[0].GetIP(), };
      return this.nodes;
    }
  }
}