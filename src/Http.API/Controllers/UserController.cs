using Http.API.Infrastructure;
using Share.Models.UserDtos;
using User = Core.Entities.User;

namespace Http.API.Controllers;

/// <summary>
/// 系统用户
/// </summary>
public class UserController :
    RestControllerBase<UserManager>,
    IRestController<User, UserAddDto, UserUpdateDto, UserFilterDto, UserItemDto>
{
    public UserController(
        IUserContext user,
        ILogger<UserController> logger,
        UserManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<UserItemDto>>> FilterAsync(UserFilterDto filter)
    {
        return await manager.FilterAsync<UserItemDto>(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<User>> AddAsync(UserAddDto form)
    {
        var entity = form.MapTo<UserAddDto, User>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 获取当前用户信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<UserShortDto?>> GetMyInfo()
    {
        return await manager.FindAsync<UserShortDto>(u => u.Id == _user.UserId);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<User?>> UpdateAsync([FromRoute] Guid id, UserUpdateDto form)
    {
        if (_user.IsAdmin || _user.UserId == id)
        {
            var user = await manager.GetCurrent(id, "Roles");
            return user == null ? (ActionResult<User?>)NotFound() : (ActionResult<User?>)await manager.UpdateAsync(user, form);
        }
        return Forbid();
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    [HttpPut("changePassword")]
    public async Task<ActionResult<bool>> ChangePasswordAsync(string newPassword)
    {
        if (_user.UserId != null)
        {
            var user = await manager.GetCurrent(_user.UserId.Value);
            return user != null ? (ActionResult<bool>)await manager.ChangePasswordAsync(user, newPassword) : (ActionResult<bool>)NotFound("非法用户");
        }
        return Forbid();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync<User>(u => u.Id == id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<User?>> DeleteAsync([FromRoute] Guid id)
    {
        return await manager.DeleteAsync(id);
    }
}