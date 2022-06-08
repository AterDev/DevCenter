namespace Share.Models.Webhook
{
    public class ErrorLoggingRequest
    {
        public string TraceId { get; set; } = string.Empty;
        /// <summary>
        /// 详细信息
        /// </summary>
        public string ErrorDetail { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// 项目名
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;
        /// <summary>
        /// 服务名
        /// </summary>
        public string ServiceName { get; set; } = string.Empty;
        /// <summary>
        /// 筛选标识名
        /// </summary>
        public string FilterName { get; set; } = string.Empty;
        /// <summary>
        /// 路由
        /// </summary>
        public string? Route { get; set; }
        /// <summary>
        /// 请求内容
        /// </summary>
        public string? RequestBody { get; set; }
        /// <summary>
        /// query string
        /// </summary>
        public string? QueryString { get; set; }
    }
}