namespace dotnet.Model;

public class Vehicle : Product
{
    public string? Make { get; set; } // العلامة التجارية
    public string? Model { get; set; } // النموذج
    public int Year { get; set; } // سنة الصنع
    public string? Type { get; set; } // نوع السيارة (مثل: سيدان، SUV، إلخ)
}