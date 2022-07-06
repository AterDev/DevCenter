using System.Xml;

using Share.Models.UserDtos;
namespace Http.Application.DataStore;
public class UserDataStore : DataStoreBase<ContextBase, User, UserUpdateDto, UserFilterDto, UserItemDto>
{
    public UserDataStore(ContextBase context, IUserContext userContext, ILogger<UserDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<UserItemDto>> FindAsync(UserFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageResult<UserItemDto>> FindWithPageAsync(UserFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<User> AddAsync(User data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<User?> UpdateAsync(Guid id, UserUpdateDto dto)
    {
        var user = await _db.FindAsync(id);
        user.Merge(dto);
        if (dto.Password != null)
        {
            user!.PasswordSalt = HashCrypto.BuildSalt();
            user.PasswordHash = HashCrypto.GeneratePwd(dto.Password, user.PasswordSalt);
        }
        await _context.SaveChangesAsync();
        return user;
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
