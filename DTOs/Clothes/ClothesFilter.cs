namespace dotnet.DTOs.Clothes;

public class ClothesFilter : BaseFilter
{
    public Guid? CategoryId { get; set; }
    public Guid? ProductStatus { get; set; }
    public long? LowestPrice { get; set; }
    public long? HighestPrice { get; set; }
    public string? Material { get; set; }

}