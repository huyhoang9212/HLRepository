using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HL.Core.Domain;
using HL.Data;
namespace HL.Test
{
    [TestClass]
    public class NorthwindContextTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            NorthwindContext context = new NorthwindContext();
            var customer = context.Customers.Find("AS001");
            customer.Phone = "0909090099";
            context.SaveChanges();
            Assert.IsNotNull(customer);
        }
    }
}
