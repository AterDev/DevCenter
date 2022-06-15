﻿namespace Http.Application.Services;

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
}
