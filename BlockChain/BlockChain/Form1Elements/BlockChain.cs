using System;
using System.Collections.Generic;

namespace BlockChain.Form1Elements
{
  /// <summary>
  /// The blockchain for the RvL blockchain project.
  /// </summary>
  public class RvLBlockChain
  {
    /// <summary>
    /// The chain of blocks.
    /// </summary>
    public IList<Block> Chain { get; set; }

    /// <summary>
    /// The constructor for the chain.
    /// </summary>
    public RvLBlockChain()
    {
      InitializeChain();
      AddGenesisBlock();
    }

    /// <summary>
    /// Initializes the chain.
    /// </summary>
    public void InitializeChain()
    {
      Chain = new List<Block>();
    }

    /// <summary>
    /// Creates the genesis block.
    /// </summary>
    /// <returns></returns>
    public Block CreateGenesisBlock()
    {
      return new Block(DateTime.Now, null, "{}");
    }

    /// <summary>
    /// Adds the genesisblock to the chain.
    /// </summary>
    public void AddGenesisBlock()
    {
      Chain.Add(CreateGenesisBlock());
    }

    /// <summary>
    /// Returns the most recent block.
    /// </summary>
    /// <returns></returns>
    public Block GetLatestBlock()
    {
      return Chain[Chain.Count - 1];
    }

    /// <summary>
    /// Adds the given block to the chain.
    /// </summary>
    /// <param name="block">The block to add to the chain.</param>
    public void AddBlock(Block block)
    {
      if (Chain.Count > 1)
      {
        if (!IsValid())
        {
          throw new Exception("The Blocks order is not valid");
        }
      }
      Block latestBlock = GetLatestBlock();
      block.Index = latestBlock.Index + 1;
      block.PreviousHash = latestBlock.Hash;
      block.Hash = block.CalculateHash();
      Chain.Add(block);
    }

    /// <summary>
    /// Checks whether the chain hash order is valid.
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
      for (int i = 1; i < Chain.Count; i++)
      {
        Block currentBlock = Chain[i];
        Block previousBlock = Chain[i - 1];
        if (currentBlock.Hash != currentBlock.CalculateHash())
        {
          return false;
        }
        if (currentBlock.PreviousHash != previousBlock.Hash)
        {
          return false;
        }
      }
      return true;
    }
  }
}
