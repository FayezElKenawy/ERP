﻿using Domain.baseData;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class SalesInvoice : BaseDataClass
    {
        public string InvoiceId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime InvoiceDate { get; set; }
        public double InvoiceTotal { get; set; }
        public double InvoiceDiscount { get; set; }
        public double InvoiceNetTotal { get; set; }
        public int InvoiceType { get; set; }
        public double InvoicePaid { get; set; }
        public double InvoiceChange { get; set; }
        public Customer Customers { get; set; }

    }
}
