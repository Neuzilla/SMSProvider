using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuzilla.SMSProvider.Core
{
    public interface ISMSVendorContext
    {
        /// <summary>
        /// 主机地址
        /// </summary>
        string Host { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        string AccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string AccessToken { get; set; }
    }
}
