using Neuzilla.SMSProvider.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Neuzilla.SMSProvider.Core
{
    public abstract class SMSApiWithXmlResponseBase<T> : ISMSApiWithXmlResponseBase<T> where T : IApiResponse, new()
    {
        public SMSApiWithXmlResponseBase()
        {

        }

        public SMSApiWithXmlResponseBase(ISMSVendorContext context)
        {
            this.Context = context;
        }
        public virtual string AccessToken
        {
            get { return Context.AccessToken; }
        }

        public ISMSVendorContext Context
        {
            get;
            set;
        }

        public abstract string Url
        {
            get;
        }

        public virtual T Execute()
        {
            RequestBuilder<T> builder = new RequestBuilder<T>(this);
            var request = builder.GetRequest();
            var client = new RestClient(Context.Host);
            var resp = client.Execute<T>(request);
            if (resp.Data.ErrorCode != 0)
                throw new SMSApiException(resp.Data.ErrorCode, resp.Data.ErrorMessage);
            return resp.Data;
        }
        public string ExecuteRawContent()
        {
            RequestBuilder<T> builder = new RequestBuilder<T>(this);
            var request = builder.GetRequest();
            var client = new RestClient(Context.Host);
            var resp = client.Execute(request);
            if (resp.ErrorException != null)
                throw resp.ErrorException;
            return resp.Content;
        }
        public XmlDocument ExecuteXmlContent()
        {
            RequestBuilder<T> builder = new RequestBuilder<T>(this);
            var request = builder.GetRequest();
            var client = new RestClient(Context.Host);
            var resp = client.Execute(request);
            if (resp.ErrorException != null)
                throw resp.ErrorException;
            var result=resp.Content;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            return doc;
        }
    }
}
