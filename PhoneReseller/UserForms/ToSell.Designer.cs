namespace LicenseGenerator.UserForms
{
    partial class ToSell
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
            this.Worker = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DateApprowed = new System.Windows.Forms.DateTimePicker();
            this.IsRepared = new System.Windows.Forms.CheckBox();
            this.WorkInformation = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.WorkCost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.WorkReport = new System.Windows.Forms.TextBox();
            this.BaseDefect = new System.Windows.Forms.TextBox();
            this.DetectDefects = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Cost = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Margin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Percent = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.WorkInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Мастер";
            // 
            // Worker
            // 
            this.Worker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Worker.FormattingEnabled = true;
            this.Worker.Location = new System.Drawing.Point(12, 25);
            this.Worker.Name = "Worker";
            this.Worker.Size = new System.Drawing.Size(121, 21);
            this.Worker.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Модель телефона";
            // 
            // Model
            // 
            this.Model.BackColor = System.Drawing.SystemColors.Window;
            this.Model.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Model.Location = new System.Drawing.Point(229, 26);
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            this.Model.Size = new System.Drawing.Size(100, 20);
            this.Model.TabIndex = 3;
            this.Model.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Дата проверки";
            // 
            // DateApprowed
            // 
            this.DateApprowed.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateApprowed.Location = new System.Drawing.Point(12, 65);
            this.DateApprowed.Name = "DateApprowed";
            this.DateApprowed.Size = new System.Drawing.Size(100, 20);
            this.DateApprowed.TabIndex = 2;
            // 
            // IsRepared
            // 
            this.IsRepared.AutoSize = true;
            this.IsRepared.Location = new System.Drawing.Point(12, 91);
            this.IsRepared.Name = "IsRepared";
            this.IsRepared.Size = new System.Drawing.Size(112, 17);
            this.IsRepared.TabIndex = 3;
            this.IsRepared.Text = "Ремонтировался";
            this.IsRepared.UseVisualStyleBackColor = true;
            this.IsRepared.CheckedChanged += new System.EventHandler(this.IsRepared_CheckedChanged);
            // 
            // WorkInformation
            // 
            this.WorkInformation.Controls.Add(this.button3);
            this.WorkInformation.Controls.Add(this.WorkCost);
            this.WorkInformation.Controls.Add(this.label7);
            this.WorkInformation.Controls.Add(this.WorkReport);
            this.WorkInformation.Controls.Add(this.BaseDefect);
            this.WorkInformation.Controls.Add(this.DetectDefects);
            this.WorkInformation.Controls.Add(this.label6);
            this.WorkInformation.Controls.Add(this.label5);
            this.WorkInformation.Controls.Add(this.label4);
            this.WorkInformation.Enabled = false;
            this.WorkInformation.Location = new System.Drawing.Point(12, 110);
            this.WorkInformation.Name = "WorkInformation";
            this.WorkInformation.Size = new System.Drawing.Size(466, 193);
            this.WorkInformation.TabIndex = 4;
            this.WorkInformation.TabStop = false;
            this.WorkInformation.Text = "Информация по ремонту";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(188, 164);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "Без ремонта";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // WorkCost
            // 
            this.WorkCost.Location = new System.Drawing.Point(6, 167);
            this.WorkCost.MaxLength = 18;
            this.WorkCost.Name = "WorkCost";
            this.WorkCost.Size = new System.Drawing.Size(100, 20);
            this.WorkCost.TabIndex = 7;
            this.WorkCost.Text = "0";
            this.WorkCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RecordingOnyMoney);
            this.WorkCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WorkCost_KeyUp);
            this.WorkCost.Validated += new System.EventHandler(this.ValidateForNotEmpty);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Стоимость работ с деталями";
            // 
            // WorkReport
            // 
            this.WorkReport.Location = new System.Drawing.Point(6, 99);
            this.WorkReport.MaxLength = 200;
            this.WorkReport.Multiline = true;
            this.WorkReport.Name = "WorkReport";
            this.WorkReport.Size = new System.Drawing.Size(283, 49);
            this.WorkReport.TabIndex = 2;
            // 
            // BaseDefect
            // 
            this.BaseDefect.BackColor = System.Drawing.SystemColors.Window;
            this.BaseDefect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BaseDefect.Enabled = false;
            this.BaseDefect.Location = new System.Drawing.Point(295, 32);
            this.BaseDefect.Multiline = true;
            this.BaseDefect.Name = "BaseDefect";
            this.BaseDefect.ReadOnly = true;
            this.BaseDefect.Size = new System.Drawing.Size(165, 155);
            this.BaseDefect.TabIndex = 4;
            this.BaseDefect.TabStop = false;
            // 
            // DetectDefects
            // 
            this.DetectDefects.Location = new System.Drawing.Point(6, 32);
            this.DetectDefects.MaxLength = 200;
            this.DetectDefects.Multiline = true;
            this.DetectDefects.Name = "DetectDefects";
            this.DetectDefects.Size = new System.Drawing.Size(283, 48);
            this.DetectDefects.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Отчет о работе";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Заявленные неисправности";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Выявленные неисправности";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(377, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Цена покупки";
            // 
            // Cost
            // 
            this.Cost.BackColor = System.Drawing.SystemColors.Window;
            this.Cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cost.Location = new System.Drawing.Point(379, 25);
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Size = new System.Drawing.Size(100, 20);
            this.Cost.TabIndex = 10;
            this.Cost.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Наценка";
            // 
            // Margin
            // 
            this.Margin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Margin.Location = new System.Drawing.Point(12, 322);
            this.Margin.MaxLength = 18;
            this.Margin.Name = "Margin";
            this.Margin.Size = new System.Drawing.Size(100, 20);
            this.Margin.TabIndex = 5;
            this.Margin.TextChanged += new System.EventHandler(this.Margin_TextChanged);
            this.Margin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RecordingOnyMoney);
            this.Margin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Margin_KeyUp);
            this.Margin.Validated += new System.EventHandler(this.ValidateForNotEmpty);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Подтвердить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(393, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Percent
            // 
            this.Percent.Location = new System.Drawing.Point(12, 348);
            this.Percent.Name = "Percent";
            this.Percent.Size = new System.Drawing.Size(100, 20);
            this.Percent.TabIndex = 6;
            this.Percent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Percent_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(118, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "руб.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(118, 351);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "%";
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(201, 348);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(100, 20);
            this.Price.TabIndex = 7;
            this.Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RecordingOnyMoney);
            this.Price.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Price_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(198, 332);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Конечная цена";
            // 
            // ToSell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 417);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Percent);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Margin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Cost);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.WorkInformation);
            this.Controls.Add(this.IsRepared);
            this.Controls.Add(this.DateApprowed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Model);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Worker);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ToSell";
            this.Text = "Выставить на продажу";
            this.WorkInformation.ResumeLayout(false);
            this.WorkInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Worker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Model;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DateApprowed;
        private System.Windows.Forms.CheckBox IsRepared;
        private System.Windows.Forms.GroupBox WorkInformation;
        private System.Windows.Forms.TextBox WorkCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BaseDefect;
        private System.Windows.Forms.TextBox DetectDefects;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Cost;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Margin;
        protected System.Windows.Forms.TextBox WorkReport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Percent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Price;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button3;
    }
}