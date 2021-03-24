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
   public class RolesRepository : Irepository<IdentityRole>
    {
        private readonly RoleManager<IdentityRole> role;

        public RolesRepository(RoleManager<IdentityRole> role)
        {
            this.role = role;
        }

        public void Add(IdentityRole entity)
        {
            throw new NotImplementedException();
        }

        public bool check(string term)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IdentityRole Find(object id)
        {
            throw new NotImplementedException();
        }

        public IList<IdentityRole> List()
        {
            return role.Roles.ToList();
        }

        public string MaxId()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<IdentityRole> Search(string term)
        {
            throw new NotImplementedException();
        }

        public IdentityRole Update(object id, IdentityRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
