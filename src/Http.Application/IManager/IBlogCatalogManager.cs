using Share.Models.BlogCatalogDtos;

namespace Http.Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IBlogCatalogManager : IDomainManager<BlogCatalog, BlogCatalogUpdateDto, BlogCatalogFilterDto>
{
	// TODO: 定义业务方法
}
