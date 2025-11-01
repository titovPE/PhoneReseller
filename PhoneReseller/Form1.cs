using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using LicenseGenerator.UserForms;
using System.Globalization;
using LicenseGenerator.Data;
using PhoneReseller.UserForms;
using PhoneReseller.Data;
using PhoneReseller.Entities;

namespace LicenseGenerator
{
    public partial class Form1 : Form
    {
        private const string version = "13.0.0";

        private const string Key =
            "<RSAKeyValue>" + "<Modulus>" +
            "kjndJ2lmTurT63Jp+bqKQPWY1AJS9eFJrc3NAtBZ74v0AhR5VzuO8tsIW8LxQ0Emu/Ntz6r7g7NLpzsQQpzdP2fDft0gCiSGzeks2Ig8nr/N1cInhM95rc2v1hWuzX55miFn38xXaFCVO9lrj6iuyXGqxt+VIBFD6y2tKgbBhBc=" +
            "</Modulus>" + "<Exponent>" + "AQAB" + "</Exponent>" + "</RSAKeyValue>";

        private int _lastPage;
        private bool IsAutocompleteEnabled = true;
        private bool IsSessionEnabled = false;

        /** Флаг показывает что было нажато первое сочетание клавиш для показа примечаний */
        private bool IsPrevousKeyRight = false;

        private Config config = Config.GetInstance();
        private DateTime currentSessionDate = DateTime.MinValue;

        public Form1()
        {
            if (!VerifyMotherBoard()) Close();
            InitializeComponent();
            Text = Text + " v "+version;
            DataProvider.Inicialize(config.DbPath);
            DialogProvider.Inicialize();
            IsSessionEnabled = Session.IsEnabled();
            timer1.Enabled = IsSessionEnabled;
            if (IsSessionEnabled)
                currentSessionDate = new SessionRepository().getLastDate();
        }

        private bool VerifyMotherBoard()
        {
            var path = Application.StartupPath + "\\key.xml";
            var cpuidString = CpuId();
            if (cpuidString.Trim(' ') == "")
            {
                MessageBox.Show("не удалось получить идентификатор процессора");
                return false;
            }
            var data = Encoding.UTF8.GetBytes(cpuidString);
            var ezp = (byte[])new XmlSerializer(typeof(byte[])).Deserialize(new StreamReader(path));
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(Key);
            var result = rsa.VerifyData(data, CryptoConfig.MapNameToOID("SHA1"), ezp);
            return result;
        }

