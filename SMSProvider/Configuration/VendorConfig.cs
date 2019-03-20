using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuzilla.SMSProvider.Configuration
{
    public class VendorConfig
    {
        protected static Dictionary<string, VendorElement> _instances; static VendorConfig()
        {
            _instances = new Dictionary<string, VendorElement>();
            VendorsConfigSection sec = (VendorsConfigSection)System.Configuration.ConfigurationManager.GetSection("vendors");
            foreach (VendorElement i in sec.Vendors)
            {
                _instances.Add(i.Name, i);
            }
        }
        public static VendorElement Instances(string instanceName)
        {
            return _instances[instanceName];
        }

        private VendorConfig()
        {
        }
    }
}
