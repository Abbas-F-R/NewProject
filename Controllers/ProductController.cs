using dotnet.DTOs.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id) => Ok(await _productService.Get(id));

        [HttpPost, Authorize(Roles = "User")]
        public async Task<IActionResult> Create(ProductDto productDto) =>
            Ok(await _productService.Create(productDto));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) => Ok(await _productService.Delete(id));

        [HttpGet]
        public async Task<IActionResult> FindAll(ProductFilter filter) => Ok(await _productService.FindAll(filter));


        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(Guid id, ProductUpdate productUpdate) =>
            Ok(await _productService.Update(productUpdate, id));
    }
}