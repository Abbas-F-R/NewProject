namespace dotnet.DTOs.Address;

public class AddressUpdate
{
    public string? Name { get; set; }
    public string? FullAddress { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public bool? IsMain { get; set; }
    public Guid? GovernorateId { get; set; }
}