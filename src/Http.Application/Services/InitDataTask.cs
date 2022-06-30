namespace Http.Application.Services;

public class InitDataTask
{
    public static async Task InitDataAsync(IServiceProvider provider)
    {
        var context = provider.GetRequiredService<ContextBase>();
        try
        {
            var timeout = context.Database.GetCommandTimeout();
            context.Database.SetCommandTimeout(5);
            // 判断是否初始化
            var role = await context.Roles.SingleOrDefaultAsync(r => r.Name.ToLower() == "admin");
            if (role == null)
            {
                Console.WriteLine("初始化数据");
                await InitRoleAndUserAsync(context);
            }
            var resourceAttributeDefines = await context.ResourceAttributeDefines.FirstOrDefaultAsync();
            if (resourceAttributeDefines == null)
            {
                await InitResourceAsync(context);
            }
            context.Database.SetCommandTimeout(timeout);
        }
        catch (Exception ex)
        {
            Console.WriteLine("检查数据库连接:" + ex.Message);
        }
    }

    /// <summary>
    /// 初始化角色和管理用户
    /// </summary>
    public static async Task InitRoleAndUserAsync(ContextBase context)
    {
        var role = new Role()
        {
            Name = "Admin"
        };
        var userRole = new Role()
        {
            Name = "User"
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
