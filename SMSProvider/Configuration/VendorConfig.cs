using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Neuzilla.SMSProvider.Configuration
{
    public class VendorConfig
    {
        protected static Dictionary<string, VendorElement> _instances; static VendorConfig()
        {
            _instances = new Dictionary<string, VendorElement>();
            var sec = (VendorsConfigSection)ConfigurationManager.GetSection("vendors");
            foreach (VendorElement i in sec.Vendors)
            {
                _instances.Add(i.Name, i);
            }
        }
        public static VendorElement GetConfig(string vendorName)
        {
            return _instances[vendorName];
        }

        private VendorConfig()
        {
        }
    }
}
