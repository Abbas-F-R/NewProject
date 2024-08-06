using dotnet.DTOs.Product;
using dotnet.Services.ClothesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace dotnet.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ClothesController(IClothesService service) : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<ClothesDto>> GetById(Guid id) => Ok(await service.Get(id));

    [HttpPost("Create"), Authorize(Roles = "User")]
    public async Task<IActionResult> Create([FromBody] ClothesForm form) =>
        Ok(await service.Create(form));


    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id) => Ok(await service.SoftDelete(id));

    [HttpGet("GetAll")]
    public async Task<IActionResult> FindAll([FromQuery] ClothesFilter filter) => Ok(await service.GetAll(filter));

    [HttpPut("Update/{id}")]
    public async Task<ActionResult<ProductDto>> Update(Guid id, [FromBody] ClothesUpdate update) =>
        Ok(await service.Update(update, id));
}