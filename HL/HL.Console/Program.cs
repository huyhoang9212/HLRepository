using HL.Core.Domain;
using HL.Data;
using System.Data.Entity.Infrastructure;
using System;
using System.Data.Entity;
namespace HL.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateSingleEntityInDisconectedScenario();
        }

        /// <summary>
        /// http://www.entityframeworktutorial.net/EntityFramework4.3/update-entity-using-dbcontext.aspx
        /// </summary>
        static void UpdateSingleEntityInDisconectedScenario()
        {
            Customer customer;
            using (NorthwindContext context = new NorthwindContext())
            {
                customer = context.Customers.Find("AS001");
                Console.WriteLine(customer.ContactName);
                var entry = context.Entry(customer);
            
                Console.WriteLine("State: {0}", entry.State); // Unchanged
            }


            using (NorthwindContext context2 = new NorthwindContext())
            {
               
                var entry = context2.Entry(customer);
                Console.WriteLine("State: {0}", entry.State); // Detached
                context2.Customers.Attach(customer);
                customer.ContactName = "Changed by attach.";
                Console.WriteLine("State: {0}", entry.State); // Modified
                context2.SaveChanges();
                Console.WriteLine(context2.Customers.Find("AS001").ContactName);
            }

            NorthwindContext nContext = new NorthwindContext();
            Console.WriteLine(nContext.Customers.Find("AS001").ContactName);

            using (NorthwindContext context3 = new NorthwindContext())
            {
                customer.ContactName = "Changed by entry";
                var entry = context3.Entry(customer);
                Console.WriteLine("State: {0}", entry.State); // Detached
                entry.State = EntityState.Modified; // Modified
                context3.SaveChanges();
              
                Console.WriteLine(context3.Customers.Find("AS001").ContactName);
            }

            nContext = new NorthwindContext();
            Console.WriteLine(nContext.Customers.Find("AS001").ContactName);

        }

        static void EntryTest()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var customer = context.Customers.Find("AS001");

                DbEntityEntry<Customer> entry = context.Entry(customer);
                Console.WriteLine("Current state: " + entry.State + customer.ContactName);
                customer.ContactName = "Hoang2";
                entry = context.Entry(customer);
                Console.WriteLine("New state: " + entry.State + customer.ContactName);

                // Console.WriteLine("Entity Name: {0}", entry.Entity.GetType().FullName);
                //Console.WriteLine("**********Property Values***********");
                //foreach(var property in entry.CurrentValues.PropertyNames)
                //{
                //    Console.WriteLine(property);
                //    Console.WriteLine("Original value: {0}", entry.OriginalValues[property]);
                //    Console.WriteLine("Current value: {0}", entry.CurrentValues[property]);
                //}

                context.SaveChanges();
                Console.WriteLine("Current state: " + entry.State);
                entry.State = EntityState.Deleted;
                Console.WriteLine("Current state: " + entry.State);
                context.SaveChanges();
                Console.WriteLine("After make it as deleted: " + entry.State);
                customer = context.Customers.Find("AS001");
                Console.ReadLine();

                var newCustomer = new Customer() { CustomerID = "AS002" };
                var newEntry = context.Entry(newCustomer);
            }
        }
    }
}
