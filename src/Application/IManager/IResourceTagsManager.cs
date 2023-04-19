using Application.Interface;
using Share.Models.ResourceTagsDtos;

namespace Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IResourceTagsManager : IDomainManager<ResourceTags, ResourceTagsUpdateDto, ResourceTagsFilterDto, ResourceTagsItemDto>
{
    // TODO: 定义业务方法
}
