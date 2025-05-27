using System.Data;
using System.Data.SQLite;

namespace PhoneReseller
{
  class LoadOldData
  {
    static DataSet1 _myDataSet;

    public LoadOldData()
    {
      var dialog = new System.Windows.Forms.OpenFileDialog();
      if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
      System.Windows.Forms.MessageBox.Show(dialog.FileName);
      LoadFile(dialog.FileName);
      FillMyDB();
    }

    private void LoadFile(string dataPath)
    {
      var myConnection = new SQLiteConnection("data source= " + dataPath);
      myConnection.Open();
      _myDataSet = new DataSet1();
      var myDataAdapter = new SQLiteDataAdapter($"SELECT        {TableNames.Vars}.*FROM      {TableNames.Vars}", myConnection);
      myDataAdapter.Fill(_myDataSet, TableNames.Vars);

      myDataAdapter.SelectCommand = new SQLiteCommand("SELECT        Rec.*FROM      Rec", myConnection);
      myDataAdapter.Fill(_myDataSet, "Rec");

      myDataAdapter.SelectCommand = new SQLiteCommand("SELECT        Sold.*FROM      Sold", myConnection);
      myDataAdapter.Fill(_myDataSet, "Sold");

      myDataAdapter.SelectCommand = new SQLiteCommand("SELECT        ToSell.*FROM      ToSell", myConnection);
      myDataAdapter.Fill(_myDataSet, "ToSell");

      myDataAdapter.SelectCommand = new SQLiteCommand("SELECT        Workers.*FROM      Workers", myConnection);
      myDataAdapter.Fill(_myDataSet, "Workers");
      myConnection.Close();
    }

    public void FillMyDB()
    {
      foreach (DataTable table in _myDataSet.Tables)
      {
        DataProvider.ClearTable(table.TableName);
        foreach (DataRow row in table.Rows)
        {
          var phone = SQLiteDataConverter.RowToDictionary(row);
          DataProvider.AddRow(phone);
        }
      }
    }
  }
}
