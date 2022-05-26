using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    /// <summary>
    /// 环境
    /// </summary>
    public class Environment : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; } = default!;
        [MaxLength(200)]
        public string? Description { get; set; }

        public List<ResourceGroup>? ResourceGroups { get; set; }
    }
}
