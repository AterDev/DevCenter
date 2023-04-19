namespace Application.Services.Webhook;

/// <summary>
/// gitlab 与钉钉用户手机号映射
/// </summary>
internal class Gitlab2DingTalkUserMap : Dictionary<string, string>
{
    public static Gitlab2DingTalkUserMap GetUsersMap()
    {
        // gitlab => dingtalk phone
        return new Gitlab2DingTalkUserMap
        {
            ["tanxingbao"] = "15844144943",
            ["feimengqi"] = "18019450453",
            ["yangkai"] = "15736875117",
            ["shiyi"] = "15180931351",
        };
    }
}
