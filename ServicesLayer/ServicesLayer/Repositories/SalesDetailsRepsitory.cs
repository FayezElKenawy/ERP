using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Repositories
{
    public class SalesDetailsRepsitory : Irepository<SalesDetails>
    {
        private readonly ApplicationDbContext _context;

        public SalesDetailsRepsitory(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(SalesDetails entity)
        {
             _context.SalesDetails.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SalesDetails Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<SalesDetails> List()
        {
            return _context.SalesDetails.ToList();
        }

        public string MaxId()
        {
            throw new NotImplementedException();
        }

        public List<SalesDetails> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, SalesDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
