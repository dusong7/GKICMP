using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;

namespace GKICMP.test
{
    public partial class MAP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ////创建围栏
                //string url = "http://restapi.amap.com/v4/geofence/meta?key=e08c94652c7c52de8aac2664482dbfae";
                //string json = "{\"name\": \"测试围栏名称\"," +
                //    "\"points\": \"118.388592,31.341447;118.38842,31.341159;118.388713,31.341076;118.38886,31.341365\"," +
                //    // "\"radius\": \"1000\","+
                //    "\"enable\": \"true\"," +
                //    "\"valid_time\": \"2020-01-01\"," +
                //    "\"repeat\": \"Mon,Tues,Wed,Thur,Fri,Sat,Sun\"," +
                //    "\"time\": \"00:00,11:59;13:00,20:59\"," +
                //    "\"desc\": \"测试围栏描述\"," +
                //    "\"alert_condition\": \"enter;leave\"}";
                //string result = WeixinQYAPI.Post(url, json);
                //string id = WeixinQYAPI.Json(result, "gid");
                //string msg = WeixinQYAPI.Json(result, "message");

                //查询围栏
                //string urls = "http://restapi.amap.com/v4/geofence/meta?key=e08c94652c7c52de8aac2664482dbfae";
                //string results = WeixinQYAPI.RequestUrl(urls);
                //string gid = WeixinQYAPI.Json(results, "gid");
                //string t = timeStamp();
                //string urll = "http://restapi.amap.com/v4/geofence/status";
                //string query = "?key=e08c94652c7c52de8aac2664482dbfae&diu=358568072860640&locations=118.38743591308594,31.3405704498291," + t;
                //string resultl = WeixinQYAPI.RequestUrl(urll + query);
            }
        }
        #region 时间戳的随机数
        /// <summary>
        /// 时间戳的随机数
        /// </summary>
        /// <returns></returns>
        public static string timeStamp()
        {
            DateTime dt1 = Convert.ToDateTime("1970-01-01 00:00:00");
            TimeSpan ts = DateTime.Now - dt1;
            return Math.Ceiling(ts.TotalSeconds).ToString();
        }
        #endregion
    }
}