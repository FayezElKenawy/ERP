using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class InvoiceListViewModel
    {
        public string InvoiceNo { get; set; }
        public string CustID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime InvoiceDate { get; set; }
        public double? InvoiceTotal { get; set; }
        public double? InvoiceDiscount { get; set; }
        public double? InvoiceNetTotal { get; set; }
        public int InvoiceType { get; set; }
        public double? InvoicePaid { get; set; }
        public double? InvoiceChange { get; set; }
        public string CustomerName { get; set; }
        public Customer Customer { get; set; }
    }
}
