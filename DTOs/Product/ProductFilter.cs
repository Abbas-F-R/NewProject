namespace dotnet.DTOs.Product;

public class ProductFilter
{
    public Guid? CategoryId { get; set; }
    public Guid? ProductStatus { get; set; }
    public long? LowestPrice { get; set; }
    public long? HighestPrice { get; set; }
    public int PageNumber { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}