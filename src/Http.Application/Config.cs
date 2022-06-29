using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.Application
{
    internal class Config
    {
        /// <summary>
        /// 缺省属性字段
        /// </summary>
        public static List<ResourceAttributeDefine> AttributeDefines { get; set; } =
            new List<ResourceAttributeDefine> {
            new ResourceAttributeDefine("名称")
            {
                Required = true,
                Name ="name",
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("描述")
            {
                Name ="description",
                Sort =1,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("Url")
            {
                Name ="rul",
                Sort =2,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("公网IP")
            {
                Name ="ipAddress",
                Sort =3,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("公网端口")
            {
                Name ="port",
                Sort =4,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("连接字符串")
            {
                Name ="connectionString",
                Sort =5,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("登录用户")
            {
                Name ="loginUser",
                Sort =6,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("密码")
            {
                Name ="password",
                Sort =7,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("密钥")
            {
                Name ="secretKey",
                Sort =8,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("AppId")
            {
                Name ="appId",
                Sort =9,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("AccessKey")
            {
                Name ="accessKey",
                Sort =9,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("AccessSecret")
            {
                Name ="accessSecret",
                Sort =10,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("Endpoint")
            {
                Name ="endpoint",
                Sort =10,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("内网IP")
            {
                Name ="internalIpAddress",
                Sort =11,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("内网端口")
            {
                Name ="internalPort",
                Sort =12,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("Webhook")
            {
                Name ="webhook",
                Sort =13,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("Token")
            {
                Name ="token",
                Sort =14,
                Type = Core.Models.ValueType.String
            },
            new ResourceAttributeDefine("配置值")
            {
                Name ="config",
                Sort =15,
                Type = Core.Models.ValueType.String
            }
        };

        /// <summary>
        /// 缺省资源类型
        /// </summary>
        public static List<ResourceTypeDefinition> typeDefinitions { get; set; }
            = new List<ResourceTypeDefinition>
            {
                new ResourceTypeDefinition("网站")
                {
                    Description = "网站链接",
                    Color = Utils.GetRandColor()
                },
                new ResourceTypeDefinition("服务器")
                {
                    Description = "服务器登录连接",
                    Color = Utils.GetRandColor()
                },
                new ResourceTypeDefinition("数据库")
                {
                    Description = "数据库连接",
                    Color = Utils.GetRandColor()
                },
                new ResourceTypeDefinition("服务账号")
                {
                    Description = "网站、APP、服务等登录账号",
                    Color = Utils.GetRandColor()
                },
                new ResourceTypeDefinition("配置项")
                {
                    Description = "配置项，如json/yml文件",
                    Color = Utils.GetRandColor()
                }
            };
    }
}
