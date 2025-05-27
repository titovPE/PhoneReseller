using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneReports.IntervalCalcs;

namespace PhoneReports
{
    class IntervalCalculators
    {
        private static Dictionary<Type,object> _calculators;
        public static BaseIntervalcalCulator<T> GetCalculator<T>()
        {
            return (BaseIntervalcalCulator<T>)_calculators[typeof(T)];
        }

    }
}
