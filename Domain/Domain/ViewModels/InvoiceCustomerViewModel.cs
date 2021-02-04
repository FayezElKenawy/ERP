using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class InvoiceCustomerViewModel
    {
        public string InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double InvoiceTotal { get; set; }
        public double InvoiceDiscount { get; set; }
        public double InvoiceNetTotal { get; set; }
        public int InvoiceType { get; set; }
        public double InvoicePaid { get; set; }
        public double InvoiceChange { get; set; }
        public int CustId { get; set; }
        public int ProductId { get; set; }
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
        public List<SalesInvoice> Invoices { get; set; }
    }
}
