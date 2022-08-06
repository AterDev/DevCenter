using Share.Models.EnvironmentDtos;

namespace Http.Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IEnvironmentManager : IDomainManager<Environment, EnvironmentUpdateDto, EnvironmentFilterDto, EnvironmentItemDto>
{
    // TODO: 定义业务方法
}
