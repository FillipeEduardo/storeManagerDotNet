using storeManagerDotNet.Models;

namespace storeManagerDotNet.Repositories.Abstractions
{
    public interface ISaleRepository : IRepositoryBase<Sale>, IUnitOfWork
    {
    }
}
