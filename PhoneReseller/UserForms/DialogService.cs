using System.Windows.Forms;
using System.Data;
using LicenseGenerator.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using LicenseGenerator.Data;

namespace LicenseGenerator.UserForms
{
  class DialogService
  {
        public static void CreatePhone(string dialogName, ColumnsDictionary entity, bool printDoc)
        {
            var phone = DialogProvider.GetForm(dialogName).ShowMe(entity);
            if (phone == null) return;
            Cache.PutSingle(new PhoneOwner().Extract(phone));
            var id = DataProvider.CreateRow(phone);
            DataProvider.AddActionLog($"{id}", "Создана запись о покупке", phone["Acceptor"]);
            if (printDoc)
                new DocPrinter(phone);
        }

        public static void Transaction(string dialogName, ColumnsDictionary entity)
        {
            string getActionName(string tabelName){
            
                switch(tabelName)
                {
                    case "ToSell":
                        return "на продажу";
                    case "Sold":
                        return "в проданные";
                }
                return "";
            };

            var phone = DialogProvider.GetForm(dialogName).ShowMe(entity);
            if (phone == null) return;
            //Особенная логика для телефонов, которые были откачены
            if (entity.ContainsKey("Rollbacked") && (bool.Parse(entity["Rollbacked"])))
            {
                entity["Rollbacked"] = false.ToString();
                entity.RoollBacked = false;
                var prevTable = phone.TableName;
                phone.TableName = prevTable == "Rec" ? "ToSell" : "Sold";
                DataProvider.UpdateRow(phone);
                var actionName = getActionName(phone.TableName);
                DataProvider.AddActionLog(phone["ID"], $"Откаченый телефон переведен {actionName}", phone["Worker"]);
                DataProvider.GetTable(prevTable);
            }
            else DataProvider.MooveRow(phone, dialogName);
            DataProvider.AddActionLog(phone["ID"], $"Телефон переведен {getActionName(dialogName)}", phone["Worker"]);
            phone.TableName = dialogName;
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
            DataProvider.AddActionLog(phone["ID"], "Редактирование телефона", phone["Worker"]);
            DataProvider.GetTable(tname);
        }

    public static void ReturnPhone(ColumnsDictionary entity)
    {
        var phone = DialogProvider.GetForm("ReturnPhone").ShowMe(entity);
        if (phone == null) return;
        phone.TableName = "Sold";
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
                if (!row.ContainsKey(((Control)item).Name)) continue;
                //if (!row.IsNull(((Control)item).Name)) continue;
                if ((item is TextBox) || (item is ComboBox))
                {
                    if (row[((Control)item).Name].ToString() == "0") continue;
                    ((Control)item).Text = row[((Control)item).Name].ToString();
                }
                if (item is DateTimePicker)
                {
                    var date = row[((Control)item).Name];
                    ((DateTimePicker)item).Value = SQLiteDataConverter.ToDate(date);//(DateTime)row[((Control)item).Name];
                }
            }
        }

    }

}
