using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneReports
{
    class BarChart<T> : IChart<T>
    {
        readonly IEnumerable<DoubleBar<T>> _bars; 

        public BarChart(IEnumerable<DoubleBar<T>> bars)
        {
            _bars = bars;
        }

        public DoubleBar<T> FirstBar()
        {
            return _bars.First();
        }

        IEnumerator<DoubleBar<T>> IEnumerable<DoubleBar<T>>.GetEnumerator()
        {
            var result = _bars.GetEnumerator();
            result.MoveNext();
            return result;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return ((IEnumerable<DoubleBar<T>>)this).GetEnumerator();            
        }        
    }   
}
