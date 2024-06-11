using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
    
    [Table("_product_status")]
    public class ProductStatus : BaseEntity
    {
        [Required]
        public required string Status { get;  set; }

        public required List<Product> ProductList { get;  set; }

       

    }
}