using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LicenseGenerator.Data;
using LicenseGenerator.Generators;

namespace LicenseGenerator.UserForms
{
    public partial class DayReport : Form
    {
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoaadSoldPhones();
        }

        private void LoaadSoldPhones()
        {
            var startDate = dateTimePicker1.Value.Date;
            var endDate = dateTimePicker2.Value.Date;
            if (startDate > endDate) return;// MessageBox.Show("конечная дата меньше начальной, отчет не может быть построен");
            var source = DataProvider.GetTable("Sold").Rows.Cast<DataRow>()
                .Where(x => x["Seller"].ToString() == Seller.Text && ((DateTime)x["SellDate"]).Date >= startDate && ((DateTime)x["SellDate"]).Date <= endDate)
                .Select(SoldGenerator.CreatePhone).ToArray();
            dataGridView0.DataSource = source;
            var contains = source.Length > 0;
            label2.Text = contains? source.Sum(x => x.SalePrice).ToString():"_";
            label4.Text = contains? source.Sum(x => x.Margin).ToString():"_";
            GridController.FillColumns(dataGridView0,"Sold");
        }
    }
}
