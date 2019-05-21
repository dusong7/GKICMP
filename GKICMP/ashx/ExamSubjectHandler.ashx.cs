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
    /// ExamSubjectHandler 的摘要说明
    /// </summary>
    public class ExamSubjectHandler : IHttpHandler
    {
        public Exam_SubjectDAL subjectDAL = new Exam_SubjectDAL();
        private StringBuilder sb = new StringBuilder("");
        public void ProcessRequest(HttpContext context)
        {
            SubjectAdd(context);
        }
        #region 考试科目添加
        /// <summary>
        /// 考试科目添加
        /// </summary>
        /// <returns></returns>
        private void SubjectAdd(HttpContext context)
        {
            string cid = context.Request.Params["cid"];
            string eid = context.Request.Params["eid"];
            string begindate = context.Request.Params["begindate"];
            string enddate = context.Request.Params["enddate"];
            int sorder =int.Parse(context.Request.Params["order"]);
            //int id = int.Parse(context.Request.Params["id"]);//-1添加,其他
            Exam_SubjectEntity model = new Exam_SubjectEntity();
            model.ESID = -1;
            model.EID = eid.ToString();
            model.CID = Convert.ToInt32(cid);
            model.BeginDate = Convert.ToDateTime(begindate);
            model.EndDate = Convert.ToDateTime(enddate);
            model.SOrder = sorder;
            int result = subjectDAL.Edit(model);

            if (result == 0)
            {
                sb.Append("{\"result\":\"success\"}");
            }
            else if (result == -2)
            {
                sb.Append("{\"result\":\"-2\"}");
            }
            else { sb.Append("{\"result\":\"fail\"}"); }
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