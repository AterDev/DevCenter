using Share.Models.UserDtos;

namespace Http.Application.Manager;

public class UserManager : DomainManagerBase<User, UserUpdateDto, UserFilterDto, UserItemDto>, IUserManager
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

    public override Task<User> AddAsync(User entity)
    {


        return base.AddAsync(entity);
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
        _ = await base.UpdateAsync(user, dto);
        _ = await SaveChangesAsync();
        return user;
    }

    public override async Task<PageList<UserItemDto>> FilterAsync(UserFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        if (filter.RoleId != null)
        {
            Role? role = await Stores.RoleQuery.FindAsync<Role>(filter.RoleId.Value);
            Queryable = Queryable.Where(u => u.Roles!.Contains(role!));
        }
        return await base.FilterAsync(filter);
    }

    public async Task<List<Role>> GetRolesAsync(List<Guid> roleIds)
    {
        return await Stores.CommandContext.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();

    }
}
