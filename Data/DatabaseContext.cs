
namespace dotnet.Data
{
    public class DatabaseContext : DbContext
    {
          public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set;}
        public DbSet<Address> Address { get; set;}
        public DbSet<Order> Orders { get; set;}
        public DbSet<Product> Products { get; set;}
        public DbSet<OrderItem> OrderItems { get; set;}
        public DbSet<Cart> Carts { get; set;}
        public DbSet<CartItem> CartItems { get; set;}
        public DbSet<District> Districts { get; set;}
        public DbSet<City> Cities { get; set;}
        public DbSet<Governorate> Governorates { get; set;}
        public DbSet<DataFile> DataFiles { get; set;}
        public DbSet<Category> Categories { get; set;}
        public DbSet<LikeProduct> LikeProducts { get; set;}
        public DbSet<ProductStatus> ProductStatus { get; set;}
        public DbSet<Store> Stores { get; set;}

    }
}