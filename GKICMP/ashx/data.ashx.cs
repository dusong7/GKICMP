using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using GK.GKICMP.Common;

namespace GKICMP.ashx
{
    /// <summary>
    /// data 的摘要说明
    /// </summary>
    public class data : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int flag = context.Request.Params["flag"] == null ? 0 : Convert.ToInt32(context.Request.Params["flag"].ToString());
            StringBuilder sb = new StringBuilder("");
            string name = "";
            sb.Append("[");
            Type enumSource = typeof(CommonEnum.TeaState);

            foreach (int itemValue in Enum.GetValues(enumSource))
            {
                if (flag > 0)
                {
                    flag -= 1;
                }
                else
                {
                    name += "{\"id\":\"" + itemValue +
                             "\",\"text\":\"" + Enum.GetName(enumSource, itemValue) + "\"},";
                }

            }
            sb.Append(name.TrimEnd(','));
            sb.Append("]");
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