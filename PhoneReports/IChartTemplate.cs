using System;
using System.Collections.Generic;

namespace PhoneReports
{
    public   interface IChartTemplate<T,TSrc>
    {
        void BindCollection(IEnumerable<TSrc> collection, Func<TSrc, T> selector);
        IChart<T> CreateChart(Func<TSrc, double> valueSelector, Func<double, double, double> agregate, string name);
        void ChangeIntervalsCount(double count);
    }
}
