using Neuzilla.SMSProvider.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Initialize()
        {
            
        }

        public Task SendSMS(string mobile, string content)
        {
            throw new NotImplementedException();
        }

        public Task SendSMS(string[] mobiles, string content)
        {
            throw new NotImplementedException();
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
