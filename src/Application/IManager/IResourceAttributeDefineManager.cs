using Application.Interface;
using Share.Models.ResourceAttributeDefineDtos;

namespace Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IResourceAttributeDefineManager : IDomainManager<ResourceAttributeDefine, ResourceAttributeDefineUpdateDto, ResourceAttributeDefineFilterDto, ResourceAttributeDefineItemDto>
{
    // TODO: 定义业务方法
}
