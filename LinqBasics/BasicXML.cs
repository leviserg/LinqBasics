using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqBasics
{
    public static class BasicXML
    {
        public static void saveXML()
        {
            List<Customer> customers = CustomersCollection.customers;
            XDocument document = new XDocument(
                new XDeclaration("1.0","utf-8","yes"),
                new XComment("Customers list XML"),
                new XElement("Customers",
                    from c in customers
                    select new XElement("Customer", new XAttribute("Id", c.Id),
                        new XElement("Name", c.FirstName),
                        new XElement("Surname", c.LastName),
                        new XElement("Age", c.Age),
                        new XElement("State", c.State)
                    )
                )
            );

            document.Save("Customers.xml"); // ..\LinqBasics\bin\Debug\..\Customers.xml
            Console.WriteLine("XML file saved...");
        }

        public static void readXML()
        {
            var custQuery = from c in XDocument.Load("Customers.xml")
                            .Descendants("Customer")
                            where (c.Element("State").Value) == "OR"
                            select new
                            {
                                FirstName = c.Element("Name").Value,
                                LastName = c.Element("Surname").Value,
                                Age = c.Element("Age").Value,
                                State = c.Element("State").Value
                            };

            foreach (var item in custQuery)
            {
                Console.WriteLine($"{item.State} : {item.FirstName} {item.LastName}");
            }
        }
    }
}
