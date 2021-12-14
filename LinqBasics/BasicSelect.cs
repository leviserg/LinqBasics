using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public static class BasicSelect
    {
        public static void printBasicSelect()
        {
            List<Customer> customers = CustomersCollection.Customers;

            Console.WriteLine("======== filtered customers by state ========");
            /*
            IEnumerable<Customer> filteredStateCustomers = from cust in customers // set datasource      ----|
                                                      where cust.State == "GA"    // set query            query preparation, may be executed in diff places with diff set of data due to changing
                                                      select cust;                // set query (contin.) ____|

            foreach (Customer customer in filteredStateCustomers)
            {
                Console.WriteLine($"{customer.State} : {customer.FirstName} {customer.LastName}"); // execute query everytime in foreach loop
            }


            */
            var filteredStateCustomers = CustomersCollection.Customers.Where(x => x.State == "GA").ToList();

            foreach (Customer customer in filteredStateCustomers)
            {
                Console.WriteLine($"{customer.State} : {customer.FirstName} {customer.LastName} {customer.Age} {customer.Price}");
            }

            Console.WriteLine("======== filtered customers by age ========");

            List<Customer> filteredAgeCustomers = customers.Where(x => x.Age > 40).ToList();

            foreach (Customer customer in filteredAgeCustomers)
            {
                Console.WriteLine($"{customer.State} : {customer.FirstName} {customer.LastName} {customer.Age} {customer.Price}");
            }

            Console.WriteLine("======== Transformation ========");
            /*
            var customerPurchases = from c in customers
                                    from p in c.Purchases
                                    where c.State == "OR"
                                    select new { c.FirstName, c.LastName, Purchase = p }; // new data structure
            */
            
            var customerPurchases = customers.
                Where(x => x.State == "OR").
                SelectMany(c => c.Purchases, (c, Purchase) => new { c.FirstName, c.LastName, Purchase });
            
            foreach (var item in customerPurchases)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} : purchase - {item.Purchase}");
            }

            Console.WriteLine("======== ReCalculation ========");
            /*
            var customerEuroPrices = from c in customers
                                    select new { c.FirstName, c.LastName, UsdPrice = c.Price, EuroPrice = c.Price * 0.89 }; // new data structure
            */
            var customerEuroPrices = customers.
            Where(x => x.Age > 40 && x.Price > 1000).
            Select(
                c => new { c.FirstName, c.LastName, FullName = $"{c.FirstName} {c.LastName}" , UsdPrice = c.Price, EuroPrice = (c.Price * 0.89) }
            );

            foreach (var item in customerEuroPrices)
            {
                Console.WriteLine($"{item.FullName} : {item.UsdPrice} USD ; {item.EuroPrice} EURO");
            }


            Console.WriteLine("======== SkipFilter ========");

            var customerFilterSkip = customers.
            Where(x => x.State == "OR").
            AsEnumerable().SkipWhile(c => c.LastName.Contains("B"));

            foreach (var item in customerFilterSkip)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine("======== Ordered ========");

            var customerOrdered = customers.OrderByDescending(c => c.Price);
            /*
            var customerOrdered = from c in customers
                                  orderby c.Price descending
                                  select c;
            */
            foreach (var item in customerOrdered)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} : Price = {item.Price}");
            }

            Console.WriteLine("======== Group By ========");

            /*
            IEnumerable<IGrouping<string, Customer>> customerGrouped = from c in customers
                                                                        group c by c.State;
            */
            //IEnumerable<IGrouping<string, Customer>> customerGrouped = customers.GroupBy(c => c.State);
            //IEnumerable<IGrouping<string, Customer>> customerGrouped = customers.OrderByDescending(x => x.Price).GroupBy(c => c.State);
            /*
            foreach (IGrouping<string, Customer> cutomerGoup in customerGrouped)
            {
                Console.WriteLine(cutomerGoup.Key);
                foreach (Customer item in cutomerGoup)
                {
                    Console.WriteLine($"\t{item.FirstName} {item.LastName} : Price = {item.Price}");
                }
            }
            */

            IEnumerable<IGrouping<bool, Customer>> customerGrouped = customers.GroupBy(c => c.Price >= 1000);

            foreach (IGrouping<bool, Customer> cutomerGoup in customerGrouped)
            {
                Console.WriteLine(cutomerGoup.Key);
                foreach (Customer item in cutomerGoup)
                {
                    Console.WriteLine($"\t{item.FirstName} {item.LastName} : Price = {item.Price}");
                }
            }


        }
    }
}
