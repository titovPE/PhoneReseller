using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneReseller.Entities
{
    internal enum ActionType
    {
        undefined = 0, // Неизвестный тип действия, используется для отладки и тестирования
        buyPhone = 1, // Покупка телефона
        editPhone = 2, // Изменение телефона
        setAsNotForSale = 3, // Пометить как не для продажи
        setAsForSale = 4, // Пометить как для продажи
        soldPhone = 5, // Продажа телефона
    }
}
