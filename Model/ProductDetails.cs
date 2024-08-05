namespace dotnet.Model;

public class ProductDetails : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}