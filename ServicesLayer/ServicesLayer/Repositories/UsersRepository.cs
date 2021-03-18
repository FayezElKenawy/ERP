using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var user = manager.FindByEmailAsync(term).Result;
            if (user != null)
            {
                return false;
            }
            return true;
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
