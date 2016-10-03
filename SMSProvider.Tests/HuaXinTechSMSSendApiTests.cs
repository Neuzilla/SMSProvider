using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using Neuzilla.SMSProvider.Vendors;
using Neuzilla.SMSProvider.Core;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMSProvider.Tests
{
    [TestClass]
    public class HuaXinTechSMSSendApiTests
    {
        protected HuaXinTechSMSContext context;
        HuaXinTechSMSService api = null;

        [TestInitialize]
        public void Setup()
        {
            context = new HuaXinTechSMSContext();
            context.Host = ConfigurationManager.AppSettings["HuaXinTech_Host"];
            context.AccountId = ConfigurationManager.AppSettings["HuaXinTech_Username"];
            context.PasswordMD5 = ConfigurationManager.AppSettings["HuaXinTech_PasswordMD5"];
            context.Signature = ConfigurationManager.AppSettings["HuaXinTech_Signature"]; ;
            context.Userid = "";

            api = new HuaXinTechSMSService(context);
            //string accesstoken = context.AccessToken;
        }

        [TestMethod]
        public void TestHandleXmlMessage()
        {
            string sampleXmlResponse = "<?xml version=\"1.0\"  encoding=\"utf-8\" ?>"
                + "<returnsms>"
                + "<returnstatus>Success</returnstatus>"
                + "<message>test message</message>"
                + "<remainpoint>1110</remainpoint>"
                + "<taskID>115</taskID>"
                + "<successCounts>2</successCounts>"
                + "</returnsms>";
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(sampleXmlResponse);
            var statusNode = xml.SelectSingleNode("/returnsms/returnstatus");
            Assert.IsNotNull(statusNode);

            Assert.AreEqual("success", statusNode.InnerText.ToLower());
            var msgNode = xml.SelectSingleNode("/returnsms/message");
            Assert.IsNotNull(msgNode);
            Assert.AreEqual("test message", msgNode.InnerText.ToLower());

            var successCountsNode = xml.SelectSingleNode("/returnsms/successCounts");
            Assert.IsNotNull(successCountsNode);
            Assert.AreEqual(2, Int32.Parse(successCountsNode.InnerText));

        }
        [TestMethod]
        public async Task TestHuaxinTechSMSSendApi()
        {
            await api.SendSMS("13564542929", "CN/CBL-16/112项目已暂停");

//            Assert.AreEqual(1, resp.SuccessSMSCount);
//            Assert.IsTrue(resp.TaskId > 0);
        }
        [TestMethod]
        public async Task TestHuaxinTechSMSSendApi_MutipleMobiles()
        {
            var mobiles = new string[] { "13564542929", "18616622603" };
            await api.SendSMS(mobiles, "CN/CBL-16/113项目已取消");
        }
        [TestMethod]
        public async Task TestHuaxinTechSMSSendApi_MutipleMobiles_SomeInvalid()
        {
            var mobiles = new string[] { "13564542929", "18616622603","1234434" };
            await api.SendSMS(mobiles, "CN/CBL-16/112合同将于一个月内结束");
            //Assert.AreEqual(2, resp.SuccessSMSCount);
        }
        [TestMethod]
        public void TestHuaxinTechSMSSendApi_EmptyAccount()
        {
            var api = new HuaXinTechSendSMSApi(context);

            var resp = api.Execute();
            Assert.IsNotNull(resp);
            Assert.AreEqual("用户名为空", resp.ErrorMessage);
            Assert.AreEqual(501, resp.ErrorCode);
            
        }
        [TestMethod]
        public void TestHuaxinTechSMSSendApi_InvalidAccount()
        {
            var api = new HuaXinTechSendSMSApi(context);

            api.Account = "abc";
            var resp = api.Execute();
            Assert.IsNotNull(resp);
            
            Assert.AreEqual(502, resp.ErrorCode);
            Assert.AreEqual("用户名错误", resp.ErrorMessage);

        }
        [TestMethod]
        public async Task TestHuaxinTechSMSSendApi_EmptyMobile()
        {
            bool exceptionCaptured = false;
            try
            {
                await api.SendSMS("", "CN/CBL-16/112项目已暂停");
            }
            catch (SMSApiException ex)
            {
                Assert.AreEqual(511, ex.ErrorCode);
                Assert.AreEqual("手机号码为空", ex.Message);
                exceptionCaptured = true;
            }
            Assert.IsTrue(exceptionCaptured);
        }
        [TestMethod]
        public async Task TestHuaxinTechSMSSendApi_EmptyContent()
        {
            bool exceptionCaptured = false;
            try
            {
                await api.SendSMS("13564542929", "");
            }
            catch (SMSApiException ex)
            {
                Assert.AreEqual(521, ex.ErrorCode);
                Assert.AreEqual("内容为空", ex.Message);
                exceptionCaptured = true;
            }
            Assert.IsTrue(exceptionCaptured);

        }
        [TestMethod]
        public async Task TestHuaxinTechSMSSendApi_InvalidMobile()
        {
            bool exceptionCaptured = false;
            try
            {
                await api.SendSMS("1356324", "CN/CBL-16/112项目已暂停");
            }
            catch (SMSApiException ex)
            {
                Assert.AreEqual(512, ex.ErrorCode);
                Assert.AreEqual("错误的手机号码", ex.Message);
                exceptionCaptured = true;
            }
            Assert.IsTrue(exceptionCaptured);
        }
        [TestMethod]
        public async Task TestHuaxinTechSMSSendApi_InvalidContent_NoSignature()
        {
            api.Context.Signature = null;
            bool exceptionCaptured = false;
            try
            {
                await api.SendSMS("13564542929", "CN/CBL-16/112项目已暂停");
            }
            catch (SMSApiException ex)
            {
                Assert.AreEqual(522, ex.ErrorCode);
                Assert.AreEqual("需要签名", ex.Message);
                exceptionCaptured = true;
            }
            Assert.IsTrue(exceptionCaptured);
        }
        [TestMethod]
        public async Task TestHuaxinTechSMSSendApi_InvalidContent_SensentiveWord()
        {
            bool exceptionCaptured = false;
            try
            {
                await api.SendSMS("13564542929", "CN/CBL-16/112项目已暂停江泽民坏事做尽");
            }
            catch (SMSApiException ex)
            {
                Assert.AreEqual(531, ex.ErrorCode);
                Assert.AreEqual("敏感词(江泽民)", ex.Message);
                exceptionCaptured = true;
            }
            Assert.IsTrue(exceptionCaptured);
        }

        [TestMethod]
        public async Task TestHuaxinTechSMSSendApi_WhitespaceInEnglishTitle()
        {
           string msg = string.Format("{0} {1} {2} - 此排期已经全部完成{3}",
            "CN/CBL-16/115", "Lvcheng Shanghai LEED CS Consulting", "Asset CAPEX", context.Signature);
                   await api.SendSMS("13564542929", msg);
        }
    }
}
