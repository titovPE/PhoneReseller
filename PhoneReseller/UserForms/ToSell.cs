using LicenseGenerator.Data;
using PhoneReseller.UserForms;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using PhoneReseller.Entities;

namespace LicenseGenerator.UserForms
{
    public partial class ToSell : Form, IReshower
    {
      ColumnsDictionary _row;
        Color MoneyColor;
        ColumnsDictionary _result;
        double FCost
        { get { return Convert.ToDouble(_row["Cost"]) + FWorkCost; } }
        double FMargin
        { get { return TextToDouble(Margin.Text); } }
        int FPercent
        { get {
          if (Percent.Text == "" || Percent.Text == "-") return 0;
          return Convert.ToInt32(Percent.Text);
        } }
        Double FWorkCost
        { get { return TextToDouble(WorkCost.Text); } }

        public ToSell()
        {
            InitializeComponent();
            MoneyColor = Margin.ForeColor;
            Price.ForeColor = MoneyColor;
            Percent.ForeColor = MoneyColor;
        }

        public ColumnsDictionary ShowMe(ColumnsDictionary row)
        {
            _result = null;
            DialogService.ClearAllChildren(this.Controls);
            DialogService.FillWorkers(Worker);
            WorkCost.Text = "0";
            _row = row;
            Model.Text = _row["Model"];
            Cost.Text = _row["Cost"];
            if (row.ContainsKey("Margin"))
            {
                Margin.Text = row["Margin"];
                MarginRecall(true);
            }
            BaseDefect.Text = _row.ContainsKey("BaseDefect") ? _row["BaseDefect"] : "";
            ShowDialog();
            return _result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          var phone = _row;// SQLiteDataConverter.RowToDictionary(Row);
          phone.Set("Worker", Worker.Text);
          phone.Set("DateApprowed",SQLiteDataConverter.AdaptStringToSQLite( SQLiteDataConverter.DateToString(DateApprowed.Value)));
          phone.Set("DetectDefects", DetectDefects.Text);
          phone.Set("IsRepared", SQLiteDataConverter.BoolTostring(IsRepared.Checked));
          phone.Set("WorkCost", SQLiteDataConverter.ToNumString(WorkCost.Text));
          phone.Set("WorkReport", WorkReport.Text);
          phone.Set("Margin", SQLiteDataConverter.ToNumString(Margin.Text));
          phone.Set("SalePrice", SQLiteDataConverter.ToNumString(Price.Text));
          phone.Set("Price", SQLiteDataConverter.ToNumString(Price.Text));
          if (!phone.ContainsKey("Rollbacked")) phone.Set("Rollbacked", false.ToString());
          FormValidator.SetTrue();
          ValidateChildren();
          if (Worker.Text == "") { MessageBox.Show("выберите работника"); return; }
          if (!FormValidator.Validated) { MessageBox.Show("не заполненны следующие поля: " + FormValidator.FailedFields); return; }
          _result = phone;
          Close();
        }


        private void Margin_KeyUp(object sender, KeyEventArgs e)
        {
            MarginRecall(true);
        }
        private void Percent_KeyUp(object sender, KeyEventArgs e)
        {
            Margin.Text = ((FCost / 100) * FPercent).ToString();
            Price.Text = (FMargin + FCost).ToString();
        }
        private void WorkCost_KeyUp(object sender, KeyEventArgs e)
        {
            MarginRecall(true);
        }
        private void Price_KeyUp(object sender, KeyEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text == "") tb.Text = "0";
            MarginRecall(false);
        }

        public void MarginRecall(bool fillPrice)
        {
          if (fillPrice) Price.Text = Price.Text = (FMargin + FCost).ToString();
          else Margin.Text = (Convert.ToDouble(Price.Text) - FCost).ToString();
          Percent.Text = ((int)((FMargin / FCost) * 100)).ToString();
        }
      


        private void IsRepared_CheckedChanged(object sender, EventArgs e)
        {
            WorkInformation.Enabled = ((CheckBox)sender).Checked;
            DetectDefects.Text = "";
            WorkReport.Text = "";
            WorkCost.Text = "0";
        }


        private void RecordingOnyNumeric(object sender, KeyPressEventArgs e)
        {
            FormValidator.RecordingOnyNumeric(sender, e);
        }
        private void RecordingOnyMoney(object sender, KeyPressEventArgs e)
        {
            FormValidator.RecordingOnyMoney(sender, e);
        }
        private void ValidateForMaxOrEmpty(object sender, EventArgs e)
        {
            FormValidator.ValidateForMaxOrEmpty(sender, e);
        }
        private void ValidateForNotEmpty(object sender, EventArgs e)
        {
            FormValidator.ValidateForNotEmpty(sender, e);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Margin_TextChanged(object sender, EventArgs e)
        {
            var value = TextToDouble(((TextBox)sender).Text);
            if (value < 0) SetMoneyColor(Color.Red);
            else SetMoneyColor(Color.Black);
        }

        public double TextToDouble(string text)
        {
            if (text == "-" || text == "") text = "0";
            if (text[0] == ',') text = "0" + text;
            return Convert.ToDouble(text);
        }

        void SetMoneyColor(Color color)
        {
            Margin.ForeColor = color;
            Price.ForeColor = color;
            Percent.ForeColor = color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          if(MessageBox.Show("Телефон будет помечен как неподлежащий продаже и перемещен на страницу администратора", "Внимание", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
          var phone = _row;//SQLiteDataConverter.RowToDictionary(Row);
          phone.Add("Worker", Worker.Text);
          phone.Add("DateApprowed",SQLiteDataConverter.AdaptStringToSQLite( SQLiteDataConverter.DateToString(DateApprowed.Value)));
          phone.Add("SellDate", SQLiteDataConverter.AdaptStringToSQLite( SQLiteDataConverter.DateToString(DateApprowed.Value)));
          phone.Add("DetectDefects", DetectDefects.Text);
          phone.Add("IsRepared", SQLiteDataConverter.BoolTostring(IsRepared.Checked));
          phone.Add("WorkCost", SQLiteDataConverter.ToNumString(WorkCost.Text));
          phone.Add("WorkReport", WorkReport.Text);
          phone.Add("SoldState","Без ремонта");
          //FormValidator.SetTrue();
          this.ValidateChildren();
          if (Worker.Text == "") 
          { 
            MessageBox.Show("выберите работника"); 
            return; 
          }
          //if (!FormValidator.Validated) { MessageBox.Show("не заполненны следующие поля: " + FormValidator.FailedFields); return; }
          DataProvider.MooveRow(phone, "Sold");
            DataProvider.AddActionLog(phone["ID"], $"Телефон помечен как не подлежащий к продаже", phone["Worker"], ActionType.setAsNotForSale);
            Close();
        }

        //public string _stc(string sorceString)
        //{
        //  return SQLiteDataConverter.AdaptStringToSQLite(sorceString);
        //}
    }
}
