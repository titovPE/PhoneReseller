using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Reflection;
using Microsoft.Win32;
using System.Data.SqlClient;
using PhoneReseller.Entities;
using PhoneReseller.Data;

namespace LicenseGenerator.Data
{
    internal static class DataProvider
    {
        private static SQLiteConnection _myConnection;
        private static SQLiteDataAdapter _myDataAdapter;
        private static DataSet1 _myDataSet;

        private static bool? isAutocompleteAvailable = null;


        public static void Inicialize(string path)
        {
            if(path == null)
                path = Application.StartupPath + "\\Phones";
            _myConnection = new SQLiteConnection("data source= " + path );
            _myDataAdapter = new SQLiteDataAdapter($"SELECT        {TableNames.Vars}.*FROM      {TableNames.Vars}",
                                                   _myConnection);
            _myDataSet = new DataSet1();
            _myConnection.Open();
            _myDataAdapter.Fill(_myDataSet, TableNames.Vars);
            //VerifyDatabase();
        }

        /// <summary>
        /// Общий метод обновления содержимого указаной таблицы в наборе данных
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetTable(string tableName)
        {
            FillDataSet(tableName, null);
            return _myDataSet.Tables[tableName];

        }

        public static bool CheckTableAvailability(string tableName)
        {
            var sqlitMaster = "sqlite_master";
            var cmd = "SELECT name FROM " + sqlitMaster + " WHERE type='table'";
            _myDataAdapter.SelectCommand = new SQLiteCommand(cmd, _myConnection);
            _myDataAdapter.Fill(_myDataSet, sqlitMaster);
            return _myDataSet.Tables[sqlitMaster]
                .Rows.Cast<DataRow>().Select(it => it["name"])
                .Any(it => it.ToString() == tableName);
        }

        internal static int ExecuteNonQuery(string command)
        {
            using (var myCommand = new SQLiteCommand(command, _myConnection))
            {
                return myCommand.ExecuteNonQuery();
            }
        }
        public static IEnumerable<DataRow> getRowsByCommand(string command)
        {
            DataTable table = new DataTable();

            using (var da = new SQLiteDataAdapter(command, _myConnection))
                da.Fill(table);
            var res = table.Rows.Cast<DataRow>().ToList();
            return res;
        }

        #region Ations log

        #endregion

        #region regular clients
        // фича отменена, но код остался для возможного использования в будущем

        /// <summary>
        /// Архивный метод делался для задачи управления постоянными клиентам, её отменили
        /// </summary>
        public static void EnableRegularClients()
        {
            var cliensTable = TableNames.Clients;

            if (CheckTableAvailability(cliensTable))
            {
                MessageBox.Show("Управление клинтами уже включили раньше. Сейчас ничего сделано не будет");
                return;
            }

            var command = $@"CREATE TABLE [{cliensTable}] (
                              [Addres] nvarchar(100) NOT NULL COLLATE NOCASE
                            , [FIO] nvarchar(50) NOT NULL COLLATE NOCASE
                            , [PasportSer] numeric(4,0) NULL
                            , [PasportNum] numeric(6,0) NULL
                            , [PasportIssuedBy] nvarchar(200) NULL COLLATE NOCASE
                            );
                            CREATE UNIQUE INDEX [Rec_sqlite_autoindex_Rec_1] ON [Rec] ([ID] ASC);";

            new SQLiteCommand(command, _myConnection).ExecuteNonQuery();
            MessageBox.Show("Управление клиентами успешно в ключено и доступно на форме пукупки телефона");
        }

        #endregion

        #region ClientsAutocomplete

        /// <summary>
        /// Проверка доступности автокомплита по 
        /// </summary>
        /// <returns></returns>
        public static bool CheckAutocompleteEnabled()
        {
            if (isAutocompleteAvailable != null)
                return isAutocompleteAvailable.Value;
            var newColumnName = "CheckAutocompleteEnabled";
            var checkCommand = $"SELECT {TableNames.Vars}.* FROM {TableNames.Vars}";
            _myDataAdapter.SelectCommand = new SQLiteCommand(checkCommand, _myConnection);
            _myDataAdapter.Fill(_myDataSet, TableNames.Vars);
            var columnNames = _myDataSet.Tables[TableNames.Vars]
                .Columns.Cast<DataColumn>()
                .Select(it => it.ColumnName);
            isAutocompleteAvailable = columnNames.Contains(newColumnName);
            return isAutocompleteAvailable.Value;

        }

