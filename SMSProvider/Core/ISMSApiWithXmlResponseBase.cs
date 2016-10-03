using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuzilla.SMSProvider.Core
{
    public interface ISMSApiWithXmlResponseBase<T> : IApiWithXmlResponse<T>
    {
        ISMSVendorContext Context { get; set; }
    }
}
