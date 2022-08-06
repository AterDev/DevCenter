using Share.Models.ResourceDtos;

namespace Http.Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IResourceManager : IDomainManager<Resource, ResourceUpdateDto, ResourceFilterDto, ResourceItemDto>
{
    Task<ResourceSelectDataDto> GetRelationSelectDataAsync();
    Task<List<Resource>> GetAllResourcesAsync(Guid value);
}
