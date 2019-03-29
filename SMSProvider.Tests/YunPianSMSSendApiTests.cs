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

            //var config = VendorConfig.Instances("YunPian");
            context.Host = ConfigurationManager.AppSettings["YunPian_Host"];
            context.AccessToken = ConfigurationManager.AppSettings["YunPian_ApiKey"];


            //context.Host = ConfigurationManager.AppSettings["HuaXinTech_Host"];
            //context.AccountId = ConfigurationManager.AppSettings["HuaXinTech_Username"];
            //context.PasswordMD5 = ConfigurationManager.AppSettings["HuaXinTech_PasswordMD5"];
            //context.Signature = ConfigurationManager.AppSettings["HuaXinTech_Signature"]; ;
            //context.Userid = "";

            api = new YunPianSMSService(context);
            //string accesstoken = context.AccessToken;
        }

       
        [TestMethod]
        public async Task TestYunPianSMSSendApi()
        {
            await api.SendSMS("15618979112", "【上海尼梭】您的验证码是1234");

//            Assert.AreEqual(1, resp.SuccessSMSCount);
//            Assert.IsTrue(resp.TaskId > 0);
        }
        [TestMethod]
        public async Task TestYunPianSMSSendApi_MutipleMobiles()
        {
            var mobiles = new string[] { "15618979112", "19945717753" };
            await api.SendSMS(mobiles, "【上海尼梭】您的验证码是3333");
        }
        
      

     
    }
}
