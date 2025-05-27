using System.Data;

namespace PhoneReseller
{
  public static  class DataRowExstesion
  {
    public static ColumnsDictionary ToDictionary(this DataRow row)
    {
      return SQLiteDataConverter.RowToDictionary(row);
    }

  }
}
