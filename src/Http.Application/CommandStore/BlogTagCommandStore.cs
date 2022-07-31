namespace Http.Application.CommandStore;
public class BlogTagCommandStore : CommandSet<BlogTag>
{
    public BlogTagCommandStore(CommandDbContext context, ILogger<BlogTagCommandStore> logger) : base(context, logger)
    {
    }

}
