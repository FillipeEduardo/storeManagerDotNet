using storeManagerDotNet.Data;
using storeManagerDotNet.Models;
using storeManagerDotNet.Repositories.Abstractions;

namespace storeManagerDotNet.Repositories
{
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        public SaleRepository(StoreContext storeContext) : base(storeContext)
        {
        }
    }
}
