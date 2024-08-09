namespace dotnet.DTOs.Product;

public class ProductForm
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public long Price { get; set; }
    public long NumberOfLikes { get; set; }
    public Guid? StoreId { get; set; }
    public Guid? CategoryId { get; set; }
    public required string Status { get; set; }
    public List<ProductVariant>? ProductVariants { get; set; }
    public List<string>? FilePath { get; set; }
}