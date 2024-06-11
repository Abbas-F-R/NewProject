global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.DTOs.Product;
using dotnet.Exceptions;
using dotnet.Interface;
using Microsoft.VisualBasic;

namespace dotnet.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _wrapper;
        private IProductService _productServiceImplementation;

        public ProductService(IRepositoryWrapper wrapper, IMapper mapper)
        {
            _wrapper = wrapper;
            _mapper = mapper;
        }

        // public async Task<(ProductDto? , string? error)> DeleteById<ProductDto>(Guid id)
        // {
        //     var order = await _wrapper.Product.Get(x => x.Id == id);
        //     if (order == null) return (null, "المنتج غير موجود");
        //     var delete = await _wrapper.Product.SoftDelete(id);
        //     if (delete == null) return (null, "لا يمكن حذف المنتج");
        //     return (order, null);
        // }

        //
        // public async Task<PageResponse<ProductResponse>> FindAllPage(Guid? categoryId, Guid? productStatus,
        //     long? lowestPrice, long? highestPrice, int pageNumber, int pageSize)
        // {
        //     var query = _context.Products.AsNoTracking().AsQueryable();
        //     query = query.Where(p =>
        //         (!categoryId.HasValue || p.CategoryId == categoryId.Value) &&
        //         (!productStatus.HasValue || p.ProductStatusId == productStatus.Value) &&
        //         (!lowestPrice.HasValue || p.Price >= lowestPrice.Value) &&
        //         (!highestPrice.HasValue || p.Price <= highestPrice.Value));
        //
        //     var totalElements = await query.CountAsync();
        //     var products = await query.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
        //     var pageResponse = products.Select(p => _mapper.Map<ProductResponse>(p)).ToList();
        //     int totalPage = (int)Math.Ceiling(totalElements / (double)pageSize);
        //
        //     return new PageResponse<ProductResponse>
        //     {
        //         Content = pageResponse,
        //         PageNo = pageNumber,
        //         PageSize = pageSize,
        //         TotalElement = totalElements,
        //         TotalPage = totalPage,
        //         IsLast = pageNumber == totalPage - 1
        //     };
        // }
        public async Task<(ProductDto?, string? error)> Get(Guid id)
        {
            var result = await _wrapper.Product.Get(x => x.Id == id);
            if (result == null)
                return (null, " Product not found");

            return (_mapper.Map<ProductDto>(result), null);
        }

        


        public async Task<(ProductDto?, string? error)> Create(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            if (dto.CategoryId == null && dto.StoreId == null)
            {
                return (null, "Both CategoryId and StoreId cannot be null.");
            }

            var category = await _wrapper.Category.Get(x => x.Id == product.CategoryId);
            if (category == null) return (null, "Category not found");
            var store = await _wrapper.Store.Get(x => x.Id == product.StoreId);
            if (store == null) return (null, " Store not found");

            product.Category = category;
            product.Store = store;

            var result = await _wrapper.Product.Add(product);
            return (_mapper.Map<ProductDto>(result), null);
        }

     

        public async Task<(ProductDto?, string? error)> Update(ProductUpdate productUpdate, Guid id)
        {
            var product = await _wrapper.Product.Get(x => x.Id == id);
            if (product == null) return (null, "product dose not exist");
            // نيابتا عن اليوزر
            if (product.StoreId != productUpdate.StoreId) return (null, "You are not authorized to update this review");
            product = _mapper.Map<Product>(productUpdate);
            var result = await _wrapper.Product.Update(product);
            return (_mapper.Map<ProductDto>(result), null);
        }

        public async Task<(ProductDto?, string? error)> Delete(Guid id)
        {
            var result = await _wrapper.Product.Get(x => x.Id == id);
            if (result == null) return (null, "product dose not exist");
            var delete = await _wrapper.Product.SoftDelete(id);
            if (delete == null) return (null, " cannot delete it");
            return (_mapper.Map<ProductDto>(result), null);
        }

        public async Task<(List<ProductDto> product, int? totalCount, string? error)> FindAll(ProductFilter filter)
        {
            var (data, totalElements) = await _wrapper.Product.GetAll<ProductResponse>(p =>
                (!filter.CategoryId.HasValue || p.CategoryId == filter.CategoryId.Value) &&
                (!filter.ProductStatus.HasValue || p.ProductStatusId == filter.ProductStatus.Value) &&
                (!filter.LowestPrice.HasValue || p.Price >= filter.LowestPrice.Value) &&
                (!filter.HighestPrice.HasValue || p.Price <= filter.HighestPrice.Value), filter.PageNumber, filter.PageSize);
            var result = _mapper.Map<List<ProductDto>>(data);
            return (result, totalElements, null);
            
        }
    }
}