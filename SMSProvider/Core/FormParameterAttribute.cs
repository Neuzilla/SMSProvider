using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuzilla.SMSProvider.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FormParameterAttribute : Attribute
    {
        /// <summary>
        /// Api property should be used as a query string in the request
        /// </summary>
        public FormParameterAttribute(string aliasName)
        {
            this.AliasName = aliasName;
        }
        /// <summary>
        /// Real name in the request
        /// </summary>
        public string AliasName { get; set; }
    }
}
