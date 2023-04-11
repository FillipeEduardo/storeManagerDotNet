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
        try
        {
            foreach (var sale in salesDTO)
            {
                if (sale.ProductId == 0) throw new Exception("\"productId\" is required");
                if (sale.Quantity == 0) throw new Exception("\"quantity\" is required");
            }
            var result = await _saleService.CreateSale(salesDTO);

            return StatusCode(201, result);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("validation", e.Message);
            return ValidationProblem(ModelState);
        }

    }

    [HttpGet]
    public async Task<IActionResult> GetAllSales()
    {
        try
        {
            var result = await _saleService.GetAllSales();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _saleService.GetSalesById(id));
        }
        catch (Exception e)
        {
            ModelState.AddModelError("validation", e.Message);
            return ValidationProblem(ModelState);
        }
    }
}
