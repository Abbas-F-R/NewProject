using dotnet.DTOs.Product;

namespace dotnet
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductDto>();

            CreateMap<Product, ProductForm>()
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.Store!.Id))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category!.Id))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.ProductStatus!.Status));

            CreateMap<UserDto, User>();
        }
    }
}