namespace dotnet.DTOs;

public class ProductUpdate
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public long? Price { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? StoreId { get; set; }
}