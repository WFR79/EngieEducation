using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ADR.DataAccessLayer.Repos.Interface
{
    public interface IRepository<TKey, TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TKey ID);
        bool Insert(TEntity Entity);
        bool Update(TEntity Entity);
        bool Delete(TEntity Entity);
    }
}
