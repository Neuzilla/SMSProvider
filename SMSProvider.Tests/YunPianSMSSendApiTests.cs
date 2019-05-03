using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using Neuzilla.SMSProvider.Vendors;
using Neuzilla.SMSProvider.Core;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Neuzilla.SMSProvider.Configuration;
using Neuzilla.SMSProvider.Vendors.YunPian;

namespace SMSProvider.Tests
{
    [TestClass]
    public class YunPianSMSSendApiTests
    {
        protected YunPianSMSContext context;
        YunPianSMSService api = null;

        [TestInitialize]
        public void Setup()
        {
            context = new YunPianSMSContext();

            var config = VendorConfig.GetConfig("YunPian");
            context.Host = config.Host;
            context.AccessToken = config.AccessToken;

            api = new YunPianSMSService(context);
        }

       
        [TestMethod]
        public async Task TestYunPianSMSSendApi()
        {
            await api.SendSMS("156XXXXXXX2", "【上海尼梭】您的验证码是162343");
        }
        [TestMethod]
        public async Task TestYunPianSMSSendApi_MutipleMobiles()
        {
            var mobiles = new string[] { "156XXXXXXX2", "156XXXXXXX2", "156XXXXXXX2", "156XXXXXXX2", "156XXXXXXX2" };  //测试前记得更换批量手机号
            await api.SendSMS(mobiles, "【上海尼梭】您的验证码是334422");
        }
        
      

     
    }
}
