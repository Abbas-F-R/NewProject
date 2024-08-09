using dotnet.DTOs.Vehicle;
namespace dotnet.Services.VehicleService;

public class VehicleService(IRepositoryWrapper wrapper, IMapper mapper) : IVehicleService
{

    public async Task<(VehicleDto? vehicle, string? error)> Get(Guid id)
        {
            var result = await wrapper.Vehicles.Get(v => v.Id == id, x => x.Include(y => y.ProductVariants)!);
            if (result == null)
                return (null, "Vehicle not found");
            return (mapper.Map<VehicleDto>(result), null);
        }

        public async Task<(VehicleDto? vehicle, string? error)> Create(VehicleForm form)
        {
            var vehicle = mapper.Map<Vehicle>(form);
            if (form.CategoryId == null && form.StoreId == null)
            {
                return (null, "Both CategoryId and StoreId cannot be null.");
            }

            var category = await wrapper.Category.Get(x => x.Id == vehicle.CategoryId);
            if (category == null)
            {
                return (null, "Category not found");
            }

            var store = await wrapper.Store.Get(x => x.Id == vehicle.StoreId);
            if (store == null)
            {
                return (null, "Store not found");
            }

            vehicle.Category = category;
            vehicle.Store = store;

            var result = await wrapper.Vehicles.Add(vehicle);
            return (mapper.Map<VehicleDto>(result), null);
        }

        public async Task<(VehicleDto? vehicle, string? error)> Update(VehicleUpdate vehicleUpdate, Guid id)
        {
            var vehicle = await wrapper.Vehicles.Get(v => v.Id == id);
            if (vehicle == null) return (null, "Vehicle does not exist");

            // Check authorization or other logic here
            if (vehicle.StoreId != vehicleUpdate.StoreId) 
                return (null, "You are not authorized to update this vehicle");

            vehicle = mapper.Map<Vehicle>(vehicleUpdate);
            var result = await wrapper.Vehicles.Update(vehicle);
            return (mapper.Map<VehicleDto>(result), null);
        }

        public async Task<(VehicleDto? vehicle, string? error)> SoftDelete(Guid id)
        {
            var result = await wrapper.Vehicles.GetById(id);
            if (result == null) return (null, "Vehicle does not exist");
            var delete = await wrapper.Vehicles.SoftDelete(id);
            if (delete == null) return (null, "Cannot delete it");
            return (mapper.Map<VehicleDto>(result), null);
        }

        public async Task<(List<VehicleDto> vehicles, int? totalCount, string? error)> GetAll(VehicleFilter filter)
        {
            var (data, totalElements) = await wrapper.Vehicles.GetAll(v =>
                    (!filter.CategoryId.HasValue || v.CategoryId == filter.CategoryId.Value) &&
                    (!filter.ProductStatus.HasValue || v.ProductStatusId == filter.ProductStatus.Value) &&
                    (!filter.LowestPrice.HasValue || v.Price >= filter.LowestPrice.Value) &&
                    (!filter.HighestPrice.HasValue || v.Price <= filter.HighestPrice.Value) &&
                    (string.IsNullOrEmpty(filter.Make) || v.Make == filter.Make) &&
                    (string.IsNullOrEmpty(filter.Model) || v.Model == filter.Model) &&
                    (string.IsNullOrEmpty(filter.Year) || v.Year == filter.Year) &&
                    (string.IsNullOrEmpty(filter.Type) || v.Type == filter.Type),
                x => x.Include(y => y.ProductVariants)!, filter.PageNumber, filter.PageSize);

            var result = mapper.Map<List<VehicleDto>>(data);
            return (result, totalElements, null);
        }
    }
