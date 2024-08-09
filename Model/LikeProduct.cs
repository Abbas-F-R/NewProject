using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
    [Table("_Like_Product")]
    public class LikeProduct : BaseEntity
    {
        public Guid ProductId { get; set; }
        public required Product Product { get;  set; }
       
        public Guid UserId { get; set; }
        public required User User { get;  set; }

       

    }
}