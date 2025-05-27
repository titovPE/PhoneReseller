using System;

namespace PhoneReports.IntervalCalcs
{
    class DateCalculator:BaseIntervalcalCulator<DateTime>
    {
        protected override object GetStepSize(DateTime start, DateTime end, double stepCount)
        {
            var result = ((end - start).Ticks) / stepCount;
            return new TimeSpan((long)result);
        }

        protected override DateTime AddStep(DateTime x, object step)
        {
            return x + (TimeSpan)step;
        }

        public override bool Above(DateTime v1, DateTime v2)
        {
            return (v1 > v2);
        }
    }
}
