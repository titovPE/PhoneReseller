using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LicenseGenerator.Data;
using LicenseGenerator.Generators;

namespace LicenseGenerator.UserForms
{
    public partial class DayReport : Form
    {

        private decimal gotMoney = 0;
        public DayReport()
        {
            InitializeComponent();
            PreRender();
        }

        public void PreRender()
        {
            Seller.Items.Clear();
            Seller.Items.AddRange(WorkersGenerator.GetWorkers().ToArray());
            if (Seller.Items.Count > 0) Seller.SelectedIndex = 0;
            LoaadSoldPhones();
        }

        public void ShowReducedDialog()
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            wokerGroup.Visible = true;
            adminGroup.Visible = false;
            var rec = LoadPhones("Rec", "BuyDate","Acceptor").Select(row => (decimal)row["Cost"]);
            var toSell = LoadPhones("ToSell", "BuyDate","Acceptor").Select(row => (decimal)row["Cost"]);
            var sold = LoadPhones(TableNames.Sold, "BuyDate","Acceptor").Select(row => (decimal)row["Cost"]);
            var totalSpent = rec.Sum() + toSell.Sum() + sold.Sum();
            labelGot.Text = gotMoney.ToString();
            labelSpent.Text = totalSpent.ToString();
            labelDifference.Text = (gotMoney - totalSpent).ToString();
            ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoaadSoldPhones();
        }

        private void LoaadSoldPhones()
        {
            var startDate = dateTimePicker1.Value.Date;
            var endDate = dateTimePicker2.Value.Date;
            if (startDate > endDate) return;// MessageBox.Show("конечная дата меньше начальной, отчет не может быть построен");
            domain.Phone[] source = LoadPhones(TableNames.Sold, "SellDate", "Seller").Select(SoldGenerator.CreatePhone).ToArray();
            dataGridView0.DataSource = source;
            var contains = source.Length > 0;
            //Это лейблы для админа
            label2.Text = contains ? source.Sum(x => x.SalePrice).ToString() : "_";
            label4.Text = contains ? source.Sum(x => x.Margin).ToString() : "_";
            //Фактически дубль данных из лейбл2, нужен для отчета прочтого работника
            gotMoney = contains ? source.Sum(x => x.SalePrice) : 0;
            GridController.FillColumns(dataGridView0, TableNames.Sold);
        }

        IEnumerable<DataRow> LoadPhones(string tableName, string dateColumn, string workerColumn)
        {
            return DataProvider.GetTable(tableName).Rows.Cast<DataRow>()
                .Where(x =>
                x[workerColumn].ToString() == Seller.Text
                && ((DateTime)x[dateColumn]).Date >= dateTimePicker1.Value.Date
                && ((DateTime)x[dateColumn]).Date <= dateTimePicker2.Value.Date
                );
        }

    }

}
