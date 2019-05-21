using System;
using System.Text;
using System.Web;

using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.ashx
{
    /// <summary>
    /// PayItemSelectHandler 的摘要说明
    /// </summary>
    public class PayItemSelectHandler : IHttpHandler
    {
        public PayProject_ItemDAL payProject_ItemDAL = new PayProject_ItemDAL();
        private StringBuilder sb = new StringBuilder("");

        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "Add":
                    AddPost(context);
                    break;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="context"></param>
        private void AddPost(HttpContext context)
        {
            string ppid = context.Request.Params["ppid"];
            string button = context.Request.Params["button"];

            button = HttpUtility.UrlDecode(button, Encoding.GetEncoding("utf-8"));


            PayProject_ItemEntity model = new PayProject_ItemEntity();
            model.PPIID = 0;
            model.PPID = ppid.ToString(); 
            //model.PIID = 


            int result = payProject_ItemDAL.Edit(model, button);
            if (result == 0)
            {
                sb.Append("{\"result\":\"success\"}");
            }
            //else if (result == -2)
            //{
            //    sb.Append("{\"result\":\"accept\"}");
            //}
            else
            {
                sb.Append("{\"result\":\"fail\"}");
            }
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