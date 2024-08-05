using dotnet.DTOs.Clothes;
namespace dotnet.Services.ClothesService;

public interface IClothesService
{
    Task<(ClothesDto? , string? error)> Get(Guid id);
    Task<(ClothesDto?,  string? error)> Create(ClothesForm entity);
    Task<(ClothesDto?,  string? error)> SoftDelete(Guid id);
    Task<(ClothesDto?,  string? error)> Update( ClothesUpdate update, Guid id);
    Task<(List<ClothesDto> product, int? totalCount, string? error)> GetAll(ClothesFilter filter);
}