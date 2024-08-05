namespace dotnet.DTOs.Clothes;

public class ClothesUpdate
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public long? Price { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? StoreId { get; set; }
    public string? Material { get; set; }
    public List<ProductVariant>? ProductVariants { get; set; }


}