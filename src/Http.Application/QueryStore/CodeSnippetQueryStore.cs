namespace Http.Application.QueryStore;
public class CodeSnippetQueryStore : QuerySet<CodeSnippet>
{
    public CodeSnippetQueryStore(QueryDbContext context, ILogger<CodeSnippetQueryStore> logger) : base(context, logger)
    {
    }
}


