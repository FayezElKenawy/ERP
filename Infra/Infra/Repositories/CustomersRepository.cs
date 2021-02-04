using Domain.Models;
using Domain.Data;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CustomersRepository : Irepository<Customer>
    {
        private readonly ApplicationDbContext context;

        public CustomersRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Customer entity)
        {
            context.Customers.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Find(int id)
        {
            return context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public IList<Customer> List()
        {
            return context.Customers.ToList();
        }

        public string MaxId()
        {
            throw new NotImplementedException();
        }

        public List<Customer> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
