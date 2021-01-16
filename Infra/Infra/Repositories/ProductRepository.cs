using Domain.Models;
using ERP.Data;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories
{
    class ProductRepository : Irepository<Product>
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
