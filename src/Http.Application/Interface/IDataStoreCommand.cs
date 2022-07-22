﻿namespace Http.Application.Interface;

/// <summary>
/// 仓储命令
/// </summary>
public interface IDataStoreCommand<TId, TEntity>
    where TEntity : class
{
    /// <summary>
    /// 创建模型
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<TEntity> CreateAsync(TEntity entity);

    /// <summary>
    /// 更新实体
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    TEntity Update(TEntity entity);


    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity?> DeleteAsync(TId id);
}
public interface IDataStoreCommand<TEntity> : IDataStoreCommand<Guid, TEntity>
    where TEntity : class
{ }