using Microsoft.AspNetCore.Mvc;
using storeManagerDotNet.DTO;
using storeManagerDotNet.Services.Abstractions;
using System.Text.Json;

namespace storeManagerDotNet.Controllers;

[ApiController]
[Route("sales")]
public class SaleController :ControllerBase
{
    private readonly ISaleService _saleService;

    public SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateSale(IEnumerable<SaleDTO> salesDTO)
    {
        foreach (var sale in salesDTO)
        {
            if (sale.ProductId == 0) return BadRequest(new { message = "\"productId\" is required" });
            if (sale.Quantity == 0) return BadRequest(new { message = "\"quantity\" is required" });
        }

        try
        {
            await _saleService.CreateSale(salesDTO);
            
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}
