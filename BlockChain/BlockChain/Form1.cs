using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockChain.Form1Elements;
using Newtonsoft.Json;

namespace BlockChain
{
    public partial class Form1 : Form
    {
        RvLBlockChain RvlChain = new RvLBlockChain();
        RvLBlockChain RvlChain2 = new RvLBlockChain();
        public Form1()
        {
            InitializeComponent();
            ChainTester();
            dataGridView1.DataSource = RvlChain.Chain;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RvlChain2 = RvlChain;
            ChainSpoofer();
            dataGridView2.DataSource = RvlChain2.Chain;
        }
        public void ChainTester()
        {
            RvlChain.AddBlock(new Block(DateTime.Now, null, "{sender:Menno,reciever:Tester,waarde:9999}"));
            RvlChain.AddBlock(new Block(DateTime.Now, null, "{sender:Tester,reciever:Tester,waarde:500}"));
            RvlChain.AddBlock(new Block(DateTime.Now, null, "{sender:Menno,reciever:Tester,waarde:800000}"));
            Console.WriteLine(JsonConvert.SerializeObject(RvlChain, Formatting.Indented));
            Console.WriteLine($"Is chain valid?:{RvlChain.IsValid()}");
        }
        public void ChainSpoofer()
        {
            Console.WriteLine("Going to alter the data of the second in the chain");
            RvlChain2.Chain[2] = new Block(DateTime.Now, RvlChain2.Chain[1].Hash,"{sender:Johannessen,reciever:Geertrude,waarde:50}");

            Console.WriteLine($"Is chain vaild: {RvlChain2.IsValid()}");
            Console.WriteLine(JsonConvert.SerializeObject(RvlChain2, Formatting.Indented));
        }
    }
}
