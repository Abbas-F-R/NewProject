using dotnet.DTOs.Address;
namespace dotnet.Services.AddressService;

public interface IAddressService 
{

    Task<(AddressDto? , string? error)> Get(Guid id);
    Task<(AddressDto?,  string? error)> Create(AddressForm entity);
    Task<(AddressDto?,  string? error)> SoftDelete(Guid id);
    Task<(AddressDto? Data, string? error)> Update(AddressUpdate addressUpdate, Guid id);
    Task<(List<AddressForm>? Data, int? CountTotele, string? error)> GatAll(AddressFilter filter);
}