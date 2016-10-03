using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Neuzilla.SMSProvider.Utility
{
    public static class MD5Generator
    {
        public static string Generate(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return Convert.ToBase64String(result);
            //return System.Text.Encoding.Default.GetString(result);
        }
    }
}
