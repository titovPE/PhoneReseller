using System.Collections.Generic;

namespace PhoneReports
{
    public interface IChart<T> : IEnumerable<DoubleBar<T>>
    {
        DoubleBar<T> FirstBar();
    }
}
