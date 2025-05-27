using System;
using System.Windows.Forms;

namespace PhoneReseller.UserForms
{
    public partial class PasswordInput : Form
    {
        string _result;
        public PasswordInput()
        {
            InitializeComponent();
        }

        public string ShowMe()
        {
            ShowDialog();
            return _result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _result = textBox1.Text;
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) Close();
            if (e.KeyChar == 13) button1.PerformClick();
        }
    }
}
