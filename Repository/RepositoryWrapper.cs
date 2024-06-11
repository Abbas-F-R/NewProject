using dotnet.Interface;

namespace dotnet.Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    private IAddressRepository _address;
    private ICartRepository _cart;
    private ICartItemRepository _cartItem;
    private ICategoryRepository _category;
    private ICityRepository _city;
    private IDistrictRepository _district;
    private IGovernorateRepository _governorate;
    private ILikeProductRepository _likeProduct;
    private IOrderRepository _order;
    private IOrderItemRepository _orderItem;
    private IProductRepository _product;
    private IProductStatusRepository _productStatus;
    private IStoreRepository _store;
    private IUserRepository _user;

    public RepositoryWrapper(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IAddressRepository Address
    {
        get
        {
            if (_address == null) _address = new AddressRepository(_context, _mapper);
            return _address;
        }
    }

    public ICartRepository Cart
    {
        get
        {
            if (_cart == null) _cart = new CartRepository(_context, _mapper);
            return _cart;
        }
    }

    public ICartItemRepository CartItem
    {
        get
        {
            if (_cartItem == null) _cartItem = new CartItemRepository(_context, _mapper);
            return _cartItem;
        }
    }

    public ICategoryRepository Category
    {
        get
        {
            if (_category == null) _category = new CategoryRepository(_context, _mapper);
            return _category;
        }
    }

    public ICityRepository City
    {
        get
        {
            if (_city == null) _city = new CityRepository(_context, _mapper);
            return _city;
        }
    }

   

    public IDistrictRepository District
    {
        get
        {
            if (_district == null) _district = new DistrictRepository(_context, _mapper);
            return _district;
        }
    }

    public IGovernorateRepository Governorate
    {
        get
        {
            if (_governorate == null) _governorate = new GovernorateRepository(_context, _mapper);
            return _governorate;
        }
    }

    public ILikeProductRepository LikeProduct
    {
        get
        {
            if (_likeProduct == null) _likeProduct = new LikeProductRepository(_context, _mapper);
            return _likeProduct;
        }
    }

    public IOrderRepository Order
    {
        get
        {
            if (_order == null) _order = new OrderRepository(_context, _mapper);
            return _order;
        }
    }

    public IOrderItemRepository OrderItem
    {
        get
        {
            if (_orderItem == null) _orderItem = new OrderItemRepository(_context, _mapper);
            return _orderItem;
        }
    }

    public IProductRepository Product
    {
        get
        {
            if (_product == null) _product = new ProductRepository(_context, _mapper);
            return _product;
        }
    }

    public IProductStatusRepository ProductStatus
    {
        get
        {
            if (_productStatus == null) _productStatus = new ProductStatusRepository(_context, _mapper);
            return _productStatus;
        }
    }

  
    public IStoreRepository Store
    {
        get
        {
            if (_store == null) _store = new StoreRepository(_context, _mapper);
            return _store;
        }
    }

    public IUserRepository User
    {
        get
        {
            if (_user == null) _user = new UserRepository(_context, _mapper);
            return _user;
        }
    }
    
}