using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;

namespace GKICMP.ashx
{
    /// <summary>
    /// AssetAccountInfo 的摘要说明
    /// </summary>
    public class AssetAccountInfo : IHttpHandler
    {

        public Asset_Account_InfoDAL infoDAL = new Asset_Account_InfoDAL();
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
            string aaid = context.Request.Params["aaid"];
            string aitype = context.Request.Params["aitype"];
            string accname = context.Request.Params["accname"];
            string accnum = context.Request.Params["accnum"];
            string accunit = context.Request.Params["accunit"];
            string accountcash = context.Request.Params["accountcash"];
            Asset_Account_InfoEntity model = new Asset_Account_InfoEntity();
            model.AAIID = 0;
            model.AAID = HttpUtility.UrlDecode(aaid, Encoding.GetEncoding("utf-8"));
            model.AccName = HttpUtility.UrlDecode(accname, Encoding.GetEncoding("utf-8"));
            model.AccNum = Convert.ToDecimal(HttpUtility.UrlDecode(accnum, Encoding.GetEncoding("utf-8")));
            model.AccountCash = Convert.ToDecimal(HttpUtility.UrlDecode(accountcash, Encoding.GetEncoding("utf-8")));
            model.AccUnit = HttpUtility.UrlDecode(accunit, Encoding.GetEncoding("utf-8"));
            model.AIType = Convert.ToInt32(HttpUtility.UrlDecode(aitype, Encoding.GetEncoding("utf-8")));
            int result = infoDAL.Edit(model);

            if (result == 0)
            {
                sb.Append("{\"result\":\"success\"}");
            }
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