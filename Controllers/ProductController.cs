using dotnet.DTOs.Product;
using dotnet.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController(IProductService productService) : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id) => Ok(await productService.Get(id));

        [HttpPost, Authorize(Roles = "User")]
        public async Task<IActionResult> Create([FromBody] ProductForm product) =>
            Ok(await productService.Create(product));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) => Ok(await productService.SoftDelete(id));

        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] ProductFilter filter) => Ok(await productService.GetAll(filter));


        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(Guid id, [FromBody] ProductUpdate productUpdate) =>
            Ok(await productService.Update(productUpdate, id));
    }
}