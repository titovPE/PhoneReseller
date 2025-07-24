namespace LicenseGenerator
{
    partial class AAA
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SPasportNum = new System.Windows.Forms.TextBox();
            this.SPasportSer = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.SPasportIssuedBy = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.SAddres = new System.Windows.Forms.TextBox();
            this.SFIO = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SPasportNum);
            this.groupBox2.Controls.Add(this.SPasportSer);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.SPasportIssuedBy);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.SAddres);
            this.groupBox2.Controls.Add(this.SFIO);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 312);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация";
            // 
            // SPasportNum
            // 
            this.SPasportNum.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SPasportNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SPasportNum.Location = new System.Drawing.Point(702, 71);
            this.SPasportNum.MaxLength = 6;
            this.SPasportNum.Name = "SPasportNum";
            this.SPasportNum.ReadOnly = true;
            this.SPasportNum.Size = new System.Drawing.Size(100, 20);
            this.SPasportNum.TabIndex = 1;
            this.SPasportNum.TabStop = false;
            // 
            // SPasportSer
            // 
            this.SPasportSer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SPasportSer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SPasportSer.Location = new System.Drawing.Point(702, 32);
            this.SPasportSer.MaxLength = 4;
            this.SPasportSer.Name = "SPasportSer";
            this.SPasportSer.ReadOnly = true;
            this.SPasportSer.Size = new System.Drawing.Size(100, 20);
            this.SPasportSer.TabIndex = 0;
            this.SPasportSer.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(406, 98);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Кем выдан";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(702, 55);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 7;
            this.label20.Text = "Номер";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(702, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "Скрия";
            // 
            // SPasportIssuedBy
            // 
            this.SPasportIssuedBy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SPasportIssuedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SPasportIssuedBy.Location = new System.Drawing.Point(405, 116);
            this.SPasportIssuedBy.MaxLength = 200;
            this.SPasportIssuedBy.Multiline = true;
            this.SPasportIssuedBy.Name = "SPasportIssuedBy";
            this.SPasportIssuedBy.ReadOnly = true;
            this.SPasportIssuedBy.Size = new System.Drawing.Size(397, 59);
            this.SPasportIssuedBy.TabIndex = 2;
            this.SPasportIssuedBy.TabStop = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(405, 55);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(38, 13);
            this.label27.TabIndex = 28;
            this.label27.Text = "Адрес";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(404, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(133, 13);
            this.label28.TabIndex = 35;
            this.label28.Text = "Фамилия, имя, отчество";
            // 
            // SAddres
            // 
            this.SAddres.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SAddres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SAddres.Location = new System.Drawing.Point(405, 71);
            this.SAddres.MaxLength = 100;
            this.SAddres.Name = "SAddres";
            this.SAddres.ReadOnly = true;
            this.SAddres.Size = new System.Drawing.Size(291, 20);
            this.SAddres.TabIndex = 25;
            this.SAddres.TabStop = false;
            // 
            // SFIO
            // 
            this.SFIO.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SFIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SFIO.Location = new System.Drawing.Point(407, 32);
            this.SFIO.MaxLength = 50;
            this.SFIO.Name = "SFIO";
            this.SFIO.ReadOnly = true;
            this.SFIO.Size = new System.Drawing.Size(289, 20);
            this.SFIO.TabIndex = 24;
            this.SFIO.TabStop = false;
            // 
            // AAA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 482);
            this.Controls.Add(this.groupBox2);
            this.Name = "AAA";
            this.Text = "AAA";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox SPasportNum;
        private System.Windows.Forms.TextBox SPasportSer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox SPasportIssuedBy;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox SAddres;
        private System.Windows.Forms.TextBox SFIO;

    }
}