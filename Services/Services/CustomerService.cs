using Microsoft.AspNetCore.Mvc;
using TP3.Models;

namespace TP3.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) {
            _customerRepository = customerRepository;

        }
        public void Add(Customer customer)
        {
            _customerRepository.Add(customer);



        }

        public void Delete(Customer customer)
        {
            _customerRepository.Delete(customer);
        }

        public ICollection<Customer> GetAll()
        {
              return _customerRepository.GetAll();
      }

        public Customer GetById(Guid id)
        {
            return _customerRepository.GetById(id);
        }

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }

   

       
    }
}
