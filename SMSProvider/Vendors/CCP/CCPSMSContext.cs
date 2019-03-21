using Neuzilla.SMSProvider.Core;
using Neuzilla.SMSProvider.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuzilla.SMSProvider.Vendors
{
    public class CCPSMSContext : ISMSVendorContext
    {
        public string AccessToken
        {
            get;set;
        }
        /// <summary>
        /// SMS Host/Url
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Account Id
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// SMS Host Port
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// App Id
        /// </summary>
        public string AppId { get; set; }
    }
}
