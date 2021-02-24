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

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public SalesInvoice Find(object id)
        {
            return context.SalesInvoices.Find(id);
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

        public List<SalesInvoice> Search(string term)
        {
            throw new NotImplementedException();
        }


        public void Update(object id, SalesInvoice entity)
        {
            var invoice = Find(id);
            invoice.InvoiceDate = entity.InvoiceDate;
            invoice.InvoiceType = entity.InvoiceType;
            invoice.InvoiceTotal = entity.InvoiceTotal;
            invoice.InvoiceDiscount = entity.InvoiceDiscount;
            invoice.InvoiceNetTotal = entity.InvoiceNetTotal;
            invoice.InvoicePaid = entity.InvoicePaid;
            invoice.CustID = entity.CustID;
            invoice.InvoiceChange = entity.InvoiceChange;
        }
    }
}
