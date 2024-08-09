namespace dotnet.Model
{
    public class Address : BaseEntity
    {
        public string? Name { get; set; }
        public  List<Order>? Orders { get; set; } = new List<Order>();
        public string? AddressLine { get; set; }
        public  string? FullAddress { get; set; }

        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public bool IsMain { get; set; }

        public Guid CityId { get; set; }
        public City? City { get; set; }

        public Guid DistrictId { get; set; }
        public District? District { get; set; }

        public Guid GovernorateId { get; set; }
        public Governorate? Governorate { get; set; }

        public Guid? StoreId { get; set; }
        public Store? Store { get; set; }
       
    }
}