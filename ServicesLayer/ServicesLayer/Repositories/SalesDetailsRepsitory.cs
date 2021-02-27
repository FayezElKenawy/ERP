using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Repositories
{
    public class SalesDetailsRepsitory : Irepository<SalesDetails>
    {
        private readonly ApplicationDbContext _context;

        public SalesDetailsRepsitory(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(SalesDetails entity)
        {
             _context.SalesDetails.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }


        public SalesDetails Find(object id)
        {
            var x = (SalesDetails)id;
            var existq = _context.SalesDetails.AsNoTracking().Where(i => i.InvoiceId == x.InvoiceId && i.ProductID == x.ProductID);
            var exist = new SalesDetails();
            foreach (var item in existq)
            {
                exist = (SalesDetails)item;
            }
            return exist;
        }

        public IList<SalesDetails> List()
        {
            return _context.SalesDetails.ToList();
        }

        public string MaxId()
        {
            throw new NotImplementedException();
        }

        public List<SalesDetails> Search(string term)
        {
            throw new NotImplementedException();
        }
        public SalesDetails Update(object id, SalesDetails entity)
        {
            var exist = Find(entity);
            _context.SalesDetails.Update(entity);
            _context.SaveChanges();
            return exist;
        }
    }
}
