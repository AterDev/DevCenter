using Application.Implement;

namespace Application.CommandStore;
public class CommentCommandStore : CommandSet<Comment>
{
    public CommentCommandStore(CommandDbContext context, ILogger<CommentCommandStore> logger) : base(context, logger)
    {
    }

}
