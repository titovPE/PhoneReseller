namespace PhoneReseller.UserForms
{
  partial class NotBuy
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
            this.Worker = new System.Windows.Forms.ComboBox();
            this.BuyDate = new System.Windows.Forms.DateTimePicker();
            this.Imei = new System.Windows.Forms.TextBox();
            this.Model = new System.Windows.Forms.TextBox();
            this.AkbNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Margin = new System.Windows.Forms.TextBox();
            this.Percent = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.BaseDefect = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Cost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Notes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // BuyDate
            // 
            this.BuyDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BuyDate.Location = new System.Drawing.Point(139, 25);
            this.BuyDate.Name = "BuyDate";
            this.BuyDate.Size = new System.Drawing.Size(100, 20);
            this.BuyDate.TabIndex = 2;
            // 
            // Imei
            // 
            this.Imei.Location = new System.Drawing.Point(12, 74);
            this.Imei.MaxLength = 15;
            this.Imei.Name = "Imei";
            this.Imei.Size = new System.Drawing.Size(136, 20);
            this.Imei.TabIndex = 4;
            // 
            // Model
            // 
            this.Model.Location = new System.Drawing.Point(154, 74);
            this.Model.MaxLength = 20;
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(139, 20);
            this.Model.TabIndex = 5;
            // 
            // AkbNumber
            // 
            this.AkbNumber.Location = new System.Drawing.Point(299, 74);
            this.AkbNumber.MaxLength = 30;
            this.AkbNumber.Name = "AkbNumber";
            this.AkbNumber.Size = new System.Drawing.Size(139, 20);
            this.AkbNumber.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Наценка";
            this.label9.Visible = false;
            // 
            // Margin
            // 
            this.Margin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Margin.Location = new System.Drawing.Point(33, 149);
            this.Margin.MaxLength = 18;
            this.Margin.Name = "Margin";
            this.Margin.Size = new System.Drawing.Size(100, 20);
            this.Margin.TabIndex = 8;
            this.Margin.Visible = false;
            this.Margin.TextChanged += new System.EventHandler(this.Margin_TextChanged);
            this.Margin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Margin_KeyUp);
            // 
            // Percent
            // 
            this.Percent.Location = new System.Drawing.Point(33, 175);
            this.Percent.Name = "Percent";
            this.Percent.Size = new System.Drawing.Size(100, 20);
            this.Percent.TabIndex = 9;
            this.Percent.Visible = false;
            this.Percent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Percent_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(139, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "руб.";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(139, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "%";
            this.label11.Visible = false;
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(193, 171);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(100, 20);
            this.Price.TabIndex = 10;
            this.Price.Visible = false;
            this.Price.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Price_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(193, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Конечная цена";
            this.label12.Visible = false;
            // 
            // BaseDefect
            // 
            this.BaseDefect.Location = new System.Drawing.Point(12, 122);
            this.BaseDefect.MaxLength = 300;
            this.BaseDefect.Multiline = true;
            this.BaseDefect.Name = "BaseDefect";
            this.BaseDefect.Size = new System.Drawing.Size(312, 95);
            this.BaseDefect.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Деффекты";
            // 
            // Cost
            // 
            this.Cost.Location = new System.Drawing.Point(244, 25);
            this.Cost.MaxLength = 18;
            this.Cost.Name = "Cost";
            this.Cost.Size = new System.Drawing.Size(136, 20);
            this.Cost.TabIndex = 3;
            this.Cost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Cost_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Мастер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Дата";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Цена покупки";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "IMEI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Модель";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "№ АКБ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Занести в базу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Notes
            // 
            this.Notes.Location = new System.Drawing.Point(12, 239);
            this.Notes.MaxLength = 300;
            this.Notes.Multiline = true;
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(312, 81);
            this.Notes.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Примечания";
            // 
            // NotBuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 331);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Imei);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Worker);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BuyDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Cost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Model);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Notes);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Percent);
            this.Controls.Add(this.AkbNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Margin);
            this.Controls.Add(this.BaseDefect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NotBuy";
            this.Text = "NotBuy";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox Worker;
    private System.Windows.Forms.DateTimePicker BuyDate;
    private System.Windows.Forms.TextBox Imei;
    private System.Windows.Forms.TextBox Model;
    private System.Windows.Forms.TextBox AkbNumber;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox Margin;
    private System.Windows.Forms.TextBox Percent;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox Price;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox BaseDefect;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox Cost;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox Notes;
    private System.Windows.Forms.Label label6;
  }
}