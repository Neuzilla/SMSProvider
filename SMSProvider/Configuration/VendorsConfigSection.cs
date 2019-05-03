using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuzilla.SMSProvider.Configuration
{
    public class VendorsConfigSection: ConfigurationSection
    {
        [ConfigurationProperty("connector")]
        public string Connector
        {
            get
            {
                return (string)base["connector"];
            }
            set
            {
                base["connector"] = value;
            }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(VendorElementCollection), AddItemName = "vendor")]
        public VendorElementCollection Vendors
        {
            get {
                return (VendorElementCollection)this[""];
            }
        }
    }
}