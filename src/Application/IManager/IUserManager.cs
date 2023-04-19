using Application.Interface;
using Share.Models.UserDtos;

namespace Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IUserManager : IDomainManager<User, UserUpdateDto, UserFilterDto, UserItemDto>
{
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="user"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    Task<bool> ChangePasswordAsync(User user, string newPassword);
    Task<List<Role>> GetRolesAsync(List<Guid> roleIds);
}