        private string CpuId()
        {
            //var mbInfo = String.Empty;
            //var scope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
            //scope.Connect();
            //var wmiClass = new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""),
            //                                    new ObjectGetOptions());
            //var t = wmiClass.Properties.Cast<PropertyData>().ToList();
            //var tmp = new List<string>();
            //new KeySelector().AddHddPropertyToList(tmp);
            //foreach (var propData in wmiClass.Properties)
            //{
            //    if (propData.Name != "SerialNumber") continue;
            //    mbInfo = Convert.ToString(propData.Value);
            //    break;
            //}


            string cpuInfo = string.Empty;
            string temp = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == string.Empty)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
            }
            return cpuInfo;

        }

        public void InitializeTabControl()
        {
            dataGridView0.DataSource = DataProvider.GetTable("Rec");
            GridController.FillColumns(dataGridView0);
            dataGridView0.Columns["Num"].Width = 40;

            dataGridView1.DataSource = DataProvider.GetTable("ToSell");
            GridController.FillColumns(dataGridView1);
            dataGridView1.Columns["isRepared"].Width = 50;
            dataGridView1.Columns["Num"].Width = 40;
            dataGridView1.Columns["SalePrice"].Width = 60;
            dataGridView1.Columns["DateApprowed"].Width = 70;


            dataGridView2.DataSource = DataProvider.GetTable(TableNames.Sold);
            GridController.FillColumns(dataGridView2);
            dataGridView2.Columns["Num"].Width = 40;

            WorkersGrid.DataSource = DataProvider.GetTable("Workers");
            GridController.FillColumns(WorkersGrid);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTabControl();
        }

        private void tabControl1_Deselected(object sender, TabControlEventArgs e)
        {
            _lastPage = tabControl1.SelectedIndex;
        }


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            var index = tabControl1.SelectedIndex;
            switch (index)
            {
                case 2:
                    Select2Page();
                    break;
            }
        }

        public void Select2Page()
        {
            admin_Panel.Visible = Autentification();
            //tabControl1.SelectedIndex = LastPage;
        }

        public bool Autentification()
        {
            var pass = new PasswordInput().ShowMe();
            return (pass == DataProvider.GetAdminPass());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogService.CreatePhone("Rec", null, true);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogService.CreatePhone("NotBuy", null, false);
        }

        /// <summary>
        /// Перевод телефона из купленных в "На продажу"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridView0);
            if (row == null) return;
            DialogService.Transaction("ToSell", row.ToDictionary());
        }

        /// <summary>
        /// Эта кнопка не видимая, метод не используется.
        /// Изначальное предназначение - открыть форму управления сохренненными клиентами
        /// Заменен в пользу метода заполнения на форме покупки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click_1(object sender, EventArgs e)
        {
            const string tableName = "Rec";
            var owner = Cache.GetSingle<Domain.PhoneOwner>().ToDictionary(tableName);
            DialogService.CreatePhone(tableName, owner, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridView1);
            DialogService.Transaction(TableNames.Sold, row.ToDictionary());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new ChangePass().ShowMe();
        }

        /// <summary>
        /// Получить выделенную строку таблицы
        /// </summary>
        /// <param name="grid">таьлицы</param>
        /// <returns></returns>
        private DataRow GetSelectedRow(DataGridView grid)
        {
            if (grid.SelectedRows.Count < 1) return null;
            if (grid.SelectedRows[0].Index < 0) return null;
            var current = grid.BindingContext[grid.DataSource].Current;
            return ((DataRowView)current).Row;
        }

        /// <summary>
        /// Отображение онформации о телефоне на странице купленных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridView0);
            if (row == null) return;

            var dictionary = SQLiteDataConverter.RowToDictionary(row);
            RecAddres.Text = dictionary.getOrNull("Addres") ?? "";
            RecFIO.Text = dictionary.getOrNull("FIO") ?? "";
            RecPasportSer.Text = dictionary.getOrNull("PasportSer") ?? "";
            RecPasportNum.Text = dictionary.getOrNull("PasportNum") ?? "";
            RecPasportIssuedBy.Text = dictionary.getOrNull("PasportIssuedBy") ?? "";
            RecCost.Text = dictionary.getOrNull("Cost") ?? "";
            RecImei.Text = dictionary.getOrNull("Imei") ?? "";
            RecModel.Text = dictionary.getOrNull("Model") ?? "";
            RecAkbNumber.Text = dictionary.getOrNull("AkbNumber") ?? "";
            RecAkbState.Text = dictionary.getOrNull("AkbState") ?? "";
            RecBaseDefect.Text = dictionary.getOrNull("BaseDefect") ?? "";
            RecState.Text = dictionary.getOrNull("State") ?? "";
            RecComplectSet.Text = dictionary.getOrNull("ComplectSet") ?? "";
            RecNotes.Text = dictionary.getOrNull("Notes") ?? "";
        }

        private void printPurchaseContract(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridView0);
            if (row == null) return;
            new DocPrinter(SQLiteDataConverter.RowToDictionary(row));
        }

        /// <summary>
        /// Отображение информации от телефоне на странице "На продажу"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridView1);
            if (row == null) return;

            var dictionary = SQLiteDataConverter.RowToDictionary(row);
            RollBack.Enabled = (dictionary.getOrNull("Rollbacked") ?? "") != "True";
            TSAddres.Text = dictionary.getOrNull("Addres") ?? "";
            TSFIO.Text = dictionary.getOrNull("FIO") ?? "";
            TSPasportSer.Text = dictionary.getOrNull("PasportSer") ?? "";
            TSPasportNum.Text = dictionary.getOrNull("PasportNum") ?? "";
            TSPasportIssuedBy.Text = dictionary.getOrNull("PasportIssuedBy") ?? "";
            TSCost.Text = dictionary.getOrNull("Cost") ?? "";
            TSImei.Text = dictionary.getOrNull("Imei") ?? "";
            TSModel.Text = dictionary.getOrNull("Model") ?? "";
            TSAkbNumber.Text = dictionary.getOrNull("AkbNumber") ?? "";
            TSAkbState.Text = dictionary.getOrNull("AkbState") ?? "";
            TSBaseDefect.Text = dictionary.getOrNull("BaseDefect") ?? "";
            TSState.Text = dictionary.getOrNull("State") ?? "";
            TSComplectSet.Text = dictionary.getOrNull("ComplectSet") ?? "";
            TSNotes.Text = dictionary.getOrNull("Notes") ?? "";
            TSPrice.Text = dictionary.getOrNull("SalePrice") ?? "";

            TSDetectDefects.Text = dictionary.getOrNull("DetectDefects") ?? "";
            TSWorkCost.Text = dictionary.getOrNull("WorkCost") ?? "";
            TSWorkReport.Text = dictionary.getOrNull("WorkReport") ?? "";
            TSMargin.Text = dictionary.getOrNull("Margin") ?? "";
            TSPrice.ForeColor = Convert.ToDouble(TSMargin.Text, CultureInfo.InvariantCulture) < 0 ? Color.Red : Color.Black;

            //MessageBox.Show(row.ToString());
        }

        /// <summary>
        /// Отображение информации о телефоне на странице Проданных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            SoldState.ForeColor = Color.Red;
            var row = GetSelectedRow(dataGridView2);
            if (row == null) return;

            var dictionary = SQLiteDataConverter.RowToDictionary(row);
            SAddres.Text = dictionary.getOrNull("Addres") ?? "";
            SFIO.Text = dictionary.getOrNull("FIO") ?? "";
            SPasportSer.Text = dictionary.getOrNull("PasportSer") ?? "";
            SPasportNum.Text = dictionary.getOrNull("PasportNum") ?? "";
            SPasportIssuedBy.Text = dictionary.getOrNull("PasportIssuedBy") ?? "";
            SCost.Text = dictionary.getOrNull("Cost") ?? "";
            SImei.Text = dictionary.getOrNull("Imei") ?? "";
            SModel.Text = dictionary.getOrNull("Model") ?? "";
            SAkbNumber.Text = dictionary.getOrNull("AkbNumber") ?? "";
            SAkbState.Text = dictionary.getOrNull("AkbState") ?? "";
            SBaseDefect.Text = dictionary.getOrNull("BaseDefect") ?? "";
            SState.Text = dictionary.getOrNull("State") ?? "";
            SComplectSet.Text = dictionary.getOrNull("ComplectSet") ?? "";
            SNotes.Text = dictionary.getOrNull("Notes") ?? "";
            SPrice.Text = dictionary.getOrNull("SalePrice") ?? "";
            SDetectDefects.Text = dictionary.getOrNull("DetectDefects") ?? "";
            SWorkCost.Text = dictionary.getOrNull("WorkCost") ?? "";
            SWorkReport.Text = dictionary.getOrNull("WorkReport") ?? "";
            SMargin.Text = dictionary.getOrNull("Margin") ?? "";
            SoldState.Text = (dictionary.getOrNull("SoldState") ?? "") == "Без ремонта" ? "Без ремонта" : "";
            // Дальше пока костыльно берем инфу из кортежа напрямую
            SDateApprowed.Text = ((DateTime)row["DateApprowed"]).ToShortDateString();
            try
            {
                SSellDate.Text = ((DateTime)row["SellDate"]).ToShortDateString();
            }
            catch
            {
                SSellDate.Text = "";
            }
            SBuyDate.Text = row.IsNull("BuyDate") ? "" : ((DateTime)row["BuyDate"]).ToShortDateString();
            SCost2.Text = row["Cost"].ToString();
            SPrice2.Text = row["SalePrice"].ToString();
            StartPrice.Text = row["Price"].ToString();
        }

        /// <summary>
        /// Правый клик мышки отображает лог событий телефона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                var row = GetSelectedRow((DataGridView)sender);
                if (row == null) return;
                var phoneID = SQLiteDataConverter.RowToDictionary(row)["ID"];
                var result = ActionsRepository.ReadLogByPhineId(phoneID);
                MessageBox.Show(result);
            }
        }

        /// <summary>
        /// Клик по кнопке изменения цены продаваемого телефона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (NewPrice.Text == "") return;
            if (!Autentification()) return;
            var row = GetSelectedRow(dataGridView1);
            var phone = SQLiteDataConverter.RowToDictionary(row);
            var index = dataGridView1.SelectedRows[0].Index;
            DataProvider.UpdateSalePrice(phone, Convert.ToDouble(NewPrice.Text));
            dataGridView1.CurrentCell = dataGridView1["IMEI", index];
            MessageBox.Show("Цена изменена", "!");
        }



        private void UpPrice_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridView1);
            var index = dataGridView1.SelectedRows[0].Index;
            DialogService.EditPhone("PriceUp", row.ToDictionary());
            dataGridView1.CurrentCell = dataGridView1["IMEI", index];
        }

        private void RecDeletePhone_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridView0);
            if (row == null) return;
            if (!Autentification()) return;
            var phone = SQLiteDataConverter.RowToDictionary(row);
            DataProvider.DeleteRow(phone);
        }

        private void TSDeletePhone_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridView1);
            if (row == null) return;
            if (!Autentification()) return;
            var phone = SQLiteDataConverter.RowToDictionary(row);
            DataProvider.DeleteRow(phone);
        }

        private void SDeletePhone_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridView2);
            if (row == null) return;
            var phone = SQLiteDataConverter.RowToDictionary(row);
            DataProvider.DeleteRow(phone);
        }


        private void RecordMoneyOnly(object sender, KeyPressEventArgs e)
        {
            FormValidator.RecordingOnyMoney(sender, e);
        }

        private void RecordingOnlyNumeric(object sender, KeyPressEventArgs e)
        {
            FormValidator.RecordingOnyNumeric(sender, e);

        }

        # region filtering
        private void RecImeiFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView0.DataSource).TableName;
            DataProvider.FilteringOn(tName, "Imei", ((TextBox)sender).Text);
        }

        private void RecNumFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView0.DataSource).TableName;
            //DataProvider.FillDataSet(tName, new List<string> { "Num LIKE '" + (sender as TextBox).Text + "%'" });
            DataProvider.FilteringOn(tName, "Num", ((TextBox)sender).Text);
        }

        private void RecModelFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView0.DataSource).TableName;
            DataProvider.FilteringOn(tName, "Model", ((TextBox)sender).Text);
        }

        private void RecFioFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView0.DataSource).TableName;
            DataProvider.FilteringOn(tName, "FIO", ((TextBox)sender).Text);
        }

        private void RecDocNumFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView0.DataSource).TableName;
            var value = ((TextBox)sender).Text;
            if (value.Length == 6 && value[0] == '0')
                DataProvider.FilteringOn(tName, "PasportNum", $"1{value}", value.Substring(1));
            else
                DataProvider.FilteringOn(tName, "PasportNum", ((TextBox)sender).Text);
        }

        private void TSImeiFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView1.DataSource).TableName;
            DataProvider.FilteringOn(tName, "Imei", ((TextBox)sender).Text);
        }

        private void TSNumFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView1.DataSource).TableName;
            DataProvider.FilteringOn(tName, "Num", ((TextBox)sender).Text);
        }

        private void TSModelFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView1.DataSource).TableName;
            DataProvider.FilteringOn(tName, "Model", ((TextBox)sender).Text);
        }

        private void TSFioFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView1.DataSource).TableName;
            DataProvider.FilteringOn(tName, "FIO", ((TextBox)sender).Text);
        }

        private void TSDocNumFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView1.DataSource).TableName;
            DataProvider.FilteringOn(tName, "PasportNum", ((TextBox)sender).Text);
        }

        private void SImeiFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView2.DataSource).TableName;
            DataProvider.FilteringOn(tName, "Imei", ((TextBox)sender).Text);
        }

        private void SNumFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView2.DataSource).TableName;
            DataProvider.FilteringOn(tName, "Num", ((TextBox)sender).Text);
        }

        private void SModelFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView2.DataSource).TableName;
            DataProvider.FilteringOn(tName, "Model", ((TextBox)sender).Text);
        }

        private void SFioFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView2.DataSource).TableName;
            DataProvider.FilteringOn(tName, "FIO", ((TextBox)sender).Text);
        }

        private void SDocNumFiltering(object sender, KeyEventArgs e)
        {
            var tName = ((DataTable)dataGridView2.DataSource).TableName;
            DataProvider.FilteringOn(tName, "PasportNum", ((TextBox)sender).Text);
        }

        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridView1);
            if (row == null) return;
            new DocPrinter(SQLiteDataConverter.RowToDictionary(row));
        }

        private void DeleteWorker(object sender, EventArgs e)
        {
            var row = GetSelectedRow(WorkersGrid);
            if (row == null) return;
            var worker = SQLiteDataConverter.RowToDictionary(row);
            DataProvider.DeleteRow(worker);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NewWorker.Text = NewWorker.Text.TrimStart(' ');
            if (NewWorker.Text == "") return;
            var worker = new ColumnsDictionary("Workers")
                             {
                                 {"Name", SQLiteDataConverter.AdaptStringToSQLite(NewWorker.Text)}
                             };
            DataProvider.AddWorker(worker);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    "все текущие телефоны из базы будут удалены. на их место скопируются телефоны из выбранной вами базы. \n ПРОДОЛЖИТЬ?",
                    "Внимание", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            new LoadOldData();
        }

        /// <summary>
        /// редактирование телефона ио страницы купленных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridView0);
            if (row == null) return;
            if (!Autentification()) return;
            int index = dataGridView0.SelectedRows[0].Index;
            DialogService.EditPhone(row["Addres"].ToString() == "_" ? "NotBuy" : "Rec", row.ToDictionary());
            dataGridView0.CurrentCell = dataGridView0["IMEI", index];
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Хотите сделать откат телефона?", "!!!", MessageBoxButtons.OKCancel) ==
                DialogResult.Cancel) return;
            var row = GetSelectedRow(dataGridView1);
            if (row == null) return;
            var phone = row.ToDictionary();
            phone["Rollbacked"] = true.ToString();
            DataProvider.UpdateRow(phone);
            DataProvider.GetTable("Rec");
        }

        private void Merge_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    "Номера телефонов добавляемой базы будут переписанны в соответствии с текущей базой перед добавлением",
                    "Внимание", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            new MergeDB();
        }

        private void NewPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) button5.PerformClick();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new DayReport().ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            {
                var row = GetSelectedRow(dataGridView2);
                DialogService.ReturnPhone(row.ToDictionary());
            }
        }


        /// <summary>
        /// Архивный метод делался для задачи управления постоянными клиентам, её отменили
        /// </summary>
        private void button17_Click_1(object sender, EventArgs e)
        {
            DataProvider.EnableRegularClients();
        }

        private void EnableClientsAutocomplete(object sender, EventArgs e)
        {
            DataProvider.EnableClientAutocomplete();
            //TODO Сделать ЮИ для подправки кто выдал (всплывающее окошго с полем для редактирования)

        }

        private void getNotes_KeyDown(object sender, KeyEventArgs e)
        {
            var tmp = Control.ModifierKeys;

            if (
                IsPrevousKeyRight
                && (tmp & Keys.Control) == Keys.Control
                && e.KeyCode == Keys.F
                )
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    RecNotes.Visible = true;
                    RecNotes.Focus();
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    TSNotes.Visible = true;
                    TSNotes.Focus();
                }
                if (tabControl1.SelectedIndex == 2)
                {
                    SNotes.Visible = true;
                    SNotes.Focus();
                }
            }

            IsPrevousKeyRight = (tmp & Keys.Control) == Keys.Control && e.KeyCode == Keys.W;
        }

        private void AnyNotes_Leave(object sender, EventArgs e)
        {
            RecNotes.Visible = false;
            TSNotes.Visible = false;
            SNotes.Visible = false;
        }

        private void button17_Click_2(object sender, EventArgs e)
        {
            ActionsRepository.EnableActionsLog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SessionRepository.EnableSessions();
            timer1.Enabled = true;
        }

        private void ToolStripMenuItemOpenSession_Click(object sender, EventArgs e)
        {
            var result = Session.openWithDialog(currentSessionDate);
            if (result != null) currentSessionDate = result.date;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Date <= currentSessionDate)
                return;
            var result = Session.OpenNew();
            if (result != null)
            {
                currentSessionDate = result.date;
                MessageBox.Show("Выполнена сверка за " + currentSessionDate.AddDays(-1).ToShortDateString(), "Выполнена сверка");
            }
        }

        private void SessionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SessionHistory().ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {

            new DayReport().ShowReducedDialog();
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            var result = Session.openWithDialog(currentSessionDate);
            if (result != null) currentSessionDate = result.date;
        }
    }

}
