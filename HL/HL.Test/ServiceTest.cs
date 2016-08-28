using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.Core.Domain;
using HL.Data;
using HL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HL.Test
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IUnitOfWork unitOfWork = new HLUnitOfWork();
            var service = new CustomerService(unitOfWork);
            
            service.CreateCustomer(new Customer { CustomerID = "003", Address = "TDT", City = "HCM", CompanyName = "Aswig", ContactName = "Hoang Le", ContactTitle = "Developer", Country = "VN" });
            var customer = service.FindCustomerById("003");
            Assert.IsNotNull(customer);
            service.DeleteCustomer(customer);
            customer = service.FindCustomerById("003");
            Assert.IsNull(customer);
        }
    }
}
