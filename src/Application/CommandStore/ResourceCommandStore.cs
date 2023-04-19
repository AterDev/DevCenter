using Application.Implement;

namespace Application.CommandStore;
public class ResourceCommandStore : CommandSet<Resource>
{
    public ResourceCommandStore(CommandDbContext context, ILogger<ResourceCommandStore> logger) : base(context, logger)
    {
    }

}
