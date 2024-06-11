namespace dotnet.Interface;

public interface IRepositoryWrapper
{
    IAddressRepository Address { get; }
    ICartRepository Cart { get; }
    ICartItemRepository CartItem { get; }
    ICategoryRepository Category { get; }
    ICityRepository City { get; }
    IDistrictRepository District { get; }
    IGovernorateRepository Governorate { get; }
    ILikeProductRepository LikeProduct { get; }
    IOrderRepository Order { get; }
    IOrderItemRepository OrderItem { get; }
    IProductRepository Product { get; }
    IProductStatusRepository ProductStatus { get; }
    IStoreRepository Store { get; }
    IUserRepository User { get; }
}