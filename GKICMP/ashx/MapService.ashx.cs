using GK.GKICMP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using System.Data;
using System.Xml;

namespace GKICMP.ashx
{
    /// <summary>
    /// MapService 的摘要说明
    /// </summary>
    public class MapService : IHttpHandler
    {
        public string key = ConfigurationManager.AppSettings["key"];
        public string gid = ConfigurationManager.AppSettings["gid"];
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "Range":
                    RangeGet(context);
                    break;
                case "Geofence":
                    Geofence(context);
                    break;
                case "Updatefence":
                    Updatefence(context);
                    break;
                case "Deletefence":
                    Deletefence(context);
                    break;
            }
        }
        /// <summary>
        /// 查询设备与围栏距离（围栏监控）
        /// </summary>
        /// <param name="context"></param>
        public void RangeGet(HttpContext context) 
        {
            string location = context.Request.Params["locations"];
            string ts = timeStamp();
            string urll = "http://restapi.amap.com/v4/geofence/status";
            string query = "?key=" + key + "&diu=355343082519390&locations=" + (location + "," + ts);
            string resultl = WeixinQYAPI.RequestUrl(urll + query);
            context.Response.Clear();
            context.Response.Write(resultl.ToString());
            context.Response.End();
        }
        /// <summary>
        /// 获取围栏
        /// </summary>
        /// <param name="context"></param>
        public void Geofence(HttpContext context)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            if (gid == "")
            {
                result = "\"errmsg\":\"error\"";
            }
            else
            {
                string urls = "http://restapi.amap.com/v4/geofence/meta?key="+key;
                string  resultl= WeixinQYAPI.RequestUrl(urls);
                //string lations = WeixinQYAPI.Json(resultl, "points");
                Dictionary<string, object> dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(resultl);
                //获取具体数据部分
                object obj = dic["data"];
                //将数据部分再次转换为json字符串
                string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                //获取数据中的  不同类型的数据   
                Dictionary<string, object> dicc = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsondata);

                //chalssinfo 
                object objclass = dicc["rs_list"];
                string jsonclass = Newtonsoft.Json.JsonConvert.SerializeObject(objclass);
                DataTable tclass = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(jsonclass);
                if (tclass != null && tclass.Rows.Count > 0)
                {
                    result += "\"errmsg\":\"ok\",\"center\":\"" + tclass.Rows[0]["center"] + "\",";
                    result += "\"lactions\":[";
                    string[] list = tclass.Rows[0]["points"].ToString().Split(';');
                    if (list.Length > 0)
                    {
                        foreach (string s in list)
                        {
                            string[] l = s.Split(',');
                            result += "{\"lon\":" + l[0] + ",\"lat\":" + l[1] + " },";
                        }
                        result = result.Trim(',');
                    }
                   result += "]";
                }
                
                // string gid = WeixinQYAPI.Json(result, "gid");
                //string result = "{\"data\":[{\"lon\":118.388592,\"lat\":31.341447 },{\"lon\":118.38842,\"lat\": 31.341159},{\"lon\":118.388713,\"lat\":31.341076 },{\"lon\":118.38886,\"lat\":31.341365}]}";
            }
            sb.Append("{");
            sb.Append(result);
            sb.Append("}");
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        /// <summary>
        /// 创建、更新围栏
        /// </summary>
        /// <param name="context"></param>
        public void Updatefence(HttpContext context)
        {
            string exe = context.Request.Params["exe"].TrimEnd(';');
            string locations = context.Request.Params["locations"].TrimEnd(';');
            string url = "";
            string json = "";
            if (exe == "1")
            {
                url = "http://restapi.amap.com/v4/geofence/meta?key=" + key + "&gid=" + gid + "&method=patch";
                json = "{\"name\": \"打卡签到围栏\"," +
                "\"points\": \"" + locations + "\"," +
                    // "\"radius\": \"1000\","+
                    //"\"enable\": \"true\"," +
                "\"valid_time\": \"2020-01-01\"," +
                "\"repeat\": \"Mon,Tues,Wed,Thur,Fri,Sat,Sun\"," +
                "\"time\": \"00:00,11:59;21:00,20:59\"," +
                "\"desc\": \"打卡签到围栏\"," +
                "\"alert_condition\": \"enter;leave\"}";
            }
            else 
            {
                url = "http://restapi.amap.com/v4/geofence/meta?key=" + key + "&gid=" + gid;
                json = "{\"name\": \"打卡签到围栏\"," +
                "\"points\": \"" + locations + "\"," +
                // "\"radius\": \"1000\","+
                "\"enable\": \"true\"," +
                "\"valid_time\": \"2020-01-01\"," +
                "\"repeat\": \"Mon,Tues,Wed,Thur,Fri,Sat,Sun\"," +
                "\"time\": \"00:00,11:59;13:00,20:59\"," +
                "\"desc\": \"打卡签到围栏\"," +
                "\"alert_condition\": \"enter;leave\"}";

               // ConfigurationManager.AppSettings.Set("gid", Guid.NewGuid().ToString());
            }
            string result = WeixinQYAPI.Post(url, json);
            if (exe != "1") 
            {
                SetConfig(WeixinQYAPI.Json(result, "gid"));
            }
            context.Response.Clear();
            context.Response.Write(result.ToString());
            context.Response.End();
        }

      
        /// <summary>
        /// 删除围栏
        /// </summary>
        /// <param name="context"></param>
        public void Deletefence(HttpContext context)
        {
            string urls = "http://restapi.amap.com/v4/geofence/meta?key=" + key + "&gid=" + gid + "&method=delete";
            //string json = "\"key\":\""+key+"\",\"gid\":\""+gid+"\"";
           // string json = "";
            string results = WeixinQYAPI.Post(urls, "");
            SetConfig("");
            //string gid = WeixinQYAPI.Json(results, "gid");
            context.Response.Clear();
            context.Response.Write(results.ToString());
            context.Response.End();
        }
        private static void SetConfig(string gids)
        {
            //string gids = WeixinQYAPI.Json(result, "gid");
            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(System.Web.HttpContext.Current.Request.ApplicationPath);
            AppSettingsSection appSection = (AppSettingsSection)config.GetSection("appSettings");
            if (appSection.Settings["gid"] == null)
            {
                appSection.Settings.Add("gid", gids);
                config.Save();
            }
            else
            {
                appSection.Settings.Remove("gid");
                appSection.Settings.Add("gid", gids);
                config.Save();
            }
        }
        #region 时间戳的随机数
        /// <summary>
        /// 时间戳的随机数
        /// </summary>
        /// <returns></returns>
        public static string timeStamp()
        {
            DateTime dt1 = Convert.ToDateTime("1970-01-01 08:00:00");
            TimeSpan ts = DateTime.Now - dt1;
            return Math.Ceiling(ts.TotalSeconds).ToString();
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}