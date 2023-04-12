using Microsoft.EntityFrameworkCore;
using storeManagerDotNet.Data;
using storeManagerDotNet.Exceptions;
using storeManagerDotNet.Repositories.Abstractions;

namespace storeManagerDotNet.Repositories;

public class RepositoryBase<TEntity> : IUnitOfWork, IRepositoryBase<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _DbSet;
    private readonly StoreContext _StoreContext;

    public RepositoryBase(StoreContext storeContext)
    {
        _StoreContext = storeContext;
        _DbSet = storeContext.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _DbSet.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetById(int id)
    {
        var result = await _DbSet.FindAsync(id);
        return result is null ? throw new DbNotFoundException("Product not found") : result;
    }

    public async Task Create(TEntity entity)
    {
        await _DbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _DbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _DbSet.Remove(entity);
    }

    public async Task<int> Commit()
    {
        return await _StoreContext.SaveChangesAsync();
    }
}
