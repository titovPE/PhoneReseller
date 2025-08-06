using LicenseGenerator.Data;
using PhoneReseller.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhoneReseller.Data
{
    internal static class ActionsRepository
    {
        //фича для работы с логом действий пользователя

        public static void EnableActionsLog()
        {
            var actionsTable = TableNames.Actions;
            if (DataProvider.CheckTableAvailability(actionsTable))
            {
                MessageBox.Show("Лог действий уже включен ранее. Сейчас ничего сделано не будет");
                return;
            }
            var command = $@"CREATE TABLE [{actionsTable}] (
                              [PhoneId] numeric(18,0) NOT NULL
                            , [Date] DATETIME NOT NULL
                            , [Action] NVARCHAR(50) NOT NULL COLLATE NOCASE
                            , [Worker] NVARCHAR(50) NOT NULL COLLATE NOCASE
                            );
                            CREATE INDEX [Actions_phone_index] ON [{actionsTable}] ([PhoneId] ASC);";
            DataProvider.ExecuteNonQuery(command);
            MessageBox.Show("Лог действий успешно в ключен и будет автоматически записываться.");
        }

        public static void AddActionLog(string phoneId, string note, string worker, ActionType action,Decimal? amount = null)
        {
            var actionsTable = TableNames.Actions;
            if (!DataProvider.CheckTableAvailability(actionsTable))
            {
                return;
            }
            //Здесь Action и Note перепутаны местами. Перваначальый дизайн подразумевал , что Action - это просто описание действия, а код события отсутствовал
            var command = $"INSERT INTO {actionsTable} (PhoneId, Date, Action, Worker, Code, Amount) " +
                      $"VALUES ({phoneId}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{note}', '{worker}', '{action}', '{amount}')";
            DataProvider.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Загружает лог действий по указанному идентификатору телефона и выводит его в виде строки.
        /// </summary>
        /// <param name="id">Идентификатор телефона</param>
        /// <returns></returns>
        public static string ReadLogByPhineId(string id)
        {
            var actionsTable = TableNames.Actions;
            if (!DataProvider.CheckTableAvailability(actionsTable))
            {
                return "Логирование отключено, показывать нечего";
            }

            var queryString = $"SELECT Date, Action FROM {actionsTable} WHERE PhoneId = {id}";
            var rows = DataProvider.getRowsByCommand(queryString)
                .OrderBy(x => (DateTime)x["Date"])
                .Select(x => $"{x["Date"]}: {x["Action"]}");
            if (rows.Count() == 0)
            {
                return "не записано ни одного действия";
            }
            var result = rows.Aggregate((a, b) => a + "\n " + b);
            return result;
        }
    }
}
