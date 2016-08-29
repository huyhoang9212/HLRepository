using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.Core.Domain;
using HL.Data;
namespace HL.Services
{
    public interface ICustomerService
    {
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

        void DeleteCustomer(string CustomerId);

        Customer FindCustomerById(string customerId);

        IQueryable<Customer> GetAllCustomers();
    }

    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = _unitOfWork.Repository<Customer>();
        }

        public void CreateCustomer(Customer customer)
        {
            _customerRepository.Insert(customer);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCustomer(string customerId)
        {
            _customerRepository.Delete(customerId);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _customerRepository.Delete(customer);
            _unitOfWork.SaveChanges();
        }

        public Customer FindCustomerById(string customerId)
        {
            return _customerRepository.Find(customerId);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
            _unitOfWork.SaveChanges();
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return _customerRepository.Queryable();
        }
    }
}
