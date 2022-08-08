using Share.Models.RoleDtos;

namespace Http.Application.Manager;

public class RoleManager : DomainManagerBase<Role, RoleUpdateDto, RoleFilterDto, RoleItemDto>, IRoleManager
{
    public RoleManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<Role> UpdateAsync(Role entity, RoleUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<RoleItemDto>> FilterAsync(RoleFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        return await base.FilterAsync(filter);
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
            .ListAsync(g => dto.GroupIds.Contains(g.Id));
        role.ResourceGroups = groups;
        return await SaveChangesAsync() > 0;
    }
}
