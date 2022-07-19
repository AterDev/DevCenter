using System.Xml;

using Share.Models.UserDtos;
namespace Http.Application.DataStore;
public class UserDataStore : DataStoreBase<ContextBase, User, UserUpdateDto, UserFilterDto, UserItemDto>
{
    public UserDataStore(ContextBase context, IUserContext userContext, ILogger<UserDataStore> logger) : base(context, userContext, logger)
    {
    }

    public override async Task<User?> FindAsync(Guid id, bool noTracking = false)
    {
        return await _db.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == id);
    }
    public override async Task<List<UserItemDto>> FindAsync(UserFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageList<UserItemDto>> FindWithPageAsync(UserFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<User> AddAsync(User data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<User?> UpdateAsync(Guid id, UserUpdateDto dto)
    {
        var user = await _db.Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Id == id);
        user.Merge(dto);
        if (dto.Password != null)
        {
            user!.PasswordSalt = HashCrypto.BuildSalt();
            user.PasswordHash = HashCrypto.GeneratePwd(dto.Password, user.PasswordSalt);
        }
        if (dto.RoleIds != null)
        {
            var roles = await _context.Roles.Where(r => dto.RoleIds.Contains(r.Id)).ToListAsync();
            user!.Roles = roles;
        }
        await _context.SaveChangesAsync();
        return user;
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }

    /// <summary>
    /// ÐÞ¸ÄÃÜÂë
    /// </summary>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    public async Task<bool> ChangePasswordAsync(Guid id, string newPassword)
    {
        var user = await _db.FindAsync(id);
        user!.PasswordSalt = HashCrypto.BuildSalt();
        user.PasswordHash = HashCrypto.GeneratePwd(newPassword, user.PasswordSalt);
        return await _context.SaveChangesAsync() > 0;
    }
}
