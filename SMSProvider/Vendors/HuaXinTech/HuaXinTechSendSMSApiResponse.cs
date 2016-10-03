using Neuzilla.SMSProvider.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuzilla.SMSProvider.Vendors
{
    public class HuaXinTechSendSMSApiResponse : IApiResponse
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrorCode
        {
            get;set;
        }
        public long TaskId
        {
            get; set;
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage
        {
            get; set;
        }
        /// <summary>
        /// 成功短信数
        /// </summary>
        public int SuccessSMSCount
        {
            get; set;
        }
    }
}
