using LicenseGenerator;
using LicenseGenerator.Data;
using LicenseGenerator.Domain;
using LicenseGenerator.UserForms;
using PhoneReseller.Data;
using PhoneReseller.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PhoneReseller.UserForms
{
  class DialogService
  {
        public static void CreatePhone(string dialogName, ColumnsDictionary entity, bool printDoc)
        {
            var phone = DialogProvider.GetForm(dialogName).ShowMe(entity);
            if (phone == null) return;
            Cache.PutSingle(new PhoneOwner().Extract(phone));
            var id = DataProvider.CreateRow(phone);
            var cost = phone.ContainsKey("Cost") ? phone["Cost"] : "0";
            ActionsRepository.AddActionLog($"{id}", "Создана запись о покупке", phone["Acceptor"], ActionType.buyPhone, decimal.Parse(cost));
            if (printDoc)
                new DocPrinter(phone);
        }

        public static void Transaction(string dialogName, ColumnsDictionary entity)
        {
            ActionTypeWithComment getActionInfo(string tabelName)
            {
                switch (tabelName)
                {
                    case "ToSell":
                        return new ActionTypeWithComment
                        {
                            Value = ActionType.setAsForSale,
                            Comment = "на продажу"
                        };
                    case TableNames.Sold:
                        return new ActionTypeWithComment
                        {
                            Value = ActionType.soldPhone,
                            Comment = "в проданные"
                        };
                }
                return new ActionTypeWithComment
                {
                    Value = ActionType.undefined,
                    Comment = "<НЕ УДАЛОСЬ ОПРЕДЕЛИТЬ ДЕЙСТВИЕ НАД ТЕЛЕФОНОМ>"
                };
            }
            ;

            var phone = DialogProvider.GetForm(dialogName).ShowMe(entity);
            if (phone == null) return;
            var price = phone.ContainsKey("Price") ? phone["Price"] : "0";
            var parsedPrice = decimal.Parse(price);
            //Особенная логика для телефонов, которые были откачены
            if (entity.ContainsKey("Rollbacked") && bool.Parse(entity["Rollbacked"]))
            {
                entity["Rollbacked"] = false.ToString();
                entity.RoollBacked = false;
                var prevTable = phone.TableName;
                phone.TableName = prevTable == "Rec" ? "ToSell" : TableNames.Sold;
                DataProvider.UpdateRow(phone);
                var localAction = getActionInfo(phone.TableName);
                ActionsRepository.AddActionLog(phone["ID"], $"Откаченый телефон переведен {localAction.Comment}", phone["Worker"], localAction.Value, parsedPrice);
                DataProvider.GetTable(prevTable);
            }
            else DataProvider.MooveRow(phone, dialogName);
            var action = getActionInfo(dialogName);
            ActionsRepository.AddActionLog(phone["ID"], $"Телефон переведен {action.Comment}", phone["Worker"], action.Value, parsedPrice);
            phone.TableName = dialogName;
            //Печать ценника пока отулючена. Нужно сделать печать пачкой из списка
            if (action.Value != ActionType.setAsForSale)
                new DocPrinter(phone);
        }

        public static void EditPhone(string dialogName, ColumnsDictionary entity)
        {
            var phone = DialogProvider.GetForm(dialogName).ShowMe(entity);
            if (phone == null) return;
            var tname = phone.TableName;
            if (entity.ContainsKey("Rollbacked"))
                phone["Rollbacked"] = entity["Rollbacked"];
            phone.RoollBacked = entity.RoollBacked;
            DataProvider.UpdateRow(phone);
            ActionsRepository.AddActionLog(phone["ID"], "Редактирование телефона", phone["Worker"], ActionType.editPhone);
            DataProvider.GetTable(tname);
        }

    public static void ReturnPhone(ColumnsDictionary entity)
    {
        var phone = DialogProvider.GetForm("ReturnPhone").ShowMe(entity);
        if (phone == null) return;
        phone.TableName = TableNames.Sold;
        DataProvider.UpdateRow(phone);
        DataProvider.GetTable("ToSell");
    }

        public static void ClearAllChildren(Control.ControlCollection collection)
        {
            ClearAllChildren(collection.OfType<Control>());
        }

        public static void ClearAllChildren(IEnumerable<Control> controls)
        {
            foreach (var item in controls)
            {
                if (item is TextBox) (item as TextBox).Text = "";
                if (item is CheckBox) ((CheckBox)item).Checked = false;
                if (item is GroupBox) ClearAllChildren(((GroupBox)item).Controls);
                if (item is DateTimePicker) (item as DateTimePicker).Value = DateTime.Now;
            }
        }

        public static void FillWorkers(ComboBox workerList)
        {
            workerList.Items.Clear();
            var workers = DataProvider.GetTable("Workers");
            foreach (DataRow item in workers.Rows)
            {
                workerList.Items.Add(item["Name"]);
            }
            if (workerList.Items.Count > 0) workerList.SelectedIndex = 0;
        }

        public static void FillText(Control.ControlCollection collection, ColumnsDictionary row)
        {
            FillText(collection.OfType<Control>(), row);
        }

        public static void FillText(IEnumerable<Control> controls, ColumnsDictionary row)
        {
            foreach (var item in controls)
            {
                if (item is GroupBox) FillText(((GroupBox)item).Controls, row);
                if (!row.ContainsKey(item.Name)) continue;
                //if (!row.IsNull(((Control)item).Name)) continue;
                if (item is TextBox || item is ComboBox)
                {
                    if (row[item.Name].ToString() == "0") continue;
                    item.Text = row[item.Name].ToString();
                }
                if (item is DateTimePicker)
                {
                    var date = row[item.Name];
                    ((DateTimePicker)item).Value = SQLiteDataConverter.ToDate(date);//(DateTime)row[((Control)item).Name];
                }
            }
        }

    }

}
