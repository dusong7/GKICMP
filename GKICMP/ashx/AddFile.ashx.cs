using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;

namespace GKICMP.ashx
{
    /// <summary>
    /// AddFile 的摘要说明
    /// </summary>
    public class AddFile : IHttpHandler
    {
        public FileBoxDAL fileBoxDAL = new FileBoxDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "Add":
                    AddPost(context);
                    break;
                case "Update":
                    UpdatePost(context);
                    break;
            }
        }
        private void AddPost(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            int pid =int.Parse(context.Request.Params["pid"]);
            string fbname = context.Request.Params["name"];
            string id =CommonFunction.Decrypt(context.Request.Params["UserID"]);
            FileBoxEntity model = new FileBoxEntity();
            model.FBID = 0;
            model.FBName = fbname;
            model.CreateUser =id;
            model.CreateDate =DateTime.Now;
            model.AdminID = id;
            model.PID = pid;
            model.FileUrl = "";
            model.RSize = 0;
            model.RFormat = "";
            model.DownLoadNum = 0;
            model.FFlag = 1;
            int result = fileBoxDAL.Edit(model);

            if (result == 0)
            {
                sb.Append("{\"result\":\"success\"}");
                sysLogDAL.Edit((new SysLogEntity("于" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "新建【" + model.FBName + "】的文件夹", id)));
            }
            else
            {
                sb.Append("{\"result\":\"fail\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        private void UpdatePost(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            int fbid = int.Parse(context.Request.Params["fbid"]);
            string fbname = context.Request.Params["name"];
            string obname = context.Request.Params["OName"];
            string pid = context.Request.Params["pid"];
            string id = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            FileBoxEntity model = new FileBoxEntity();
            model.FBID = fbid;
            model.FBName = fbname;
            //model.CreateUser = id;
            //model.CreateDate = DateTime.Now;
            //model.AdminID = id;
            model.PID =int.Parse(pid);
            //model.FileUrl = "";
            //model.RSize = 0;
            //model.RFormat = "";
            //model.DownLoadNum = 0;
            //model.FFlag = 1;
            int result = fileBoxDAL.Update(model);
            if (result == 0)
            {
                sb.Append("{\"result\":\"success\"}");
                sysLogDAL.Edit((new SysLogEntity("于" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "将文件夹【" + obname + "】重命名为【" + model.FBName + "】", id)));
            }
            else if (result == -2)
            {
                sb.Append("{\"result\":\"此目录下已存在此文件名，请重新修改\"}");
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