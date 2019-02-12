using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Elements
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
            if (!IsValid())
            {
                throw new Exception("The Blocks order is not valid");
            }
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Hash = block.CalculateHash();
            Chain.Add(block);
        }
        public bool IsValid()
        {
            for (int i = 0; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];
                if(currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }
                if(currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
