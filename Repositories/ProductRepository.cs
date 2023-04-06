using storeManagerDotNet.Data;
using storeManagerDotNet.Models;
using storeManagerDotNet.Repositories.Abstractions;

namespace storeManagerDotNet.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(StoreContext storeContext) : base(storeContext)
        {

        }
    }
}
