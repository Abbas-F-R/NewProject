using dotnet.DTOs.Address;
using dotnet.Services.AddressService;
using Microsoft.AspNetCore.Mvc;
namespace dotnet.Controllers;

public class AddressController(IAddressService addressService) : BaseController
{

    [HttpGet("{id}")]
    public async Task<ActionResult<AddressDto>> Get(Guid id) => Ok(await addressService.Get(id));
    
    [HttpPost("/create")]
    public async Task<ActionResult<AddressDto>> Create([FromBody] AddressForm addressForm) => Ok(await addressService.Create(addressForm));
    
    [HttpPut("/Update")]
    public async Task<ActionResult<AddressDto>> Update([FromBody] AddressUpdate addressUpdate, Guid id) => Ok(await addressService.Update(addressUpdate, id));
    
    [HttpDelete("SoftDelete")]
    public async Task<ActionResult<AddressDto>> SoftDelete(Guid id) => Ok(await addressService.SoftDelete(id));
    
    [HttpGet("/GetAll")]
    public async Task<ActionResult<List<AddressDto>>> GetAll([FromQuery]AddressFilter filter) => Ok(await addressService.GatAll(filter));
    
    
    
}