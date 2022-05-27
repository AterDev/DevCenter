﻿namespace Core.Models
{
    /// <summary>
    /// 资源属性定义
    /// </summary>
    public class ResourceAttributeDefine : EntityBase
    {
        [MaxLength(50)]
        public string DisplayName { get; set; }
        [MaxLength(60)]
        public string Name { get; set; } = string.Empty;
        public ValueType Type { get; set; } = ValueType.String;
        public bool IsEnable { get; set; } = true;
        /// <summary>
        /// 是否必须
        /// </summary>
        public bool Required { get; set; } = false;
        /// <summary>
        /// 排序 
        /// </summary>
        public short Sort { get; set; } = 0;

        public ResourceAttributeDefine(string displayName)
        {
            DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
        }

        private ResourceAttributeDefine()
        {

        }
    }
}