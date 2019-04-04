namespace BlockChain
{
    partial class Form1
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
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.dataGridView2 = new System.Windows.Forms.DataGridView();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.LblDataAltered = new System.Windows.Forms.Label();
      this.LblValid = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.LblInvalid = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(7, 307);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(262, 27);
      this.button1.TabIndex = 0;
      this.button1.Text = "Foutieve data in een block opslaan";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // dataGridView1
      // 
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Enabled = false;
      this.dataGridView1.Location = new System.Drawing.Point(3, 18);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.RowTemplate.Height = 24;
      this.dataGridView1.Size = new System.Drawing.Size(1476, 250);
      this.dataGridView1.TabIndex = 1;
      // 
      // dataGridView2
      // 
      this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView2.Enabled = false;
      this.dataGridView2.Location = new System.Drawing.Point(3, 18);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.RowHeadersVisible = false;
      this.dataGridView2.RowTemplate.Height = 24;
      this.dataGridView2.Size = new System.Drawing.Size(1476, 232);
      this.dataGridView2.TabIndex = 2;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.panel1);
      this.groupBox1.Controls.Add(this.dataGridView1);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(1482, 271);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "De originele BlockChain";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.panel2);
      this.groupBox2.Controls.Add(this.dataGridView2);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.groupBox2.Location = new System.Drawing.Point(0, 352);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(1482, 253);
      this.groupBox2.TabIndex = 6;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "De aangepaste BlockChain";
      // 
      // LblDataAltered
      // 
      this.LblDataAltered.AutoSize = true;
      this.LblDataAltered.Location = new System.Drawing.Point(12, 287);
      this.LblDataAltered.Name = "LblDataAltered";
      this.LblDataAltered.Size = new System.Drawing.Size(46, 17);
      this.LblDataAltered.TabIndex = 7;
      this.LblDataAltered.Text = "label1";
      // 
      // LblValid
      // 
      this.LblValid.AutoSize = true;
      this.LblValid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LblValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LblValid.Location = new System.Drawing.Point(0, 0);
      this.LblValid.Name = "LblValid";
      this.LblValid.Size = new System.Drawing.Size(59, 20);
      this.LblValid.TabIndex = 2;
      this.LblValid.Text = "label1";
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.panel1.Controls.Add(this.LblValid);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(3, 244);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1476, 24);
      this.panel1.TabIndex = 3;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.panel2.Controls.Add(this.LblInvalid);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(3, 226);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(1476, 24);
      this.panel2.TabIndex = 4;
      // 
      // LblInvalid
      // 
      this.LblInvalid.AutoSize = true;
      this.LblInvalid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LblInvalid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LblInvalid.Location = new System.Drawing.Point(0, 0);
      this.LblInvalid.Name = "LblInvalid";
      this.LblInvalid.Size = new System.Drawing.Size(59, 20);
      this.LblInvalid.TabIndex = 2;
      this.LblInvalid.Text = "label1";
      this.LblInvalid.Visible = false;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1482, 605);
      this.Controls.Add(this.LblDataAltered);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label LblDataAltered;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label LblValid;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label LblInvalid;
  }
}

