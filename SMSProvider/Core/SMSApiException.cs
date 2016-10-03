using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuzilla.SMSProvider.Core
{
    public class SMSApiException : Exception
    {
        public SMSApiException(int errorCode, string errorMsg)
            : base(errorMsg)
        {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; set; }
    }
}
