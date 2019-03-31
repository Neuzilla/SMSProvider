﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Neuzilla.SMSProvider.Vendors.YunPian.client.Model
{
    public class BlackWord
    {
        [JsonProperty("black_word")]
        public string BlackWordList { set; get; }

        public List<string> ToList()
        {
            return BlackWordList != null ? new List<string>(BlackWordList.Split(',')) : new List<string>();
        }
    }
}