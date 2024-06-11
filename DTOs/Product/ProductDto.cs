using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.DTOs
{
    public class ProductDto
    {
    public string? Name{get; set;}
    public string? Description{get; set;}
    public long Price{get; set;}
    public Guid? CategoryId{get; set;}
    public Guid? StoreId{get; set;}


    }
}