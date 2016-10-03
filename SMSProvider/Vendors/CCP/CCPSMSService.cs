using Neuzilla.SMSProvider.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuzilla.SMSProvider.Vendors
{
    public class CCPSMSService:ISMSService<CCPSMSContext>
    {
        CCPRestSDK api = null;
        public CCPSMSService()
        {
        }
        public CCPSMSService(CCPSMSContext context)
        {
            this.Context = context;
            Initialize();
        }

        public CCPSMSContext Context
        {
            get;set;
        }
        public void Initialize()
        {
            api = new CCPRestSDK();
            //ip格式如下，不带https://
            bool isInit = 
                api.init(this.Context.Host, this.Context.Port);
            api.setAccount(this.Context.AccountId, this.Context.AccessToken);
            api.setAppId(this.Context.AppId);
        }

        public Task SendSMS(string mobile, string content)
        {
            throw new NotImplementedException();
        }

        public Task SendSMS(string[] mobiles, string content)
        {
            throw new NotImplementedException();
        }
        public async Task SendSMSTemplate(string mobile, string templateId, params string[] contents)
        {
            await this.SendSMSTemplate(new string[] { mobile }, templateId, contents);
        }
        public async Task SendSMSTemplate(string[] mobiles, string templateId, params string[] contents)
        {
            Dictionary<string, object> retData = api.SendTemplateSMS(string.Join(",",mobiles), templateId,
                contents);
            if (retData.First().Value.ToString() != "000000")
            {
                throw new SMSApiException(Int32.Parse(retData["statusCode"].ToString()),retData["statusMsg"].ToString());
            }
        }
    }
}
