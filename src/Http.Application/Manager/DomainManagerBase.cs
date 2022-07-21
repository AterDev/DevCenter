namespace Http.Application.Manager
{
    public class DomainManagerBase<TEntity> : IDomainManager<TEntity>
        where TEntity : EntityBase
    {
        public DataStoreContext Stores { get; init; }
        public QuerySet<TEntity> Query { get; init; }
        public CommandSet<TEntity> Command { get; init; }

        public DomainManagerBase(DataStoreContext storeContext)
        {
            Stores = storeContext;
            Query = Stores.QuerySet<TEntity>();
            Command = Stores.CommandSet<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await Command.CreateAsync(entity);
        }

        public async Task<TEntity> UpdateAsync<TUpdate>(Guid id, TUpdate entity)
        {
            return await Command.UpdateAsync(id, entity);
        }

        public async Task<TEntity?> DeleteAsync(Guid id)
        {
            return await Command.DeleteAsync(id);
        }

        public async Task<TDto?> FindAsync<TDto>(Guid id)
        {
            return await Query.FindAsync<TDto>(id);
        }

        public async Task<PageList<TItem>> Filter<TItem>(Expression<Func<TEntity, bool>> whereExp, Dictionary<string, bool>? order, int pageIndex = 1, int pageSize = 12)
        {
            return await Query.FilterAsync<TItem>(whereExp, order, pageIndex, pageSize);
        }
    }
}
