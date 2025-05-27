using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneReports
{
    public class ChartService
    {
        public IChartTemplate<T, TSrc> GetChartTemplate<T, TSrc>(IEnumerable<TSrc> collection, Func<TSrc, T> selector)
        {
            var calc = IntervalCalculators.GetCalculator<T>();
            T startInterval =selector( collection.First());
            T endInterval = startInterval;
            foreach (var item in collection)
            {
                var val = selector(item);
                if (calc.Above( startInterval, val)) startInterval = val;
                if (calc.Above( val, endInterval)) endInterval = val;
            }
            return new DoubleChartTamplate<T,TSrc>(calc.GetIntervals(10, startInterval, endInterval), calc);
        }
    }    
}
