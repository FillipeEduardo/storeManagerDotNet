using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeManagerDotNet.Data;
using storeManagerDotNet.Models;

namespace storeManagerDotNet.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductController(StoreContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var dados = await _context.Products.AsNoTracking().ToListAsync();
                dados = dados.OrderBy(x => x.Id).ToList();

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            try
            {
                var dados = await _context.Products.FindAsync(id);
                if (dados is null)
                {
                    return NotFound(new { message = "Product not found" });
                }
                return Ok(dados);

            }
            catch (Exception ex)
            {
                return NotFound( new { message = "Product not found" });
            }
        }
    }
}
