using dotnet.DTOs.Product;
namespace dotnet.DTOs.Book;

public class BookFilter : ProductFilter
{
    public string? Author { get; set; }
    public string? Isbn { get; set; }
}