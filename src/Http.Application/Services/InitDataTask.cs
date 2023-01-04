namespace Http.Application.Services;
public class InitDataTask
{
    public static async Task InitDataAsync(IServiceProvider provider)
    {
        var context = provider.GetRequiredService<CommandDbContext>();
        var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger<InitDataTask>();
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
                var role = await context.Roles.SingleOrDefaultAsync(r => r.Name.ToLower() == "admin");
                if (role == null)
                {
                    logger.LogInformation("初始化数据");
                    await InitRoleAndUserAsync(context);
                }
                var resourceAttributeDefines = await context.ResourceAttributeDefines.FirstOrDefaultAsync();
                if (resourceAttributeDefines == null)
                {
                    await InitResourceAsync(context);
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError("初始化异常,请检查数据库配置：{message}", ex.Message);
        }
    }

    /// <summary>
    /// 初始化角色和管理用户
    /// </summary>
    public static async Task InitRoleAndUserAsync(ContextBase context)
    {
        var role = new Role()
        {
            Name = "管理员",
            IdentifyName = "Admin"
        };
        var userRole = new Role()
        {
            Name = "用户",
            IdentifyName = "User"
        };
        var salt = HashCrypto.BuildSalt();
        var user = new User()
        {
            UserName = "admin",
            Email = "admin@dusi.dev",
            EmailConfirmed = true,
            PasswordSalt = salt,
            PasswordHash = HashCrypto.GeneratePwd("123456", salt),
            Roles = new List<Role>() { role },
        };
        context.Roles.Add(userRole);
        context.Roles.Add(role);
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// 初始化资源
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static async Task InitResourceAsync(ContextBase context)
    {
        // 定义资源属性
        var attributes = Config.AttributeDefines;
        await context.AddRangeAsync(attributes);

        // 资源类型
        var resourceTypes = Config.TypeDefinitions;
        await context.AddRangeAsync(resourceTypes);

        // 标签
        var resourceTags = Config.ResourceTags;
        await context.AddRangeAsync(resourceTags);
        // 环境
        var environments = Config.Environments;
        await context.AddRangeAsync(environments);
        await context.SaveChangesAsync();

    }
}
