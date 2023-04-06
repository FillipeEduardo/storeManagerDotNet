using storeManagerDotNet.Models;

namespace storeManagerDotNet.Repositories.Abstractions
{
    public interface IProductRepository : IRepositoryBase<Product>, IUnitOfWork
    {
    }
}
