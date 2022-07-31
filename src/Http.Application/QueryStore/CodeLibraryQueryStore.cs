namespace Http.Application.QueryStore;
public class CodeLibraryQueryStore : QuerySet<CodeLibrary>
{
    public CodeLibraryQueryStore(QueryDbContext context, ILogger<CodeLibraryQueryStore> logger) : base(context, logger)
    {
    }
}


