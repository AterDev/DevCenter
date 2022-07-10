using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Models;
using Core.Utils;

using EntityFramework;

using Http.API.Test.DatastoreTests;

using Microsoft.EntityFrameworkCore;

using NGitLab;

namespace Http.API.Test
{
    public class SomeWorks : BaseTest
    {
        private readonly ContextBase _context;
        public SomeWorks(WebApplicationFactory<Program> factory) : base(factory)
        {
            _context = _service.GetRequiredService<ContextBase>();
        }

        [Fact]
        public async Task GetGitHubUsers()
        {
            var url = "";
            var pat = "";
            var client = new GitLabClient(url, pat);
            var users = client.Users.Get(new UserQuery { IsActive = true, PerPage = 50 });
            // 构建用户
            var userList = new List<User>();
            // 默认角色
            var role = await _context.Roles.Where(r => r.IdentifyName == "developer").FirstOrDefaultAsync();
            foreach (var user in users)
            {
                var salt = HashCrypto.BuildSalt();
                var newUser = new User
                {
                    UserName = user.Username,
                    RealName = user.Name,
                    PasswordSalt = salt,
                    PasswordHash = HashCrypto.GeneratePwd(user.Username, salt),
                    Email = user.Email,
                    Roles = new List<Role>() { role! }
                };
                userList.Add(newUser);
            }
            var usernames = userList.Select(u => u.UserName).ToList();
            // 查询已存在的用户
            var existUsers = await _context.Users.Where(u => usernames.Contains(u.UserName))
                .Select(u => u.UserName).ToListAsync();
            // 只插入不存在的用户
            userList = userList.Where(u => !existUsers.Contains(u.UserName)).ToList();


            await _context.AddRangeAsync(userList);
            var res = await _context.SaveChangesAsync();
            System.Console.WriteLine(res);
        }
    }
}
