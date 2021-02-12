using Domain.Models;
using Domain.Data;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Repositories
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

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Customer Find(int id)
        {
            return context.Customers.FirstOrDefault(c => c.CustID == id.ToString());
        }

        public Customer Find(object id)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> List()
        {
            return context.Customers.ToList();
        }

        public string MaxId()
        {
            try
            {
                string id = context.Customers.Max(i => i.CustID).ToString();
                return id;
            }
            catch (Exception)
            {

                return "0";
            }
        }

        public List<Customer> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(object id, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
