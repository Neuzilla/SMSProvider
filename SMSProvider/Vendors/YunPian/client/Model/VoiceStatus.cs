using Newtonsoft.Json;

namespace Neuzilla.SMSProvider.Vendors.YunPian.client.Model
{
    public class VoiceStatus : BaseStatus
    {
        [JsonProperty("uid")]
        public string Uid { set; get; }

        [JsonProperty("duration")]
        public double Duration { set; get; }
    }
}