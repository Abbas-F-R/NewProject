using dotnet.DTOs.Product;
using dotnet.Interface;

namespace dotnet.Services.ProductService
{
    public class ProductService(IRepositoryWrapper wrapper, IMapper mapper) : IProductService
    {


        public async Task<(ProductDto?, string? error)> Get(Guid id)
        {
            var result = await wrapper.Product.Get(p => p.Id == id ,x => x.Include(y => y.ProductVariants)!);
            if (result == null)
                return (null, " Product not found");
            return (mapper.Map<ProductDto>(result), null);
        }


        public async Task<(ProductDto?, string? error)> Create(ProductForm dto)
        {
            var product = mapper.Map<Product>(dto);
            if (dto.CategoryId == null && dto.StoreId == null)
            {
                return (null, "Both CategoryId and StoreId cannot be null.");
            }
            var category = await wrapper.Category.Get(x => x.Id == product.CategoryId);
            if (category == null)
            {
                return (null, "Category not found");
            }

            var store = await wrapper.Store.Get(x => x.Id == product.StoreId);
            if (store == null)
            {
                return (null, "Store not found");
            }

            product.Category = category;
            product.Store = store;

            var result = await wrapper.Product.Add(product);
            return (mapper.Map<ProductDto>(result), null);
        }
       


        public async Task<(ProductDto?, string? error)> Update(ProductUpdate productUpdate, Guid id)
        {
            var product = await wrapper.Product.Get(x => x.Id == id);
            if (product == null) return (null, "product dose not exist");
            // نيابتا عن اليوزر
            if (product.StoreId != productUpdate.StoreId) return (null, "You are not authorized to update this review");
            product = mapper.Map<Product>(productUpdate);
            var result = await wrapper.Product.Update(product);
            return (mapper.Map<ProductDto>(result), null);
        }
        
        public async Task<(ProductDto?, string? error)> SoftDelete(Guid id)
        {
            var result = await wrapper.Product.GetById(id);
            if (result == null) return (null, "product dose not exist");
            var delete = await wrapper.Product.SoftDelete(id);
            if (delete == null) return (null, " cannot delete it");
            return (mapper.Map<ProductDto>(result), null);
        }


       
        public async Task<(List<ProductForm> product, int? totalCount, string? error)> GetAll(ProductFilter filter)
        {
            var (data, totalElements) = await wrapper.Product.GetAll(p =>
                    (!filter.CategoryId.HasValue || p.CategoryId == filter.CategoryId.Value) &&
                    (!filter.ProductStatus.HasValue || p.ProductStatusId == filter.ProductStatus.Value) &&
                    (!filter.LowestPrice.HasValue || p.Price >= filter.LowestPrice.Value) &&
                    (!filter.HighestPrice.HasValue || p.Price <= filter.HighestPrice.Value),x => x.Include(y => y.ProductVariants)!, filter.PageNumber, filter.PageSize);
            var result = mapper.Map<List<ProductForm>>(data);
            return (result, totalElements, null);
        }
    }
}