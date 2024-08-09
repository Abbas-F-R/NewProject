using dotnet.DTOs.Vehicle;
namespace dotnet.Services.VehicleService;

public interface IVehicleService
{
    Task<(VehicleDto? vehicle, string? error)> Get(Guid id);
    Task<(VehicleDto? vehicle, string? error)> Create(VehicleForm form);
    Task<(VehicleDto? vehicle, string? error)> SoftDelete(Guid id);
    Task<(VehicleDto? vehicle, string? error)> Update(VehicleUpdate update, Guid id);
    Task<(List<VehicleDto> vehicles, int? totalCount, string? error)> GetAll(VehicleFilter filter);

}