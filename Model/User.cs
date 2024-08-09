
namespace dotnet.Model
{
    public class User : BaseEntity
    {
        
        public string? PasswordHash { get; set; } 
        
        public string? Username { get; set; } 
        public Role Role { get;  set; }
        public  List<Cart>? Carts { get;  set; }
        public  List<LikeProduct>? LikeProductList { get;  set; }
        public  List<Order>? OrderList { get;  set; }

    
    }
}
