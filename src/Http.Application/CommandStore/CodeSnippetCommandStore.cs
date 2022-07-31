namespace Http.Application.CommandStore;
public class CodeSnippetCommandStore : CommandSet<CodeSnippet>
{
    public CodeSnippetCommandStore(CommandDbContext context, ILogger<CodeSnippetCommandStore> logger) : base(context, logger)
    {
    }

}
