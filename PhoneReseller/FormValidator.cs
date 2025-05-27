using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhoneReseller
{
    static class FormValidator
    {
        public static bool Validated;
        public static string FailedFields;
        public static void SetTrue ()
        {
            Validated = true;
            FailedFields = "";
        }
        static readonly Dictionary<string, string> _localization = new Dictionary<string, string> 
        {
           {"Addres","Адрес"             },
           {"FIO","Фамилия, Имя, Отчество"               },
           {"PasportSer","ПаспортСерия"      },
           {"PasportNum","ПаспортНомер"      },
           {"PasportIssuedBy","ПаспортВыдан"      },
           {"Cost","Цена покупки"         },
           {"BuyDate","ДатаПокупки"       },
           {"Imei","IMEI"              },
           {"Model","Модель"    },
           {"AkbNumber","№ АКБ"          },
           {"AkbState","АКБсостояние"      },
           {"BaseDefect","ВыявленныеДеффекты"},
           {"State","Состояние"         },
           {"ComplectSet","Комплектность"     },
           {"Notes","Примечания"        },
           {"Acceptor","Принял"            },

           {"Worker","ПеревелНаПродажу"  },
           {"DateApprowed","ДатаПроверки"      },
           {"DetectDefects","НайденныеДеффекты" },
           {"IsRepared","Ремонтировался"    },
           {"WorkCost","СтоимостьРемонта"  },
           {"WorkReport","ОтчетПоРемонту"    },
           {"Margin","Наценка"           },

           {"SellDate","ДатаПродажи"       },
           {"Seller","Продавец"          },
           {"SalePrice","Цена"              },
           {"ПокупкаТелефона","Rec"               },
           {"Ценник","ToSell"            },
           {"ПродажаТелефона","Sold"              },
           {"ReasonOfBack","Причина возврата"}

            
        };


        public static void RecordingOnyMoney(object sender, KeyPressEventArgs e)
        {
            var zptCount = ((TextBox) sender).Text.Count(item => item == ',');
            if (e.KeyChar == '.') e.KeyChar = ',';
            var c = e.KeyChar;
            //MessageBox.Show(((int)c).ToString());
            if (((c < 48) || (c > 57)) && c != 44 && c != 8) e.KeyChar = '\0';
            if (c == ',') zptCount++;
            if (zptCount > 1) { e.KeyChar = '\0'; Console.Beep(); }
        }
        public static void RecordingOnyNumeric(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (((c < 48) || (c > 57)) && c != 8) e.KeyChar = '\0';
        }


        public static void ValidateForMaxOrEmpty(object sender, EventArgs e)
        {
            if (!Validated) return;
            if (!(sender is TextBox)) return;
            var item = (TextBox)sender;
            Validated = item.Text.Length == item.MaxLength || item.Text.TrimStart(' ') == "";
            if (!Validated) FailedFields += _localization[ ((TextBox)sender).Name];
        }
        public static void ValidateForNotEmpty(object sender, EventArgs e)
        {
            if (!Validated) return;
            if (!(sender is TextBox)) return;
            var item = (TextBox)sender;
            Validated = item.Text.TrimStart(' ') != "";
            if (!Validated) FailedFields += _localization[((TextBox)sender).Name];
        }


    }
}
