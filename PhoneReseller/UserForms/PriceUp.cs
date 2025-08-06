using PhoneReseller.Data;
using PhoneReseller.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LicenseGenerator.UserForms
{
    public partial class PriceUp : Form, IReshower
    {
        public PriceUp()
        {
            InitializeComponent();
            PriceText.KeyPress += FormValidator.RecordingOnyMoney;
            PriceText.Validated += FormValidator.ValidateForNotEmpty;
        }

        private ColumnsDictionary _row;
        private ColumnsDictionary _result;

        public ColumnsDictionary ShowMe(ColumnsDictionary row)
        {
            DialogService.ClearAllChildren(this.Controls);
            _row = row;
            ShowDialog();
            return _result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var oldPrice = double.Parse(_row["SalePrice"]);
            FormValidator.SetTrue();
            if (!FormValidator.Validated) { MessageBox.Show("Назначъте новую цену"); return; }
            var newPrice = double.Parse(PriceText.Text);
            if (newPrice < oldPrice) { MessageBox.Show("Новая сумма меньше старой"); return; }
            _row["SalePrice"] =SQLiteDataConverter.ToNumString(PriceText.Text);
            _result = _row;
            Close();
        }
    }
}
