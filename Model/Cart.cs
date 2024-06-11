using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
     [Table("_cart")]
    public class Cart : BaseEntity
    {
        public required List<Order> Orders { get;  set; }

        [ForeignKey("User")]
        public Guid UserId { get;  set; }

        public required User User { get;  set; }
    }
}