namespace dotnet.DTOs.Address;

public class AddressDto
{
    public required string AddressLine { get; set; }
    public required string FullAddress { get; set; }

    public int Latitude { get; set; }

    public int Longitude { get; set; }

    public bool? IsMain { get; set; }
    public Guid? GovernorateId { get; set; }
    public string? GovernorateName { get; set; }
}