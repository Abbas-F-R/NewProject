namespace dotnet.Model;

public class ProductVariant : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; } 
    // Attribute details as JSON
    [MaxLength(300)]
    public string? AttributesJson { get; set; }
}