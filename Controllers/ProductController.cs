using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using storeManagerDotNet.DTO;
using storeManagerDotNet.Models;
using storeManagerDotNet.Services.Abstractions;

namespace storeManagerDotNet.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _Products;
        private readonly IMapper _mapper;

        public ProductController(IProductService products, IMapper mapper)
        {
            _Products = products;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var dados = await _Products.GetProducts();
            dados = dados.OrderBy(x => x.Id).ToList();
            return Ok(dados);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var dados = await _Products.GetById(id);
            return Ok(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _Products.Create(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            return Ok(await _Products.UpdateProduct(id, product));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _Products.Delete(id);
            return StatusCode(204);
        }

    }
}
