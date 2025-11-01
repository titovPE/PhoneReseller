namespace LicenseGenerator.UserForms
{
    partial class DayReport
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
            this.Seller = new System.Windows.Forms.ComboBox();
            this.dataGridView0 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.adminGroup = new System.Windows.Forms.GroupBox();
            this.wokerGroup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSpent = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelGot = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelDifference = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView0)).BeginInit();
            this.adminGroup.SuspendLayout();
            this.wokerGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Seller
            // 
            this.Seller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Seller.FormattingEnabled = true;
            this.Seller.Location = new System.Drawing.Point(16, 15);
            this.Seller.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Seller.Name = "Seller";
            this.Seller.Size = new System.Drawing.Size(160, 24);
            this.Seller.TabIndex = 4;
            this.Seller.SelectedIndexChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dataGridView0
            // 
            this.dataGridView0.AllowUserToAddRows = false;
            this.dataGridView0.AllowUserToDeleteRows = false;
            this.dataGridView0.AllowUserToResizeColumns = false;
            this.dataGridView0.AllowUserToResizeRows = false;
            this.dataGridView0.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView0.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView0.Location = new System.Drawing.Point(16, 48);
            this.dataGridView0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView0.MultiSelect = false;
            this.dataGridView0.Name = "dataGridView0";
            this.dataGridView0.ReadOnly = true;
            this.dataGridView0.RowHeadersVisible = false;
            this.dataGridView0.RowHeadersWidth = 51;
            this.dataGridView0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView0.Size = new System.Drawing.Size(813, 263);
            this.dataGridView0.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(185, 16);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Общая цена :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "_";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(438, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Прибыль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "_";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(460, 16);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker2.TabIndex = 6;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // adminGroup
            // 
            this.adminGroup.Controls.Add(this.label1);
            this.adminGroup.Controls.Add(this.label4);
            this.adminGroup.Controls.Add(this.label2);
            this.adminGroup.Controls.Add(this.label3);
            this.adminGroup.Location = new System.Drawing.Point(16, 318);
            this.adminGroup.Name = "adminGroup";
            this.adminGroup.Size = new System.Drawing.Size(813, 36);
            this.adminGroup.TabIndex = 11;
            this.adminGroup.TabStop = false;
            // 
            // wokerGroup
            // 
            this.wokerGroup.Controls.Add(this.labelDifference);
            this.wokerGroup.Controls.Add(this.label9);
            this.wokerGroup.Controls.Add(this.labelGot);
            this.wokerGroup.Controls.Add(this.label7);
            this.wokerGroup.Controls.Add(this.labelSpent);
            this.wokerGroup.Controls.Add(this.label5);
            this.wokerGroup.Location = new System.Drawing.Point(16, 318);
            this.wokerGroup.Name = "wokerGroup";
            this.wokerGroup.Size = new System.Drawing.Size(813, 54);
            this.wokerGroup.TabIndex = 12;
            this.wokerGroup.TabStop = false;
            this.wokerGroup.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Покупка";
            // 
            // labelSpent
            // 
            this.labelSpent.AutoSize = true;
            this.labelSpent.Location = new System.Drawing.Point(80, 10);
            this.labelSpent.Name = "labelSpent";
            this.labelSpent.Size = new System.Drawing.Size(14, 16);
            this.labelSpent.TabIndex = 1;
            this.labelSpent.Text = "_";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(274, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Продажа";
            // 
            // labelGot
            // 
            this.labelGot.AutoSize = true;
            this.labelGot.Location = new System.Drawing.Point(346, 10);
            this.labelGot.Name = "labelGot";
            this.labelGot.Size = new System.Drawing.Size(14, 16);
            this.labelGot.TabIndex = 3;
            this.labelGot.Text = "_";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(538, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Разница";
            // 
            // labelDifference
            // 
            this.labelDifference.AutoSize = true;
            this.labelDifference.Location = new System.Drawing.Point(609, 10);
            this.labelDifference.Name = "labelDifference";
            this.labelDifference.Size = new System.Drawing.Size(14, 16);
            this.labelDifference.TabIndex = 5;
            this.labelDifference.Text = "_";
            // 
            // DayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 393);
            this.Controls.Add(this.wokerGroup);
            this.Controls.Add(this.adminGroup);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView0);
            this.Controls.Add(this.Seller);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DayReport";
            this.Text = "DayReport";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView0)).EndInit();
            this.adminGroup.ResumeLayout(false);
            this.adminGroup.PerformLayout();
            this.wokerGroup.ResumeLayout(false);
            this.wokerGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Seller;
        private System.Windows.Forms.DataGridView dataGridView0;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.GroupBox adminGroup;
        private System.Windows.Forms.GroupBox wokerGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelDifference;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelGot;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelSpent;
    }
}