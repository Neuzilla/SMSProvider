using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuzilla.SMSProvider.Configuration
{
    public class VendorElementCollection:ConfigurationElementCollection, IEnumerable<VendorElement>
    {
        private readonly List<VendorElement> elements;
        public VendorElementCollection()
        {
            this.elements = new List<VendorElement>();
        }
        protected override ConfigurationElement CreateNewElement()
        {
            var element = new VendorElement();
            this.elements.Add(element);
            return element;
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((VendorElement)element).Name;
        }

        public new IEnumerator<VendorElement> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }
    }
}
