
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Text;
using System.Data;

namespace GKICMP.ashx
{
    /// <summary>
    /// RestTime 的摘要说明
    /// </summary>
    public class RestTime : IHttpHandler
    {
        public RestTimeDAL restTimeDAL = new RestTimeDAL();
        public void ProcessRequest(HttpContext context)
        {
            RestTimeList(context);
        }
        private void RestTimeList(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = restTimeDAL.GetList();
            sb.Append("[");
            string name = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //name += "{"id":"1","title":"测试","start":"2017-09-04 06:30:00","end":"2017-09-04 07:00:00","members":null,"username":null,"notice":false,"allDay":false,"hasnoticed":false,"className":null,"editable":false,"backgroundColor":"#c90000","textColor":null,"status":"正常  ","custom":"蜗牛和黄鹂鸟.mp3"}";
                    name+="{\"id\":" + "\"" + dr["RTID"].ToString() + "\",";
                    name+="\"title\":" + "\"" + dr["RestName"].ToString() + "\",";
                    name+="\"start\":" + "\"" + GetDate(int.Parse(dr["weeks"].ToString())) +" "+ dr["BeginTime"].ToString() + "\",";
                    name += "\"end\":" + "\"" + GetDate(int.Parse(dr["weeks"].ToString())) + " " + dr["EndTime"].ToString() + "\",";
                    name += "\"bmname\":" + "\"" + dr["BMName"].ToString() + "\",";
                    name += "\"ename\":" + "\"" + dr["EMName"].ToString() + "\",";
                    name += "\"rname\":" + "\"" + dr["RMName"].ToString() + "\",";
                    name+="\"members\":null,\"username\":null,\"notice\":false,\"allDay\":false,\"hasnoticed\":false,\"className\":null,\"editable\":false,\"backgroundColor\":\"#c90000\",\"textColor\":null,\"status\":\"正常\"},";
                }

            }
            sb.Append(name.TrimEnd(','));
            sb.Append("]");
            context.Response.Clear();
            context.Response.Write(sb.ToString().TrimEnd(','));
            context.Response.End();
        }
        public string GetDate(int week) 
        {
            DateTime startweek = DateTime.Now.AddDays(1 - Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d")));
            return startweek.AddDays(week-1).ToString("yyyy-MM-dd");
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}