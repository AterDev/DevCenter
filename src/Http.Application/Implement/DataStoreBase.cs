
namespace Http.Application.Implement;

public class DataStoreBase<TContext, TEntity, TUpdate, TFilter, TItem> : IDataStore<TEntity, TUpdate, TFilter, TItem, Guid>
    where TEntity : EntityBase
    where TFilter : FilterBase
    where TContext : DbContext
{
    public readonly TContext _context;
    public readonly ILogger _logger;
    protected readonly DbSet<TEntity> _db;
    protected readonly IUserContext _userCtx;

    public IQueryable<TEntity> _query;
    public DbSet<TEntity> Db => _db;

    public DataStoreBase(TContext context, IUserContext userContext, ILogger logger)
    {
        _context = context;
        _userCtx = userContext;
        _logger = logger;
        _db = _context.Set<TEntity>();
        _query = _db.AsQueryable();
    }

    /// <summary>
    /// 根据id查询数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="noTracking">是否追踪</param>
    /// <returns></returns>
    public virtual async Task<TEntity?> FindAsync(Guid id, bool noTracking = false)
    {
        IQueryable<TEntity> query = _db.Where(s => s.Id == id).AsQueryable();
        if (noTracking == true)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync();
    }

    /// <summary>
    /// 根据条件查询一条数据
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public virtual async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression, bool noTracking = false)
    {
        IQueryable<TEntity> query = _db.Where(expression).AsQueryable();
        if (noTracking == true)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync();
    }

    /// <summary>
    /// 筛选数据
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="noTracking"></param>
    /// <returns></returns>
    public virtual async Task<List<TItem>> FindAsync(TFilter filter, bool noTracking = true)
    {
        IQueryable<TEntity> query = _query.OrderByDescending(d => d.CreatedTime).AsQueryable();

        if (noTracking == true)
        {
            query = query.AsNoTracking();
        }

        return await query.Select<TEntity, TItem>()
            .Skip((filter.PageIndex - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();
    }

    /// <summary>
    /// 筛选数据，分页结构
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public virtual async Task<PageList<TItem>> FindWithPageAsync(TFilter filter)
    {
        int count = _query.Count();
        if (filter.PageIndex < 1)
        {
            filter.PageIndex = 1;
        }

        if (filter.PageSize < 0)
        {
            filter.PageSize = 0;
        }

        List<TItem> data = await _query.AsNoTracking()
            .Skip((filter.PageIndex - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select<TEntity, TItem>()
            .ToListAsync();
        return new PageList<TItem>
        {
            Count = count,
            Data = data,
            PageIndex = filter.PageIndex
        };
    }

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        TEntity? data = await _db.FindAsync(id);
        if (data == null) { return false; }
        _ = _db.Remove(data);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<TEntity> AddAsync(TEntity data)
    {
        _ = _db.Add(data);
        _ = await _context.SaveChangesAsync();
        return data;
    }

    public virtual async Task<TEntity?> UpdateAsync(Guid id, TUpdate dto)
    {
        TEntity? data = await _db.FindAsync(id);
        if (data == null) { return null; }
        // merge data and save 
        _ = data.Merge(dto, false);
        data.UpdatedTime = DateTimeOffset.UtcNow;
        _ = await _context.SaveChangesAsync();
        return data;
    }

    public virtual async Task<bool> Exist(Guid id)
    {
        TEntity? data = await _db.FindAsync(id);
        return data != null;
    }

    public virtual bool Any(Func<TEntity, bool> predicate)
    {
        return _db.Any(predicate);
    }

    /// <summary>
    /// 批量更新
    /// </summary>
    /// <returns></returns>
    public virtual async Task<int> BatchUpdateAsync(List<Guid> ids, TUpdate dto)
    {
        try
        {
            List<TEntity> data = _db.Where(item => ids.Contains(item.Id))
                .ToList();
            foreach (TEntity? item in data)
            {
                _ = item.Merge(dto);
            }
            return await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <returns></returns>
    public virtual async Task<int> BatchDeleteAsync(List<Guid> ids)
    {
        try
        {
            List<TEntity> data = _db.Where(item => ids.Contains(item.Id))
                .ToList();
            _context.RemoveRange(data);
            return await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public virtual async Task<int> BatchAddAsync(List<TEntity> entities)
    {
        await _db.AddRangeAsync(entities);
        return await _context.SaveChangesAsync();
    }
}
