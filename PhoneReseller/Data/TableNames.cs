using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicenseGenerator.Data
{
    internal class TableNames
    {
        //эта таблица не используется, 
        public static string Clients = "Clients";
        public static string Vars = "GlobalVariables";
        //Таблица для хранения лога действий пользователя
        public static string Actions = "Actions";
        //* Таблица истории Сверок */
        public static string Sessions = "Sessions";
    }
}
