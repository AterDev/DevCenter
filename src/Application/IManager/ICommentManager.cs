using Application.Interface;
using Share.Models.CommentDtos;

namespace Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface ICommentManager : IDomainManager<Comment, CommentUpdateDto, CommentFilterDto, CommentItemDto>
{
    // TODO: 定义业务方法
}
