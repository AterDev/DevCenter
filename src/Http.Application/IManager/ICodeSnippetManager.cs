using Share.Models.CodeSnippetDtos;

namespace Http.Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface ICodeSnippetManager : IDomainManager<CodeSnippet, CodeSnippetUpdateDto, CodeSnippetFilterDto>
{
	// TODO: 定义业务方法
}
