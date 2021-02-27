using Domain.Models;
using Domain.Data;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            var pro = context.Products.AsNoTracking().Where(i => i.ProductId == id.ToString());
            var pro1 = new Product();
            foreach (var item in pro)
            {
                pro1 = (Product)item;
            }
            return pro1;
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


        public Product Update(object id, Product entity)
        {
            context.Products.Update(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
