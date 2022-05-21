namespace Core.Models
{
    /// <summary>
    /// 秘钥
    /// </summary>
    public class SecretInfo : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(200)]
        public string? Description { get; set; }
        [MaxLength(200)]
        public string? Host { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int? Port { get; set; }
        [MaxLength(60)]
        public string? Username { get; set; }
        [MaxLength(60)]
        public string? Password { get; set; }
        [MaxLength(200)]
        public string? PAT { get; set; }
        [MaxLength(100)]
        public string? Key { get; set; }
        [MaxLength(100)]
        public string? Secret { get; set; }
        [MaxLength(1000)]
        public string? Certificate { get; set; }
        public SecretType Type { get; set; } = SecretType.Password;
        /// <summary>
        /// 所属环境
        /// </summary>
        [MaxLength(100)]
        public string Environment { get; set; } = "default";
    }


}
