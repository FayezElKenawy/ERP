using Domain.Models;
using Domain.Data;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesLayer.Repositories
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

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Product Find(object id)
        {
            var pro=context.Products.Find(id);
            return pro;
        }

        public IList<Product> List()
        {
            return  context.Products.ToList();
        }

        public string MaxId()
        {
            throw new NotImplementedException();
        }

        public List<Product> Search(string term)
        {
            throw new NotImplementedException();
        }


        public void Update(object id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
