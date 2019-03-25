namespace BlockChain
{
	partial class Form4
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.button1 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(175, 194);
      this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(117, 25);
      this.button1.TabIndex = 0;
      this.button1.Text = "Creëer Hash";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(304, 194);
      this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(389, 22);
      this.textBox1.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(86, 360);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(206, 17);
      this.label2.TabIndex = 3;
      this.label2.Text = "De Hashwaarde in tekst format:";
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(300, 360);
      this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.Size = new System.Drawing.Size(389, 22);
      this.textBox2.TabIndex = 4;
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(304, 270);
      this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBox3.Multiline = true;
      this.textBox3.Name = "textBox3";
      this.textBox3.ReadOnly = true;
      this.textBox3.Size = new System.Drawing.Size(389, 47);
      this.textBox3.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(304, 170);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(452, 17);
      this.label3.TabIndex = 6;
      this.label3.Text = "Voer hieronder de waardes in waarvan je de hashcode wilt berekenen.";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(60, 270);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(233, 17);
      this.label4.TabIndex = 7;
      this.label4.Text = "De byte output van de hash functie:";
      // 
      // Form4
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1067, 554);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.textBox3);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.button1);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "Form4";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form4";
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
  }
}