using dotnet.DTOs.Product;
namespace dotnet.DTOs.Clothes;

public class ClothesFilter : ProductFilter
{
    public string? Material { get; set; }
}