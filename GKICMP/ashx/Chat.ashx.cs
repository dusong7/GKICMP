using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;

namespace GKICMP.ashx
{
    /// <summary>
    /// Chat 的摘要说明
    /// </summary>
    public class Chat : IHttpHandler
    {
        public NetworkTeach_MessDAL networkTeach_MessDAL = new NetworkTeach_MessDAL();
        public NetworkTeachDAL networkTeachDAL = new NetworkTeachDAL();
        public NetworkTeach_LoginDAL networkTeach_LoginDAL = new NetworkTeach_LoginDAL();
        public void ProcessRequest(HttpContext context)
        {
            //string name = context.Request.Params["name"];
            string id = context.Request.Params["id"];
            string method = context.Request.Params["method"];
            if (method != null && method == "time")
            {
                OnLineTimes(context);
            }
            else
            {
                if (id != null && id != "")
                {
                    NetworkTeachEntity model = networkTeachDAL.GetObjByID(id);
                    if (model != null)
                    {
                        context.Response.Clear();
                        context.Response.Write(model.NTTUrl);
                        context.Response.End();
                    }
                }
                else
                {
                    string text = context.Request.Params["text"];
                    NetworkTeach_MessEntity model = new NetworkTeach_MessEntity();
                    model.SysID = context.Request.Params["UserID"];
                    model.MessContent = text;
                    model.CreateDate = DateTime.Now;
                    model.NTID = context.Request.Params["ntid"];
                    model.PID = -1;
                    int result = networkTeach_MessDAL.Edit(model);
                }
            }
            //if (method != null && method == "time")
            //{
            //    OnLineTimes(context);
            //}
            //using (SqlConnection conn1 = new SqlConnection("Data Source=192.168.10.20;User ID=yghd;Password=123456;Initial Catalog=GK_YGHD;Pooling=true;"))
            //{
            //    conn1.Open();
            //    SqlCommand command = conn1.CreateCommand();
            //    command.CommandText = "insert into Tb_NetworkTeach_Mess values ('1','" + name + "','" + DateTime.Now + "','" + text + "',-1)";
            //    command.ExecuteNonQuery();
            //    conn1.Close();
            //}
        }
        public void OnLineTimes(HttpContext context)
        {
            string sb = "";
            string text = context.Request.Params["text"];
            string ntlid = context.Request.Params["ntlid"];
            NetworkTeach_LoginEntity model = new NetworkTeach_LoginEntity();
            model.NTLID = ntlid;
            model.NTID = context.Request.Params["ntid"];
            model.SysID =CommonFunction.Decrypt(context.Request.Params["UserID"]);
            model.LoginBegin = DateTime.Now.AddMinutes(-5);
            model.LoginEnd = DateTime.Now;
            int result = networkTeach_LoginDAL.Edit(model);
            if (result > 0)
                sb = "{\"result\":\"sucess\"}";
            else
                sb = "{\"result\":\"error\"}";
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