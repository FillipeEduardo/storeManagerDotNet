using storeManagerDotNet.Models;

namespace storeManagerDotNet.Repositories.Abstractions
{
    public interface ISaleProductRepository : IRepositoryBase<SaleProduct>, IUnitOfWork
    {
    }
}
