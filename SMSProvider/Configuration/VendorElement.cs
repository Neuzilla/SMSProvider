using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuzilla.SMSProvider.Configuration
{
    public class VendorElement: ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("username")]
        public string Username
        {
            get { return (string)base["username"]; }
            set { base["username"] = value; }
        }

        [ConfigurationProperty("accessToken")]
        public string AccessToken
        {
            get { return (string)base["accessToken"]; }
            set { base["accessToken"] = value; }
        }

        [ConfigurationProperty("host", IsRequired = true)]
        public string Host
        {
            get { return (string)base["host"]; }
            set { base["host"] = value; }
        }

        [ConfigurationProperty("port")]
        public string Port
        {
            get { return (string)base["port"]; }
            set { base["port"] = value; }
        }

        [ConfigurationProperty("appId")]
        public string AppId
        {
            get { return (string)base["appId"]; }
            set { base["appId"] = value; }
        }

        [ConfigurationProperty("signature")]
        public string Signature
        {
            get { return (string)base["signature"]; }
            set { base["signature"] = value; }
        }

        [ConfigurationProperty("password")]
        public string Password
        {
            get { return (string)base["password"]; }
            set { base["password"] = value; }
        }
    }
}