        /// <summary>
        /// Включение автозаполнения клиентов. 
        /// Создает в глобальных переменных новуй солбец для проверки что опция включена
        /// После этого создает индексы на серии и номере паспорта в овсех таблицах телефонов
        /// </summary>
        public static void EnableClientAutocomplete()
        {
            var newColumnName = "CheckAutocompleteEnabled";
            var isEnabled = CheckAutocompleteEnabled();
            if (isEnabled)
            {
                MessageBox.Show("Автозаполнение клиентов уже было включено раньше, поэтому сейчас ничего не сделано");
                return;
            }

            var alterCommand = $"ALTER TABLE {TableNames.Vars} ADD COLUMN {newColumnName} BIT NOT NULL DEFAULT 1";
            new SQLiteCommand(alterCommand, _myConnection).ExecuteNonQuery();

            new List<string>() { "Rec", "ToSell", TableNames.Sold }.ForEach(tableName =>
            {
                var indexCommand = $"CREATE INDEX idx_{tableName}_PasportSer_PasportNum ON {tableName} (PasportSer, PasportNum)";
                new SQLiteCommand(indexCommand, _myConnection).ExecuteNonQuery();
            });
            isAutocompleteAvailable = true;
            MessageBox.Show("Автозаполнение клиентов включено");
        }

        /// <summary>
        /// Поиск по всем таблицам самой свежей записи (максимальный номер записи) выполненной для указанного паспорта
        /// Если не найдена, возвращает null
        /// </summary>
        /// <param name="pasportNumber"></param>
        /// <param name="pasportSeries"></param>
        /// <returns></returns>
        public static DataRow GetRowByPasport(string pasportNumber, string pasportSeries)
        {
            DataRow GetMax(IEnumerable<DataRow> rows)
            {
                if (rows.Count() == 0)
                    return null;
                var maxNum = rows.Max(it => int.Parse(it["Num"].ToString()));
                return rows.First(it => it["Num"].ToString() == maxNum.ToString());
            };

            IEnumerable<DataRow> getRowsByCommand(string command)
            {
                DataTable table = new DataTable();

                using (var da = new SQLiteDataAdapter(command, _myConnection))
                    da.Fill(table);
                var res = table.Rows.Cast<DataRow>().ToList();
                return res;
            }

            var condition = $"WHERE (PasportSer = {pasportSeries} OR PasportSer = 1{pasportSeries}) " +
                $"AND (PasportNum = {pasportNumber} OR PasportNum = 1{pasportNumber})";
            var result = new List<DataRow>();

            new List<string>() { "Rec", "ToSell", TableNames.Sold }.ForEach(tableName =>
            {
                var command = $"SELECT * FROM {tableName} {condition}";
                var rows = getRowsByCommand(command);
                var maxRow = GetMax(rows);
                if (maxRow != null) result.Add(maxRow);
            });
            return GetMax(result);
        }

        #endregion

        //Регион чтения бд для отображения в UI
        #region filling gridView

        public static void FillDataSet(string tableName, List<string> whereList)
        {
            if (whereList == null) whereList = new List<string>();
            //если что, можно будет передавать список WHERE и конструировать из него строку запроса с условиями
            //также можно будет сделать Dictionary для вшитых условий.
            //var where = WherelistTostring(whereList);
            if (_myDataSet.Tables[tableName] != null) _myDataSet.Tables[tableName].Clear();
            if (tableName == "Rec")
            {
                FillRec(whereList);
                return;
            }
            if (tableName == "ToSell")
            {
                FillToSell(whereList);
                return;
            }
            if (tableName == TableNames.Sold) whereList.Add("(RollBacked = 0) OR (RollBacked IS NULL)");
            var where = WherelistTostring(whereList);
            Select(tableName, where);
        }

        private static void FillRec(List<string> whereList)
        {
            var @where = WherelistTostring(whereList);
            Select("Rec", where);

            whereList.Add("RollBacked = 1");
            @where = WherelistTostring(whereList);
            var command = "SELECT        ToSell.* FROM  ToSell " + where;
            _myDataAdapter.SelectCommand = new SQLiteCommand(command, _myConnection);
            _myDataAdapter.Fill(_myDataSet, "Rec");
        }

