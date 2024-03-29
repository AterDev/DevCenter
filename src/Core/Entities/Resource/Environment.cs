﻿namespace Core.Entities.Resource;

/// <summary>
/// 环境
/// </summary>
public class Environment : EntityBase
{
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    [MaxLength(20)]
    public string? Color { get; set; } = Helper.GetRandColor();

    public List<ResourceGroup>? ResourceGroups { get; set; }
}
