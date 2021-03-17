using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrvicesLayer.Repositories
{
    public class UsersRepository : Irepository<ApplicationUser>
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ApplicationUser entity)
        {
            throw new NotImplementedException();
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
            return _context.Users.ToList();
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
