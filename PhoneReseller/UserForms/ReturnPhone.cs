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
    public partial class ReturnPhone : Form, IReshower
    {
        public ReturnPhone()
        {
            InitializeComponent();
            ReasonOfBack.Validated+= FormValidator.ValidateForNotEmpty;
        }
        ColumnsDictionary _result;
        ColumnsDictionary _row;

        public ColumnsDictionary ShowMe(ColumnsDictionary row)
        {
            _row = row;
            ReasonOfBack.Text = "";
            ShowDialog();
            return _result;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            var phone = _row;
            phone["ReasonOfBack"] = (phone.ContainsKey("ReasonOfBack")?phone["ReasonOfBack"]:"")+" | "+ReasonOfBack.Text;
            phone["Rollbacked"] = true.ToString();
            FormValidator.SetTrue();
            ValidateChildren();
            if (!FormValidator.Validated) { MessageBox.Show("Не заполнена причина возврата"); return; }
            _result = phone;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
