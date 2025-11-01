using LicenseGenerator;
using LicenseGenerator.Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PhoneReseller.Data
{
    static class SQLiteDataConverter
    {
        public static string CheckBoxCollectionToString(Control.ControlCollection collection)
        {
            return collection.OfType<CheckBox>().Where(item => item.Checked).Aggregate("", (current, item) => current + item.Text + ", ");
        }

        public static string ShiftChar(string str, char finded, string forShift)
        {
            string result = "";
            foreach (var item in str)
            {
                if (item == finded) result += forShift;
                else result += item;
            }
            return result;
        }
        public static string DateToString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
        public static string BoolTostring(bool value)
        {
            return value ? "1" : "0";
        }

        public static string ToNumString(object value)
        {
            string result = value.ToString();
            if (result == "") return "0";
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == ',')
                {
                    result = result.Substring(0, i) + '.' + result.Substring(i + 1);
                    break;
                }
            }
            return result;
        }

        public static ColumnsDictionary RowToDictionary(DataRow row)
        {
            if (row == null) return null;
            var result = new ColumnsDictionary(row.Table.TableName);
            foreach (DataColumn item in row.Table.Columns)
            {
                var value = row[item.Caption].ToString();
                //MessageBox.Show(value);
                if (value == "")
                    continue;

                value = ToNumString(row[item.Caption]);
                //if (row[item.Caption] is string) value =value;
                if (row[item.Caption] is DateTime) value = '\'' + DateToString((DateTime)row[item.Caption]) + '\'';
                if (row[item.Caption] is bool) value = ((bool)row[item.Caption]).ToString();// BoolTostring((bool)row[item.Caption]);
                result.IsRow = false;//todo коммент здесь данные возвращаются в чистом виде. при сохранении их надо бцдет обработать (доставить ковычки везде); внутри пользовательских форм мы должны работат!!! только с данными в чистом виде.
                result.Add(item.Caption, value);
            }
            if (result.ContainsKey("RollBacked"))//замена большой буквы на маленькую
            {
                result["Rollbacked"] = result["RollBacked"];
                result.Remove("RollBacked");
            }
            if (result.ContainsKey("Rollbacked"))
            {
                if (string.IsNullOrEmpty(result["Rollbacked"]))
                    result["Rollbacked"] = true.ToString();
                result.RoollBacked = bool.Parse(result["Rollbacked"]);
            }
            if (result.ContainsKey("PasportSer"))
            {
                var rawSer = result["PasportSer"];
                if (rawSer.Length == 5 && rawSer.StartsWith("1")) 
                {
                    result["PasportSer"] = rawSer.Substring(1, 4);
                }else if(rawSer.Length == 3)
                {
                    result["PasportSer"] = "0" + rawSer;
                }
            }
            if (result.ContainsKey("PasportNum"))
            {
                var rawNum = result["PasportNum"];
                if (rawNum.Length == 7 && rawNum.StartsWith("1"))
                {
                    result["PasportNum"] = rawNum.Substring(1, 6);
                }
                else if (rawNum.Length == 5)
                {
                    result["PasportNum"] = "0" + rawNum;
                }
            }

            return result;
        }

        public static string AdaptStringToSQLite(string str)
        {
            var result = "'";
            result += ShiftChar(str, '\'', "|");
            result += "'";
            return result;
        }

        public static DateTime ToDate(string date)
        {
            var arrDate = date.Split('-');
            int year = int.Parse(arrDate[0].TrimStart('\''));
            int month = int.Parse(arrDate[1]);
            int day = int.Parse(arrDate[2].TrimEnd('\''));
            var result = new DateTime(year, month, day);
            return result;
        }


        public static double ToDouble(string dbString)
        {
            for (int i = 0; i < dbString.Length; i++)
            {
                if (dbString[i] == '.')
                {
                    dbString = dbString.Substring(0, i) + ',' + dbString.Substring(i + 1);
                    break;
                }
            }
            return Convert.ToDouble(dbString);
        }

        /// <summary>
        /// Специализированный конвертер данных для передачи в таблицу клиентов. Не используется
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ColumnsDictionary clientDictionaryToSQLiteFormat(ColumnsDictionary entity)
        {
            var result = entity.CloneTyped();

            if (result.ContainsKey("Addres")) result["Addres"] = AdaptStringToSQLite(result["Addres"]);
            if (result.ContainsKey("FIO")) result["FIO"] = AdaptStringToSQLite(result["FIO"]);
            if (result.ContainsKey("PasportIssuedBy")) result["PasportIssuedBy"] = AdaptStringToSQLite(result["PasportIssuedBy"]);
            if (result.ContainsKey("PasportSer"))
            {
                var escapedSeries = result["PasportSer"].StartsWith("0")
                    ? "1" + result["PasportSer"]
                    : result["PasportSer"];
                result["PasportSer"] = AdaptStringToSQLite(escapedSeries);
            }
            if (result.ContainsKey("PasportNum"))
            {
                var escapedNumber = result["PasportNum"].StartsWith("0")
                    ? "1" + result["PasportNum"]
                    : result["PasportNum"];
                result["PasportNum"] = AdaptStringToSQLite(escapedNumber);
            }
            return result;
        }

        /// <summary>
        /// Унифицированый конвертер для погодтовки дсловаря к сохранению в БД
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ColumnsDictionary DictionaryToSQLiteFormat(ColumnsDictionary entity)
        {
            var result = entity.CloneTyped();
            if (entity.RoollBacked)
                result.TableName = entity.TableName == "Rec" ? "ToSell" : TableNames.Sold;
            if (result.IsRow) return result;
            if (result.ContainsKey("Rollbacked"))
            {
                result["RollBacked"] = bool.Parse(result["Rollbacked"]) ? "1" : "0";
                result.Remove("Rollbacked");
            }
            if (result.ContainsKey("Acceptor")) result["Acceptor"] = AdaptStringToSQLite(result["Acceptor"]);
            if (result.ContainsKey("Addres")) result["Addres"] = AdaptStringToSQLite(result["Addres"]);
            result["FIO"] = AdaptStringToSQLite(result["FIO"]);
            if (result.ContainsKey("Notes")) result["Notes"] = AdaptStringToSQLite(result["Notes"]);
            if (result.ContainsKey("DetectDefects")) result["DetectDefects"] = AdaptStringToSQLite(result["DetectDefects"]);
            if (result.ContainsKey("PasportIssuedBy")) result["PasportIssuedBy"] = AdaptStringToSQLite(result["PasportIssuedBy"]);
            result["Model"] = AdaptStringToSQLite(result["Model"]);
            if (result.ContainsKey("State")) result["State"] = AdaptStringToSQLite(result["State"]);
            if (result.ContainsKey("AkbState")) result["AkbState"] = AdaptStringToSQLite(result["AkbState"]);
            if (result.ContainsKey("BaseDefect")) result["BaseDefect"] = AdaptStringToSQLite(result["BaseDefect"]);
            if (result.ContainsKey("ComplectSet")) result["ComplectSet"] = AdaptStringToSQLite(result["ComplectSet"]);
            if (result.ContainsKey("AkbNumber")) result["AkbNumber"] = AdaptStringToSQLite(result["AkbNumber"]);
            if (result.ContainsKey("Worker")) result["Worker"] = AdaptStringToSQLite(result["Worker"]);
            if (result.ContainsKey("Seller")) result["Seller"] = AdaptStringToSQLite(result["Seller"]);
            bool tmp;
            if (result.ContainsKey("IsRepared")) result["IsRepared"] = bool.TryParse(result["IsRepared"], out tmp) && tmp ? "1" : "0";
            if (result.ContainsKey("WorkReport")) result["WorkReport"] = AdaptStringToSQLite(result["WorkReport"]);
            if (result.ContainsKey("ReasonOfBack")) result["ReasonOfBack"] = AdaptStringToSQLite(result["ReasonOfBack"]);
            if (result.ContainsKey("PasportSer"))
            {
                var escapedSeries = result["PasportSer"].StartsWith("0")
                    ? "1" + result["PasportSer"]
                    : result["PasportSer"];
                result["PasportSer"] = AdaptStringToSQLite(escapedSeries);
            }
            if (result.ContainsKey("PasportNum"))
            {
                var escapedNumber = result["PasportNum"].StartsWith("0")
                    ? "1" + result["PasportNum"]
                    : result["PasportNum"];
                result["PasportNum"] = AdaptStringToSQLite(escapedNumber);
            }
            result.IsRow = true;
            return result;
        }
    }
}
