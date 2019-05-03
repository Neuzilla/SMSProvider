using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neuzilla.SMSProvider.Configuration;
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
            var config = VendorConfig.GetConfig("CCP");

            var context = new CCPSMSContext() {
                Host = config.Host,
                Port = config.Port,
                AccountId = config.Username,
                AccessToken = config.AccessToken,
                AppId = config.AppId
                };

            smsService = new CCPSMSService(context);
        }
        [TestMethod]
        public async Task TestSendSMS_ScheduleStart()
        {
            await smsService.SendSMSTemplate("1356454XXXX", "121032","CN/CBL-12/116","","Asset OPEX");
        }
        [TestMethod]
        public async Task TestSendSMS_ScheduleReject()
        {
            await smsService.SendSMSTemplate("1356454XXXX", "121030", "CN/CBL-12/116", "", "Asset OPEX");
        }
        [TestMethod]
        public async Task TestSendSMS_ScheduleReview()
        {
            await smsService.SendSMSTemplate("1356454XXXX", "121028", "CN/CBL-12/116", null, null);
        }
        [TestMethod]
        public async Task TestSendSMS_ScheduleSubmit()
        {
            await smsService.SendSMSTemplate("1356454XXXX", "121027", "CN/CBL-12/116", "", "Asset OPEX", "Cherry Sun");
        }
        [TestMethod]
        public async Task TestSendSMS_ScheduleComplete()
        {
            await smsService.SendSMSTemplate("1356454XXXX", "121025", "CN/CBL-12/116", "", "Asset OPEX");
        }

        [TestMethod]
        public async Task TestSendSMS_SendCaptcha()
        {
            await smsService.SendSMSTemplate("1356454XXXX", "423937", "123456", "3");
        }
    }
}
