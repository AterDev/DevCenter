using Share.Models.ResourceGroupDtos;

namespace Http.Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IResourceGroupManager : IDomainManager<ResourceGroup, ResourceGroupUpdateDto, ResourceGroupFilterDto>
{
	// TODO: 定义业务方法
}
