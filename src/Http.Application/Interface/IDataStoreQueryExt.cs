namespace Http.Application.Interface;
/// <summary>
/// 高级查询接口
/// </summary>
public interface IDataStoreQueryExt<TEntity>
{

    /// <summary>
    /// 条件查询
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="whereExp"></param>
    /// <param name="order"></param>
    /// <returns></returns>
    Task<PageList<TItem>> Filter<TItem>(Expression<Func<TEntity, bool>> whereExp, Dictionary<string, bool>? order, int pageIndex = 1, int pageSize = 12);
}
