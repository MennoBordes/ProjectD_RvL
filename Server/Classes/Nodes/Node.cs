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
      this.nodes = new List<NodeCredentials>();
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

    public List<List<string>> GetAllNodes(){
      List<List<string>> temp = new List<List<string>>();
      foreach(var node in nodes){
        temp.Add(node.GetAllNodeCredentials());
      }
      return temp;
    }
    
    // 1 main class
    // bevat verwijzingen naar node-credentials
  }
}