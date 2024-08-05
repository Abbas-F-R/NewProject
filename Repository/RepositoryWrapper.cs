using dotnet.Interface;

namespace dotnet.Repository;

public class RepositoryWrapper(DatabaseContext context, IMapper mapper) : IRepositoryWrapper
{

    private IAddressRepository? _address;
    private ICartRepository? _cart;
    private ICartItemRepository? _cartItem;
    private ICategoryRepository? _category;
    private ICityRepository? _city;
    private IDistrictRepository? _district;
    private IGovernorateRepository? _governorate;
    private ILikeProductRepository? _likeProduct;
    private IOrderRepository? _order;
    private IOrderItemRepository? _orderItem;
    private IProductRepository? _product;
    private IProductStatusRepository? _productStatus;
    private IStoreRepository? _store;
    private IUserRepository? _user;
    private IClothesRepository? _clothes;

    public IAddressRepository Address => _address ??= new AddressRepository(context, mapper);
    public ICartRepository Cart => _cart ??= new CartRepository(context, mapper);
    public ICartItemRepository CartItem => _cartItem ??= new CartItemRepository(context, mapper);
    public ICategoryRepository Category => _category ??= new CategoryRepository(context, mapper);
    public ICityRepository City => _city ??= new CityRepository(context, mapper);
    public IDistrictRepository District => _district ??= new DistrictRepository(context, mapper);
    public IGovernorateRepository Governorate => _governorate ??= new GovernorateRepository(context, mapper);
    public ILikeProductRepository LikeProduct => _likeProduct ??= new LikeProductRepository(context, mapper);
    public IOrderRepository Order => _order ??= new OrderRepository(context, mapper);
    public IOrderItemRepository OrderItem => _orderItem ??= new OrderItemRepository(context, mapper);
    public IProductRepository Product => _product ??= new ProductRepository(context, mapper);
    public IProductStatusRepository ProductStatus => _productStatus ??= new ProductStatusRepository(context, mapper);
    public IStoreRepository Store => _store ??= new StoreRepository(context, mapper);
    public IUserRepository User => _user ??= new UserRepository(context, mapper);
    public IClothesRepository Clothes => _clothes ??= new ClothesRepository(context, mapper);
}