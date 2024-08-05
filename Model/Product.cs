namespace dotnet.Model
{

    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public long NumberOfLikes { get; set; }
        public Guid ProductStatusId { get; set; }
        public ProductStatus? ProductStatus { get; set; }
        public List<ProductVariant>? ProductVariants { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        public List<DataFile>? DataFiles { get; set; }
        public List<LikeProduct>? LikesOfProduct { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid StoreId { get; set; }
        public Store? Store { get; set; }
    }
}