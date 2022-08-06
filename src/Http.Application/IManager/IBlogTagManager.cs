using Share.Models.BlogTagDtos;

namespace Http.Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IBlogTagManager : IDomainManager<BlogTag, BlogTagUpdateDto, BlogTagFilterDto, BlogTagItemDto>
{
	// TODO: 定义业务方法
}
