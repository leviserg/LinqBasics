using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public static class CustomersCollection
    {

        public static List<Customer> customers = new List<Customer> {
            new Customer(1, "GA", "John", "Alford", 28, 930.00, new string[] { "Panel 625", "Panel 200" }),
            new Customer(2, "AR", "Jack", "Brock", 32, 2100.00, new string[] { "12V Li" }),
            new Customer(3, "MI", "Nick", "Gill", 34, 585.80, new string[] { "Bulb 23W", "Panel 625" }),
            new Customer(4, "GA", "John", "Howell", 36, 512.00, new string[] { "Panel 200", "Panel 180" }),
            new Customer(5, "OR", "Jack", "Jenkins", 38, 2267.80, new string[] { "Bulb 23W", "12V Li", "Panel 180" }),
            new Customer(6, "GA", "Nick", "Ratliff", 40, 1034.00, new string[] { "Panel 625" }),
            new Customer(7, "OR", "Mike", "Bartlett", 42, 2105.00, new string[] { "12V Li", "AA NiMH" }),
            new Customer(8, "MI", "Mike", "Faulkner", 44, 167.80, new string[] { "Bulb 23W", "Panel 180" }),
            new Customer(9, "GA", "Sally", "Malone", 46, 512.00, new string[] { "Panel 180", "Panel 200" }),
            new Customer(10, "OR", "Hadley", "Sosa", 48, 590.20, new string[] { "Panel 625", "Bulb 23W", "Bulb 9W" }),
            new Customer(11, "OR", "Nash", "Vasquez", 50, 10.20, new string[] { "Bulb 23W", "Bulb 9W" }),
            new Customer(12, "WA", "Joshua", "Delaney", 52, 350.00, new string[] { "Panel 200" }),
        };

    }
}
