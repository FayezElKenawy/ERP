using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class SalesDetails
    {

        public string InvoiceId { get; set; }

        public string ProductID { get; set; }
        public double? Quantity { get; set; }
        public double? SalesPrice { get; set; }
        public double? Total { get; set; }
        public double? Cost { get; set; }
        public double? discount { get; set; }
        public double? VatAmount { get; set; }
        public double? TotalWithVat { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public SalesInvoice SalesInvoice { get; set; }
    }
}
