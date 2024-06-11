using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
    [Table("_order")]
    public class Order : BaseEntity
    {
        public bool Delivered { get;  set; }

        public required ICollection<OrderItem> OrderItems { get;  set; }
       
        [ForeignKey("Cart")]
        public Guid CartId { get;  set; }
        public required Cart Cart { get;  set; }
        
        [ForeignKey("User")]
        public Guid UserId { get;  set; }
        public required User User { get;  set; }
        
        [ForeignKey("Address")]
        public Guid AddressId { get;  set; }
        public required Address Address { get;  set; }

       
    }
}