using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.baseData
{
   public class IdentityOperations
    {
        private readonly UserManager<ApplicationUser> manager;

        public IdentityOperations(UserManager<ApplicationUser> manager)
        {
            this.manager = manager;
        }

        public bool checkEmail(string email)
        {
            var user =  manager.FindByEmailAsync(email).Result;
            if (email != null)
            {
                return false;
            }
            return true;
        }
    }
}
