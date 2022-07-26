using Share.Models.UserDtos;

namespace Http.Application.Manager;

public class UserManager : DomainManagerBase<User, UserUpdateDto, UserFilterDto>, IUserManager
{
    public UserManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public async Task<bool> ChangePasswordAsync(User user, string newPassword)
    {
        user!.PasswordSalt = HashCrypto.BuildSalt();
        user.PasswordHash = HashCrypto.GeneratePwd(newPassword, user.PasswordSalt);
        return await SaveChangesAsync() > 0;
    }

    public override async Task<User> UpdateAsync(User user, UserUpdateDto dto)
    {
        if (dto.RoleIds != null)
        {
            user.Roles = null;
            user.Roles = await GetRolesAsync(dto.RoleIds);
        }

        if (dto.Password != null)
        {
            user.PasswordSalt = HashCrypto.BuildSalt();
            user.PasswordHash = HashCrypto.GeneratePwd(dto.Password, user.PasswordSalt);
        }
        await base.UpdateAsync(user, dto);
        await SaveChangesAsync();
        return user;
    }

    public override async Task<PageList<TItem>> FilterAsync<TItem>(UserFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        return await base.FilterAsync<TItem>(filter);
    }

    public async Task<List<Role>> GetRolesAsync(List<Guid> roleIds)
    {
        return await Stores.CommandContext.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();

    }
}
