using Http.Application.IManager;
using Share.Models.EnvironmentDtos;

namespace Http.Application.Manager;

public class EnvironmentManager : DomainManagerBase<Environment, EnvironmentUpdateDto, EnvironmentFilterDto, EnvironmentItemDto>, IEnvironmentManager
{
    public EnvironmentManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<Environment> UpdateAsync(Environment entity, EnvironmentUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<EnvironmentItemDto>> FilterAsync(EnvironmentFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        // if ... Queryable = ...
        return await Query.FilterAsync<EnvironmentItemDto>(Queryable);
    }

}
