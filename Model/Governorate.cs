using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
    [Table("governorate")]
    public class Governorate : BaseEntity
    {
        [Required]
        public required string Name { get;  set; }

        public required ICollection<Address> AddressList { get;  set; }

        public required ICollection<District> Districts { get;  set; }

    
    }
}