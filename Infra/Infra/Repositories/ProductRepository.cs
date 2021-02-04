using Domain.Models;
using Domain.Data;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class ProductRepository : Irepository<Product>
    {
        private readonly ApplicationDbContext context;
        
        public ProductRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public void Add(Product entity)
        {
            context.Products.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> List()
        {
            return context.Products.ToList();
        }

        public string MaxId()
        {
            throw new NotImplementedException();
        }

        public List<Product> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
