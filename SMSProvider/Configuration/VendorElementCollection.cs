using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuzilla.SMSProvider.Configuration
{
    public class VendorElementCollection:ConfigurationElementCollection 
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new VendorElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((VendorElement)element).Name;
        }
        protected override string ElementName
        {
            get
            {
                return "vendor";
            }
        }
        public VendorElement this[int index]
        {
            get
            {
                return (VendorElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
    }
}
