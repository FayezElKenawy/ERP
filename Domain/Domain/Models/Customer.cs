using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }
        public string CustArName { get; set; }
        public string CustEnName { get; set; }
        public string CustMobileNo { get; set; }
        public string CustAdress { get; set; }
        public double CustBalance { get; set; }
        public double CustOpenBalance { get; set; }
        public int AccountNo { get; set; }
    }
}
