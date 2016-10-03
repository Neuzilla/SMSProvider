using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuzilla.SMSProvider.Core
{
    public interface IApiResponse
    {
        int ErrorCode { get; set; }
        string ErrorMessage { get; set; }
    }
}
