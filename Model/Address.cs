using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
   [Table("_address")]
    public class Address : BaseEntity
    {
       

        public required  List<Order> Orders { get; set; }
        public required string AddressLine { get; set; }
        public required string FullAddress { get; set; }

        public int Latitude { get; set; }

        public int Longitude { get; set; }

        public bool IsMain { get; set; }
        
        [ForeignKey("City")]
        public Guid CityId { get;  set; }
        public required City City { get; set; }

        [ForeignKey("District")]
        public Guid DistrictId { get;  set; }
          public required District District { get;  set; }
        [ForeignKey("Governorate")]
        public Guid GovernorateId { get;  set; }
        public required Governorate Governorate { get; set; }

        [ForeignKey("Store")]
        public Guid? StoreId { get;  set; }
        public required Store Store { get; set; }


       
    }
}