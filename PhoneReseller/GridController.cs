using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using LicenseGenerator.Data;

namespace LicenseGenerator
{
    class GridController
    {
        static readonly Dictionary<string, string> _recColumns = new Dictionary<string, string>
        {
                //{"Addres",""},
                {"BuyDate","Дата покупки"},
                {"FIO","ФИО"},
                //{"PasportSer",""},
                //{"PasportNum",""},
                //{"PasportIssuedBy",""},
                {"Cost", "Цена покупки"},
                {"Imei", "IMEI"},
                {"Model","Модель"},
                //{"AkbNumber",""},
                //{"AkbState",""},
                // {"BaseDefect",""},
                //{"State",""},
                //{"ComplectSet",""},
                //{"Notes",""},
                {"Num","№"}
               // {"Acceptor",""}
        };
        static readonly Dictionary<string, string> _toSellColumns = new Dictionary<string, string>
        {
                //{"Addres",""},
                //{"BuyDate","Дата покупки"},
                {"FIO","ФИО"},
                //{"PasportSer",""},
                //{"PasportNum",""},
                //{"PasportIssuedBy",""},
                //{"Cost", "цена"},
                {"Imei", "IMEI"},
                {"Model","Модель"},
                //{"AkbNumber",""},
                //{"AkbState",""},
                // {"BaseDefect",""},
                //{"State",""},
                //{"ComplectSet",""},
                //{"Notes",""},
                // {"Acceptor",""},            phone.Add("Worker",_stc(Worker.Text));
                {"DateApprowed","Проверен"},
                //{"DetectDefects",""},
                {"IsRepared","Ремонт"},
                //{"WorkCost",""},
                //{"WorkReport",""},
                //{"Margin",""},
                {"SalePrice","Цена продажи"},
                {"Num","№"}
                //{("Price",""}
        };
        static readonly Dictionary<string, string> _soldColumns = new Dictionary<string, string>
        {
                //{"Addres",""},
                //{"BuyDate","Дата покупки"},
                //{"FIO","ФИО"},
                //{"PasportSer",""},
                //{"PasportNum",""},
                //{"PasportIssuedBy",""},
                //{"Cost", "цена"},
                {"Imei", "IMEI"},
                {"Model","Модель"},
                //{"AkbNumber",""},
                //{"AkbState",""},
                // {"BaseDefect",""},
                //{"State",""},
                //{"ComplectSet",""},
                //{"Notes",""},
                // {"Acceptor",""},            phone.Add("Worker",_stc(Worker.Text));
                //{"DateApprowed","проверен"},
                //{"DetectDefects",""},
                //{"IsRepared","Ремонт"},
                //{"WorkCost",""},
                //{"WorkReport",""},
                //{"Margin",""},
                {"SalePrice","Цена продажи"},
                {"Num","№"},
                //{("Price",""},
                {"SellDate","Продан"},
                {"Seller","Продавец" },
        };
        static readonly Dictionary<string, string> _workersColumns = new Dictionary<string, string>
        {
            {"Name","Имя"}
        };
        static readonly Dictionary<string, string> _clientsColumns = new Dictionary<string, string>
        {
            {"Addres","Адрес"},
            {"FIO","ФИО"},
            {"PasportSer","Пасп сер"},
            {"PasportNum","Пасп №"},
            {"PasportIssuedBy","Кем выдан"},
        };

        static readonly Dictionary<string, Dictionary<string, string>> _generalDictionary = new Dictionary<string, Dictionary<string, string>>
        {
            {"Rec",_recColumns},
            {"ToSell",_toSellColumns},
            {"Sold",_soldColumns},
            {"Workers",_workersColumns},
            {TableNames.Clients,_clientsColumns}
        };

        public static void FillColumns(DataGridView grid)
        {
            var dictionary = _generalDictionary[((DataTable)grid.DataSource).TableName];
            for (var i = 0; i < grid.Columns.Count; i++ )
            {
                var item = grid.Columns[i];
                if (dictionary.ContainsKey(item.Name)) 
                    item.HeaderText = dictionary[item.Name];
                else
                    item.Visible = false;
            }
        }

        public static void FillColumns(DataGridView grid, string tableName)
        {
            var dictionary = _generalDictionary[tableName];
            for (var i = 0; i < grid.Columns.Count; i++)
            {
                var item = grid.Columns[i];
                if (dictionary.ContainsKey(item.Name))
                    item.HeaderText = dictionary[item.Name];
                else
                    item.Visible = false;
            }
        }

    }
}
