namespace dotnet.Model;

public class Book : Product
{
    public string? Author { get; set; }
    public string? Isbn { get; set; }
    public int PageCount { get; set; }
}