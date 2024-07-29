using dotnet.DTOs.Address;
using dotnet.Services.AddressService;
using Microsoft.AspNetCore.Mvc;
namespace dotnet.Controllers;

public class AddressController : BaseController
{
    private readonly IAddressService _addressService;
    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AddressDto>> Get(Guid id) => Ok(await _addressService.Get(id));
    
    [HttpPost("/create")]
    public async Task<ActionResult<AddressDto>> Create(AddressForm addressForm) => Ok(await _addressService.Create(addressForm));
    
    [HttpPut("/Update")]
    public async Task<ActionResult<AddressDto>> Update(AddressUpdate addressUpdate, Guid id) => Ok(await _addressService.Update(addressUpdate, id));
    
    [HttpDelete("SoftDelete")]
    public async Task<ActionResult<AddressDto>> SoftDelete(Guid id) => Ok(await _addressService.SoftDelete(id));
    
    [HttpGet("/GetAll")]
    public async Task<ActionResult<List<AddressDto>>> GetAll(AddressFilter filter) => Ok(await _addressService.GatAll(filter));
    
    
    
}