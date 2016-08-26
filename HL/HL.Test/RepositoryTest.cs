using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HL.Data;
using HL.Core.Domain;

namespace HL.Test
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using(var context = new NorthwindContext())
            {
                var customerRepository = new Repository<Customer>(context);
                var customer = customerRepository.Find("AS001");
                customer.Address = "address changed.";
                var entryCus = context.Entry(customer);
                Assert.IsNotNull(customer);

                var order = new Repository<Order>(context).Find(1);
                Assert.IsNotNull(order);
            };
        }

        [TestMethod]
        public void TestRepository2()
        {
            var context = new NorthwindContext();
            var customerRepo = new Repository<Customer>(context);
            var customer = new Customer { CustomerID = "003", Address = "TDT", City = "HCM", CompanyName = "Aswig", ContactName = "Hoang Le", ContactTitle = "Developer", Country = "VN" };
            customerRepo.Insert(customer);
            context.SaveChanges();

         
            var addedCustomer = customerRepo.Find("003");
            Assert.IsNotNull(addedCustomer);

            addedCustomer.ContactName = "Changed changed";

            var context2 = new NorthwindContext();
            var repo2 = new Repository<Customer>(context2);
            repo2.Update(addedCustomer);
            context2.SaveChanges();

            customerRepo.Delete(addedCustomer);
            context.SaveChanges();

            addedCustomer = customerRepo.Find("003");
            Assert.IsNull(addedCustomer);
        }
    }
}
