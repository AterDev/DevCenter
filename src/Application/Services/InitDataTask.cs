using Application;

namespace Application.Services;
public class InitDataTask
{
    public static async Task InitDataAsync(IServiceProvider provider)
    {
        CommandDbContext context = provider.GetRequiredService<CommandDbContext>();
        ILoggerFactory loggerFactory = provider.GetRequiredService<ILoggerFactory>();
        ILogger<InitDataTask> logger = loggerFactory.CreateLogger<InitDataTask>();
        string? connectionString = context.Database.GetConnectionString();
        try
        {
            context.Database.Migrate();
            if (!await context.Database.CanConnectAsync())
            {
                logger.LogError("数据库无法连接:{message}", connectionString);
                return;
            }
            else
            {
                // 判断是否初始化
                Role? role = await context.Roles.SingleOrDefaultAsync(r => r.IdentifyName.ToLower() == "admin");
                if (role == null)
                {
                    logger.LogInformation("初始化数据");
                    await InitRoleAndUserAsync(context);
                }
                ResourceAttributeDefine? resourceAttributeDefines = await context.ResourceAttributeDefines.FirstOrDefaultAsync();
                if (resourceAttributeDefines == null)
                {
                    await InitResourceAsync(context);
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError("初始化异常,请检查数据库配置：{message}", ex.Message + ex.Source + ex.StackTrace);
        }
    }

    /// <summary>
    /// 初始化角色和管理用户
    /// </summary>
    public static async Task InitRoleAndUserAsync(ContextBase context)
    {
        Role role = new()
        {
            Name = "管理员",
            IdentifyName = "Admin"
        };
        Role userRole = new()
        {
            Name = "用户",
            IdentifyName = "User"
        };
        string salt = HashCrypto.BuildSalt();
        User user = new()
        {
            UserName = "admin",
            Email = "admin@dusi.dev",
            EmailConfirmed = true,
            PasswordSalt = salt,
            PasswordHash = HashCrypto.GeneratePwd("123456", salt),
            Roles = new List<Role>() { role },
        };
        _ = context.Roles.Add(userRole);
        _ = context.Roles.Add(role);
        _ = context.Users.Add(user);
        _ = await context.SaveChangesAsync();
    }

    /// <summary>
    /// 初始化资源
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static async Task InitResourceAsync(ContextBase context)
    {
        // 定义资源属性
        List<ResourceAttributeDefine> attributes = Config.AttributeDefines;
        await context.AddRangeAsync(attributes);

        // 资源类型
        List<ResourceTypeDefinition> resourceTypes = Config.TypeDefinitions;
        await context.AddRangeAsync(resourceTypes);

        // 标签
        List<ResourceTags> resourceTags = Config.ResourceTags;
        await context.AddRangeAsync(resourceTags);
        // 环境
        List<Environment> environments = Config.Environments;
        await context.AddRangeAsync(environments);
        _ = await context.SaveChangesAsync();

    }
}
