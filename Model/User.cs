
namespace dotnet.Model
{
    public class User : BaseEntity
    {
        
        public required string PasswordHash { get; set; } 
        public  string? RefreshToken { get; set; } 
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpired { get; set; }
        public required string Username { get; set; } 
        public Role Role { get;  set; }
        public  List<Cart>? Carts { get;  set; }
        public  List<LikeProduct>? LikeProductList { get;  set; }
        public  List<Order>? OrderList { get;  set; }

    
    }
}
