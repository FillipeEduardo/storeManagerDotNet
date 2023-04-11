using storeManagerDotNet.DTO;
using storeManagerDotNet.Models;
using storeManagerDotNet.Repositories.Abstractions;
using storeManagerDotNet.Services.Abstractions;

namespace storeManagerDotNet.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _sales;
        private readonly ISaleProductRepository _saleProducts;
        private readonly IProductRepository _product;

        public SaleService(ISaleRepository sales, ISaleProductRepository saleProducts, IProductRepository product)
        {
            _sales = sales;
            _saleProducts = saleProducts;
            _product = product;
        }

        public async Task CreateSale(IEnumerable<SaleDTO> saleDTO)
        {
            foreach (var item in saleDTO)
            {
                var product = await _product.GetById(item.ProductId);
            }

            var sale = new Sale();
            await _sales.Create(sale);
            await _sales.Commit();

            foreach (var item in saleDTO)
            {
                var saleProduct = new SaleProduct
                {
                    SaleId = sale.Id,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };
                await _saleProducts.Create(saleProduct);
            }
            await _saleProducts.Commit();
        }

    }
}
