using System.Data;

namespace LicenseGenerator.Data
{
  public static  class DataRowExstesion
  {
    public static ColumnsDictionary ToDictionary(this DataRow row)
    {
      return SQLiteDataConverter.RowToDictionary(row);
    }

  }
}
