﻿using Microsoft.AspNetCore.Mvc;
using TP3.Models;

namespace TP3.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationdbContext _db;
        public CustomerRepository(ApplicationdbContext db) {
            _db = db;

        }
        public void Add(Customer customer)
        {
              _db.Customers.Add(customer);
                 _db.SaveChanges();
            

        }

        public void Delete(Customer customer)
        {
              _db.Customers.Remove(customer);
              _db.SaveChanges();
        }

        public ICollection<Customer> GetAll()
        {
              return _db.Customers.ToList();
      }

        public Customer GetById(Guid id)
        {
            return _db.Customers.FirstOrDefault(customer => customer.Id == id);
        }

        public void Update(Customer customer)
        {
              _db.Customers.Update(customer);
                _db.SaveChanges();
        }
    }
}
