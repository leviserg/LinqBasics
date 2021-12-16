using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class Distributor
    {
        public string Name { get; set; }
        public string State { get; set; }

        public Distributor(string _Name, string _State)
        {
            Name = _Name;
            State = _State;
        }
    }
}
