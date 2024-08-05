using dotnet.Interface;
namespace dotnet.Services.ClothesService;

public class ClothesService(IRepositoryWrapper wrapper , IMapper mapper) : IClothesService
{
    

    public async Task<(ClothesDto?, string? error)> Get(Guid id)
    {
        var result = await wrapper.Clothes.Get(c => c.Id == id , x => x.Include(y => y.ProductVariants)!);
        if (result == null)
            return (null, " Product not found");
        return (mapper.Map<ClothesDto>(result), null);

    }
    public async Task<(ClothesDto?, string? error)> Create(ClothesForm form)
    {
       var entity = mapper.Map<Clothes>(form);
       if (form.CategoryId == null && form.StoreId == null)
       {
           return (null, "Both CategoryId and StoreId cannot be null.");
       }
       var category = await wrapper.Category.Get(x => x.Id == entity.CategoryId);
       if (category == null)
       {
           return (null, "Category not found");
       }

       var store = await wrapper.Store.Get(x => x.Id == entity.StoreId);
       if (store == null)
       {
           return (null, "Store not found");
       }

       entity.Category = category;
       entity.Store = store;

       var result = await wrapper.Clothes.Add(entity);
       return (mapper.Map<ClothesDto>(result), null);
    }
    public async Task<(ClothesDto?, string? error)> SoftDelete(Guid id)
    {
        var result = await wrapper.Clothes.GetById(id);
        if (result == null) return (null, "product dose not exist");
        var delete = await wrapper.Product.SoftDelete(id);
        if (delete == null) return (null, " cannot delete it");
        return (mapper.Map<ClothesDto>(result), null);
    }
    public async Task<(ClothesDto?, string? error)> Update(ClothesUpdate update, Guid id)
    {
        var clothes = await wrapper.Clothes.Get(x => x.Id == id);
        if (clothes == null) return (null, "product dose not exist");
        // نيابتا عن اليوزر
        if (clothes.StoreId != update.StoreId) return (null, "You are not authorized to update this review");
        clothes = mapper.Map<Clothes>(update);
        var result = await wrapper.Product.Update(clothes);
        return (mapper.Map<ClothesDto>(result), null);
        
    }
    
    public async Task<(List<ClothesDto> product, int? totalCount, string? error)> GetAll(ClothesFilter filter)
    {
        var (data, totalElements) = await wrapper.Clothes.GetAll(p =>
            (!filter.CategoryId.HasValue || p.CategoryId == filter.CategoryId.Value) &&
            (!filter.ProductStatus.HasValue || p.ProductStatusId == filter.ProductStatus.Value) &&
            (!filter.LowestPrice.HasValue || p.Price >= filter.LowestPrice.Value) &&
            (!filter.HighestPrice.HasValue || p.Price <= filter.HighestPrice.Value), x => x.Include(y => y.ProductVariants)! ,  filter.PageNumber, filter.PageSize);
        var result = mapper.Map<List<ClothesDto>>(data);
        return (result, totalElements, null);
    }
}