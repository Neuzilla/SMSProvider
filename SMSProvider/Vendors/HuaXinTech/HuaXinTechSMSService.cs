using Neuzilla.SMSProvider.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuzilla.SMSProvider.Vendors
{
    public class HuaXinTechSMSService : ISMSService<HuaXinTechSMSContext>
    {
        HuaXinTechSendSMSApi api = null;
        public HuaXinTechSMSService()
        {
        }
        public HuaXinTechSMSService(HuaXinTechSMSContext context)
        {
            this.Context = context;
            this.Initialize();
        }

        public HuaXinTechSMSContext Context
        {
            get;set;
        }
        public void Initialize()
        {
            this.api = new HuaXinTechSendSMSApi(this.Context);
            api.Account = Context.AccountId;
            api.Password = Context.PasswordMD5;
        }
        public async Task SendSMS(string mobile, string content)
        {
            await SendSMS(new string[] { mobile }, content);
        }
        public async Task SendSMS(string[] mobiles, string content)
        {
            api.Mobiles = string.Join(",",mobiles);
            if(!string.IsNullOrEmpty(content))
                api.Content = content+ Context.Signature;
            var resp = api.Execute();
            if (resp == null)
            {
                throw new SMSApiException(500, "未知错误");
            }
            else if(resp.ErrorCode != 0)
            {
                throw new SMSApiException(resp.ErrorCode, resp.ErrorMessage);
            }
        }
        public Task SendSMSTemplate(string mobile, string templateId, params string[] contents)
        {
            throw new NotImplementedException();
        }
        public Task SendSMSTemplate(string[] mobiles, string templateId, params string[] contents)
        {
            throw new NotImplementedException();
        }
    }
}
