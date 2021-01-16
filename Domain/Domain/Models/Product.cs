using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Model { get; set; }
        public string Desc { get; set; }
        public double Cost { get; set; }
        public double SalePrice { get; set; }

    }
}
