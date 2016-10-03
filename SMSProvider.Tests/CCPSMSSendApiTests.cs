using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neuzilla.SMSProvider.Core;
using Neuzilla.SMSProvider.Vendors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSProvider.Tests
{
    [TestClass]
    public class CCPSMSSendApiTests
    {
        CCPSMSService smsService;
        [TestInitialize]
        public void Setup()
        {
            smsService = new CCPSMSService(new CCPSMSContext()
            {
                Host = ConfigurationManager.AppSettings["CCP_Host"],
                Port = ConfigurationManager.AppSettings["CCP_Port"],
                AccountId = ConfigurationManager.AppSettings["CCP_AccountSid"],
                AccessToken = ConfigurationManager.AppSettings["CCP_AccountToken"],
                AppId = ConfigurationManager.AppSettings["CCP_AppId"]
            });
        }
        [TestMethod]
        public async Task TestSendSMS_ScheduleStart()
        {
            await smsService.SendSMSTemplate("13564542929", "121032","CN/CBL-12/116","","Asset OPEX");
        }
        [TestMethod]
        public async Task TestSendSMS_ScheduleReject()
        {
            await smsService.SendSMSTemplate("13564542929", "121030", "CN/CBL-12/116", "", "Asset OPEX");
        }
        [TestMethod]
        public async Task TestSendSMS_ScheduleReview()
        {
            await smsService.SendSMSTemplate("13564542929", "121028", "CN/CBL-12/116", null, null);
        }
        [TestMethod]
        public async Task TestSendSMS_ScheduleSubmit()
        {
            await smsService.SendSMSTemplate("13564542929", "121027", "CN/CBL-12/116", "", "Asset OPEX", "Cherry Sun");
        }
        [TestMethod]
        public async Task TestSendSMS_ScheduleComplete()
        {
            await smsService.SendSMSTemplate("13564542929", "121025", "CN/CBL-12/116", "", "Asset OPEX");
        }
    }
}
