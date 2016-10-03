using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Neuzilla.SMSProvider.Core
{
    public interface IApi<T>
    {
        string Url { get; }
        T Execute();
        string ExecuteRawContent();
    }
}
