using Neuzilla.SMSProvider.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuzilla.SMSProvider.Vendors.YunPian
{
    public class YunPianSMSContext : ISMSVendorContext
    {
        public string AccessToken
        {
            get; set;
        }
        public string Host { get; set; }

        public string AccountId { get; set; }

    }
}
