using dotnet.DTOs.Product;
namespace dotnet.DTOs.Book;

public class BookDto : ProductDto
{
    public string? Author { get; set; }
    public string? Isbn { get; set; }
    public int PageCount { get; set; }
}