        private static void FillToSell(List<string> whereList)
        {
            var toSellWhere = new List<string>(whereList){
                "(RollBacked = 0) OR (RollBacked IS NULL)"
            }; 
            Select("ToSell", WherelistTostring(toSellWhere));
            whereList.Add("RollBacked = 1");
            var @where = WherelistTostring(whereList);
            var command = "SELECT        Sold.* FROM  Sold " + where;
            _myDataAdapter.SelectCommand = new SQLiteCommand(command, _myConnection);
            _myDataAdapter.Fill(_myDataSet, "ToSell");
        }

        /// <summary>
        /// Передает результат селекта в набор данных с помощью адаптера БД
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="otherElements">дополнение к строке запроса. любые SQL команды. например WHERE Num LIKE '4%'</param>
        private static void Select(string tableName, string otherElements)
        {
            var command = "SELECT " + tableName + ".* FROM  " + tableName + "  " + otherElements;
            _myDataAdapter.SelectCommand = new SQLiteCommand(command, _myConnection);
            _myDataAdapter.Fill(_myDataSet, tableName);
        }

        private static string WherelistTostring(List<string> whereList)
        {
            if (whereList.Count == 0) return "";
            var result = whereList.Aggregate("WHERE   ", (current, item) => current + "( " + item + ") AND");
            return result.Substring(0, result.Length - 3);
        }


        public static void FilteringOn(string tableName, string fieldName, string filteringValue, string alterValue = null)
        {
            //if (_myDataSet.Tables[tableName] != null) _myDataSet.Tables[tableName].Clear();
            //var command = "SELECT " + tableName + ".* FROM " + tableName + " WHERE        (" + fieldName + " LIKE '" + filteringValue + "%')";
            ////message(command);
            //_myDataAdapter.SelectCommand = new SQLiteCommand(command, _myConnection);
            //_myDataAdapter.Fill(_myDataSet, tableName);

            var condidtion = fieldName + " LIKE '" + filteringValue + "%'";
            if (alterValue != null) condidtion = condidtion + " OR " + fieldName + " LIKE '" + alterValue + "%'";

            FillDataSet(tableName, new List<string> { condidtion });

        }

        #endregion

        private static void UpdateGlobalVariables(int id, int num)
        {
            if (num < GetMaxNum()) num = GetMaxNum();
            new SQLiteCommand($"UPDATE {TableNames.Vars} SET MaxID = {id}, MaxNum = {num}", _myConnection).
                ExecuteNonQuery();
            _myDataSet.Tables[TableNames.Vars].Clear();
            _myDataAdapter.SelectCommand = new SQLiteCommand(
                $"SELECT {TableNames.Vars}.* FROM {TableNames.Vars}", _myConnection) ;
            _myDataAdapter.Fill(_myDataSet, TableNames.Vars);
        }
         
        private static void UpdateWorkerID(int id)
        {
            new SQLiteCommand($"SELECT {TableNames.Vars}.* FROM {TableNames.Vars}", _myConnection).ExecuteNonQuery();
            _myDataSet.Tables[TableNames.Vars].Clear();
            _myDataAdapter.SelectCommand = new SQLiteCommand(
                $"SELECT {TableNames.Vars}.* FROM {TableNames.Vars}", _myConnection);
            _myDataAdapter.Fill(_myDataSet, TableNames.Vars);
        }

