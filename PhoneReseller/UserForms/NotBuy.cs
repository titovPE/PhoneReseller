using PhoneReseller.Data;
using PhoneReseller.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LicenseGenerator.UserForms
{
  public partial class NotBuy : Form, IReshower
  {
    ColumnsDictionary Result;
    ColumnsDictionary Row;

    double FCost
    { get { return TextToDouble(Cost.Text); } }
    double FMargin
    { get { return TextToDouble(Margin.Text); } }
    int FPercent
    { get {
      if (Percent.Text == "" || Percent.Text == "-") return 0;
      return Convert.ToInt32(Percent.Text);
    } }

    public NotBuy()
    {
      InitializeComponent();
      SetValidetion();
    }

    private void SetValidetion()
    {
      Cost.KeyPress += FormValidator.RecordingOnyMoney;
      Cost.Validated += FormValidator.ValidateForNotEmpty;
      Imei.KeyPress += FormValidator.RecordingOnyNumeric;
      Imei.Validated += FormValidator.ValidateForMaxOrEmpty;
      Imei.Validated += FormValidator.ValidateForNotEmpty;
      Model.Validated += FormValidator.ValidateForNotEmpty; ;
      AkbNumber.Validated += FormValidator.ValidateForNotEmpty;
    }

    public ColumnsDictionary ShowMe(ColumnsDictionary row)
    {
      Result = null;
      Row = null;
      DialogService.ClearAllChildren(this.Controls);
      DialogService.FillWorkers(Worker);
      if (row != null)
      {
        DialogService.FillText(this.Controls, row);
        Row = row;
      }
      this.ShowDialog();
      return Result;
    }



    private void Margin_TextChanged(object sender, EventArgs e)
    {
      var value = TextToDouble(((TextBox)sender).Text);
      if (value < 0) SetMoneyColor(Color.Red);
      else SetMoneyColor(Color.Black);
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

    private void Price_KeyUp(object sender, KeyEventArgs e)
    {
      var tb = (TextBox)sender;
      if (tb.Text == "") tb.Text = "0";
      MarginRecall(false);
    }

    private void Cost_KeyUp(object sender, KeyEventArgs e)
    {
      MarginRecall(true);
    }

    public void MarginRecall(bool fillPrice)
    {
      if (fillPrice) Price.Text = Price.Text = (FMargin + FCost).ToString();
      else Margin.Text = (Convert.ToDouble(Price.Text) - FCost).ToString();
      Percent.Text = ((int)((FMargin / FCost) * 100)).ToString();
    }

    void SetMoneyColor(Color color)
    {
      Margin.ForeColor = color;
      Price.ForeColor = color;
      Percent.ForeColor = color;
    }

    public double TextToDouble(string text)
    {
      if (text == "-" || text == "") text = "0";
      if (text[0] == ',') text = "0" + text;
      return Convert.ToDouble(text);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var phone = new ColumnsDictionary("Rec")
      {
        {"FIO",("это наш телефон")},
        {"Acceptor", (Worker.Text)},
        {"Cost", SQLiteDataConverter.ToNumString( Cost.Text)},
       {"BuyDate",SQLiteDataConverter.AdaptStringToSQLite( SQLiteDataConverter.DateToString(BuyDate.Value))},
        {"Imei", Imei.Text},
        {"Model",(Model.Text)},
        {"AkbNumber",(AkbNumber.Text)},
        {"Notes",(Notes.Text)},
        {"BaseDefect",(BaseDefect.Text)},
        {"Addres",("_")},
        //{"Margin", SQLiteDataConverter.ToNumString(Margin.Text)},
        //{"SalePrice", SQLiteDataConverter.ToNumString(Price.Text)},
        //{"Price", SQLiteDataConverter.ToNumString(Price.Text)}
      };
      if (Row != null) phone.Add("ID", Row["ID"].ToString());
      FormValidator.SetTrue();
      this.ValidateChildren();
      if (Worker.Text == "") { MessageBox.Show("выберите приемщика"); return; }
      if (!FormValidator.Validated) { MessageBox.Show("не заполненны следующие поля: " + FormValidator.FailedFields); return; }
      Result = phone;
      this.Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
