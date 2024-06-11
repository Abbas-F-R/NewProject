using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
    [Table("_product")]
    public class Product : BaseEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public long Price { get; set; }

        public long NumberOfLikes { get; set; }

        [ForeignKey("ProductStatus")] public Guid ProductStatusId { get; set; }

        public  ProductStatus? ProductStatus { get; set; }

        public  List<OrderItem>? OrderItems { get; set; }

        public  List<DataFile>? DataFiles { get; set; }

        public  List<LikeProduct>? LikesOfProduct { get; set; }

        [ForeignKey("Category")] public Guid CategoryId { get; set; }
        public  Category? Category { get; set; }

        [ForeignKey("Store")]
        public Guid StoreId { get; set; }
        public Store? Store { get; set; }
    }
}