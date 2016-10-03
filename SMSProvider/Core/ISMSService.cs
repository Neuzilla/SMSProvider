using Neuzilla.SMSProvider.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuzilla.SMSProvider.Core
{
    public interface ISMSService<T> where T:ISMSVendorContext,new()
    {
        T Context { get; set; }
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="content">短信内容</param>
        /// <returns></returns>
        Task SendSMS(string mobile, string content);
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobiles">手机号</param>
        /// <param name="content">短信内容</param>
        /// <returns></returns>
        Task SendSMS(string[] mobiles, string content);
        /// <summary>
        /// 发送模版短信给单个手机号
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="templateId">模板编号</param>
        /// <param name="contents">短信内容</param>
        /// <returns></returns>
        Task SendSMSTemplate(string mobile, string templateId, params string[] contents);
        /// <summary>
        /// 发送模版短信给一批手机号
        /// </summary>
        /// <param name="mobiles">手机号</param>
        /// <param name="templateId">模板编号</param>
        /// <param name="contents">短信内容</param>
        /// <returns></returns>
        Task SendSMSTemplate(string[] mobiles,string templateId, params string[] contents);
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize();
    }
}
