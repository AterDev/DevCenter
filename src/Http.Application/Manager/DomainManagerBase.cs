using Http.Application.Implement;

namespace Http.Application.Manager
{
    /// <summary>
    /// 
    /// </summary>
    public class DomainManagerBase<TEntity> : IDomainManager<TEntity>
        where TEntity : EntityBase
    {
        private readonly DataStoreContext storeContext;
        private readonly DataStoreQueryBase<QueryDbContext, TEntity> query;
        private readonly DataStoreCommandBase<CommandDbContext, TEntity> command;

        public DomainManagerBase(DataStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync<TUpdate>(Guid id, TUpdate entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TDto> FindAsync<TDto>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PageList<TItem>> Filter<TItem>(Expression<Func<TEntity, bool>> whereExp, Dictionary<string, bool>? order, int pageIndex = 1, int pageSize = 12)
        {
            throw new NotImplementedException();
        }
    }
}
