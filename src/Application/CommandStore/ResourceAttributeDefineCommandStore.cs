using Application.Implement;

namespace Application.CommandStore;
public class ResourceAttributeDefineCommandStore : CommandSet<ResourceAttributeDefine>
{
    public ResourceAttributeDefineCommandStore(CommandDbContext context, ILogger<ResourceAttributeDefineCommandStore> logger) : base(context, logger)
    {
    }

}
