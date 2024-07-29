

namespace dotnet.Model
{
    public class Category : BaseEntity
    {
        public string? CategoryName { get;  set; }
        public string? CategoryDescription { get; set; } 
        public  List<Product>? Products { get;  set; }
        public Guid? StoreId { get;  set; }
        public  Store? Store { get;  set; }


    }
}