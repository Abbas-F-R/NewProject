using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
   [Table("city")]
    public class City : BaseEntity
    {
        public required string Name { get;  set; }

        public required List<Address> AddressList { get;  set; }

        [ForeignKey("District")]
        public Guid DistrictId { get;  set; }
        public required District District { get;  set; }

      
    }
}