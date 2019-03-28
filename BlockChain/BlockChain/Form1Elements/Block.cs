using System;
using System.Text;
using System.Security.Cryptography;

namespace BlockChain.Form1Elements
{
  /// <summary>
  /// The block
  /// </summary>
  public class Block
  {
    /// <summary>
    /// The index of the block in the chain.
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// The timestamp at which the block was created.
    /// </summary>
    public DateTime TimeStamp { get; set; }

    /// <summary>
    /// The hash of the block before the current block.
    /// </summary>
    public string PreviousHash { get; set; }

    /// <summary>
    /// The hash of the current block.
    /// </summary>
    public string Hash { get; set; }
    
    /// <summary>
    /// The data stored in the current block.
    /// </summary>
    public string Data { get; set; }

    /// <summary>
    /// The constructor of the block
    /// </summary>
    /// <param name="timestamp">The timestamp at which the block is created</param>
    /// <param name="previousHash">The hash of the previous block</param>
    /// <param name="data">The data to be stored in the current block</param>
    public Block(DateTime timestamp, string previousHash, string data)
    {
      this.Index = 0;
      this.TimeStamp = timestamp;
      this.PreviousHash = previousHash;
      this.Data = data;
      this.Hash = CalculateHash();
    }

    /// <summary>
    /// Calculates the hash of the current block
    /// </summary>
    /// <returns></returns>
    public string CalculateHash()
    {
      SHA256 sha256 = SHA256.Create();
      byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{Data}");
      byte[] outputBytes = sha256.ComputeHash(inputBytes);
      return Convert.ToBase64String(outputBytes);
    }
  }
}
