using dotnet.DTOs.Address;
using dotnet.Services.AddressService;
using Microsoft.AspNetCore.Mvc;
namespace dotnet.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class AddressController(IAddressService addressService) : BaseController
{

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id) => Ok(await addressService.Get(id));
    
    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] AddressForm addressForm) => Ok(await addressService.Create(addressForm));
    
    [HttpPut("Update/{id}")]
    public async Task<ActionResult> Update([FromBody] AddressUpdate addressUpdate, Guid id) => Ok(await addressService.Update(addressUpdate, id));
    
    [HttpDelete("softDelete/{id}")]
    public async Task<ActionResult> SoftDelete(Guid id) => Ok(await addressService.SoftDelete(id));
    
    [HttpGet("all")]
    public async Task<ActionResult> GetAll([FromQuery] AddressFilter filter) => Ok(await addressService.GatAll(filter));
    
    
    
}