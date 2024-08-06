namespace dotnet.DTOs.Book;

public class BookUpdate
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public long? Price { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? StoreId { get; set; }
    public List<ProductVariant>? ProductVariants { get; set; }

    public string? Author { get; set; }
    public string? Isbn { get; set; }
    public int PageCount { get; set; }
}