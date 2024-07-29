using dotnet.Interface;

namespace dotnet.Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

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

    public RepositoryWrapper(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IAddressRepository Address => _address ??= new AddressRepository(_context, _mapper);
    public ICartRepository Cart => _cart ??= new CartRepository(_context, _mapper);
    public ICartItemRepository CartItem => _cartItem ??= new CartItemRepository(_context, _mapper);
    public ICategoryRepository Category => _category ??= new CategoryRepository(_context, _mapper);
    public ICityRepository City => _city ??= new CityRepository(_context, _mapper);
    public IDistrictRepository District => _district ??= new DistrictRepository(_context, _mapper);
    public IGovernorateRepository Governorate => _governorate ??= new GovernorateRepository(_context, _mapper);
    public ILikeProductRepository LikeProduct => _likeProduct ??= new LikeProductRepository(_context, _mapper);
    public IOrderRepository Order => _order ??= new OrderRepository(_context, _mapper);
    public IOrderItemRepository OrderItem => _orderItem ??= new OrderItemRepository(_context, _mapper);
    public IProductRepository Product => _product ??= new ProductRepository(_context, _mapper);
    public IProductStatusRepository ProductStatus => _productStatus ??= new ProductStatusRepository(_context, _mapper);
    public IStoreRepository Store => _store ??= new StoreRepository(_context, _mapper);
    public IUserRepository User => _user ??= new UserRepository(_context, _mapper);
}