using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Node.Classes
{
  public static class Validation
  {
    public static bool validateBlock(JObject incomingBlock, JArray current_chain)
    {
      // return checkTimestamp (current_chain, incomingBlock);

      calculateHashOfLatestBlockInCurrentChain(current_chain);
      if (checkTimestamp(current_chain, incomingBlock) && checkHashOfLastBlockInCurrentChain(current_chain, incomingBlock))
      {
        // validated
        System.Console.WriteLine("All is valid");

        return true;
      }
      else
      {
        // notvalidated
        System.Console.WriteLine("Something is not valid");
        return false;
      }
    }

    public static bool checkTimestamp(JArray current_chain, JObject incomingBlock)
    {
      var latestBlock = current_chain.Last;
      DateTime timestampLatestBlock = Convert.ToDateTime((string)latestBlock["timestamp"]);
      DateTime timestampIncomingBlock = Convert.ToDateTime((string)incomingBlock["timestamp"]);
      if (timestampIncomingBlock > timestampLatestBlock)
      {
        return true;
      }
      else
      {
        System.Console.WriteLine("Timestamp is not valid");
        return false;
      }
    }

    public static bool checkHashOfLastBlockInCurrentChain(JArray current_chain, JObject incomingBlock)
    {
      string incomingPreviousHash = (string)incomingBlock["previous_hash"];
      if (calculateHashOfLatestBlockInCurrentChain(current_chain) == incomingPreviousHash)
      {
        return true;
      }
      else
      {
        System.Console.WriteLine("Hash doesn't match");
        return false;
      }
    }

    public static string calculateHashOfLatestBlockInCurrentChain(JArray current_chain)
    { //returns hash
      var latestBlock = current_chain.Last;
      string TimeStamp = (string)latestBlock["timestamp"];
      JObject EncryptedData = (JObject)latestBlock["data"];

      SHA256 sha256 = SHA256.Create();
      byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{EncryptedData}");
      byte[] outputBytes = sha256.ComputeHash(inputBytes);

      string BlockHash = Convert.ToBase64String(outputBytes);
      //   System.Console.WriteLine(BlockHash);
      return BlockHash;
    }

  }
}