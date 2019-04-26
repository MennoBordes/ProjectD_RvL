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
        new NodeCredentials("NodeIp1","RSA1",new DateTime(2019,04,15,05,55,15)),
        new NodeCredentials("NodeIp2","RSA2",new DateTime(2019,04,15,05,55,15)),
        new NodeCredentials("NodeIp3","RSA3",new DateTime(2019,04,15,05,55,15)),
        new NodeCredentials("NodeIp4","RSA4",new DateTime(2019,04,15,05,55,15)),
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

    public List<List<string>> GetAllNodesList(){
      List<List<string>> temp = new List<List<string>>();
      foreach(var node in nodes){
        temp.Add(node.GetAllNodeCredentials());
      }
      return temp;
    }

    public List<NodeCredentials> GetAllNodesClass(){
      // List<NodeCredentials> temp = new List<NodeCredentials>();
      // foreach(var node in nodes){
      //   temp.Add(node.GetAllNodeCredentials());
      // }

      // temp.Add(nodes);
      List<Object> temp = new List<Object>();
      foreach(var node in nodes){
        var obj = new NodeCredentials(node.GetIP(), node.GetRSA(), DateTime.Parse(node.GetDate()));
        temp.Add(obj);
      }
      var result = new {ip = this.nodes[0].GetIP(),};
      return this.nodes;
    }
  }
}