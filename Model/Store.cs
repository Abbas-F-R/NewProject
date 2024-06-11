using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
    public class Store : BaseEntity
    {
      
        public string? StoreName { get;  set; }
        public string? StorePhone { get;  set; }
        [ForeignKey("User")]
        public Guid UserId { get;  set; }
        public  User? User { get;  set; }
        public  List<Product>? Products { get;  set; }
        public  List<Category>? Categories { get;  set; }
        public  List<Address>? AddressList { get;  set; }

      
    
    }
}