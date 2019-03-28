using System;
using System.Collections.Generic;

namespace BlockChain.Form1Elements
{
  public class RvLBlockChain
  {
    public IList<Block> Chain { get; set; }
    public RvLBlockChain()
    {
      InitializeChain();
      AddGenesisBlock();
    }

    public void InitializeChain()
    {
      Chain = new List<Block>();
    }

    public Block CreateGenesisBlock()
    {
      return new Block(DateTime.Now, null, "{}");
    }

    public void AddGenesisBlock()
    {
      Chain.Add(CreateGenesisBlock());
    }

    public Block GetLatestBlock()
    {
      return Chain[Chain.Count - 1];
    }

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
