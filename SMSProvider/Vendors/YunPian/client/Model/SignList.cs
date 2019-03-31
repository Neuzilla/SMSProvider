using System.Collections.Generic;
using Newtonsoft.Json;

namespace Neuzilla.SMSProvider.Vendors.YunPian.client.Model
{
    public class SignList
    {
        [JsonProperty("total")]
        public int Total { set; get; }

        [JsonProperty("sign")]
        public List<Sign> Sign { set; get; }
    }
}