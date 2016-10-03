using Neuzilla.SMSProvider.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuzilla.SMSProvider.Vendors
{

    public class HuaXinTechSendSMSApi: SMSApiWithXmlResponseBase<HuaXinTechSendSMSApiResponse>,IHuaXinTechSendSMSApi
    {

        public HuaXinTechSendSMSApi(ISMSVendorContext context) : base(context)
        {

        }
        public override HuaXinTechSendSMSApiResponse Execute()
        {
            HuaXinTechSendSMSApiResponse resp = new HuaXinTechSendSMSApiResponse();
            var xml= base.ExecuteXmlContent();
            var statusNode=xml.SelectSingleNode("/returnsms/returnstatus");
            if(statusNode==null)
                throw new SMSApiException(400, "invalid xml response");

            if (statusNode.InnerText.ToLower() == "success")
            {
                resp.ErrorCode = 0;
                var successCountsNode = xml.SelectSingleNode("/returnsms/successCounts");
                resp.SuccessSMSCount = Int32.Parse(successCountsNode.InnerText);

                var taskIDNode = xml.SelectSingleNode("/returnsms/taskID");
                resp.TaskId = Int64.Parse(taskIDNode.InnerText);
            } else
            {
                
                var msgNode = xml.SelectSingleNode("/returnsms/message");
                resp.ErrorMessage = msgNode.InnerText;
                switch (resp.ErrorMessage)
                {
                    case "用户名为空":
                        resp.ErrorCode = 501;
                        break;
                    case "手机号码为空":
                        resp.ErrorCode = 511;
                        break;
                    case "内容为空":
                        resp.ErrorCode = 521;
                        break;
                    case "用户名错误":
                        resp.ErrorCode = 502;
                        break;
                    case "错误的手机号码":
                        resp.ErrorCode = 512;
                        break;
                    case "需要签名":
                        resp.ErrorCode = 522;
                        break;
                    default:
                        if (resp.ErrorMessage.StartsWith("敏感词"))
                            resp.ErrorCode = 531;
                        else
                            resp.ErrorCode = 500;
                        break;
                }

            }
            return resp;
        }

        public override string Url
        {
            get
            {
                return "/sms.aspx";
            }
        }
        public string Account
        {
            get;set;
        }
        public string UserId
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public string Action
        {
            get { return "send"; }
        }
        public string Mobiles
        {
            get; set;
        }
        public string Content
        {
            get;set;
        }
    }
}
