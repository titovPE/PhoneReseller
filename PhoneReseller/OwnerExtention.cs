using PhoneReseller.Domain;


namespace PhoneReseller
{
  static class OwnerExtention
  {
    public static ColumnsDictionary ToDictionary(this PhoneOwner owner, string tableName)
    {
      if (owner == null) return null;
      var result = new ColumnsDictionary(tableName);
      result["Addres"] = owner.Addres;
      result["FIO"] = owner.FIO;
      result["PasportIssuedBy"] = owner.PasportIssuedBy;
      result["PasportNum"] = owner.PasportNum;
      result["PasportSer"] = owner.PasportSer;
      return result;
    }

    public static PhoneOwner Extract(this PhoneOwner owner, ColumnsDictionary phone)
    {
      owner.Addres = phone["Addres"];
      owner.FIO = phone["FIO"];
      owner.PasportIssuedBy =phone.ContainsKey("PasportIssuedBy")? phone["PasportIssuedBy"]:"";
      owner.PasportNum = phone.ContainsKey("PasportNum") ? phone["PasportNum"] : "";
      owner.PasportSer = phone.ContainsKey("PasportSer") ? phone["PasportSer"] : "";
      return owner;
    }
  }
}
