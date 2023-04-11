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

        public async Task<ResultSale> CreateSale(IEnumerable<SaleDTO> saleDTO)
        {
            foreach (var item in saleDTO)
            {
                await _product.GetById(item.ProductId);
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
            return new ResultSale() {
            Id = sale.Id,
            ItemsSold = saleDTO,
            };
        }

        public async Task<List<ResultSaleProduct>> GetAllSales()
        {
            var temp = await _saleProducts.GetAll();
            List<ResultSaleProduct> result = new List<ResultSaleProduct>();
            foreach (var item in temp)
            {
                var sale = await _sales.GetById(item.SaleId);
                ResultSaleProduct resultSaleProduct = new ResultSaleProduct()
                {
                    SaleId = item.SaleId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Date = sale.Date,
                };
                result.Add(resultSaleProduct);
            }
            return result;
        }

        public async Task<List<ResultSaleProduct>> GetSalesById(int id)
        {
            var result = await GetAllSales();
            result = result.Where(x => x.SaleId == id).ToList();
            
            return result.Count == 0 ? throw new Exception("Sale not found") : result;
        }

    }
}
