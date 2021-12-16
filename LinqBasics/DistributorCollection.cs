using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public static class DistributorCollection
    {
        public static List<Distributor> distributors = new List<Distributor>
        {
            new Distributor ("Edgepulse", "UT"),
            new Distributor ("Jabbersphere","GA"),
            new Distributor ("Quaxo","FL"),
            new Distributor ("Yakijo","OR"),
            new Distributor ("Scaboo","GA"),
            new Distributor ("Innojam","WA"),
            new Distributor ("Edgetag","WA"),
            new Distributor ("Leexo","HI"),
            new Distributor ("Abata","OR"),
            new Distributor ("Vidoo","TX")
        };
    }
}
