namespace dotnet.Model
{
    public class City : BaseEntity
    {
        public string? Name { get;  set; }
        public  List<Address>? AddressList { get;  set; }
        public Guid DistrictId { get;  set; }
        public  District? District { get;  set; }

      
    }
}