using Http.API.Infrastructure;
using static Share.Services.GitLabCIGenerator;

namespace Http.API.Controllers;

/// <summary>
/// 工具集
/// </summary>
public class ToolsController : RestControllerBase
{
    [HttpPost("GitLabCIGenerator")]
    public ActionResult<string> GenerateCIYml([FromBody] SSHOption option)
    {
        return GetYmlContent(option);
    }
}
