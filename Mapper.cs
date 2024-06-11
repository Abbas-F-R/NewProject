

using dotnet.DTOs.Product;

namespace dotnet
{
    public class Mapper : Profile
    {
        public Mapper()
        {
        CreateMap<ProductDto, Product>();

        CreateMap<Product, ProductDto>();

        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.ProductStatus.Status));

        CreateMap<UserDto, User>();
        }
        
    }
}