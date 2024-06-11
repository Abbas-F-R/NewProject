using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
     [Table("_cart_items")]
    public class CartItem : BaseEntity
    {
      
        [ForeignKey("Cart")]
        public Guid CartId { get;  set; }
        public required Cart Cart { get;  set; }
       

        [ForeignKey("Product")]
        public Guid ProductId { get;  set; }
        public required Product Product { get; set; }


        [ForeignKey("Address")]
        public Guid AddressId { get; set; }
        public required Address Address { get; set; }

        public int Quantity { get; set; }
        public long PricePerUnit { get; set; }
        
       
    }
}