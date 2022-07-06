using Microsoft.EntityFrameworkCore;

using Share.Models.UserDtos;
namespace Http.API.Controllers;

/// <summary>
/// 系统用户
/// </summary>
public class UserController : RestApiBase<UserDataStore, User, UserAddDto, UserUpdateDto, UserFilterDto, UserItemDto>
{
    public UserController(IUserContext user, ILogger<UserController> logger, UserDataStore store) : base(user, logger, store)
    {
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override async Task<ActionResult<PageResult<UserItemDto>>> FilterAsync(UserFilterDto filter)
    {
        return await base.FilterAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<User>> AddAsync(UserAddDto form)
    {
        var user = new User();
        user.Merge(form);
        user.PasswordSalt = HashCrypto.BuildSalt();
        user.PasswordHash = HashCrypto.GeneratePwd(form.Password ?? "123456", user.PasswordSalt);
        if (form.RoleIds != null)
        {
            var roles = await _store._context.Roles.Where(r => form.RoleIds.Contains(r.Id)).ToListAsync();
            user.Roles = roles;
        }
        return await _store.AddAsync(user);
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<User?>> UpdateAsync([FromRoute] Guid id, UserUpdateDto form)
    {
        return await base.UpdateAsync(id, form);
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    public override async Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        return await base.DeleteAsync(id);
    }

    /// <summary>
    /// ⚠ 批量删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public override async Task<ActionResult<int>> BatchDeleteAsync(List<Guid> ids)
    {
        // 危险操作，请确保该方法的执行权限
        //return await base.BatchDeleteAsync(ids);
        return await Task.FromResult(0);
    }
}
