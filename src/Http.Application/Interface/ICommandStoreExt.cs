namespace Http.Application.Interface;
public interface ICommandStoreExt<TId, TEntity>
    where TEntity : EntityBase
{
    /// <summary>
    /// 批量新增
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="chunk"></param>
    /// <returns></returns>
    Task<List<TEntity>> CreateRangeAsync(List<TEntity> entities, int? chunk = 50);
}

public interface ICommandStoreExt<TEntity> : ICommandStoreExt<Guid, TEntity>
     where TEntity : EntityBase
{ }
