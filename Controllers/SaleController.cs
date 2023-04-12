using Microsoft.AspNetCore.Mvc;
using storeManagerDotNet.DTO;
using storeManagerDotNet.Services.Abstractions;

namespace storeManagerDotNet.Controllers;

[ApiController]
[Route("sales")]
public class SaleController : ControllerBase
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
            if (sale.ProductId == 0) throw new Exception("\"productId\" is required");
            if (sale.Quantity == 0) throw new Exception("\"quantity\" is required");
        }
        var result = await _saleService.CreateSale(salesDTO);
        return StatusCode(201, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSales()
    {
        var result = await _saleService.GetAllSales();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _saleService.GetSalesById(id));
    }
}
