using Domain.Models;
using ERP.Data;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    class SalesReopsitory : Irepository<SalesInvoice>
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SalesInvoice Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<SalesInvoice> List()
        {
            throw new NotImplementedException();
        }

        public List<SalesInvoice> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, SalesInvoice entity)
        {
            throw new NotImplementedException();
        }
    }
}
