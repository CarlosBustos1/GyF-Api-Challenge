using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GyF_Api_Challenge.Data.Interfaces
{
    public interface IReadonlyRepository<TEntity,TId> where TEntity : class,new()
    {
        Task<TEntity> FindByIdAsync(TId id);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>> predicate);

        Task<List<TEntity>> GetAllAsync();  
    }
}
