namespace Http.Application.Manager
{
    public class DomainManagerBase<TEntity> : IDomainManager<TEntity>
        where TEntity : EntityBase
    {
        private readonly DataStoreContext _context;
        private readonly QuerySet<TEntity> query;
        private readonly CommandSet<TEntity> command;

        public DomainManagerBase(DataStoreContext storeContext)
        {
            _context = storeContext;
            query = _context.QuerySet<TEntity>();
            command = _context.CommandSet<TEntity>();
        }
        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync<TUpdate>(Guid id, TUpdate entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TDto?> FindAsync<TDto>(Guid id)
        {
            return await query.FindAsync<TDto>(id);
        }

        public Task<PageList<TItem>> Filter<TItem>(Expression<Func<TEntity, bool>> whereExp, Dictionary<string, bool>? order, int pageIndex = 1, int pageSize = 12)
        {
            throw new NotImplementedException();
        }
    }
}