        /// <summary>
        /// создает новую запись в таблице, при этом айди равен муксимальному +1
        /// </summary>
        /// <param name="valuesSet"></param>
        public static int CreateRow(ColumnsDictionary valuesSet, bool enableID = true)
        {

            var valuesRow = valuesSet.TableName == TableNames.Clients
                ? SQLiteDataConverter.clientDictionaryToSQLiteFormat(valuesSet)
                    : SQLiteDataConverter.DictionaryToSQLiteFormat(valuesSet);

            //TODO если это таблица клиент,
            //там нет ни идентификатора ни номера идентификатор
            //наверно нужен для индекса и получения чодржиможгго выбранной записи а вот номер точно не нужен.
            //Видать надо сделатьновый метод.
            var id = GetMaxID() + 1;
            var columns = "(";
            var values = "(";
            if (enableID) {
                columns = columns + " ID , Num";
                values = values + id + " ," + (GetMaxNum() + 1);
            }

            UpdateGlobalVariables(GetMaxID() + 1, GetMaxNum() + 1);
            foreach (var item in valuesRow)
            {
                if (item.Key == "ID" || item.Key == "Num") continue;
                columns += " ," + item.Key;
                values += " ," + item.Value;
            }
            columns += " )";
            values += ") ";
            var command = "INSERT INTO " + valuesRow.TableName + " " + columns + " VALUES " + values;
            //string command = "INSERT INTO ToSell                          (Worker, DateApprowed, DetectDefects, IsRepared, WorkCost, WorkReport, Price, Margin, Addres, FIO, PasportSer, PasportNum, PasportIssuedBy, Cost, BuyDate,                          Imei, Model, AkbNumber, AkbState, BaseDefect, State, ComplectSet, Notes, ID, SalePrice, Num, Acceptor) VALUES        ('qqq', '10/1/2020', 'erw', 0, 100, 'werwe', 100, 100, 'wqer', 'wqer', 1111, 111111, 'wer', 1000, '10/2/1930', 111111111, 'ewrtewr', 'retwer', 'rwetwer', 'wertwe', 'ewrtwe',                          'erwtwe', 'wertwe', 100, 2000, 100, 'sdfgsdfg')";
            //message(command);
            var myCommand = new SQLiteCommand(command, _myConnection);
            myCommand.ExecuteNonQuery();
            FillDataSet(valuesRow.TableName, null);
            return id;
        }

        public static void AddWorker(ColumnsDictionary worker)
        {
            var id = Convert.ToInt32(_myDataSet.Tables[TableNames.Vars].Rows[0]["WorkerID"]) + 1;
            var columns = "( ID ";
            var values = "(" + id;
            UpdateWorkerID(id);
            //UpdateGlobalVariables((GetMaxID() + 1), (GetMaxNum() + 1));

            foreach (var item in worker)
            {
                columns += " ," + item.Key;
                values += " ," + item.Value;
            }
            columns += " )";
            values += ") ";
            var command = "INSERT INTO " + worker.TableName + " " + columns + " VALUES " + values;
            var myCommand = new SQLiteCommand(command, _myConnection);
            myCommand.ExecuteNonQuery();
            FillDataSet(worker.TableName, null);
        }

        public static void AddRow(ColumnsDictionary row)
        {
            var dictionary = SQLiteDataConverter.DictionaryToSQLiteFormat(row);
            var columns = "(";
            var values = "(";
            //UpdateGlobalVariables((GetMaxID() + 1), (GetMaxNum() + 1));
            foreach (var item in dictionary)
            {
                columns += item.Key + " ,";
                values += item.Value + " ,";
            }
            columns = columns.Substring(0, columns.Length - 1) + " )";
            values = values.Substring(0, values.Length - 1) + ") ";
            var command = "INSERT INTO " + dictionary.TableName + " " + columns + " VALUES " + values;
            //string command = "INSERT INTO ToSell                          (Worker, DateApprowed, DetectDefects, IsRepared, WorkCost, WorkReport, Price, Margin, Addres, FIO, PasportSer, PasportNum, PasportIssuedBy, Cost, BuyDate,                          Imei, Model, AkbNumber, AkbState, BaseDefect, State, ComplectSet, Notes, ID, SalePrice, Num, Acceptor) VALUES        ('qqq', '10/1/2020', 'erw', 0, 100, 'werwe', 100, 100, 'wqer', 'wqer', 1111, 111111, 'wer', 1000, '10/2/1930', 111111111, 'ewrtewr', 'retwer', 'rwetwer', 'wertwe', 'ewrtwe',                          'erwtwe', 'wertwe', 100, 2000, 100, 'sdfgsdfg')";
            //message(command);
            var myCommand = new SQLiteCommand(command, _myConnection);
            myCommand.ExecuteNonQuery();
            FillDataSet(dictionary.TableName, null);
        }

        public static void DeleteRow(ColumnsDictionary row)
        {

            var newRow = SQLiteDataConverter.DictionaryToSQLiteFormat(row);
            var command = "DELETE FROM " + newRow.TableName + " WHERE        (" + newRow.TableName + ".ID = " + newRow["ID"] +
                          ")";
            new SQLiteCommand(command, _myConnection).ExecuteNonQuery();
            FillDataSet(newRow.TableName, null);
        }

        public static void ClearTable(string tableName)
        {
            var command = "DELETE FROM " + tableName;
            new SQLiteCommand(command, _myConnection).ExecuteNonQuery();
            FillDataSet(tableName, null);
        }

