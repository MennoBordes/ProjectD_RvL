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
      byte[] hash = CreateHash(textBox1.Text);
      textBox2.Text = Convert.ToBase64String(hash);
      string res = string.Empty;
      foreach (byte b in hash)
      {
				res = res + b + " ";
			}
			textBox3.Text = res;
		}

    private void button2_Click(object sender, EventArgs e)
    {
      byte[] hash = CreateHash(textBox6.Text);
      textBox5.Text = Convert.ToBase64String(hash);
      string res = string.Empty;
      foreach (byte b in hash)
      {
        res = res + b + " ";
      }
      textBox4.Text = res;
    }

    /// <summary>
    /// Takes as input a string and returns the hashcode for that given string
    /// </summary>
    /// <param name="text">The string to convert to a byte[]</param>
    /// <returns></returns>
    private byte[] CreateHash(string text)
    {
      SHA256 sha256 = SHA256.Create();
      byte[] input = Encoding.ASCII.GetBytes(text);
      return sha256.ComputeHash(input);
    }
  }
}
