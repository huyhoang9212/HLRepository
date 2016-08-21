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
    }
}
