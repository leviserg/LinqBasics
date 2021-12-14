using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public static class CustomersCollection
    {

        public static List<Customer> Customers = new List<Customer> {
            new Customer(1, "GA", "Cailin", "Alford", 28, 930.00, new string[] { "Panel 625", "Panel 200" }),
            new Customer(2, "AR", "Theodore", "Brock", 32, 2100.00, new string[] { "12V Li" }),
            new Customer(3, "MI", "Jerry", "Gill", 34, 585.80, new string[] { "Bulb 23W", "Panel 625" }),
            new Customer(4, "GA", "Owens", "Howell", 36, 512.00, new string[] { "Panel 200", "Panel 180" }),
            new Customer(5, "OR", "Adena", "Jenkins", 38, 2267.80, new string[] { "Bulb 23W", "12V Li", "Panel 180" }),
            new Customer(6, "GA", "Medge", "Ratliff", 40, 1034.00, new string[] { "Panel 625" }),
            new Customer(7, "OR", "Sydney", "Bartlett", 42, 2105.00, new string[] { "12V Li", "AA NiMH" }),
            new Customer(8, "MI", "Malik", "Faulkner", 44, 167.80, new string[] { "Bulb 23W", "Panel 180" }),
            new Customer(9, "GA", "Serena", "Malone", 46, 512.00, new string[] { "Panel 180", "Panel 200" }),
            new Customer(10, "OR", "Hadley", "Sosa", 48, 590.20, new string[] { "Panel 625", "Bulb 23W", "Bulb 9W" }),
            new Customer(11, "OR", "Nash", "Vasquez", 50, 10.20, new string[] { "Bulb 23W", "Bulb 9W" }),
            new Customer(12, "WA", "Joshua", "Delaney", 52, 350.00, new string[] { "Panel 200" }),
        };

    }
}
