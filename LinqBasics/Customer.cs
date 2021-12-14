using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class Customer
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Price { get; set; }
        public string[] Purchases { get; set; }

        public Customer(int _Id, string _State, string _FirstName, string _LastName, int _Age, double _Price, string[] _Purchases)
        {
            Id = _Id;
            State = _State;
            FirstName = _FirstName;
            LastName = _LastName;
            Age = _Age;
            Price = _Price;
            Purchases = _Purchases;
        }
    }
}
