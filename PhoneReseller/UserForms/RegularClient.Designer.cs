namespace PhoneReseller.UserForms
{
    partial class RegularClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegularClient));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.clientGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.clientGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PasportNum = new System.Windows.Forms.TextBox();
            this.PasportSer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PasportIssuedBy = new System.Windows.Forms.TextBox();
            this.FIO = new System.Windows.Forms.TextBox();
            this.Addres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientGridView)).BeginInit();
            this.clientGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 426);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(533, 114);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // clientGridView
            // 
            this.clientGridView.AllowUserToAddRows = false;
            this.clientGridView.AllowUserToDeleteRows = false;
            this.clientGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientGridView.Location = new System.Drawing.Point(12, 12);
            this.clientGridView.Name = "clientGridView";
            this.clientGridView.ReadOnly = true;
            this.clientGridView.Size = new System.Drawing.Size(240, 150);
            this.clientGridView.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(521, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clientGroupBox
            // 
            this.clientGroupBox.Controls.Add(this.groupBox1);
            this.clientGroupBox.Controls.Add(this.button1);
            this.clientGroupBox.Controls.Add(this.FIO);
            this.clientGroupBox.Controls.Add(this.Addres);
            this.clientGroupBox.Controls.Add(this.label1);
            this.clientGroupBox.Controls.Add(this.label2);
            this.clientGroupBox.Location = new System.Drawing.Point(11, 163);
            this.clientGroupBox.Name = "clientGroupBox";
            this.clientGroupBox.Size = new System.Drawing.Size(602, 228);
            this.clientGroupBox.TabIndex = 26;
            this.clientGroupBox.TabStop = false;
            this.clientGroupBox.Text = "Клиент";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PasportNum);
            this.groupBox1.Controls.Add(this.PasportSer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PasportIssuedBy);
            this.groupBox1.Location = new System.Drawing.Point(6, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 115);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Паспорт";
            // 
            // PasportNum
            // 
            this.PasportNum.Location = new System.Drawing.Point(6, 77);
            this.PasportNum.MaxLength = 6;
            this.PasportNum.Name = "PasportNum";
            this.PasportNum.Size = new System.Drawing.Size(100, 20);
            this.PasportNum.TabIndex = 1;
            // 
            // PasportSer
            // 
            this.PasportSer.Location = new System.Drawing.Point(6, 32);
            this.PasportSer.MaxLength = 4;
            this.PasportSer.Name = "PasportSer";
            this.PasportSer.Size = new System.Drawing.Size(100, 20);
            this.PasportSer.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Кем выдан";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Номер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Серия";
            // 
            // PasportIssuedBy
            // 
            this.PasportIssuedBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasportIssuedBy.Location = new System.Drawing.Point(115, 35);
            this.PasportIssuedBy.MaxLength = 200;
            this.PasportIssuedBy.Multiline = true;
            this.PasportIssuedBy.Name = "PasportIssuedBy";
            this.PasportIssuedBy.Size = new System.Drawing.Size(469, 65);
            this.PasportIssuedBy.TabIndex = 2;
            // 
            // FIO
            // 
            this.FIO.Location = new System.Drawing.Point(5, 42);
            this.FIO.MaxLength = 50;
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(278, 20);
            this.FIO.TabIndex = 3;
            // 
            // Addres
            // 
            this.Addres.Location = new System.Drawing.Point(300, 42);
            this.Addres.MaxLength = 100;
            this.Addres.Name = "Addres";
            this.Addres.Size = new System.Drawing.Size(296, 20);
            this.Addres.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Фамилия, имя, отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Адрес";
            // 
            // RegularClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 552);
            this.Controls.Add(this.clientGroupBox);
            this.Controls.Add(this.clientGridView);
            this.Controls.Add(this.textBox1);
            this.Name = "RegularClient";
            this.Text = "Постоянный клиент";
            this.Load += new System.EventHandler(this.RegularClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientGridView)).EndInit();
            this.clientGroupBox.ResumeLayout(false);
            this.clientGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView clientGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox clientGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PasportNum;
        private System.Windows.Forms.TextBox PasportSer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PasportIssuedBy;
        private System.Windows.Forms.TextBox FIO;
        private System.Windows.Forms.TextBox Addres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}