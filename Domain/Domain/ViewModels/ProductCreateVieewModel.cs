using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ProductCreateVieewModel
    {
        [Required]
        [MaxLength(40)]
        [Display(Name ="Product Id")]
        public string ProductId { get; set; }
        [Required]
        [MaxLength(120)]
        [Display(Name ="Arabic Name")]
        public string ArabicName { get; set; }
        [Required]
        [MaxLength(120)]
        [Display(Name = "English Name")]
        public string EnglishName { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Dsicription")]
        [MaxLength(200)]
        public string Desc { get; set; }
        [Display(Name = "Sales Price")]
        [DataType(DataType.Currency)]
        
        public double SalePrice { get; set; }


    }
}
