using dotnet.DTOs.Product;
using dotnet.Repository;

namespace dotnet.Services.ProductService;

public interface IProductService : IBaseService<ProductDto>
{
    Task<(ProductDto?,  string? error)> Update( ProductUpdate update, Guid id);
    Task<(List<ProductDto> product, int? totalCount, string? error)> FindAll(ProductFilter filter);
}

