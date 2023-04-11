using storeManagerDotNet.DTO;

namespace storeManagerDotNet.Services.Abstractions
{
    public interface ISaleService
    {
        Task<ResultSale> CreateSale(IEnumerable<SaleDTO> salesDTO);
        Task<List<ResultSaleProduct>> GetAllSales();
        Task<List<ResultSaleProduct>> GetSalesById(int id);
    }
}
