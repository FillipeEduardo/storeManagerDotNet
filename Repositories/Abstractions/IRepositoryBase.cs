namespace storeManagerDotNet.Repositories.Abstractions
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
    }
}
