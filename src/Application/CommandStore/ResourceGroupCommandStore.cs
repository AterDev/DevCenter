using Application.Implement;

namespace Application.CommandStore;
public class ResourceGroupCommandStore : CommandSet<ResourceGroup>
{
    public ResourceGroupCommandStore(CommandDbContext context, ILogger<ResourceGroupCommandStore> logger) : base(context, logger)
    {
    }

}
