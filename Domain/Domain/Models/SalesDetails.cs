using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class SalesDetails
    {
        [Key]
        public int InvoiceId { get; set; }
        [Key]
        public int ProductID { get; set; }
        public double? Quantity { get; set; }
        public double? SalesPrice { get; set; }
        public double? Total { get; set; }
        public double? Cost { get; set; }
        public double? discount { get; set; }
        public double? VatAmount { get; set; }
        public double? TotalWithVat { get; set; }

        public List<Product> Products { get; set; }
        public List<SalesInvoice> SalesInvoices { get; set; }
    }
}
