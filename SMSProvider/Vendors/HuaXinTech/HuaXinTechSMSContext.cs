using Neuzilla.SMSProvider.Core;
using Neuzilla.SMSProvider.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuzilla.SMSProvider.Vendors
{
    public class HuaXinTechSMSContext:ISMSVendorContext
    {
        public string AccessToken
        {
            get;set;
        }

        public string Host { get; set; }

        public string AccountId { get; set; }
        /// <summary>
        /// 密码的MD5码
        /// </summary>
        public string PasswordMD5 { get; set; }

        public string Signature { get; set; }

        /// <summary>
        /// 用户ID，可不填
        /// </summary>
        public string Userid { get; set; }
    }
}
