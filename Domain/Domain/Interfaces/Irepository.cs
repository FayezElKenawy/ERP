using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
   public interface Irepository<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(int id);
        List<TEntity> Search(string term);
        string MaxId();
    }
}
