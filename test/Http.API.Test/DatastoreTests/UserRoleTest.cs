
using System.Collections.Generic;
using System.Threading.Tasks;

using Core.Entities;
using Http.Application.IManager;

namespace Http.API.Test.DatastoreTests;
/// <summary>
/// 用户角色测试
/// </summary>
public class UserRoleTest : BaseTest
{
    //readonly UserDataStore _userStore;
    private readonly IRoleManager _roleStore;

    public UserRoleTest(WebApplicationFactory<Program> factory) : base(factory)
    {
        //_userStore = _service.GetRequiredService<UserDataStore>();
        _roleStore = _service.GetRequiredService<IRoleManager>();
    }


    [Fact]
    public async Task Shoud_SequenceAsync()
    {
        var roles = new List<Role>();
        for (int i = 0; i < 20; i++)
        {
            var newRole = new Role { Name = "role" + i, IdentifyName = "role" };
            await _roleStore.AddAsync(newRole);
        }
        //await _roleStore._context.AddRangeAsync(roles);
    }

}
