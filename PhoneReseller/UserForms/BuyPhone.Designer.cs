namespace PhoneReseller.UserForms
{
    partial class BuyPhone
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
            this.FIO = new System.Windows.Forms.TextBox();
            this.Addres = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PasportNum = new System.Windows.Forms.TextBox();
            this.PasportSer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PasportIssuedBy = new System.Windows.Forms.TextBox();
            this.Model = new System.Windows.Forms.TextBox();
            this.AkbNumber = new System.Windows.Forms.TextBox();
            this.State = new System.Windows.Forms.GroupBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.InflatedAKB = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.BatteryMiss = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.State_Text = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.AkbState = new System.Windows.Forms.TextBox();
            this.ComplectSet = new System.Windows.Forms.GroupBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ComplectSet_Text = new System.Windows.Forms.TextBox();
            this.BaseDefect = new System.Windows.Forms.TextBox();
            this.Notes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Cost = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.BuyDate = new System.Windows.Forms.DateTimePicker();
            this.Acceptor = new System.Windows.Forms.ComboBox();
            this.Imei = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.clientGroupBox = new System.Windows.Forms.GroupBox();
            this.fillByRegularClientButton = new System.Windows.Forms.Button();
            this.insertClientFromPrevousPurchaseButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.State.SuspendLayout();
            this.ComplectSet.SuspendLayout();
            this.clientGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FIO
            // 
            this.FIO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FIO.Location = new System.Drawing.Point(5, 40);
            this.FIO.MaxLength = 50;
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(278, 20);
            this.FIO.TabIndex = 4;
            // 
            // Addres
            // 
            this.Addres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Addres.Location = new System.Drawing.Point(300, 40);
            this.Addres.MaxLength = 100;
            this.Addres.Name = "Addres";
            this.Addres.Size = new System.Drawing.Size(296, 20);
            this.Addres.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.PasportNum);
            this.groupBox1.Controls.Add(this.PasportSer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PasportIssuedBy);
            this.groupBox1.Location = new System.Drawing.Point(6, 66);
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
            this.PasportNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PasporNum_KeyUp);
            // 
            // PasportSer
            // 
            this.PasportSer.Location = new System.Drawing.Point(6, 32);
            this.PasportSer.MaxLength = 4;
            this.PasportSer.Name = "PasportSer";
            this.PasportSer.Size = new System.Drawing.Size(100, 20);
            this.PasportSer.TabIndex = 0;
            this.PasportSer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PasportSer_KeyUp);
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
            // Model
            // 
            this.Model.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Model.Location = new System.Drawing.Point(157, 266);
            this.Model.MaxLength = 20;
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(139, 20);
            this.Model.TabIndex = 7;
            // 
            // AkbNumber
            // 
            this.AkbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AkbNumber.Location = new System.Drawing.Point(302, 266);
            this.AkbNumber.MaxLength = 30;
            this.AkbNumber.Name = "AkbNumber";
            this.AkbNumber.Size = new System.Drawing.Size(139, 20);
            this.AkbNumber.TabIndex = 8;
            // 
            // State
            // 
            this.State.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.State.Controls.Add(this.checkBox9);
            this.State.Controls.Add(this.InflatedAKB);
            this.State.Controls.Add(this.checkBox2);
            this.State.Controls.Add(this.checkBox3);
            this.State.Controls.Add(this.checkBox1);
            this.State.Controls.Add(this.BatteryMiss);
            this.State.Controls.Add(this.label16);
            this.State.Controls.Add(this.State_Text);
            this.State.Controls.Add(this.label11);
            this.State.Controls.Add(this.AkbState);
            this.State.Location = new System.Drawing.Point(12, 292);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(373, 139);
            this.State.TabIndex = 9;
            this.State.TabStop = false;
            this.State.Text = "Состояние";
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(119, 42);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(160, 17);
            this.checkBox9.TabIndex = 4;
            this.checkBox9.Text = "Индикатор влаги красный";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // InflatedAKB
            // 
            this.InflatedAKB.AutoSize = true;
            this.InflatedAKB.Location = new System.Drawing.Point(119, 19);
            this.InflatedAKB.Name = "InflatedAKB";
            this.InflatedAKB.Size = new System.Drawing.Size(110, 17);
            this.InflatedAKB.TabIndex = 3;
            this.InflatedAKB.Text = "вздутая батарея";
            this.InflatedAKB.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(9, 19);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(78, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Царапины";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(9, 42);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(74, 17);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Трещины";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Потертости";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // BatteryMiss
            // 
            this.BatteryMiss.AutoSize = true;
            this.BatteryMiss.Location = new System.Drawing.Point(196, 63);
            this.BatteryMiss.Name = "BatteryMiss";
            this.BatteryMiss.Size = new System.Drawing.Size(132, 17);
            this.BatteryMiss.TabIndex = 6;
            this.BatteryMiss.Text = "Отсутствует батарея";
            this.BatteryMiss.UseVisualStyleBackColor = true;
            this.BatteryMiss.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Дополнительно";
            // 
            // State_Text
            // 
            this.State_Text.Location = new System.Drawing.Point(6, 99);
            this.State_Text.MaxLength = 200;
            this.State_Text.Multiline = true;
            this.State_Text.Name = "State_Text";
            this.State_Text.Size = new System.Drawing.Size(185, 34);
            this.State_Text.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Состояние батареи";
            // 
            // AkbState
            // 
            this.AkbState.Location = new System.Drawing.Point(196, 99);
            this.AkbState.MaxLength = 100;
            this.AkbState.Multiline = true;
            this.AkbState.Name = "AkbState";
            this.AkbState.Size = new System.Drawing.Size(171, 34);
            this.AkbState.TabIndex = 7;
            // 
            // ComplectSet
            // 
            this.ComplectSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComplectSet.Controls.Add(this.checkBox11);
            this.ComplectSet.Controls.Add(this.checkBox10);
            this.ComplectSet.Controls.Add(this.checkBox7);
            this.ComplectSet.Controls.Add(this.checkBox6);
            this.ComplectSet.Controls.Add(this.checkBox5);
            this.ComplectSet.Controls.Add(this.checkBox4);
            this.ComplectSet.Controls.Add(this.label12);
            this.ComplectSet.Controls.Add(this.ComplectSet_Text);
            this.ComplectSet.Location = new System.Drawing.Point(391, 292);
            this.ComplectSet.Name = "ComplectSet";
            this.ComplectSet.Size = new System.Drawing.Size(222, 139);
            this.ComplectSet.TabIndex = 10;
            this.ComplectSet.TabStop = false;
            this.ComplectSet.Text = "комплектность";
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(90, 63);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(69, 17);
            this.checkBox11.TabIndex = 5;
            this.checkBox11.Text = "Коробка";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(90, 42);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(85, 17);
            this.checkBox10.TabIndex = 4;
            this.checkBox10.Text = "Документы";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(90, 19);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(69, 17);
            this.checkBox7.TabIndex = 3;
            this.checkBox7.Text = "Флешка";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(6, 63);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(53, 17);
            this.checkBox6.TabIndex = 2;
            this.checkBox6.Text = "Диск";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(6, 42);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(69, 17);
            this.checkBox5.TabIndex = 1;
            this.checkBox5.Text = "Зарядка";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 19);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(78, 17);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "Гарнитура";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Другие детали";
            // 
            // ComplectSet_Text
            // 
            this.ComplectSet_Text.Location = new System.Drawing.Point(6, 99);
            this.ComplectSet_Text.MaxLength = 100;
            this.ComplectSet_Text.Multiline = true;
            this.ComplectSet_Text.Name = "ComplectSet_Text";
            this.ComplectSet_Text.Size = new System.Drawing.Size(210, 34);
            this.ComplectSet_Text.TabIndex = 100;
            // 
            // BaseDefect
            // 
            this.BaseDefect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BaseDefect.Location = new System.Drawing.Point(18, 458);
            this.BaseDefect.MaxLength = 200;
            this.BaseDefect.Multiline = true;
            this.BaseDefect.Name = "BaseDefect";
            this.BaseDefect.Size = new System.Drawing.Size(156, 123);
            this.BaseDefect.TabIndex = 11;
            // 
            // Notes
            // 
            this.Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Notes.Location = new System.Drawing.Point(183, 458);
            this.Notes.MaxLength = 300;
            this.Notes.Multiline = true;
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(296, 123);
            this.Notes.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Фамилия, имя, отчество";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Адрес";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Дата покупки ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Цена покупки";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "IMEI";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(157, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Модель";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(302, 251);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "№ АКБ";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 442);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Заявленные дефекты";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(180, 442);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Примечания";
            // 
            // Cost
            // 
            this.Cost.Location = new System.Drawing.Point(306, 25);
            this.Cost.MaxLength = 18;
            this.Cost.Name = "Cost";
            this.Cost.Size = new System.Drawing.Size(136, 20);
            this.Cost.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Приемщик";
            // 
            // BuyDate
            // 
            this.BuyDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BuyDate.Location = new System.Drawing.Point(139, 26);
            this.BuyDate.Name = "BuyDate";
            this.BuyDate.Size = new System.Drawing.Size(111, 20);
            this.BuyDate.TabIndex = 1;
            // 
            // Acceptor
            // 
            this.Acceptor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Acceptor.Location = new System.Drawing.Point(12, 25);
            this.Acceptor.Name = "Acceptor";
            this.Acceptor.Size = new System.Drawing.Size(121, 21);
            this.Acceptor.TabIndex = 0;
            // 
            // Imei
            // 
            this.Imei.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Imei.Location = new System.Drawing.Point(15, 266);
            this.Imei.MaxLength = 15;
            this.Imei.Name = "Imei";
            this.Imei.Size = new System.Drawing.Size(136, 20);
            this.Imei.TabIndex = 6;
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OK.Location = new System.Drawing.Point(514, 529);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(99, 23);
            this.OK.TabIndex = 13;
            this.OK.Text = "Занести в базу";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(514, 558);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox12
            // 
            this.checkBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(350, 250);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(96, 17);
            this.checkBox12.TabIndex = 22;
            this.checkBox12.TabStop = false;
            this.checkBox12.Text = "Не заполнять";
            this.checkBox12.UseVisualStyleBackColor = true;
            this.checkBox12.CheckedChanged += new System.EventHandler(this.checkBox12_CheckedChanged);
            // 
            // clientGroupBox
            // 
            this.clientGroupBox.Controls.Add(this.groupBox1);
            this.clientGroupBox.Controls.Add(this.FIO);
            this.clientGroupBox.Controls.Add(this.Addres);
            this.clientGroupBox.Controls.Add(this.label1);
            this.clientGroupBox.Controls.Add(this.label2);
            this.clientGroupBox.Location = new System.Drawing.Point(11, 52);
            this.clientGroupBox.Name = "clientGroupBox";
            this.clientGroupBox.Size = new System.Drawing.Size(602, 187);
            this.clientGroupBox.TabIndex = 25;
            this.clientGroupBox.TabStop = false;
            this.clientGroupBox.Text = "Клиент";
            // 
            // fillByRegularClientButton
            // 
            this.fillByRegularClientButton.Location = new System.Drawing.Point(514, 11);
            this.fillByRegularClientButton.Name = "fillByRegularClientButton";
            this.fillByRegularClientButton.Size = new System.Drawing.Size(144, 23);
            this.fillByRegularClientButton.TabIndex = 15;
            this.fillByRegularClientButton.Text = "Постоянный клиент";
            this.fillByRegularClientButton.UseVisualStyleBackColor = true;
            this.fillByRegularClientButton.Visible = false;
            this.fillByRegularClientButton.Click += new System.EventHandler(this.fillByRegularClientButton_Click);
            // 
            // insertClientFromPrevousPurchaseButton
            // 
            this.insertClientFromPrevousPurchaseButton.Location = new System.Drawing.Point(494, 4);
            this.insertClientFromPrevousPurchaseButton.Name = "insertClientFromPrevousPurchaseButton";
            this.insertClientFromPrevousPurchaseButton.Size = new System.Drawing.Size(144, 23);
            this.insertClientFromPrevousPurchaseButton.TabIndex = 14;
            this.insertClientFromPrevousPurchaseButton.Text = "Из предыдущей покупки";
            this.insertClientFromPrevousPurchaseButton.UseVisualStyleBackColor = true;
            this.insertClientFromPrevousPurchaseButton.Visible = false;
            this.insertClientFromPrevousPurchaseButton.Click += new System.EventHandler(this.insertClientFromPrevousPurchaseButton_Click);
            // 
            // BuyPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 593);
            this.Controls.Add(this.fillByRegularClientButton);
            this.Controls.Add(this.clientGroupBox);
            this.Controls.Add(this.checkBox12);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.insertClientFromPrevousPurchaseButton);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Imei);
            this.Controls.Add(this.Acceptor);
            this.Controls.Add(this.BuyDate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.Cost);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Notes);
            this.Controls.Add(this.BaseDefect);
            this.Controls.Add(this.ComplectSet);
            this.Controls.Add(this.State);
            this.Controls.Add(this.AkbNumber);
            this.Controls.Add(this.Model);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BuyPhone";
            this.Text = "Покупка телефона ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.State.ResumeLayout(false);
            this.State.PerformLayout();
            this.ComplectSet.ResumeLayout(false);
            this.ComplectSet.PerformLayout();
            this.clientGroupBox.ResumeLayout(false);
            this.clientGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FIO;
        private System.Windows.Forms.TextBox Addres;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PasportIssuedBy;
        private System.Windows.Forms.TextBox Model;
        private System.Windows.Forms.TextBox AkbNumber;
        private System.Windows.Forms.GroupBox State;
        private System.Windows.Forms.TextBox AkbState;
        private System.Windows.Forms.GroupBox ComplectSet;
        private System.Windows.Forms.TextBox ComplectSet_Text;
        private System.Windows.Forms.TextBox BaseDefect;
        private System.Windows.Forms.TextBox Notes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Cost;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker BuyDate;
        private System.Windows.Forms.ComboBox Acceptor;
        private System.Windows.Forms.TextBox PasportNum;
        private System.Windows.Forms.TextBox PasportSer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox State_Text;
        private System.Windows.Forms.TextBox Imei;
        private System.Windows.Forms.CheckBox BatteryMiss;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox InflatedAKB;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.GroupBox clientGroupBox;
        private System.Windows.Forms.Button fillByRegularClientButton;
        private System.Windows.Forms.Button insertClientFromPrevousPurchaseButton;
    }
}