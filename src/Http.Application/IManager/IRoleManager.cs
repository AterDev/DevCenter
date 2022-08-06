using Share.Models.RoleDtos;

namespace Http.Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IRoleManager : IDomainManager<Role, RoleUpdateDto, RoleFilterDto>
{
	// TODO: 定义业务方法
}
