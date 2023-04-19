using Application.Implement;

namespace Application.CommandStore;
public class ResourceTypeDefinitionCommandStore : CommandSet<ResourceTypeDefinition>
{
    public ResourceTypeDefinitionCommandStore(CommandDbContext context, ILogger<ResourceTypeDefinitionCommandStore> logger) : base(context, logger)
    {
    }

}
