﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Neuzilla.SMSProvider.Vendors.YunPian.client.Model;

namespace Neuzilla.SMSProvider.Vendors.YunPian.client.Api
{
    public class SmsApi : YunpianApi
    {
        public const string ApiName = "sms";

        public override void Init(YunpianClient clnt)
        {
            base.Init(clnt);
            Name = ApiName;
            Host = clnt.Conf().Get(Const.YpSmsHost, "https://sms.yunpian.com");
        }

        /**
         * <h1>智能匹配模板发送 only v1</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * mobile String 是 接收的手机号;发送多个手机号请以逗号分隔，一次不要超过1000个
         * 国际短信仅支持单号码发送，国际号码需包含国际地区前缀号码，格式必须是"+"号开头("+"号需要urlencode处理，否则会出现格式错误)，国际号码不以"+"开头将被认为是中国地区的号码
         * （针对国际短信，mobile参数会自动格式化到E.164格式，可能会造成传入mobile参数跟后续的状态报告中的号码不一致。E.164格式说明，参见：
         * https://en.wikipedia.org/wiki/E.164） 单号码：15205201314
         * 多号码：15205201314,15205201315 国际短信：+93701234567
         * </p>
         * <p>
         * text String 是 短信内容 【云片网】您的验证码是1234
         * </p>
         * <p>
         * extend String 否 扩展号。默认不开放，如有需要请联系客服申请 001
         * </p>
         * <p>
         * uid String 否 该条短信在您业务系统内的ID，比如订单号或者短信发送记录的流水号。填写后发送状态返回值内将包含这个ID
         * 默认不开放，如有需要请联系客服申请 10001
         * </p>
         * <p>
         * callback_url String 否
         * 本条短信状态报告推送地址。短信发送后将向这个地址推送短信发送报告。"后台-系统设置-数据推送与获取”可以做批量设置。如果后台已经设置地址的情况下，单次请求内也包含此参数，将以请求内的推送地址为准。
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<SmsSingleSend> Send(Dictionary<string, string> param)
        {
            var r = new Result<SmsSingleSend>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Mobile, Const.Text);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            Version = Const.VersionV1;
            var h = new MapResultHandler<SmsSingleSend>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                    {
                        return rsp[Const.Result].ToObject<SmsSingleSend>();
                    }
                    default: return null;
                }
            });

            try
            {
                Path = "send.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>单条发送</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * mobile String 是
         * 接收的手机号；仅支持单号码发送；国际号码需包含国际地区前缀号码，格式必须是"+"号开头("+"号需要urlencode处理，否则会出现格式错误)，国际号码不以"+"开头将被认为是中国地区的号码
         * （针对国际短信，mobile参数会自动格式化到E.164格式，可能会造成传入mobile参数跟后续的状态报告中的号码不一致。E.164格式说明，参见：
         * https://en.wikipedia.org/wiki/E.164） 国内号码：15205201314
         * 国际号码：urlencode("+93701234567");
         * </p>
         * <p>
         * text String 是 短信内容 【云片网】您的验证码是1234
         * </p>
         * <p>
         * extend String 否 扩展号。默认不开放，如有需要请联系客服申请 001
         * </p>
         * <p>
         * uid String 否 该条短信在您业务系统内的ID，比如订单号或者短信发送记录的流水号。填写后发送状态返回值内将包含这个ID
         * 默认不开放，如有需要请联系客服申请 10001
         * </p>
         * <p>
         * callback_url String 否
         * 本条短信状态报告推送地址。短信发送后将向这个地址推送短信发送报告。"后台-系统设置-数据推送与获取”可以做批量设置。如果后台已经设置地址的情况下，单次请求内也包含此参数，将以请求内的推送地址为准。
         * http://your_receive_url_address
         * </p>
         * <p>
         * register Boolean 否 是否为注册验证码短信，如果传入true，则该条短信作为注册验证码短信统计注册成功率。
         * 默认不开放，如有需要请联系客服申请 true
         * </p>
         * <p>
         * mobile_stat Boolean 否 按手机号统计短链接点击量，为手机号生成专属短链接，并自动替换短信中的短链接（限yp2.cn）。 true
         * </p>
         *
         * @param param
         * @return
         */
        public Result<SmsSingleSend> SingleSend(Dictionary<string, string> param)
        {
            var r = new Result<SmsSingleSend>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Mobile, Const.Text);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<SmsSingleSend>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<SmsSingleSend>();
                    }
                    default: return null;
                }
            });

            try
            {
                Path = "single_send.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>批量发送</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * mobile String 是 接收的手机号；发送多个手机号请以逗号分隔，一次不要超过1000个。 单号码：15205201314
         * 多号码：15205201314,15205201315
         * </p>
         * <p>
         * text String 是 短信内容 【云片网】您的验证码是1234
         * </p>
         * <p>
         * extend String 否 扩展号。默认不开放，如有需要请联系客服申请 001
         * </p>
         * <p>
         * uid String 否 该条短信在您业务系统内的ID，比如订单号或者短信发送记录的流水号。填写后发送状态返回值内将包含这个ID
         * 默认不开放，如有需要请联系客服申请 10001
         * </p>
         * <p>
         * callback_url String 否
         * 本条短信状态报告推送地址。短信发送后将向这个地址推送短信发送报告。"后台-系统设置-数据推送与获取”可以做批量设置。如果后台已经设置地址的情况下，单次请求内也包含此参数，将以请求内的推送地址为准。
         * http://your_receive_url_address
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<SmsBatchSend> BatchSend(Dictionary<string, string> param)
        {
            var r = new Result<SmsBatchSend>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Mobile, Const.Text);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<SmsBatchSend>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        var batch = new SmsBatchSend
                        {
                            TotalCount = rsp[Const.TotalCount].ToObject<int>(),
                            TotalFee = rsp[Const.TotalFee].ToObject<double>(),
                            Data = rsp[Const.Data].ToObject<List<SmsSingleSend>>()
                        };
                        return batch;
                    }
                    default: return null;
                }
            });

            try
            {
                Path = "batch_send.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>个性化发送</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * mobile String 是
         * 接收的手机号；多个手机号请以逗号分隔，一次不要超过1000个且手机号个数必须与短信内容条数相等；不支持国际号码发送；
         * 多号码：15205201314,15205201315
         * </p>
         * <p>
         * text String 是
         * 短信内容，多个短信内容请使用UTF-8做urlencode后，使用逗号分隔，一次不要超过1000条且短信内容条数必须与手机号个数相等
         * 内容示意：UrlEncode("【云片网】您的验证码是1234", "UTF-8") + "," +
         * UrlEncode("【云片网】您的验证码是5678", "UTF-8")
         * </p>
         * <p>
         * extend String 否 扩展号。默认不开放，如有需要请联系客服申请 001
         * </p>
         * <p>
         * uid String 否 该条短信在您业务系统内的ID，比如订单号或者短信发送记录的流水号。填写后发送状态返回值内将包含这个ID
         * 默认不开放，如有需要请联系客服申请 10001
         * </p>
         * <p>
         * callback_url String 否
         * 本条短信状态报告推送地址。短信发送后将向这个地址推送短信发送报告。"后台-系统设置-数据推送与获取”可以做批量设置。如果后台已经设置地址的情况下，单次请求内也包含此参数，将以请求内的推送地址为准。
         * http://your_receive_url_address
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<SmsBatchSend> MultiSend(Dictionary<string, string> param)
        {
            var r = new Result<SmsBatchSend>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Mobile, Const.Text);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<SmsBatchSend>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        var batch = new SmsBatchSend
                        {
                            TotalCount = rsp[Const.TotalCount].ToObject<int>(),
                            TotalFee = rsp[Const.TotalFee].ToObject<double>(),
                            Data = rsp[Const.Data].ToObject<List<SmsSingleSend>>()
                        };
                        return batch;
                    }
                    default: return null;
                }
            });

            try
            {
                Path = "multi_send.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * /v1/sms/multi_send.json
         * 
         * @param param
         * @return
         */
        public Result<List<SmsSingleSend>> MultiSendV1(Dictionary<string, string> param)
        {
            var r = new Result<List<SmsSingleSend>>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Mobile, Const.Text);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            Version = Const.VersionV1;
            var h = new SimpleListResultHandler<SmsSingleSend>(Version);

            try
            {
                Path = "multi_send.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>获取状态报告</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * page_size Integer 否 每页个数，最大100个，默认20个 20
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<List<SmsStatus>> PullStatus(Dictionary<string, string> param)
        {
            var r = new Result<List<SmsStatus>>();
            r = CheckParam(ref param, r, Const.Apikey);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new ListMapResultHandler<SmsStatus>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                    {
                        return rsp is JObject
                            ? rsp[Const.SmsStatus].ToObject<List<SmsStatus>>()
                            : new List<SmsStatus>();
                    }
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<List<SmsStatus>>();
                    }
                    default: return new List<SmsStatus>();
                }
            });

            try
            {
                Path = "pull_status.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>获取回复短信</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * page_size Integer 否 每页个数，最大100个，默认20个 20
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<List<SmsReply>> PullReply(Dictionary<string, string> param)
        {
            var r = new Result<List<SmsReply>>();
            r = CheckParam(ref param, r, Const.Apikey);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new ListMapResultHandler<SmsReply>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                    {
                        return rsp is JObject 
                            ? rsp[Const.SmsReply].ToObject<List<SmsReply>>()
                            : new List<SmsReply>();
                    }
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<List<SmsReply>>();
                    }
                    default: return new List<SmsReply>();
                }
            });

            try
            {
                Path = "pull_reply.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>查回复的短信</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * start_time String 是 短信回复开始时间 2013-08-11 00:00:00
         * </p>
         * <p>
         * end_time String 是 短信回复结束时间 2013-08-12 00:00:00
         * </p>
         * <p>
         * page_num Integer 是 页码，默认值为1 1
         * </p>
         * <p>
         * page_size Integer 是 每页个数，最大100个 20
         * </p>
         * <p>
         * mobile String 否 填写时只查该手机号的回复，不填时查所有的回复 15205201314
         * </p>
         * <p>
         * return_fields 否 返回字段（暂未开放
         * </p>
         * <p>
         * sort_fields 否 排序字段（暂未开放） 默认按提交时间降序
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<List<SmsReply>> GetReply(Dictionary<string, string> param)
        {
            var r = new Result<List<SmsReply>>();
            r = CheckParam(ref param, r, Const.Apikey, Const.StartTime, Const.EndTime, Const.PageNum, Const.PageSize);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new ListMapResultHandler<SmsReply>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                    {
                        return rsp is JObject 
                            ? rsp[Const.SmsReply].ToObject<List<SmsReply>>()
                            : new List<SmsReply>();
                    }
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<List<SmsReply>>();
                    }
                    default: return new List<SmsReply>();
                }
            });

            try
            {
                Path = "get_reply.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>查屏蔽词</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * text String 是 要检查的短信模板或者内容 这是一条测试短信
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<List<string>> GetBlackWord(Dictionary<string, string> param)
        {
            var r = new Result<List<string>>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Text);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new ListMapResultHandler<string>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                    {
                        return rsp is JObject
                            ? rsp[Const.Result].ToObject<BlackWord>().ToList()
                            : new List<string>();
                    }
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<List<string>>();
                    }
                    default: return new List<string>();
                }
            });

            try
            {
                Path = "get_black_word.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>查短信发送记录</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * mobile String 否 需要查询的手机号 15205201314
         * </p>
         * <p>
         * start_time String 是 短信发送开始时间 2013-08-11 00:00:00
         * </p>
         * <p>
         * end_time String 是 短信发送结束时间 2013-08-12 00:00:00
         * </p>
         * <p>
         * page_num Integer 否 页码，默认值为1 1
         * </p>
         * <p>
         * page_size Integer 否 每页个数，最大100个 20
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<List<SmsRecord>> GetRecord(Dictionary<string, string> param)
        {
            var r = new Result<List<SmsRecord>>();
            r = CheckParam(ref param, r, Const.Apikey, Const.StartTime, Const.EndTime);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new ListMapResultHandler<SmsRecord>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                    {
                        return rsp is JObject
                            ? rsp[Const.Sms].ToObject<List<SmsRecord>>()
                            : new List<SmsRecord>();
                    }
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<List<SmsRecord>>();
                    }
                    default: return new List<SmsRecord>();
                }
            });

            try
            {
                Path = "get_record.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>统计短信条数</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * start_time String 是 短信发送开始时间 2013-08-11 00:00:00
         * </p>
         * <p>
         * end_time String 是 短信发送结束时间 2013-08-12 00:00:00
         * </p>
         * <p>
         * mobile String 否 需要查询的手机号 15205201314
         * </p>
         * <p>
         * page_num Integer 否 页码，默认值为1 1
         * </p>
         * <p>
         * page_size Integer 否 每页个数，最大100个 20
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<int> Count(Dictionary<string, string> param)
        {
            var r = new Result<int>();
            r = CheckParam(ref param, r, Const.Apikey, Const.StartTime, Const.EndTime);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new ValueResultHandler<int>(Version, int.Parse);

            try
            {
                Path = "count.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }


        /**
         * <h1>指定模板发送 only v1</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * mobile String 是 接收的手机号 15205201314
         * </p>
         * <p>
         * tpl_id Long 是 模板id 1
         * </p>
         * <p>
         * tpl_value String 是 变量名和变量值对。请先对您的变量名和变量值分别进行urlencode再传递。使用参考：代码示例。
         * 注：变量名和变量值都不能为空 模板： 【#company#】您的验证码是#code#。 最终发送结果： 【云片网】您的验证码是1234。
         * tplvalue=urlencode("#code#") + "=" + urlencode("1234") + "&amp;" +
         * urlencode("#company#") + "=" + urlencode("云片网"); 若您直接发送报文请求则使用下面这种形式
         * tplvalue=urlencode(urlencode("#code#") + "=" + urlencode("1234") +
         * "&amp;" + urlencode("#company#") + "=" + urlencode("云片网"));
         * </p>
         * <p>
         * extend String 否 扩展号。默认不开放，如有需要请联系客服申请 001
         * </p>
         * <p>
         * uid String 否 用户自定义唯一id。最大长度不超过256的字符串。 默认不开放，如有需要请联系客服申请 10001
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<SmsSingleSend> TplSend(Dictionary<string, string> param)
        {
            var r = new Result<SmsSingleSend>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Mobile, Const.TplId, Const.TplValue);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            Version = Const.VersionV1;
            var h = new MapResultHandler<SmsSingleSend>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                    {
                        return rsp[Const.Result]?.ToObject<SmsSingleSend>();
                    }

                    default: return null;
                }
            });

            try
            {
                Path = "tpl_send.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>指定模板单发 only v2</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * mobile String 是
         * 接收的手机号（针对国际短信，mobile参数会自动格式化到E.164格式，可能会造成传入mobile参数跟后续的状态报告中的号码不一致。E.164格式说明，参见：
         * https://en.wikipedia.org/wiki/E.164） 15205201314
         * </p>
         * <p>
         * tpl_id Long 是 模板id 1
         * </p>
         * <p>
         * tpl_value String 是 变量名和变量值对。请先对您的变量名和变量值分别进行urlencode再传递。使用参考：代码示例。
         * 注：变量名和变量值都不能为空 模板： 【#company#】您的验证码是#code#。 最终发送结果： 【云片网】您的验证码是1234。
         * tplvalue=urlencode("#code#") + "=" + urlencode("1234") + "&amp;" +
         * urlencode("#company#") + "=" + urlencode("云片网"); 若您直接发送报文请求则使用下面这种形式
         * tplvalue=urlencode(urlencode("#code#") + "=" + urlencode("1234") +
         * "&amp;" + urlencode("#company#") + "=" + urlencode("云片网"));
         * </p>
         * <p>
         * extend String 否 扩展号。默认不开放，如有需要请联系客服申请 001
         * </p>
         * <p>
         * uid String 否 用户自定义唯一id。最大长度不超过256的字符串。 默认不开放，如有需要请联系客服申请 10001
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<SmsSingleSend> TplSingleSend(Dictionary<string, string> param)
        {
            var r = new Result<SmsSingleSend>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Mobile, Const.TplId, Const.TplValue);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<SmsSingleSend>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<SmsSingleSend>();
                    }

                    default: return null;
                }
            });

            try
            {
                Path = "tpl_single_send.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>指定模板群发 only v2</h1>
         *
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * mobile String 是
         * 接收的手机号（针对国际短信，mobile参数会自动格式化到E.164格式，可能会造成传入mobile参数跟后续的状态报告中的号码不一致。E.164格式说明，参见：
         * https://en.wikipedia.org/wiki/E.164） 15205201314
         * </p>
         * <p>
         * tpl_id Long 是 模板id 1
         * </p>
         * <p>
         * tpl_value String 是 变量名和变量值对。请先对您的变量名和变量值分别进行urlencode再传递。使用参考：代码示例。
         * 注：变量名和变量值都不能为空 模板： 【#company#】您的验证码是#code#。 最终发送结果： 【云片网】您的验证码是1234。
         * tplvalue=urlencode("#code#") + "=" + urlencode("1234") + "&amp;" +
         * urlencode("#company#") + "=" + urlencode("云片网"); 若您直接发送报文请求则使用下面这种形式
         * tplvalue=urlencode(urlencode("#code#") + "=" + urlencode("1234") +
         * "&amp;" + urlencode("#company#") + "=" + urlencode("云片网"));
         * </p>
         * <p>
         * extend String 否 扩展号。默认不开放，如有需要请联系客服申请 001
         * </p>
         * <p>
         * uid String 否 用户自定义唯一id。最大长度不超过256的字符串。 默认不开放，如有需要请联系客服申请 10001
         * </p>
         *
         * @param param
         * @return
         */
        public Result<SmsBatchSend> TplBatchSend(Dictionary<string, string> param)
        {
            var r = new Result<SmsBatchSend>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Mobile, Const.TplId, Const.TplValue);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<SmsBatchSend>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<SmsBatchSend>();
                    }

                    default: return null;
                }
            });

            try
            {
                Path = "tpl_batch_send.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }


        /**
         * <h1>注册成功回调 only v2</h1>
         * <p>
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * mobile String 是
         * 注册成功的手机号，请和调用接口的手机号一致 15205201314
         * </p>
         * <p>
         * time String 否 注册成功的时间，格式yyyy-MM-dd HH:mm:ss，可以是一天前，超过时间无法记录，默认当前时间 2017-03-15 18:30:00
         * </p>
         * <p>
         * 如果需要更准确的注册成功数据（排除找回密码等类型验证码产生的数据），
         * 在注册页调用 single_send.json 接口时带上参数“register”（布尔类型），值为“true”，
         * 则该条短信会被认定为注册验证码短信。
         * 此功能需联系客服开通。
         * </p>
         *
         * @param param
         * @return
         * @see SmsApi#single_send(Map)
         */
        public Result<object> RegComplete(Dictionary<string, string> param)
        {
            var r = new Result<object>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Mobile);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<object>(Version, rsp => null);

            try
            {
                Path = "reg_complete.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }
    }
}