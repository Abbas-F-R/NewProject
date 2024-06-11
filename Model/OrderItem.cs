using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
    [Table("_order_items")]
    public class OrderItem :BaseEntity
    {
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public required Order Order { get;  set; }

        public required Product Product { get;  set; }

        public int Quantity { get;  set; }

        public long PricePerUnit { get;  set; }


    }
}