using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HL.Core;
using HL.Data;
using HL.Services;
using HL.Core.Domain;

namespace HL.Test
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IUnitOfWork unitOfWork = new HLUnitOfWork();

            IRepository<Customer> customerRepo = unitOfWork.Repository<Customer>();

            customerRepo.Insert(new Customer { CustomerID = "1", Address = "TDT", City = "HCM", CompanyName = "Aswig", ContactName = "Hoang Le", ContactTitle = "Developer", Country = "VN" });
            unitOfWork.SaveChanges();

            var customer = unitOfWork.Repository<Customer>().Find("1");
            Assert.IsNotNull(customer);

            customerRepo.Delete(customer);
            unitOfWork.SaveChanges();


        }
    }
}
