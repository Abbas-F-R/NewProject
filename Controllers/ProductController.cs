using dotnet.DTOs.Product;
using dotnet.Services.ProductService;
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
        public async Task<IActionResult> Create(ProductForm product) =>
            Ok(await _productService.Create(product));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) => Ok(await _productService.SoftDelete(id));

        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] ProductFilter filter) => Ok(await _productService.GetAll(filter));


        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(Guid id,  ProductUpdate productUpdate) =>
            Ok(await _productService.Update(productUpdate, id));
    }
}