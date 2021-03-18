using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SrvicesLayer.Repositories
{
    public class UsersRepository : Irepository<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> manager;

        public UsersRepository(ApplicationDbContext context,UserManager<ApplicationUser> manager)
        {
            this.manager = manager;
        }

        public void Add(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public bool check(string term)
        {
            var username = new EmailAddressAttribute().IsValid(term) ? term : null;

            if (username != null)
            {
              return  checkEmail(username);
            }
            else
            {
                return checkMobile(username);
            }
        }
        private bool checkEmail(string term)
        {
            var user = manager.FindByEmailAsync(term).Result;
            if (user!=null)
            {
                return false;
            }
            return true;
        }
        private bool checkMobile(string term)
        {
            var user = manager.Users.FirstOrDefault(u=>u.PhoneNumber==term);
            if (user!=null)
            {
                return true;
            }
            return false;
        }
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Find(object id)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicationUser> List()
        {
            return manager.Users.ToList();
        }

        public string MaxId()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> Search(string term)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Update(object id, ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
