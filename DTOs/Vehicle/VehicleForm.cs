using dotnet.DTOs.Product;
namespace dotnet.DTOs.Vehicle;

public class VehicleForm : ProductForm
{
    public string? Make { get; set; } // العلامة التجارية
    public string? Model { get; set; } // النموذج
    public string? Year { get; set; } // سنة الصنع
    public string? Type { get; set; } // نوع السيارة (مثل: سيدان، SUV، إلخ)
}