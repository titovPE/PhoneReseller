using LicenseGenerator.Data;
using PhoneReseller.Data;
using PhoneReseller.UserForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LicenseGenerator.UserForms
{
  public partial class BuyPhone : Form, IReshower
  {
    ColumnsDictionary _result;
    ColumnsDictionary _row;

        public BuyPhone()
        {
            InitializeComponent();
            SetValidation();
        }

    private void SetValidation()
    {
      FIO.Validated += FormValidator.ValidateForNotEmpty;
      Addres.Validated += FormValidator.ValidateForNotEmpty;
      Cost.KeyPress += FormValidator.RecordingOnyMoney;
      Cost.Validated += FormValidator.ValidateForNotEmpty;
      PasportSer.KeyPress += FormValidator.RecordingOnyNumeric;
      PasportSer.Validated += FormValidator.ValidateForMaxOrEmpty;
      PasportNum.KeyPress += FormValidator.RecordingOnyNumeric;
      PasportNum.Validated += FormValidator.ValidateForMaxOrEmpty;
      Imei.KeyPress += FormValidator.RecordingOnyNumeric;
      Imei.Validated += FormValidator.ValidateForMaxOrEmpty;
      Imei.Validated += FormValidator.ValidateForNotEmpty;
      Model.Validated += FormValidator.ValidateForNotEmpty;
      AkbNumber.Validated += FormValidator.ValidateForNotEmpty;
    }

        public ColumnsDictionary ShowMe(ColumnsDictionary row)
        {
            fillByRegularClientButton.Visible = DataProvider.CheckTableAvailability(TableNames.Clients);
            _result = null;
            _row = null;
            DialogService.FillWorkers(Acceptor);

            DialogService.ClearAllChildren(Controls);
            checkBox12.Checked = true;
            if (row != null)
            {
                _row = row;
                DialogService.FillText(Controls, row);
                if (row.ContainsKey("State"))
                    FillChecs(State.Controls, row["State"], State_Text);
                if (row.ContainsKey("ComplectSet"))
                    FillChecs(ComplectSet.Controls, row["ComplectSet"], ComplectSet_Text);
                if (row.ContainsKey("AkbNumber"))
                    if (row["AkbNumber"] == string.Empty)
                        checkBox12.Checked = true;
            }
            ShowDialog();
            return _result;
        }

    private void FillChecs(Control.ControlCollection checks, string checkedInfo, TextBox other)
    {
      var result = 0;
      var checkList = checkedInfo.Split(',');
      for (int i = 0; i < checkList.Length; i++) checkList[i] = checkList[i].TrimStart(' ');
      foreach (var item in checks)
      {
          if (!(item is CheckBox)) continue;
          var ch = (CheckBox) item;
          if (!checkList.Contains(ch.Text)) continue;
          ch.Checked = true;
          result++;
      }
        if (result < checkList.Length) other.Text = checkList[checkList.Length - 1];
    }

    private void checkBox1_CheckStateChanged(object sender, EventArgs e)
    {
      AkbState.Enabled = !BatteryMiss.Checked;
      InflatedAKB.Enabled = !BatteryMiss.Checked;
      InflatedAKB.Checked = false;
      if (BatteryMiss.Checked) AkbState.Text = "";
    }

    private void OK_Click(object sender, EventArgs e)
    {
      var phone = new ColumnsDictionary("Rec")
      {
        {"Addres",Addres.Text},
        {"FIO",FIO.Text},
        {"PasportIssuedBy",PasportIssuedBy.Text},
        {"Cost", SQLiteDataConverter.ToNumString( Cost.Text)},
        {"BuyDate",SQLiteDataConverter.AdaptStringToSQLite( SQLiteDataConverter.DateToString(BuyDate.Value))},
        {"Imei", Imei.Text},
        {"Model",Model.Text},
        {"AkbNumber",AkbNumber.Text},
        {"AkbState",AkbState.Text},
        {"BaseDefect",BaseDefect.Text},
        {"State",SQLiteDataConverter.CheckBoxCollectionToString(State.Controls)+State_Text.Text},
        {"ComplectSet",SQLiteDataConverter.CheckBoxCollectionToString(ComplectSet.Controls) + ComplectSet_Text.Text},
        {"Notes",Notes.Text},
        {"Acceptor",Acceptor.Text}
      };
      if (PasportSer.Text != string.Empty) phone.Add("PasportSer", SQLiteDataConverter.ToNumString(PasportSer.Text));
      if (PasportNum.Text != string.Empty) phone.Add("PasportNum", SQLiteDataConverter.ToNumString(PasportNum.Text));
      if (_row != null && _row.ContainsKey("ID")) phone.Add("ID", _row["ID"].ToString());
      FormValidator.SetTrue();
      this.ValidateChildren();
      if (Acceptor.Text == "") { MessageBox.Show("выберите приемщика"); return; }
      if (!FormValidator.Validated) { MessageBox.Show("не заполненны следующие поля: " + FormValidator.FailedFields); return; }
      _result = phone;
      this.Close();
    }

    public string _stc(string sorceString)
    {
      return SQLiteDataConverter.AdaptStringToSQLite(sorceString);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

        private void PasportSer_KeyUp(object sender, KeyEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 4) PasportNum.Select();
            if (isAutocompleteAvailable()) tryToFillClient();
        }

        private void PasporNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 6) PasportIssuedBy.Select();
            if (!isAutocompleteAvailable())
                return;

            tryToFillClient();
        }

        /// <summary>
        /// Проверяет что автоподстановка активирована в приложении и достаточно данных для поиска клиента
        /// </summary>
        /// <returns></returns>
        private bool isAutocompleteAvailable()
        {
            return DataProvider.CheckAutocompleteEnabled() 
                && PasportSer.Text.Length == 4 
                && PasportNum.Text.Length == 6;
        }

        private void tryToFillClient() {
            var series = PasportSer.Text;
            var number = PasportNum.Text;

            var row = DataProvider.GetRowByPasport(number, series);            
            if(row ==  null) return;
            var controls = new List<Control> {FIO,PasportIssuedBy,PasportSer,PasportNum };
            DialogService.ClearAllChildren(controls);
            DialogService.FillText(controls, row.ToDictionary());
            Addres.Select();
        }


        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            updateAkbNumAvailability();
        }

        private void updateAkbNumAvailability() {
            AkbNumber.Enabled = !checkBox12.Checked;
            if (AkbNumber.Enabled) AkbNumber.Validated += FormValidator.ValidateForNotEmpty;
            else AkbNumber.Validated -= FormValidator.ValidateForNotEmpty;
        }


        /// <summary>
        /// Архивный метод делался для задачи управления постоянными клиентам, её отменили
        /// </summary>
        private void insertClientFromPrevousPurchaseButton_Click(object sender, EventArgs e)
        {
            var row = Cache.GetSingle<Domain.PhoneOwner>().ToDictionary("Rec");
            if (row != null) DialogService.FillText(clientGroupBox.Controls, row);
        }


        /// <summary>
        /// Архивный метод делался для задачи управления постоянными клиентам, её отменили
        /// </summary>
        private void fillByRegularClientButton_Click(object sender, EventArgs e)
        {
          new  RegularClient().ShowDialog();
        }
    }

}
