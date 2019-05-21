
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;

namespace GKICMP.ashx
{
    /// <summary>
    /// IPControl 的摘要说明
    /// </summary>
    public class IPControl : IHttpHandler
    {
        public MusicLibDAL musicLibDAL = new MusicLibDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "List":
                    List(context);
                    break;
            }
        }
        private void List(HttpContext context)
        {
            int recordCount = 0;
            string name = "";
            StringBuilder sb = new StringBuilder();
            DataTable dt = musicLibDAL.GetPaged(100, 1, ref recordCount, "");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                    name += "{\"value\":\"" + dr["Src"].ToString().Replace(@"\",@"\\") +
                          "\",\"text\":\"" + dr["Name"].ToString() + "\"},";
            }
            sb.Append("{\"result\":\"true\",\"data\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]}");
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
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