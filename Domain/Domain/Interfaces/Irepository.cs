using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
   public interface Irepository<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(object id);
        void Add(TEntity entity);
        TEntity Update(object id, TEntity entity);
        void Delete(object id);
        List<TEntity> Search(string term);
        string MaxId();
        void SaveChanges();
    }
}
