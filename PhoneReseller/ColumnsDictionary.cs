using System;
using System.Collections.Generic;

namespace LicenseGenerator
{
    public class ColumnsDictionary: Dictionary<string,string>,ICloneable
    {
        public bool IsRow { get; set; }
        public string TableName;
        public bool RoollBacked { get; set; }
        public ColumnsDictionary(string tableName)
        {
            TableName = tableName;
        }
        public void Set(string key, string value)
        {
          if (ContainsKey(key)) this[key] = value;
          else Add(key, value);
        }

        public object Clone()
        {
          var result = new ColumnsDictionary(TableName){IsRow = IsRow,RoollBacked = RoollBacked};
          foreach (var item in Keys)
            result.Add(item,this[item]);
          return result;
        }

        public ColumnsDictionary CloneTyped()
        {
          return (ColumnsDictionary)Clone();
        }

        public string getOrNull(string key)
        {
            if (ContainsKey(key))
                return this[key];
            else return null;
        }

    }
}
