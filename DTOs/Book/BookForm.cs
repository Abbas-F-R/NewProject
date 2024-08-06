namespace dotnet.DTOs.Book;

public class BookForm
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string ProductDescription { get; set; }
    public long Price { get; set; }
    public long NumberOfLikes { get; set; }
    public Guid? StoreId { get; set; }
    public Guid? CategoryId { get; set; }
    public required string Status { get; set; }
    public List<ProductVariant>? ProductVariants { get; set; }

    public string? Author { get; set; }
    public string? Isbn { get; set; }
    public int PageCount { get; set; }
    
}