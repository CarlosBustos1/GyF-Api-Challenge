using GyF_Api_Challenge.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GyF_Api_Challenge.Data.Repositories
{
    public class ReadonlyRepository<TEntity, TId> : IReadonlyRepository<TEntity, TId> where TEntity : class, new()
    {
        protected readonly GyFContext GyFContext;

        public ReadonlyRepository(GyFContext gyFContext)
        {
            GyFContext = gyFContext;
        }
        public async Task<TEntity> FindByIdAsync(TId id)
        {
            return await GyFContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await GyFContext.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GyFContext.Set<TEntity>()
                .Where(predicate)
                .ToListAsync();
        }
    }
}
