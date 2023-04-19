using Application.Implement;

namespace Application.CommandStore;
public class CodeLibraryCommandStore : CommandSet<CodeLibrary>
{
    public CodeLibraryCommandStore(CommandDbContext context, ILogger<CodeLibraryCommandStore> logger) : base(context, logger)
    {
    }

}
