using Neuzilla.SMSProvider.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuzilla.SMSProvider.Vendors.YunPian
{
    public interface IYunPianSendSMSApi: Core.ISMSApi<IApiResponse>, IMustPost
    {

    }
}
