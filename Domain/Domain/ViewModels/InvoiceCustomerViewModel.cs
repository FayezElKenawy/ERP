using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class InvoiceCustomerViewModel
    {
        public string InvoiceNo { get; set; }
        public string CustID { get; set; }
        public string InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double? InvoiceTotal { get; set; }
        public double? InvoiceDiscount { get; set; }
        public double? InvoiceNetTotal { get; set; }
        public int InvoiceType { get; set; }
        public double? InvoicePaid { get; set; }
        public double? InvoiceChange { get; set; }
        [Required]
        public string ProductID { get; set; }
        public string downdetails { get; set; }
        public double? Quantity { get; set; }
        public double? SalesPrice { get; set; }
        public double? Total { get; set; }
        public double? Cost { get; set; }
        public double? discount { get; set; }
        public double? VatAmount { get; set; }
        public double? TotalWithVat { get; set; }
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
        public SalesInvoice Invoices { get; set; }
        public SalesDetails Details { get; set; }
        public Product product { get; set; }
    }
}
