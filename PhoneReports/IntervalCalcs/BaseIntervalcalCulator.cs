using System.Collections.Generic;

namespace PhoneReports.IntervalCalcs
{
    abstract class BaseIntervalcalCulator<T>
    {
        protected abstract object GetStepSize (T start, T end, double stepCount);
        protected abstract T AddStep(T x, object step);
        
        public abstract bool Above(T v1, T v2);

        public IEnumerable<T> GetIntervals(double intervalsCount, T start, T end)
        {
            var stepSize = GetStepSize(start, end, intervalsCount);
            var l = new List<T> { start };
            for (int i = 0; i < 10; i++)
            {
                start = AddStep(start, stepSize);
                l.Add(start);
            }
            return l;
        }
    }
}
