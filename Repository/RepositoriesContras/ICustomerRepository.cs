using TP3.Models;

namespace TP3.Services
{
    public interface ICustomerRepository
    {
        public ICollection<Customer> GetAll();
        public Customer GetById(Guid id);
        public void Add (Customer customer);
        public void Update (Customer customer);
        public void Delete (Customer customer);


    }
}
