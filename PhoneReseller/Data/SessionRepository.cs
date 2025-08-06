using LicenseGenerator.Data;
using PhoneReseller.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhoneReseller.Data
{
    internal class SessionRepository
    {
        public void Add(Session session) { 
        var command = $"INSERT INTO {TableNames.Sessions} (Date, StartedAt) VALUES ('{session.date.ToString("yyyy-MM-dd")}', '{session.startedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            DataProvider.ExecuteNonQuery(command);
        }

        public DateTime getLastDate() {
            var command = $"SELECT Date FROM {TableNames.Sessions} order by Date desc LIMIT 1";
            var result = DataProvider.getRowsByCommand(command);
            if(result.Count ()== 0)
                return DateTime.MinValue; // если нет сессий, то возвращаем минимальную дату    
            return DateTime.Parse(result.First()["Date"].ToString());

        }

        public static void EnableSessions()
        {
            var sessionsTable = TableNames.Sessions;
            if (DataProvider.CheckTableAvailability(sessionsTable))
            {
                MessageBox.Show("Сессии уже включены ранее. Сейчас ничего сделано не будет");
                return;
            }
            var actionsCommand = $"ALTER TABLE {TableNames.Actions} ADD COLUMN Code NVARCHAR(50);" +
                $"ALTER TABLE {TableNames.Actions} ADD COLUMN Amount numeric(18,2);";
            DataProvider.ExecuteNonQuery(actionsCommand);

            var command = $@"CREATE TABLE [{sessionsTable}] (
                              [Date] DATETIME NOT NULL
                            , [StartedAt] DATETIME NOT NULL
                            );
                            CREATE INDEX [Sessions_date_index] ON [{sessionsTable}] ([Date] ASC);";
            DataProvider.ExecuteNonQuery(command);
            MessageBox.Show("Сессии успешно включены и будут автоматически записываться.");
        }
    }
}
