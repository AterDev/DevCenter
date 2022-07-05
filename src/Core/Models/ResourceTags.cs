﻿namespace Core.Models
{
    /// <summary>
    /// 资源标识 
    /// </summary>
    public class ResourceTags : EntityBase
    {
        [MaxLength(100)]
        public string Name { get; set; } = default!;
        [MaxLength(20)]
        public string? Color { get; set; } = Utils.Utils.GetRandColor();
        [MaxLength(30)]
        public string? Icon { get; set; }

        public List<Resource>? Resources { get; set; }

    }
}
