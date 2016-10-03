using Neuzilla.SMSProvider.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuzilla.SMSProvider.Vendors
{
    public interface IHuaXinTechSendSMSApi: ISMSApiWithXmlResponseBase<HuaXinTechSendSMSApiResponse>,IMustPost
    {
        [FormParameter("account")]
        string Account
        {
            get; set;
        }
        [FormParameter("userid")]
        string UserId
        {
            get; set;
        }
        [FormParameter("password")]
        string Password
        {
            get; set;
        }
        [FormParameter("action")]
        string Action
        {
            get;
        }
        [FormParameter("mobile")]
        string Mobiles
        {
            get; set;
        }
        [FormParameter("content")]
        string Content
        {
            get; set;
        }
    }
}
