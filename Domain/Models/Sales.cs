using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Sales
    {
        public int InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double InvoiceTotal { get; set; }
        public double InvoiceDiscount { get; set; }
        public double InvoiceNetTotal { get; set; }
        public int InvoiceType { get; set; }
        public double InvoicePaid { get; set; }
        public double InvoiceChange { get; set; }
        public Product Products { get; set; }
    }
}
