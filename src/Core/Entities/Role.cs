﻿using Core.Entities.Resource;

namespace Core.Entities;
/// <summary>
/// 角色表
/// </summary>
public class Role : EntityBase
{
    /// <summary>
    /// 角色名称
    /// </summary>
    [MaxLength(30)]
    public required string Name { get; set; }
    [MaxLength(30)]
    public required string IdentifyName { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    /// <summary>
    /// 图标
    /// </summary>
    [MaxLength(30)]
    public string? Icon { get; set; }

    public List<User>? Users { get; set; }
    public List<Permission>? Permissions { get; set; }
    public List<ResourceGroup>? ResourceGroups { get; set; }

}
