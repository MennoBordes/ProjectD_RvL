using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BlockChain
{
	public partial class Form4 : Form
	{
		public Form4()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SHA256 sha256 = SHA256.Create();
			byte[] inputBytes = Encoding.ASCII.GetBytes(textBox1.Text);
			byte[] outputBytes = sha256.ComputeHash(inputBytes);
			textBox2.Text = Convert.ToBase64String(outputBytes);
			string res = string.Empty;
			foreach(byte b in outputBytes)
			{
				res = res + b + " ";
			}
			textBox3.Text = res;
		}

    private void button2_Click(object sender, EventArgs e)
    {
      SHA256 sha256 = SHA256.Create();
      byte[] inputbytes = Encoding.ASCII.GetBytes(textBox6.Text);
      byte[] outputBytes = sha256.ComputeHash(inputbytes);
      textBox5.Text = Convert.ToBase64String(outputBytes);
      string res = string.Empty;
      foreach (byte b in outputBytes)
      {
        res = res + b + " ";
      }
      textBox4.Text = res;
    }
  }
}
