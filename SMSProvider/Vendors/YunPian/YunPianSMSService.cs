using Neuzilla.SMSProvider.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neuzilla.SMSProvider.Vendors.YunPian.client;
using Neuzilla.SMSProvider.Vendors.YunPian.client.Model;
using Neuzilla.SMSProvider.Vendors.YunPian.client.Util;

namespace Neuzilla.SMSProvider.Vendors.YunPian
{
    public class YunPianSMSService : ISMSService<YunPianSMSContext>
    {
        public YunPianSMSContext Context
        {
            get; set;
        }
        public YunPianSMSService(YunPianSMSContext context)
        {
            this.Context = context;
            Initialize();
        }

        private YunpianClient yunpianClient = null;



        public void Initialize()
        {
            Dictionary<string, string> TestDev = new Dictionary<string, string>
        {
            {Const.YpVersion, Const.VersionV2},
           
            {Const.YpSmsHost,  Context.Host},
            {Const.HttpCharset, "utf-8"},
            {Const.HttpSoTimeout, "30"} //second
        };

            if (yunpianClient == null)
            {
                //test dev
                 //yunpianClient = new YunpianClient(Context.AccessToken, TestDev).Init();
                yunpianClient = new YunpianClient(Context.AccessToken).Init();
            }
        }

        public async Task SendSMS(string mobile, string content)
        {
            await SendSMS(new[] { mobile }, content);
        }

        public async Task SendSMS(string[] mobiles, string content)
        {
            var param = new Dictionary<string, string>
            {
                [Const.Mobile] = string.Join(",", mobiles),
                [Const.Text] = content,
            };
            var r = yunpianClient.Sms().BatchSend(param);
            yunpianClient.Dispose();
            if (r == null)
            {
                throw new SMSApiException(500, "未知错误");
            }
            else if (r.Code != 0)
            {
                throw new SMSApiException(r.Code, r.Msg);
            }
        }

        public async Task SendSMSTemplate(string mobile, string templateId, params string[] contents)
        {
            await SendSMSTemplate(new[] { mobile }, templateId, contents);
        }

        public async Task SendSMSTemplate(string[] mobiles, string templateId, params string[] contents)
        {
            throw new NotImplementedException();
            //var param = new Dictionary<string, string>
            //{
            //    [Const.Mobile] = string.Join(",", mobiles),
            //    [Const.Text] = ApiUtil.UrlEncodeAndLink("utf-8", ",", contents),
            //    [Const.TplId] = templateId
            //};
            //var r = yunpianClient.Sms().TplBatchSend(param);
            //yunpianClient.Dispose();
            //if (r == null)
            //{
            //    throw new SMSApiException(500, "未知错误");
            //}
            //else if (r.Code != 0)
            //{
            //    throw new SMSApiException(r.Code, r.Msg);
            //}

            //不支持直接用tplid
            // var param = new Dictionary<string, string>
            //{
            //    [Const.Mobile] = "18616020611",
            //    [Const.TplId] = "1",
            //    [Const.TplValue] = "#company#=云片网"
            //};

        }
    }
}
