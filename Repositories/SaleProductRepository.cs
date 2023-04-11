using Microsoft.EntityFrameworkCore;
using storeManagerDotNet.Data;
using storeManagerDotNet.DTO;
using storeManagerDotNet.Models;
using storeManagerDotNet.Repositories.Abstractions;

namespace storeManagerDotNet.Repositories
{
    public class SaleProductRepository : RepositoryBase<SaleProduct>, ISaleProductRepository
    {
        public SaleProductRepository(StoreContext storeContext) : base(storeContext)
        {

        }
    }
}
