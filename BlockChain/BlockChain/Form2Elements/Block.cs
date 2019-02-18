using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BlockChain.Form2Elements;

namespace BlockChain.Form2Elements
{
    public class Block
    {
        private readonly DateTime _TimeStamp;

        private long _Nonce;

        public string PreviousHash { get; set; }
        public string Hash { get; set; }

        public List<Transaction> Transactions { get; set; }

        public Block(DateTime timestamp, List<Transaction> transactions, string previousHash = "")
        {
            _TimeStamp = timestamp;
            _Nonce = 0;

            Transactions = transactions;
            PreviousHash = previousHash;
            Hash = CreateHash();
        }

        public string CreateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = PreviousHash + _TimeStamp + Transactions + _Nonce;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return Encoding.Default.GetString(bytes);
            }
        }

        public void MineBlock(int ProofOfWorkDifficulty)
        {
            string hashValidationTemplate = new string('0', ProofOfWorkDifficulty);
            while (Hash.Substring(0, ProofOfWorkDifficulty) != hashValidationTemplate)
            {
                _Nonce++;
                Hash = CreateHash();
            }
            Console.WriteLine("Blocked with HASH={0} successfully mined!", Hash);
        }
    }
}
