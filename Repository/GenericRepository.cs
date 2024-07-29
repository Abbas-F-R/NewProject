using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using dotnet.Interface;
using Microsoft.EntityFrameworkCore.Query;

namespace dotnet.Repository;

public class GenericRepository<T, TId> : IGenericRepository<T, TId> where T : BaseEntity
{
    protected readonly DatabaseContext _context;
    protected readonly IMapper _mapper;

    protected GenericRepository(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<T?> GetById(TId id, bool deleted = false)
    {
        var result = await _context.Set<T>().FindAsync(id);
        if (result is { IsDeleted : true }) return null;

        return result;
    }


    public async Task<(List<TDto> data, int totalCount)> GetAll<TDto>(int pageNumber = 0, int pageSize = 10,
        bool deleted = false)
    {
        var query = _context.Set<T>().AsNoTracking().Where(t => t.IsDeleted == deleted);
        query = query.OrderByDescending(t => t.CreationDate);
        return await ExecuteQuery<TDto>(query, pageNumber, pageSize);
    }

    public async Task<(List<TDto> data, int totalCount)> GetAll<TDto>(Expression<Func<T, bool>> predicate,
        int pageNumber = 0, int pageSize = 10, bool deleted = false)
    {
        var query = _context.Set<T>().AsNoTracking().Where(predicate).Where(t => t.IsDeleted == deleted);
        return await ExecuteQuery<TDto>(query, pageNumber, pageSize);
    }

    public async Task<(List<T> data, int totalCount)> GetAll(int pageNumber = 0, int pageSize = 10,
        bool deleted = false)
    {
        return await GetAll(null, null, pageNumber, pageSize, deleted);
    }

    public async Task<(List<T> data, int totalCount)> GetAll(Expression<Func<T, bool>> predicate, int pageNumber = 0,
        int pageSize = 10, bool deleted = false)
    {
        return await GetAll(predicate, null, pageNumber, pageSize, deleted);
    }

    public async Task<(List<T> data, int totalCount)> GetAll(
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include,
        int pageNumber = 0, int pageSize = 10, bool deleted = false)
    {
        return await GetAll(null, include, pageNumber, pageSize, deleted);
    }

    public async Task<(List<T> data, int totalCount)> GetAll(Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, int pageNumber = 0, int pageSize = 10,
        bool deleted = false)
    {
        var query = predicate == null
            ? _context.Set<T>().Where(t => t.IsDeleted == deleted)
            : _context.Set<T>().Where(t => t.IsDeleted == deleted)
                .Where(predicate);
        query = include != null ? include(query) : query;
        query = query.OrderByDescending(model => model.CreationDate);
        return (await (pageNumber == 0
                ? query.ToListAsync()
                : query.Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize)
                    .ToListAsync()),
            await query.CountAsync());
    }

    public async Task<T?> Add(T entity, Guid? userId = null)
    {
        await _context.Set<T>().AddAsync(entity);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }

        return entity;
    }

    public async Task<T?> Delete(TId id, Guid? userId = null)
    {
        var result = await GetById(id);
        if (result == null) return null;
        _context.Set<T>().Remove(result);
        await _context.SaveChangesAsync();
        return result;
    }

    public async Task<T?> SoftDelete(TId id, Guid? userId = null)
    {
        var result = await GetById(id);
        if (result == null) return null;
        if (result.IsDeleted) return null;

        result.IsDeleted = true;
        _context.Set<T>().Update(result);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }

        return result;
    }

    public async Task<T?> Update(T entity, Guid? userId = null)
    {

        _context.Set<T>().Update(entity);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }

        return entity;    }

    public async Task<List<TDto>> UpdateAll<TDto>(List<T> entities, Guid? userId = null)
    {
        var updateData = new List<T>();
        foreach (var entity in entities)
        {
            _context.Set<T>().Update(entity);
            updateData.Add(entity);
        }

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return _mapper.Map<List<TDto>>(updateData);
    }

    public async Task<List<T>> UpdateAll(List<T> entities, Guid? userId = null)
    {
        var updatedData = new List<T>();

        foreach (var entity in entities)
        {
            _context.Set<T>().Update(entity);
            updatedData.Add(entity);
        }

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }


        return updatedData;
    }

    public async Task<TDto?> Get<TDto>(Expression<Func<T, bool>> predicate, bool deleted = false)
    {
        var entity = await _context.Set<T>()
            .AsNoTracking()
            .Where(predicate)
            .Where(t => t.IsDeleted == deleted)
            .ProjectTo<TDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return entity;
    }

    public async Task<T?> Get(Expression<Func<T, bool>> predicate, bool deleted = false)
    {
        var entity = await _context.Set<T>()
            .AsNoTracking()
            .Where(t => t.IsDeleted == deleted)
            .Where(predicate)
            .FirstOrDefaultAsync();

        return entity;
    }

    public async Task<T?> Get(Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, bool deleted = false)
    {
        var query = _context.Set<T>().Where(t => t.IsDeleted == deleted)
            .AsQueryable();
        query = predicate != null ? query.Where(predicate) : query;
        if (include != null) query = include(query);
        return await query.FirstOrDefaultAsync();
    }

    private async Task<(List<TDto> data, int totalCount)> ExecuteQuery<TDto>(IQueryable<T> query, int pageNumber,
        int pageSize)
    {
        var totalCount = await query.CountAsync();
        var data = pageNumber == 0
            ? await query.ProjectTo<TDto>(_mapper.ConfigurationProvider).ToListAsync()
            : await query.Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ProjectTo<TDto>(_mapper.ConfigurationProvider).ToListAsync();

        return (data, totalCount);
    }
}