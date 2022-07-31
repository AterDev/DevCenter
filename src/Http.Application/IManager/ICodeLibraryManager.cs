using Share.Models.CodeLibraryDtos;

namespace Http.Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface ICodeLibraryManager : IDomainManager<CodeLibrary, CodeLibraryUpdateDto, CodeLibraryFilterDto>
{
	// TODO: 定义业务方法
}
