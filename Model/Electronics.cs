namespace dotnet.Model;

public class Electronics : Product
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int WarrantyPeriodMonths { get; set; }
}