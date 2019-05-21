using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK.GKICMP.Entities;
using System.Xml;

namespace GK.GKICMP.Common
{
   public  class SendWX
    {
        /// <summary>
        /// 初始化参数
        /// iftrue
        /// www.iftrue.cn
        /// 2014-07-08
        /// </summary>
        public class Init
        {
            /// <summary>
            /// 微信公众平台－开发者中心－服务器配置　中的Token
            /// </summary>
            public static string Token;

            /// <summary>
            /// 静态构造
            /// </summary>
            static Init()
            {
                string _token = ConfigurationManager.AppSettings["token"];
                if (!string.IsNullOrEmpty(_token))
                    Token = _token;
            }
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        public class MsgType
        {
            public const string text = "text";
            public const string image = "image";
            public const string voice = "voice";
            public const string video = "video";
            public const string location = "location";
            public const string link = "link";
            public const string events = "event";
        }
        /// <summary>
        /// 解析ＸＭＬ，转换为实体
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private Entities.Receive_Msg GetReceiveModel(XmlElement element)
        {
            Entities.Receive_Msg model = null;
            string msgType = element.SelectSingleNode("MsgType").InnerText;
            switch (msgType)
            {
                case MsgType.text: model = new Entities.Receive_Text(); break;
                case MsgType.image: model = new Entities.Receive_Image(); break;
                case MsgType.voice: model = new Entities.Receive_Voice(); break;
                case MsgType.video: model = new Entities.Receive_Video(); break;
                case MsgType.location: model = new Entities.Receive_Location(); break;
                case MsgType.link: model = new Entities.Receive_Link(); break;
                case MsgType.events: model = GetEventModel(element.SelectSingleNode("Event").InnerText, element.SelectSingleNode("EventKey") == null ? "" : element.SelectSingleNode("EventKey").InnerText); break;
            }
            try
            {
                foreach (System.Reflection.PropertyInfo p in model.GetType().GetProperties())
                {
                    if (p.Name != "Xml")
                    {
                        p.SetValue(model, element.SelectSingleNode(p.Name).InnerText, null);
                    }
                    else
                    {
                        p.SetValue(model, element.OuterXml, null);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        /// <summary>
        /// 事件类型
        /// </summary>
        public class Event
        {
            public const string subscribe = "subscribe";
            public const string unsubscribe = "unsubscribe";
            public const string scan = "SCAN";
            public const string location = "LOCATION";
            public const string click = "CLICK";
            public const string view = "VIEW";

        }
        public string Send_Msg<T>(T t, ref string msg)
        {
            if (t == null)
                return "";
            StringBuilder strB = new StringBuilder();
            strB.Append("<xml>");
            foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
            {
                strB.Append(string.Format("<{0}>{1}</{0}>", p.Name, p.GetValue(t, null).ToString()));
            }
            strB.Append("</xml>");
            return strB.ToString();
        }
        /// <summary>
        /// 获取事件对象
        /// </summary>
        /// <param name="evt">事件类型</param>
        /// <param name="eventKey">事件KEY值</param>
        /// <returns></returns>
        private Entities.Receive_Msg GetEventModel(string evt, string eventKey)
        {
            Entities.Receive_Msg model = null;
            switch (evt)
            {
                case Event.subscribe:
                    if (string.IsNullOrEmpty(eventKey))
                    {
                        model = new Entities.Receive_Event();
                    }
                    else
                    {
                        model = new Entities.Receive_Event_Scan();
                    }
                    break;
                case Event.unsubscribe:
                    model = new Entities.Receive_Event();
                    break;
                case Event.scan:
                    model = new Entities.Receive_Event_Scan();
                    break;
                case Event.location:
                    model = new Entities.Receive_Event_Location();
                    break;
                case Event.click:
                    model = new Entities.Receive_Event_Click();
                    break;
                case Event.view:
                    model = new Entities.Receive_Event_View();
                    break;
            }
            return model;
        }
    }
}
