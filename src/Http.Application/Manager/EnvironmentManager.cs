using Share.Models.EnvironmentDtos;

namespace Http.Application.Manager;

public class EnvironmentManager : DomainManagerBase<Environment, EnvironmentUpdateDto, EnvironmentFilterDto>, IEnvironmentManager
{
    public EnvironmentManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<Environment> UpdateAsync(Environment entity, EnvironmentUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<TItem>> FilterAsync<TItem>(EnvironmentFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        return await base.FilterAsync<TItem>(filter);
    }

}
