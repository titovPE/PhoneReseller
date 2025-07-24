using LicenseGenerator.Data;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LicenseGenerator.Generators
{
    public static class WorkersGenerator
    {
        public static IEnumerable<string> GetWorkers()
        {
            var workers = DataProvider.GetTable("Workers");
            return workers.Rows.Cast<DataRow>().Select(x => x["Name"]).Cast<string>();
        }
    }
}
