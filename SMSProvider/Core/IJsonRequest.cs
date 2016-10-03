using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuzilla.SMSProvider.Core
{
    public interface IJsonRequest
    {
        IJsonRequestContainer JsonData { get; set; }
    }

    public interface IJsonRequestContainer
    {

    }
}
