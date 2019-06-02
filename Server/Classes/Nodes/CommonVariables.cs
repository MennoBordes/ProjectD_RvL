using System;

namespace Server.Classes.Nodes
{
  public class CommonNodeVariables
  {
    public static string WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
    public static string BlockLocation = WorkingDirectory + @"node.json";
    public static string SavedNodesLocation = WorkingDirectory + @"RunningNodes.json";
  }
}