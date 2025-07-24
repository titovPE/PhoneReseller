using System;
using System.Data;
using LicenseGenerator.domain;

namespace LicenseGenerator.Generators
{
    public static class SoldGenerator
    {
        public static Phone CreatePhone(DataRow row)
        {
            var result = new Phone();
                             //{
            result.Addres = row["Addres"].ToString();
            result.FIO = row["FIO"].ToString();
            result.PSer = row["PasportSer"].ToString();
            result.PNum = row["PasportNum"].ToString();
            result.PIssuedBy = row["PasportIssuedBy"].ToString();
            result.SalePrice = (decimal) row["SalePrice"];
            result.Imei = row["Imei"].ToString();
            result.Model = row["Model"].ToString();
            result.AKBNumber = row["AkbNumber"].ToString();
            result.AKBState = row["AkbState"].ToString();
            result.BaseDeffect = row["BaseDefect"].ToString();
            result.State = row["State"].ToString();
            result.ComplectSet = row["ComplectSet"].ToString();
            result.Notes = row["Notes"].ToString();
            result.Seller = row["Seller"].ToString();
            result.Num = (decimal) row["Num"];
            result.SellDate = (DateTime) row["SellDate"];
            result.Margin = (decimal) row["Margin"];
                             //};
            return result;
        }
    }
}
