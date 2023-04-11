using storeManagerDotNet.DTO;

namespace storeManagerDotNet.Services.Abstractions
{
    public interface ISaleService
    {
        Task CreateSale(IEnumerable<SaleDTO> salesDTO);
    }
}
