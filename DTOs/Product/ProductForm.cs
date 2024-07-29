namespace dotnet.DTOs.Product
{
    public class ProductForm
    {
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string ProductDescription { get; set; }
    public long Price { get; set; }
    public long NumberOfLikes { get; set; }
    public Guid? StoreId { get; set; }
    public Guid? CategoryId { get; set; }
    public required string Status { get; set; }
    }
    
}