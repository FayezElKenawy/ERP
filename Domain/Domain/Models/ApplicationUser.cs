using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name ="Frist Name")]
        [MaxLength(50)]
        public string FristName { get; set; }
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string  LastName { get; set; }


        
    }
}
