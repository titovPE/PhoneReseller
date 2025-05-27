using System;

namespace PhoneReports.IntervalCalcs
{
    class DoubleCalculator:BaseIntervalcalCulator<double>
    {
        protected override object GetStepSize(double start, double end, double stepCount)
        {
            return (end - start) / stepCount;
        }

        protected override double AddStep(double x, object step)
        {
            return x + (double)step;
        }

        public override bool Above(Double v1, Double v2)
        {
            return v1 > v2;
        }
    }
}
