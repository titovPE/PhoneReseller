using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhoneReseller.UserForms
{
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        public void ShowMe()
        {
            ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPass;
            if (New1.Text == New2.Text) newPass = New1.Text;
            else {MessageBox.Show("повтор нового пароля отличается, введите еще раз новый пароль"); return;}
            if (Old.Text == DataProvider.GetAdminPass())
            {
                DataProvider.UpdateAdminPass(newPass);
                MessageBox.Show("Пароль изменен");
            }
            else MessageBox.Show("пароль не верен");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
