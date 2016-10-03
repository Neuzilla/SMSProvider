using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Neuzilla.SMSProvider.Core
{
    public interface IApiWithXmlResponse<T>: IApi<T>
    {
        XmlDocument ExecuteXmlContent();
    }
}
