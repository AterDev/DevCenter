﻿using Share.Models.UserDtos;

namespace Http.Application.Manager;
/// <summary>
/// 定义用户实体业务接口规范
/// </summary>
public interface IUserManager : IDomainManager<User, UserUpdateDto>
{
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="user"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    Task<bool> ChangePasswordAsync(User user, string newPassword);

    /// <summary>
    /// 获取角色
    /// </summary>
    /// <param name="user"></param>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    Task<List<Role>> GetRolesAsync(List<Guid> roleIds);
}
