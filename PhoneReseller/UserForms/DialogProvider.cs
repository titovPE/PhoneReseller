using System;
using System.Collections.Generic;

namespace PhoneReseller.UserForms
{
    /// <summary>
    /// Поставщик форм диалогов. Что то ввроде контейнера зависимостей на минималках
    /// </summary>
    public static class DialogProvider
    {
      static Dictionary<string, IReshower> _dicht;
        public static void Inicialize ()
        {
          _dicht = new Dictionary<string, IReshower>
          {//todo переделать, что бы формы сами выдавали свои имена и это определялось в IReshower
            {"Rec",new BuyPhone()},
            {"ToSell", new ToSell()},
            {"Sold", new SellPhone()},
            {"NotBuy", new NotBuy()},
            {"ReturnPhone", new ReturnPhone()},
            {"PriceUp", new PriceUp()},
          };
        }

        public static IReshower GetForm(string formNaame)
        {
          return _dicht[formNaame];
        }
        public static double TextToDouble(string text)
        {
          if (text == "-" || text == "") text = "0";
          if (text[0] == ',') text = "0" + text;
          return Convert.ToDouble(text);
        }
    }
}
