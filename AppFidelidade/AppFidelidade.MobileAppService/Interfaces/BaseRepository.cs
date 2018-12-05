using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFidelidade.MobileAppService.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class    
    {
        void Add(TEntity item);
        void Update(TEntity item);
        TEntity Remove(string key);
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
    }
}
