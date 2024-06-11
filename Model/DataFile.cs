using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Model
{
    [Table("_data_file")]
    public class DataFile : BaseEntity
    {
        public required string FileName { get; set; }
        public required string FileType { get; set; }
        public required byte[] Data { get; set; }
        public required Product Product { get; set; }

        [ForeignKey("Store")]
        public Guid StorId { get; set; }
        public required Store Store { get; set; }

    }
}