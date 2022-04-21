
namespace Core.Models
{
    /// <summary>
    /// 导航
    /// </summary>
    public class Navigation : EntityBase
    {
        /// <summary>
        /// 导航名称
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; } = default!;
        /// <summary>
        /// 链接
        /// </summary>
        [MaxLength(200)]
        public string Url { get; set; } = default!;

        /// <summary>
        /// 说明
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; } = default!;

        public NavigationType Type { get; set; }

        public NavigationGroup Group { get; set; } = null!;
    }


}
