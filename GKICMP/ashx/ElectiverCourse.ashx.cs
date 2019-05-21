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
    /// ElectiverCourse 的摘要说明
    /// </summary>
    public class ElectiverCourse : IHttpHandler
    {
        private StringBuilder sb = new StringBuilder("");
        public Electiver_CourseDAL electiver_CourseDAL=new Electiver_CourseDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ECourseDAL eCourseDAL = new ECourseDAL();
        public ElectiverDAL eleDAL = new ElectiverDAL();
        public Electiver_StuDAL electiver_StuDAL = new Electiver_StuDAL();
        public SysSetConfigDAL sysSetConfigDAL = new SysSetConfigDAL();
      
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "Add":
                    AddPost(context);
                    break;
                case "CList":
                    CList(context);
                    break;
                case "EList":
                    EList(context);
                    break;
                case "SCList":
                    SCList(context);
                    break;
                case "OnLine":
                    OnLine(context);
                    break;
            }
        }

        public void AddPost(HttpContext context) 
        {
            StringBuilder sb = new StringBuilder();
            string userid =CommonFunction.Decrypt( context.Request.Params["UserID"]);
            
            try
            {

                string ecid = context.Request.Params["ecid"] == "" ? "0" : context.Request.Params["ecid"];
                string eleid = context.Request.Params["eleid"];
                string cid = context.Request.Params["cid"];
                string count = context.Request.Params["count"];
                string grade = context.Request.Params["grade"];
                
                Electiver_CourseEntity model = new Electiver_CourseEntity();
                model.ECID = int.Parse(ecid);
                model.EleID = int.Parse(eleid);
                model.CourseID = int.Parse(cid);
                model.MaxCount = int.Parse(count);
                grade = grade.TrimEnd(',');
                int result = electiver_CourseDAL.Edit(model, grade);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity(int.Parse(ecid) == 0 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改, (int.Parse(ecid) == 0 ? "添加" : "修改") + "选课课程【" + cid + "】的信息", userid));
                    sb.Append("{\"result\":\"sucess\"}");
                }
                else if (result == -2)
                {
                    sb.Append("{\"result\":\"repeat\"}");
                }
                else
                {
                    sb.Append("{\"result\":\"fail\"}");
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, userid));
                sb.Append("{\"result\":\"fail\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        public void CList(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            int recordCount = -1;
            int eleid = Convert.ToInt32(context.Request.Params["eleid"]);
            ECourseEntity model = new ECourseEntity();
            model.Isdel = (int)CommonEnum.IsorNot.否;
            //DataTable dt = eCourseDAL.GetList(pagesize, pageindex, ref recordCount, model, userid, eleid);

            //DataTable dt = electiver_CourseDAL.GetList(eleid);
            DataTable dt = electiver_CourseDAL.GetListNew(eleid, userid);
            string name = "";

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //name += "{\"CID\":\"" + dt.Rows[i]["CID"] + "\",";//课程id
                    //name += "\"CourseName\":\"" + dt.Rows[i]["CourseName"] + "\",";//课程名称
                    //name += "\"CourseGradeName\":\"" + dt.Rows[i]["CourseGradeName"] + "\",";//等级
                    //name += "\"CourseDesc\":\"" + dt.Rows[i]["CourseDesc"] + "\",";//简介
                    //name += "\"bmrs\":\"" + dt.Rows[i]["bmrs"] + "\",";//分类
                    //name += "\"CourseTypeName\":\"" + dt.Rows[i]["CourseTypeName"] + "\"},";//分类


                    name += "{\"EleID\":\"" + dt.Rows[i]["EleID"] + "\",";//
                    name += "\"ECID\":\"" + dt.Rows[i]["ECID"] + "\",";//
                    name += "\"CourseName\":\"" + dt.Rows[i]["CourseName"] + "\",";//
                    name += "\"ClevelName\":\"" + dt.Rows[i]["ClevelName"] + "\",";//
                    name += "\"CourseTypeName\":\"" + dt.Rows[i]["CourseTypeName"] + "\",";//
                    name += "\"CourseID\":\"" + dt.Rows[i]["CourseID"] + "\",";//
                    name += "\"ClevelName\":\"" + dt.Rows[i]["ClevelName"] + "\",";//
                    name += "\"MaxCount\":\"" + dt.Rows[i]["MaxCount"] + "\",";//
                    name += "\"IsIn\":\"" + dt.Rows[i]["IsIn"] + "\",";//
                    name += "\"SignCount\":\"" + dt.Rows[i]["SignCount"] + "\",";//
                    name += "\"ECount\":\"" + dt.Rows[i]["ECount"] + "\",";//
                    name += "\"DY\":\"" + dt.Rows[i]["DY"] + "\"},";//


                    
                }
                sb.Append("{\"result\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        public void EList(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            int recordCount = -1;
            string year = "";
            int term = 0;
            //if (DateTime.Now.Month > 8 || DateTime.Now.Month < 3)
            //{
            //    if (DateTime.Now.Month > 0)
            //        year = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
            //    else
            //        year = DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
            //    term = (int)CommonEnum.XQ.上学期;
            //}
            //else
            //{
            //    year = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
            //    term=(int)CommonEnum.XQ.下学期;
            //}
            SysSetConfigEntity cmodel = sysSetConfigDAL.GetObjByID();
            year = cmodel.EYear;
            term = cmodel.NowTerm;

            ElectiverEntity model = new ElectiverEntity("", year, term);
            DataTable dt = eleDAL.GetPagedApp(pagesize, pageindex, ref recordCount, model);
            string name = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"EleID\":\"" + dt.Rows[i]["EleID"] + "\",";//任务id
                    name += "\"ElectiverName\":\"" + dt.Rows[i]["ElectiverName"] + "\",";//任务名称
                    name += "\"EBegin\":\"" + Convert.ToDateTime(dt.Rows[i]["EBegin"]).ToString("yyyy-MM-dd") + "\",";//开始日期
                    name += "\"EEnd\":\"" + Convert.ToDateTime(dt.Rows[i]["EEnd"]).ToString("yyyy-MM-dd") + "\",";//结束日期
                    name += "\"EYear\":\"" + dt.Rows[i]["EYear"] + "\",";//学年
                    name += "\"TermID\":\"" + dt.Rows[i]["TermID"] + "\",";//学期
                    name += "\"Ecount\":\"" + dt.Rows[i]["Ecount"] + "\",";//限制门数
                    name += "\"EStopDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EStopDate"]).ToString("yyyy-MM-dd") + "\",";//结束日期
                    name += "\"EstimateBDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EstimateBDate"]).ToString("yyyy-MM-dd") + "\",";//预选开始日期
                    name += "\"EstimateEDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EstimateEDate"]).ToString("yyyy-MM-dd") + "\",";//预选结束日期
                    name += "\"EState\":\"" + dt.Rows[i]["EState"] + "\"},";//状态
                }
                sb.Append("{\"result\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        public void SCList(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            int recordCount = -1;
            string year = "";
            int term = 0;
            if (DateTime.Now.Month > 8 || DateTime.Now.Month < 3)
            {
                if (DateTime.Now.Month > 0)
                    year = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
                else
                    year = DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
                term = (int)CommonEnum.XQ.上学期;
            }
            else
            {
                year = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
                term = (int)CommonEnum.XQ.下学期;
            }
            Electiver_StuEntity model = new Electiver_StuEntity();
            model.StuID = userid;
            DataTable dt = electiver_StuDAL.GetCourseByStu(pagesize, pageindex, ref recordCount, userid, year, term);
            string name = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"CID\":\"" + dt.Rows[i]["CID"] + "\",";//课程id
                    name += "\"CourseName\":\"" + dt.Rows[i]["CourseName"] + "\",";//课程名称
                    name += "\"CourseGradeName\":\"" + dt.Rows[i]["CourseGradeName"] + "\",";//等级
                    name += "\"CourseDesc\":\"" + dt.Rows[i]["CourseDesc"] + "\",";//简介
                    name += "\"CourseTypeName\":\"" + dt.Rows[i]["CourseTypeName"] + "\"},";//分类
                }
                sb.Append("{\"result\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }

        #region 手机端--选课提交
        public void OnLine(HttpContext context)
        {
           
            int cid = Convert.ToInt32(context.Request.Params["id"]);
            int eleid = Convert.ToInt32(context.Request.Params["eleid"]);
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            bool IsBack = bool.Parse(context.Request.Params["isback"]);
            int result = 0;
            Electiver_StuEntity model = new Electiver_StuEntity();
            model.ESID = 0;
            model.EleID = eleid;
            model.CorseID = cid;
            model.StuID = userid;
            model.EleDate = DateTime.Now;
            if (IsBack)
                model.IsBack = 1;
            else
                model.IsBack = 0;
           
            result = electiver_StuDAL.Edit(model);
            if (result > 0)
            {
                sb.Append("{\"result\":\"true\"}");
            }
            else
            {
                sb.Append("{\"result\":\"false\"}");
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