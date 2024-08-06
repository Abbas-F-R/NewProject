namespace dotnet.DTOs.Book;

public class BookFilter : BaseFilter
{
    public Guid? CategoryId { get; set; }
    public Guid? ProductStatus { get; set; }
    public long? LowestPrice { get; set; }
    public long? HighestPrice { get; set; }
    
    public string? Author { get; set; }
    public string? Isbn { get; set; }
}