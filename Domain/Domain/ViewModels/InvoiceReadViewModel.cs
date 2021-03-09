using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class InvoiceReadViewModel
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double InvoiceTotal { get; set; }
        public double InvoiceDiscount { get; set; }
        public double InvoiceNetTotal { get; set; }
        public int InvoiceType { get; set; }
        public double InvoicePaid { get; set; }
        public double InvoiceChange { get; set; }
    }
}