        public static void MooveRow(ColumnsDictionary row, string destonationTable)
        {
            var oldTable = row.TableName;
            row.TableName = destonationTable;
            AddRow(row);
            row.TableName = oldTable;
            DeleteRow(row);
            //string command = "DELETE FROM " + row.TableName + " WHERE        (" + row.TableName + ".ID = " + row["ID"] + ")";
            //new SQLiteCommand(command, MyConnection).ExecuteNonQuery();
            //message(command);
        }

        public static void UpdateRow(ColumnsDictionary row)
        {
            var dictoinary = SQLiteDataConverter.DictionaryToSQLiteFormat(row);
            var command = "UPDATE       " + dictoinary.TableName + " SET ";
            command = dictoinary.Aggregate(command, (current, item) => current + item.Key + " = " + item.Value + " , ");
            command = command.Substring(0, command.Length - 3) + " WHERE  (ID = " + dictoinary["ID"] + ")";
            new SQLiteCommand(command, _myConnection).ExecuteNonQuery();
            FillDataSet(dictoinary.TableName, null);
        }

       

        private static int GetMaxID()
        {
            return Convert.ToInt32(_myDataSet.Tables[TableNames.Vars].Rows[0]["MaxID"]);
        }

        private static int GetMaxNum()
        {
            return Convert.ToInt32(_myDataSet.Tables[TableNames.Vars].Rows[0]["MaxNum"]);
        }

        public static string GetAdminPass()
        {
            var result = _myDataSet.Tables[TableNames.Vars].Rows[0]["AdminPass"].ToString();
            return result;
        }

        public static void UpdateAdminPass(string pass)
        {
            new SQLiteCommand($"UPDATE       {TableNames.Vars} SET AdminPass = " + pass, _myConnection).ExecuteNonQuery();
            _myDataSet.Tables[TableNames.Vars].Clear();
            _myDataAdapter.SelectCommand = new SQLiteCommand(
                $"SELECT        {TableNames.Vars}.* FROM      {TableNames.Vars}", _myConnection);
            _myDataAdapter.Fill(_myDataSet, TableNames.Vars);
        }

        public static void UpdateValueInRow(ColumnsDictionary row, string fieldName, string newValue)
        {
            new SQLiteCommand(
                "UPDATE       " + row.TableName + " SET " + fieldName + " = " + newValue + " WHERE  (ID = " + row["ID"] +
                ")", _myConnection).ExecuteNonQuery();
            _myDataSet.Tables[row.TableName].Clear();
            _myDataAdapter.SelectCommand =
                new SQLiteCommand("SELECT        " + row.TableName + ".* FROM      " + row.TableName + "", _myConnection);
            _myDataAdapter.Fill(_myDataSet, row.TableName);
        }

        /// <summary>
        /// Обновление в БД цены, по которой продается телефон
        /// </summary>
        /// <param name="row"></param>
        /// <param name="newPrice"></param>
        public static void UpdateSalePrice(ColumnsDictionary row, double newPrice)
        {
            //Рачет нового значения поля наценки
            double workCost = (row.ContainsKey("WorkCost"))?SQLiteDataConverter.ToDouble(row["WorkCost"]):0;
            var margin = newPrice - (SQLiteDataConverter.ToDouble(row["Cost"]) + workCost);

            var newRow = SQLiteDataConverter.DictionaryToSQLiteFormat(row);
            newRow["SalePrice"] = newPrice.ToString();
            newRow["Margin"] = margin.ToString();
            UpdateRow(newRow);
            GetTable(row.TableName);
        }

        public static void VerifyDatabase()
        {
            VerifyColumn(TableNames.Sold, "Rollbacked", "bit");
            VerifyColumn(TableNames.Sold, "ReasonOfBack", "varchar(256)");
        }

        private static void VerifyColumn(string tableName, string columnName, string columnType)
        { 
                var command = "SELECT        " + tableName + ".* FROM  " + tableName;
                _myDataAdapter.SelectCommand = new SQLiteCommand(command, _myConnection);
                _myDataAdapter.Fill(_myDataSet, tableName);

                var datatable = _myDataSet.Tables[tableName];
                if (!datatable.Columns.Contains(columnName))
                    new SQLiteCommand("ALTER TABLE " + tableName + " ADD " + columnName + " " + columnType, _myConnection).ExecuteNonQuery();
                datatable.Clear();
        }

        //static void message(string message)
        //{
        //  System.Windows.Forms.MessageBox.Show(message);

        //}
    }
}
