using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public static class BasicJoin
    {
        public static void printBasicJoin()
        {
            List<Customer> customers = CustomersCollection.customers;
            List<Distributor> distributors = DistributorCollection.distributors;
            double[] rates = { 0.89, 0.65, 120 };
            /*
            var matchOps = from c in customers
                           join d in distributors on c.State equals d.State
                           select new { FullName = $"{c.FirstName} {c.LastName}", cState = c.State, Distributor = d.Name, dState = d.State };
            */
            
            var matchOps = customers.Join(distributors,
                    c => c.State,
                    d => d.State,
                    (c, d) => new
                    {
                        FullName = $"{c.FirstName} {c.LastName}",
                        cState = c.State,
                        Distributor = d.Name,
                        dState = d.State
                    }
                );

            IEnumerable<CustomerDistributor> matchOpsNewClass = customers.Join(distributors,
                c => c.State,
                d => d.State,
                (c, d) => new CustomerDistributor
                {
                    FullName = $"{c.FirstName} {c.LastName}",
                    cState = c.State,
                    Distributor = d.Name,
                    dState = d.State
                }
            );
            /*
            foreach (var item in matchOpsNewClass)
            {
                Console.WriteLine($"{item.FullName} : {item.Distributor} , {item.cState} = {item.dState}");
            }
            */

            // hierarchy type
            var matchQry = from c in customers
                           join d in distributors on c.State equals d.State
                           into matches
                           select new { 
                                Customer = $"{c.FirstName} {c.LastName}",
                                Distributors = matches.Select(d => d.Name)
                           };

            Console.WriteLine(" ====== Customers and their Distributors ====== ");

            foreach (var cd in matchQry)
            {
                if(cd.Distributors.Count() > 0)
                {
                    Console.Write($"{cd.Customer} => ");
                    foreach (var dist in cd.Distributors)
                    {
                        Console.Write($"{dist.ToString()}; ");
                    }
                    Console.WriteLine();
                }
            }

            // way 1           
            var matchDistibQry = from d in distributors
                           join c in customers on d.State equals c.State
                           into matches
                           select new
                           {
                               Distributor = d.Name,
                               Customers = matches.Select(c => $"{c.FirstName} {c.LastName}")
                           };
            // way 2
            var matchDistibQry_ = distributors.GroupJoin(customers,
                d => d.State,
                c => c.State,
                (d, c) => new
                {
                    Distributor = d.Name,
                    Customers = c.Select( c => $"{c.FirstName} {c.LastName}")
                }
            );


            Console.WriteLine(" ====== Distibutors and their Customers ====== ");

            foreach (var dist in matchDistibQry)
            {
                if (dist.Customers.Count() > 0)
                {
                    Console.Write($"{dist.Distributor} => ");
                    foreach (var cust in dist.Customers)
                    {
                        Console.Write($"{cust}; ");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine(" ====== Distibutors and their Customers ====== ");

            foreach (var dist in matchDistibQry_)
            {
                if (dist.Customers.Count()>0)
                {
                    Console.Write($"{dist.Distributor} => ");
                    foreach (var cust in dist.Customers)
                    {
                        Console.Write($"{cust}; ");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine(" ====== Cross Join Rates ====== ");


            IEnumerable<double> allPrices = from c in customers
                                            from e in rates
                                            select c.Price * e;

            /*
            foreach (double price in allPrices)
            {
                Console.WriteLine(price);
            }
            */
        }

    }
}
