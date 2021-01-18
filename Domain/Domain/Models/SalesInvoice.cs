using Domain.baseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class SalesInvoice : BaseDataClass
    {
        public DateTime InvoiceDate { get; set; }
        public double InvoiceTotal { get; set; }
        public double InvoiceDiscount { get; set; }
        public double InvoiceNetTotal { get; set; }
        public int InvoiceType { get; set; }
        public double InvoicePaid { get; set; }
        public double InvoiceChange { get; set; }
        public Product Products { get; set; }
        public Customer Customer { get; set; }
    }
}
