namespace dotnet.DTOs.Product;

public class ProductFilter : BaseFilter
{
    public Guid? CategoryId { get; set; }
    public Guid? ProductStatus { get; set; }
    public long? LowestPrice { get; set; }
    public long? HighestPrice { get; set; }
  
}