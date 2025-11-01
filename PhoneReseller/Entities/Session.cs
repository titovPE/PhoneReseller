using LicenseGenerator.Data;
using PhoneReseller.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhoneReseller.Entities
{
    /** 
     * Торговая сессия, в интерфейсе "Сверка" время в течение котрого 
     * все телефоны будут сгруппированы как купленныее в один день 
     */
    internal class Session
    {
        /** Фактическая даты сессии. Тоесть дата в которую будет выполнена основная масса операций */
        public DateTime date;
        /** когда была открыта сессия, тоесть когда операции начали сыпаться в неё */
        public DateTime startedAt;

        public static bool IsEnabled()
        {
            return DataProvider.CheckTableAvailability(TableNames.Sessions);
        }

        public static Session openWithDialog(DateTime currentSessionDate)
        {
            if (currentSessionDate > DateTime.Now)
            {
                MessageBox.Show(SessionMessages.SessionAlreadyOpen);
                return null;
            }

            if (
                MessageBox.Show(SessionMessages.SeccionOpenConfirmation, SessionMessages.SeessionConfirmationHeader, MessageBoxButtons.OKCancel)
                == DialogResult.Cancel
               )
            {
                return null;
            }
            var result = Session.OpenNew();
            if (result == null)
            {
                MessageBox.Show(SessionMessages.SessionOpenError);
            }
            return result;
        }

        /** Открыть новую сессиию на правильный день, если это возможно*/
        public static Session OpenNew() {     
            var repository = new SessionRepository();
            var now = DateTime.Now.Date;
            var lastDate = repository.getLastDate();
            if(lastDate > now) 
                return null; // если сессия уже открыта, то не открываем новую
            //если нет сегодняшней сессии, то открываем её на сегодня, иначе на следующий день
            var stsionDatte = lastDate<now ? now : lastDate.AddDays(1);

            var result =  new Session
            {
                date = stsionDatte,
                startedAt = DateTime.Now
            };
            repository.Add(result);
            return result;
        }
    }

    static class SessionMessages { 
        public const string SessionAlreadyOpen = "Серка за сегодня уже есть, пока сдеелать новую нельзя";
        public const string SessionOpenError = "Не удаось создать новую свееку, возможно, она уже есть";
        public const string SessionEnabledInfo = "Свеки успешно включены и будут автоматически записываться.";
        public const string SeccionOpenConfirmation = "Дневной отчет делается только 1 раз в сутки. После его создания все операции с телефонами будут выполнятся в рамках следующего оттчета. Его можно будет создать Завтра. " +
            "\n\nПродолжить создание отчета?";
        public const string SeessionConfirmationHeader = "Создание дневного отчета";
    }



}
