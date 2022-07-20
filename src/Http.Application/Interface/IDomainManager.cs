namespace Http.Application.Interface
{
    /// <summary>
    /// 仓储数据管理接口
    /// </summary>
    public interface IDomainManager<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync<TUpdate>(Guid id, TUpdate entity);
        Task<TEntity?> DeleteAsync(Guid id);
        Task<TDto?> FindAsync<TDto>(Guid id);
        Task<PageList<TItem>> Filter<TItem>(Expression<Func<TEntity, bool>> whereExp, Dictionary<string, bool>? order, int pageIndex = 1, int pageSize = 12);

    }
}
