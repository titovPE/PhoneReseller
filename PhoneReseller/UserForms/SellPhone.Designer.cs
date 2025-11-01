namespace LicenseGenerator.UserForms
{
    partial class SellPhone
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Seller = new System.Windows.Forms.ComboBox();
            this.SellDate = new System.Windows.Forms.DateTimePicker();
            this.Price = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Продавец";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата продажи";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Цена продажи";
            // 
            // Seller
            // 
            this.Seller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Seller.FormattingEnabled = true;
            this.Seller.Location = new System.Drawing.Point(16, 31);
            this.Seller.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Seller.Name = "Seller";
            this.Seller.Size = new System.Drawing.Size(160, 24);
            this.Seller.TabIndex = 3;
            // 
            // SellDate
            // 
            this.SellDate.Enabled = false;
            this.SellDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.SellDate.Location = new System.Drawing.Point(20, 80);
            this.SellDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SellDate.Name = "SellDate";
            this.SellDate.Size = new System.Drawing.Size(156, 22);
            this.SellDate.TabIndex = 4;
            // 
            // Price
            // 
            this.Price.BackColor = System.Drawing.SystemColors.Window;
            this.Price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Price.Location = new System.Drawing.Point(20, 128);
            this.Price.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Size = new System.Drawing.Size(157, 22);
            this.Price.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Продать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(216, 108);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SellPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 166);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.SellDate);
            this.Controls.Add(this.Seller);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SellPhone";
            this.Text = "SellPhone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Seller;
        private System.Windows.Forms.DateTimePicker SellDate;
        private System.Windows.Forms.TextBox Price;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}