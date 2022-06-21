using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Options
{

    public record DingTalkOptions(string Name, string NotifyUrl, string Secret);
    public class WebhookOptions
    {
        public List<DingTalkOptions> DingTalk { get; set; }
    }
}
