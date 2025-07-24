using LicenseGenerator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace LicenseGenerator.UserForms
{
    public partial class RegularClient : Form
    {
        public RegularClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = new ColumnsDictionary(TableNames.Clients)
              {
                {"Addres",Addres.Text},
                {"FIO",FIO.Text},
                {"PasportIssuedBy",PasportIssuedBy.Text},
                {"PasportSer",PasportSer.Text},
                {"PasportNum",PasportNum.Text}
              };

            //TODO внутри вызваемого метода надо реализовать правильную работу с записью. Комиентарии написал
            DataProvider.CreateRow(result);
        }

        private void RegularClient_Load(object sender, EventArgs e)
        {
            clientGridView.DataSource = DataProvider.GetTable(TableNames.Clients);
            GridController.FillColumns(clientGridView);
        }
    }
}
