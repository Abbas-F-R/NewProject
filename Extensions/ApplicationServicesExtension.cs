using dotnet.Interface;
using dotnet.Services.AddressService;
using dotnet.Services.AuthService;
namespace dotnet.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
       
        // إضافة DbContext مع اتصال PostgreSQL
        services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

        // إضافة AutoMapper مع التجميع الحالي
        services.AddAutoMapper(typeof(Program).Assembly);

        // إضافة الخدمات بالمدى المحدد (Scoped)
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped<IJwtService, JwtService>(); 
        services.AddScoped<IAddressService, AddressService>();

        //
        // services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        // services.AddScoped<IAddressRepository, AddressRepository>();
        // services.AddScoped<ICartRepository, CartRepository>();
        // services.AddScoped<ICartItemRepository, CartItemRepository>();
        // services.AddScoped<ICategoryRepository, CategoryRepository>();
        // services.AddScoped<ICityRepository, CityRepository>();
        // services.AddScoped<IDistrictRepository, DistrictRepository>();
        // services.AddScoped<IGovernorateRepository, GovernorateRepository>();
        // services.AddScoped<ILikeProductRepository, LikeProductRepository>();
        // services.AddScoped<IOrderRepository, OrderRepository>();
        // services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        // services.AddScoped<IProductRepository, ProductRepository>();
        // services.AddScoped<IProductStatusRepository, ProductStatusRepository>();
        // services.AddScoped<IStoreRepository, StoreRepository>();
        // services.AddScoped<IUserRepository, UserRepository>();
       
        
        return services;

    } 
}