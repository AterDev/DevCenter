using Share.Models.RoleDtos;

namespace Http.Application.Manager;

public class RoleManager : DomainManagerBase<Role, RoleUpdateDto, RoleFilterDto>, IRoleManager
{
    public RoleManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<Role> UpdateAsync(Role entity, RoleUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<TItem>> FilterAsync<TItem>(RoleFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        var query = GetQueryable();
        return await Query.FilterAsync<TItem>(query);
    }

    /// <summary>
    /// 为角色分配资源组
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<bool> SetResourceGroupsAsync(RoleResourceDto dto)
    {
        var role = await Command.Db.Include(r => r.ResourceGroups)
            .FirstOrDefaultAsync(r => r.Id == dto.RoleId);
        role!.ResourceGroups = null;

        var groups = await Stores.ResourceGroupCommand
            .ListAsync<ResourceGroup>(g => dto.GroupIds.Contains(g.Id));
        role.ResourceGroups = groups;
        return await SaveChangesAsync() > 0;
    }
}
