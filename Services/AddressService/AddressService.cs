using dotnet.DTOs.Address;
using dotnet.Interface;
namespace dotnet.Services.AddressService;

public class AddressService(IRepositoryWrapper wrapper, IMapper mapper) : IAddressService
{

    public async Task<(AddressDto?, string? error)> Get(Guid id)
    {
        var result = await wrapper.Address.Get(a => a.Id == id);
        if (result == null)
        {
            return (null, "Address NotFound");
        }

        return (mapper.Map<AddressDto>(result), null);
    }
    public async Task<(AddressDto?, string? error)> Create(AddressForm entity)
    {
        var address = mapper.Map<Address>(entity);
        var result = await wrapper.Address.Add(address);
        if (result == null) return (null, "Error in creating Address");
        return (mapper.Map<AddressDto>(result), null);

    }
    public async Task<(AddressDto?, string? error)> SoftDelete(Guid id)
    {
        var result = await wrapper.Address.GetById(id);
        if (result == null)
        {
            return (null, "Address not found ");
        }

        var delete = await wrapper.Address.SoftDelete(id);
        if (delete == null)
        {
            return (null, "Error in deleting Address");
        }

        return (mapper.Map<AddressDto>(delete), null);
    }
    public async Task<(AddressDto? Data, string? error)> Update(AddressUpdate addressUpdate, Guid id)
    {
        var result = await wrapper.Address.GetById(id);
        if (result == null)
        {
            return (null, "Address not found ");
        }

        result = mapper.Map<Address>(addressUpdate);
        var update = await wrapper.Address.Update(result, id);
        if (result == null)
        {
            return (null, "Address not found ");
        }

        return (mapper.Map<AddressDto>(update), null);

    }
    public async Task<(List<AddressForm>? Data, int? CountTotele, string? error)> GatAll(AddressFilter filter)
    {
        var (data, totalElements) = await wrapper.Address.GetAll(
            a => a.Name == filter.Name, filter.PageSize, filter.PageNumber);
        var result = mapper.Map<List<AddressForm>>(data);
        return (result, totalElements, null);
    }
}