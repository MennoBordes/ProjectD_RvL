using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockChain.Form2Elements;

namespace BlockChain
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Callable()
        {
            const string minerAddress = "miner1";
            const string User1Address = "A";
            const string User2Address = "B";

            RvLBlockchain blockchain = new RvLBlockchain(proofOfWorkDifficulty: 2, miningReward: 10);
            blockchain.CreateTransaction(new Transaction(User1Address, User2Address, 200, "BlaBlaBla"));
            blockchain.CreateTransaction(new Transaction(User2Address, User1Address, 10, "BloBloBlo"));

            Console.WriteLine("Is valid: {0}", blockchain.IsValidChain());

            Console.WriteLine();
            Console.WriteLine("--------- Start mining ---------");
            blockchain.MineBlock(minerAddress);

            Console.WriteLine("BALANCE of the miner: {0}", blockchain.GetBalance(minerAddress));

            blockchain.CreateTransaction(new Transaction(User1Address, User2Address, 5, "Total"));

            Console.WriteLine();
            Console.WriteLine("--------- Start mining ---------");
            blockchain.MineBlock(minerAddress);


        }
    }
}
