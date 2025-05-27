using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhoneReseller.Generators;

namespace PhoneReseller.UserForms
{
    public partial class SellPhone : Form, IReshower
    {
      ColumnsDictionary Row;
        ColumnsDictionary Result;
        public SellPhone()
        {
          InitializeComponent();
        }

        public ColumnsDictionary ShowMe(ColumnsDictionary row)
        {
            Result = null;
            if (row == null) return null;
            Row = row;
            Seller.Items.Clear();
            Seller.Items.AddRange(WorkersGenerator.GetWorkers().ToArray());
            if (Seller.Items.Count > 0) Seller.SelectedIndex = 0;
            DialogService.ClearAllChildren(Controls);
            Price.Text = row["SalePrice"].ToString();
            ShowDialog();
            return Result;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
          var phone = Row;
          phone["SellDate"] = SQLiteDataConverter.AdaptStringToSQLite(SQLiteDataConverter.DateToString(SellDate.Value));
          phone["Seller"] = (Seller.Text);
          if (!phone.ContainsKey("Acceptor")) phone.Add("Acceptor",("_"));
          if (Seller.Text == "") { MessageBox.Show("выберите работника"); return; }
          Result = phone;
          Close();
        }



    }
}
