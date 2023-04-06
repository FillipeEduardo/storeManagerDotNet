using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using storeManagerDotNet.DTO;
using storeManagerDotNet.Models;
using storeManagerDotNet.Repositories.Abstractions;

namespace storeManagerDotNet.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _Products;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository products, IMapper mapper)
        {
            _Products = products;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var dados = await _Products.Get();
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
                var dados = await _Products.GetById(id);
                if (dados is null)
                {
                    return NotFound(new { message = "Product not found" });
                }
                return Ok(dados);

            }
            catch (Exception)
            {
                return NotFound(new { message = "Product not found" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(ProductDTO productDTO)
        {
            try
            {
                var product = _mapper.Map<Product>(productDTO);
                await _Products.Create(product);
                await _Products.Commit();
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
