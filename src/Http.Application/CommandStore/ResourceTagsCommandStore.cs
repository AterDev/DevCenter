namespace Http.Application.CommandStore;
public class ResourceTagsCommandStore : CommandSet<ResourceTags>
{
    public ResourceTagsCommandStore(CommandDbContext context, ILogger<ResourceTagsCommandStore> logger) : base(context, logger)
    {
    }

}
