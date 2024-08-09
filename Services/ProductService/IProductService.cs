using dotnet.DTOs.Product;

namespace dotnet.Services.ProductService;

public interface IProductService 
{
    Task<(ProductDto? , string? error)> Get(Guid id);
    Task<(ProductDto?,  string? error)> Create(ProductForm form);
    Task<(ProductDto?,  string? error)> SoftDelete(Guid id);
    Task<(ProductDto?,  string? error)> Update( ProductUpdate update, Guid id);
    Task<(List<ProductDto> product, int? totalCount, string? error)> GetAll(ProductFilter filter);
}

