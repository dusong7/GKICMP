using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace GKICMP.ashx
{
    /// <summary>
    /// oa 的摘要说明
    /// </summary>
    public class oa : IHttpHandler
    {
        private StringBuilder sb = new StringBuilder("");
        public Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();        
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "yf":
                    yf(context);
                    break;
            }            
        }
        #region 手机端--已发和待处理
        //1 待处理 2 已发
        public void yf(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string didname = context.Request.Params["didname"];
            string name = "";
            EgovernmentEntity model = new EgovernmentEntity();
            model.Etitle = didname;
            model.Begin = Convert.ToDateTime("1900-12-01");
            model.End = Convert.ToDateTime("9999-12-01");
            model.CreateUser = userid;
            DataTable dt = egovernment_FlowDAL.GetSendPaged(pagesize, pageindex, ref recordCount, model);
            //DataTable dt = egovernment_FlowDAL.GetPagedAPPByFlag(pagesize, pageindex, ref recordCount, model, flag);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //sb.Append("{\"result\":\"success\",");
                    name += "{\"FID\":\"" + dt.Rows[i]["FID"] + "\",";//
                    name += "\"IsApproved\":\"" + dt.Rows[i]["IsApproved"] + "\",";//
                    name += "\"Etitle\":\"" + dt.Rows[i]["Etitle"] + "\",";//
                    name += "\"CreateDate\":\"" + Convert.ToDateTime(dt.Rows[i]["CreateDate"]).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"CreateUserName\":\"" + dt.Rows[i]["CreateUserName"] + "\",";//
                    name += "\"AcceptUserName\":\"" + GetAcceptName(Convert.ToInt32(dt.Rows[i]["Counta"]), dt.Rows[i]["AcceptUserList"].ToString()) + "\",";//
                    name += "\"Completed\":\"" + dt.Rows[i]["Completed"] + "\",";//
                    name += "\"State\":\"" + dt.Rows[i]["State"] + "\"},";//
                    //name += "\"EContent\":\"" + dt.Rows[i]["EContent"] + "\"},";//
                    // sb.Append("\"State\":\"" + dt.Rows[i]["State"] + "\"");//
                    //sb.Append("}");


                }
                sb.Append("{\"result\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");

                //sb.Append("{\"dzzw\":\"" + dt.Rows[0]["dzzw"] + "\",\"jsqj\":\"" + dt.Rows[0]["jsqj"] + "\",\"xsqj\":\"" + dt.Rows[0]["xsqj"] + "\",\"dkjl\":\"" + dt.Rows[0]["dkjl"] + "\",\"bxjl\":\"" + dt.Rows[0]["bxjl"] + "\"} ");
            }
            else
            {
                sb.Append("{\"result\":\"false\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        public string GetAcceptName(int count, string name)
        {
            int counts = count == null ? 0 : Convert.ToInt32(count);
            if (counts < 2)
            {
                return name.ToString();
            }
            else
            {
                return name.ToString().Split(',')[0] + "等" + count.ToString() + "人";
            }

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