using Domain.Models;
using Domain.Data;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServicesLayer.Repositories
{
    public class SalesReopsitory : Irepository<SalesInvoice>
    {
        private readonly ApplicationDbContext context;

        public SalesReopsitory(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(SalesInvoice entity)
        {
            context.SalesInvoices.Add(entity);
            context.SaveChanges();
        }

        public bool check(string term)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public SalesInvoice Find(object id)
        {
            return context.SalesInvoices.AsNoTracking().Where(n=>n.InvoiceNo==id.ToString()).FirstOrDefault();
        }

        public IList<SalesInvoice> List()
        {
            return context.SalesInvoices.ToList();
        }

        public string MaxId()
        {
            try
            {
                string id = context.SalesInvoices.Max(i => i.InvoiceNo).ToString();
                return id;
            }
            catch (Exception)
            {

                return "0";
            }
            

            
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<SalesInvoice> Search(string term)
        {
            throw new NotImplementedException();
        }


        public SalesInvoice Update(object id, SalesInvoice entity)
        {
            context.SalesInvoices.Update(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
