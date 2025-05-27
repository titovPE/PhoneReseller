using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneReports.IntervalCalcs;

namespace PhoneReports
{
    class DoubleChartTamplate<T, src> : IChartTemplate<T,src>
    {
        object _srcCollection;
        public IEnumerable<T> Intervals { get; private set; }
        T _first;
        IEnumerable<DoubleBar<T>> Bars;
        readonly BaseIntervalcalCulator<T> _calc;
        Func<src, T> _baseSelector;

        public DoubleChartTamplate(IEnumerable<T> intervals, BaseIntervalcalCulator<T> calc)
        {
            Intervals.Select(x => new DoubleBar<T> {Marker = x,Value = 0 });
            _calc = calc;
        }

        public void BindCollection(IEnumerable<src> collection, Func<src, T> selector)
        {
            _srcCollection = collection;
            _baseSelector = selector;
        }

        public IChart<T> CreateChart(Func<src, double> valueSelector, Func<double, double, double> agregate, string name)
        {
           
            foreach (src item in (IEnumerable<src>)_srcCollection)
            {
                var cBase = _baseSelector(item);
                if (_calc.Above(Intervals.First(), cBase) || _calc.Above(cBase, Intervals.Last())) continue;
                foreach (var bar in Bars)
                {
                    bar.Value = agregate(bar.Value, valueSelector(item));
                    bar.BarHeader = name;
                }
            }
            return new BarChart<T>(Bars);
        }

        public void ChangeIntervalsCount(double count)
        {
            Intervals = _calc.GetIntervals(count, Intervals.First(), Intervals.Last());
        }        
    }
}
