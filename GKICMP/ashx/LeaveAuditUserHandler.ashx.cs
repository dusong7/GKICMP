using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GKICMP.ashx
{
    /// <summary>
    /// LeaveAuditUserHandler 的摘要说明
    /// </summary>
    public class LeaveAuditUserHandler : IHttpHandler
    {

        private StringBuilder sb = new StringBuilder("");
        public LeaveAuditDAL auditDAL = new LeaveAuditDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "AddLeaveAuditUser":
                    AddLeaveAuditUser(context);
                    break;
            }
        }
        #region 添加请假审核人信息
        /// <summary>
        /// 添加请假审核人信息
        /// </summary>
        /// <param name="context"></param>
        private void AddLeaveAuditUser(HttpContext context)
        {
            try
            {
                string lid = context.Request.Params["lid"];
                string audituser = context.Request.Params["uid"];
                string state = context.Request.Params["state"];
                int iscurrent = int.Parse(context.Request.Params["iscur"]);
                Leave_AuditEntity model = new Leave_AuditEntity();
                model.LID = lid;
                model.AuditUser = audituser;
                model.AuditResult = (int)CommonEnum.AduitState.未审核;
                model.IsCurrent = iscurrent;
                int result = auditDAL.AuditEdit(model, Convert.ToInt32(state));
                if (result == 0)
                {
                    sb.Append("{\"result\":\"success\"}");
                }
                else if (result == -2)
                {
                    sb.Append("{\"result\":\"same\"}");
                }
                else
                {
                    sb.Append("{\"result\":\"fail\"}");
                }
            }
            catch (Exception error)
            {
                sb.Append("{\"result\":\"fail\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
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