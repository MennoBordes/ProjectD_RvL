using System;
using System.Windows.Forms;

namespace BlockChain
{
	public partial class Form3 : Form
	{
		public Form3()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form1 form = new Form1();
			form.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			form.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Form4 form = new Form4();
			form.Show();
		}
	}
}
