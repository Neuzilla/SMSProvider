using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neuzilla.SMSProvider.Vendors.YunPian.client.Model;
using RestSharp.Extensions.MonoHttp;

namespace Neuzilla.SMSProvider.Vendors.YunPian.client.Util
{
    public static class ApiUtil
    {
        public static string UrlEncodeAndLink(string charset, string seperator, params string[] text)
        {
            if (charset == null)
                charset = Const.HttpCharsetDefault;

            if (seperator == null)
                seperator = Const.SeperatorComma;

            var encoding = Encoding.GetEncoding(charset);
            return string.Join(seperator, text.Select(t => HttpUtility.UrlEncode(t, encoding)));
            // return string.Join(seperator, text);
        }
    }
}
