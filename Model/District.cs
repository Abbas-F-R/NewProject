using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
    [Table("district")]
    public class District : BaseEntity
    {
    
        public required string Name { get;  set; }

        public required ICollection<Address> AddressList { get;  set; }

        public required ICollection<City> CityList { get;  set; }

        [ForeignKey("Governorate")]
        public Guid GovernorateId { get;  set; }
        public required Governorate Governorate { get;  set; }

    }
}