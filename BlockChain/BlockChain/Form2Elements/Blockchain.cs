using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockChain.Form1Elements;

namespace BlockChain.Form2Elements
{
    class RvLBlockchain
    {
        private readonly int _ProofOfWorkDifficulty;
        private readonly double _MiningReward;

        private List<Transaction> _PendingTransactions;

        public List<Block> Chain { get; set; }

        public RvLBlockchain(int proofOfWorkDifficulty, int miningReward)
        {
            _ProofOfWorkDifficulty = proofOfWorkDifficulty;
            _MiningReward = miningReward;
            _PendingTransactions = new List<Transaction>();
            Chain = new List<Block> { CreateGenesisBlock() };
        }

        private Block CreateGenesisBlock()
        {
            List<Transaction> transactions = new List<Transaction> { new Transaction("", "", 0.0, "") };
            return new Block(DateTime.Now, transactions, "0");
        }

        public void CreateTransaction(Transaction transaction)
        {
            _PendingTransactions.Add(transaction);
        }

        public void MineBlock(string minerAddress, string additionalInfo)
        {
            Transaction minerRewardTransaction = new Transaction(null, minerAddress, _MiningReward, additionalInfo);
            _PendingTransactions.Add(minerRewardTransaction);

            Block block = new Block(DateTime.Now, _PendingTransactions);
            block.MineBlock(_ProofOfWorkDifficulty);

            block.PreviousHash = Chain.Last().Hash;
            Chain.Add(block);

            _PendingTransactions = new List<Transaction>();
        }
        
        public bool IsValidChain()
        {
            for (int i = 0; i < Chain.Count; i++)
            {
                Block previousBlock = Chain[i - 1];
                Block currentBlock = Chain[i];

                if(currentBlock.Hash != currentBlock.CreateHash())
                    return false;
                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }
            return true;
        }

        public double GetBalance(string address)
        {
            double balance = 0;

            foreach (Block block in Chain)
            {
                foreach(Transaction transaction in block.Transactions)
                {
                    if (transaction.From == address)
                    {
                        balance -= transaction.Amount;
                    }
                    if(transaction.To == address)
                    {
                        balance += transaction.Amount; 
                    }
                }
            }
            return balance;
        }
    }
}
