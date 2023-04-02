using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeManagerDotNet.Data;
using storeManagerDotNet.DTO;
using storeManagerDotNet.Models;

namespace storeManagerDotNet.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;

        public ProductController(StoreContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
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
            catch (Exception)
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
            catch (Exception)
            {
                return NotFound( new { message = "Product not found" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(ProductDTO productDTO)
        {
            try
            {
                var product = _mapper.Map<Product>(productDTO);
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
