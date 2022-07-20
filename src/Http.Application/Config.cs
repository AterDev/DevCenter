using Environment = Core.Entities.Environment;

namespace Http.Application;

internal class Config
{
    /// <summary>
    /// 缺省属性字段
    /// </summary>
    public static List<ResourceAttributeDefine> AttributeDefines = new()
    {
        new ResourceAttributeDefine()
        {
            DisplayName = "名称",
            Required = true,
            Name ="name",
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "描述",
            Name ="description",
            Sort =1,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "Url",
            Name ="rul",
            Sort =2,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "公网IP",
            Name ="ipAddress",
            Sort =3,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "公网端口",
            Name ="port",
            Sort =4,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "连接字符串",
            Name ="connectionString",
            Sort =5,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "登录用户",
            Name ="loginUser",
            Sort =6,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "密码",
            Name ="password",
            Sort =7,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "密钥",
            Name ="secretKey",
            Sort =8,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "AppId",
            Name ="appId",
            Sort =9,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "AccessKey",
            Name ="accessKey",
            Sort =9,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "AccessSecret",
            Name ="accessSecret",
            Sort =10,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "Endpoint",
            Name ="endpoint",
            Sort =10,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "内网IP",
            Name ="internalIpAddress",
            Sort =11,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "内网端口",
            Name ="internalPort",
            Sort =12,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "Webhook",
            Name ="webhook",
            Sort =13,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "Token",
            Name ="token",
            Sort =14,
            Type = Core.Models.ValueType.String
        },
        new ResourceAttributeDefine()
        {
            DisplayName = "配置值",
            Name ="config",
            Sort =15,
            Type = Core.Models.ValueType.String
        }
    };

    /// <summary>
    /// 缺省资源类型
    /// </summary>
    public static List<ResourceTypeDefinition> TypeDefinitions = new()
        {
            new ResourceTypeDefinition()
            {
                Name = "网站",
                Description = "网站链接",
                Color = Helper.GetRandColor()
            },
            new ResourceTypeDefinition()
            {
                Name = "服务器",
                Description = "服务器登录连接",
                Color = Helper.GetRandColor()
            },
            new ResourceTypeDefinition()
            {
                Name = "数据库",
                Description = "数据库连接",
                Color = Helper.GetRandColor()
            },
            new ResourceTypeDefinition()
            {
                Name = "服务账号",
                Description = "网站、APP、服务等登录账号",
                Color = Helper.GetRandColor()
            },
            new ResourceTypeDefinition()
            {
                Name = "配置项",
                Description = "配置项，如json/yml文件",
                Color = Helper.GetRandColor()
            }
        };

    public static List<ResourceTags> ResourceTags = new()
    {
        new ResourceTags()
        {
            Name = "服务器",
            Color = Helper.GetRandColor()
        },
        new ResourceTags()
        {
            Name = "数据库",
            Color = Helper.GetRandColor()
        },
        new ResourceTags()
        {
            Name = "网站",
            Color = Helper.GetRandColor()
        }
    };

    public static List<Environment> Environments = new()
    {
         new Environment(){
             Name = "开发",
             Description = "开发环境",
         },
         new Environment(){
             Name = "测试",
             Description = "测试环境",
         },
         new Environment(){
             Name = "生产",
             Description = "生产环境",
         },
    };
}
