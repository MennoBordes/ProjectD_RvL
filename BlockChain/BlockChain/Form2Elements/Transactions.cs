using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Form2Elements
{
    public class Transaction
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Amount { get; set; }
        public string AdditionalData { get; set; }

        public Transaction(string from, string to, double amount, string additionalData)
        {
            From = from;
            To = to;
            Amount = amount;
            AdditionalData = additionalData;
        }
    }
}
