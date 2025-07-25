using PhoneReseller.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneReseller.Entities
{
    /** 
     * Торговая сессия, в интерфейсе "Касса" время в течение котрого 
     * все телефоны будут сгруппированы как купленныее в один день 
     */
    internal class Session
    {
        /** Фактическая даты сессии. Тоесть дата в которую будет выполнена основная масса операций */
        public DateTime date;
        /** когда была открыта сессия, тоесть когда операции начали сыпаться в неё */
        public DateTime startedAt;

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
}
