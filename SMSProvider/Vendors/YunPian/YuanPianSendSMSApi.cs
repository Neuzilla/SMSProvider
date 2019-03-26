using Neuzilla.SMSProvider.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuzilla.SMSProvider.Vendors.YunPian
{
    public class YuanPianSendSMSApi : SMSApiBase<YunPianSendSMSApiResponse>, IYunPianSendSMSApi
    {
        public override string Url
        {
            get {
                return "";
            }
        }

        IApiResponse IApi<IApiResponse>.Execute()
        {
            throw new NotImplementedException();
        }
    }
}
