using GyF_Api_Challenge.Data.Interfaces;
using System;
using System.Text;

namespace GyF_Api_Challenge.Data.Repositories
{

    public class UpdatableRepository<TEntity, TId> : ReadonlyRepository<TEntity, TId>, IUpdatableRepository<TEntity, TId> where TEntity : class, new()
    {
        protected readonly GyFContext GyFContext;

        public UpdatableRepository(GyFContext gyFContext) : base(gyFContext)
        {
            GyFContext = gyFContext;
        }
        public void Delete(TEntity entity)
        {
            GyFContext.Remove(entity);
        }

        public void Delete(TId id)
        {
            throw new NotImplementedException();
        }

        public virtual void Persist(TEntity entity)
        {
            GyFContext.Add(entity);
        }

        public void Update(TEntity entity)
        {
            GyFContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
