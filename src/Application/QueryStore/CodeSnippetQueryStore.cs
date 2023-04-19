using Application.Implement;

namespace Application.QueryStore;
public class CodeSnippetQueryStore : QuerySet<CodeSnippet>
{
    public CodeSnippetQueryStore(QueryDbContext context, ILogger<CodeSnippetQueryStore> logger) : base(context, logger)
    {
    }
}


