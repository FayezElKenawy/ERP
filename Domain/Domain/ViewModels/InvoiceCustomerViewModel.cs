﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
   public class InvoiceCustomerViewModel
    {
        public int InvoiceId { get; set; }
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
    }
}
