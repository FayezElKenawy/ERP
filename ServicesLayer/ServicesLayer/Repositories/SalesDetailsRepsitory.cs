using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public SalesDetails Find(int id)
        {
            return _context.SalesDetails.Find(id);
        }

        public SalesDetails Find(object id)
        {
            throw new NotImplementedException();
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



        public void Update(object id, SalesDetails entity)
        {
            var detail = Find(id);
            detail.InvoiceId = entity.InvoiceId;
            detail.ProductID = entity.ProductID;
            detail.Quantity = entity.Quantity;
            detail.SalesPrice = entity.SalesPrice;
            detail.Total = entity.Total;
            detail.discount = entity.discount;
            detail.VatAmount = entity.VatAmount;
            detail.TotalWithVat = entity.TotalWithVat;
            detail.Cost = entity.Cost;
        }
    }
}
