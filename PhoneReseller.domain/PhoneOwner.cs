namespace PhoneReseller.Domain
{
    /// <summary>
    /// Информация о человеке, продавшем телефон
    /// </summary>
  public class PhoneOwner
  {
    public string Addres { get; set; }
    public string FIO { get; set; }
    public string PasportIssuedBy { get; set; }
    public string PasportSer { get; set; }
    public string PasportNum { get; set; }
  }
}
