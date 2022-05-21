namespace Share.Models.Webhook.DingTalk
{
    public class MessageBase
    {
        [JsonPropertyName("msgtype")]
        public virtual string MsgType { get; set; } = default!;
        [JsonPropertyName("at")]
        public MessageAt? At { get; set; }
    }

    public class MessageAt
    {
        [JsonPropertyName("atMobiles")]
        public List<string>? AtMobiles { get; set; }
        [JsonPropertyName("atUserIds")]
        public List<string>? AtUerIds { get; set; }
        [JsonPropertyName("isAtAll")]
        public bool? IsAtAll { get; set; } = false;
    }

}
