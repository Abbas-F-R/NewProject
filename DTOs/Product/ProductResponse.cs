namespace dotnet.DTOs.Product
{
    public class ProductResponse
    {
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string ProductDescription { get; set; }
    public long Price { get; set; }
    public long NumberOfLikes { get; set; }
    public required string StoreName { get; set; }
    public required string CategoryName { get; set; }
    public required string Status { get; set; }
    }
    
}