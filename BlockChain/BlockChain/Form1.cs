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
      LblValid.Text = "De gegevens in deze BlockChain zijn valide!";
      LblDataAltered.Text = "Klik op de knop om foutieve gegevens toe te voegen aan de BlockChain.";
    }

    private void button1_Click(object sender, EventArgs e)
    {
      RvlChain2 = RvlChain;
      ChainSpoofer();
      dataGridView2.DataSource = RvlChain2.Chain;
      LblInvalid.Text = "De data in block 3, op index 2, is aangepast, waardoor de hashcode van dat Block tevens is aangepast!";
      LblInvalid.Visible = true;
    }
    public void ChainTester()
    {
      RvlChain.AddBlock(new Block(DateTime.Now, null, "{sender:Hogeschool Rotterdam,reciever:Belastingdienst,waarde:9999}"));
      RvlChain.AddBlock(new Block(DateTime.Now, null, "{sender:Belastingdienst,reciever:Hogeschool Rotterdam,waarde:500}"));
      RvlChain.AddBlock(new Block(DateTime.Now, null, "{sender:Hogeschool Rotterdam,reciever:Belastingdienst,waarde:8000}"));
      //Console.WriteLine(JsonConvert.SerializeObject(RvlChain, Formatting.Indented));
      Console.WriteLine($"Is chain valid?:{RvlChain.IsValid()}");
    }
    public void ChainSpoofer()
    {
      Console.WriteLine("Going to alter the data of the second in the chain");
      string FakeData = "{sender:Belastingdienst,reciever:Hogeschool Rotterdam,waarde:50000}";
      RvlChain.Chain[2].Data = FakeData;
      RvlChain.Chain[2].Hash = RvlChain.Chain[2].CalculateHash();
      //var spoofBlock = new Block(DateTime.Now.AddDays(5), RvlChain2.Chain[1].Hash, FakeData);
      //RvlChain2.Chain[2] = spoofBlock;

      //Console.WriteLine($"Added the following data in to the chain: {spoofBlock.Data}");
      Console.WriteLine($"Is chain vaild: {RvlChain2.IsValid()}");

      //Console.WriteLine(JsonConvert.SerializeObject(RvlChain2, Formatting.Indented));
    }
  }
}
