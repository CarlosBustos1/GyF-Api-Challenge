namespace GyF_Api_Challenge.Data.Interfaces
{
    public interface IUpdatableRepository<TEntity, TId>  : IReadonlyRepository<TEntity, TId> where TEntity : class, new()
    {
        void Persist(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TId id);

        void Update(TEntity entity);    
    }
}
