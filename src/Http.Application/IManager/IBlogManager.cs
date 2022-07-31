using Share.Models.BlogDtos;

namespace Http.Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IBlogManager : IDomainManager<Blog, BlogUpdateDto, BlogFilterDto>
{
	// TODO: 定义业务方法
}
