using storeManagerDotNet.Models;
using storeManagerDotNet.Repositories.Abstractions;
using storeManagerDotNet.Services.Abstractions;

namespace storeManagerDotNet.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _Products;

        public ProductService(IProductRepository products)
        {
            _Products = products;
        }

        public async Task Create(Product product)
        {
            await _Products.Create(product);
            await _Products.Commit();
        }

        public async Task<Product> GetById(int id)
        {
            return await _Products.GetById(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _Products.GetAll();
        }


    }
}
