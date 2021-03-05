using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
   public class ProductReadViewModel
    {
        public string ProductId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Model { get; set; }
        public string Desc { get; set; }
        public double Cost { get; set; }
        public double SalePrice { get; set; }
        public double Balance { get; set; }
        public double OpenBalance { get; set; }
        public double LastBalance { get; set; }
        public double LastCost { get; set; }
        public double OpenCost { get; set; }
        public double ForignCost { get; set; }
    }
}
