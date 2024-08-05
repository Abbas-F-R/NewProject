using dotnet.DTOs.Address;
using dotnet.Interface;
namespace dotnet.Services.AddressService;

public class AddressService : IAddressService
{

    private readonly IRepositoryWrapper _wrapper;
    private readonly IMapper _mapper;
    public AddressService(IRepositoryWrapper wrapper, IMapper mapper)
    {
        _wrapper = wrapper;
        _mapper = mapper;
    }
    public async Task<(AddressDto?, string? error)> Get(Guid id)
    {
        var result = await _wrapper.Address.Get(a => a.Id == id);
        if (result == null)
        {
            return (null, "Address NotFound");
        }
        return (_mapper.Map<AddressDto>(result), null);
    }
    public async Task<(AddressDto?, string? error)> Create(AddressForm entity)
    {
        var address = _mapper.Map<Address>(entity);
        var result = await _wrapper.Address.Add(address);
        if (result == null) return (null, "Error in creating Address");
        return (_mapper.Map<AddressDto>(result), null);

    }
    public async Task<(AddressDto?, string? error)> SoftDelete(Guid id)
    {
        var result = await _wrapper.Address.GetById(id);
        if (result == null)
        {
            return (null, "Address not found ");
        }
        var delete = await _wrapper.Address.SoftDelete(id);
        if (delete == null)
        {
            return (null, "Error in deleting Address");
        }

        return (_mapper.Map<AddressDto>(delete), null);
    }
    public async Task<(AddressDto? Data, string? error)> Update(AddressUpdate addressUpdate, Guid id)
    {
        var result = await _wrapper.Address.GetById(id);
        if (result == null)
        {
            return (null, "Address not found ");
        }
        result = _mapper.Map<Address>(addressUpdate);
        var update = await _wrapper.Address.Update(result, id);
        if (result == null)
        {
            return (null, "Address not found ");
        }
        return (  _mapper.Map<AddressDto>(update), null);

    }
    public async Task<(List<AddressDto>? Data, int? CountTotele, string? error)> GatAll(AddressFilter filter)
    {
        var (data, totalElements)  = await _wrapper.Address.GetAll(
            a => a.Name == filter.Name, filter.PageSize, filter.PageNumber);
        var result = _mapper.Map<List<AddressDto>>(data);
        return (result, totalElements, null);
    }
}