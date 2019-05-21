using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

using GK.GKICMP.DAL;
using System.Data;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using Baidu.Aip.Speech;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace GKICMP.ashx
{
    /// <summary>
    /// GetMainDate 的摘要说明
    /// </summary>
    public class GetMainDate : IHttpHandler
    {
        private StringBuilder sb = new StringBuilder("");
        public MainDAL mainDAL = new MainDAL();
        public Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        public WorkPlanDAL workPlanDAL = new WorkPlanDAL();
        public AfficheDAL afficheDAL = new AfficheDAL();
        public StudentActivityDAL studentActivityDAL = new StudentActivityDAL();
        public LeaveAuditDAL leaveAuditDAL = new LeaveAuditDAL();
        public ExamDAL examDAL = new ExamDAL();
        public HomeWorkDAL homeWorkDAL = new HomeWorkDAL();
        public SysNoticeDAL sysNoticeDAL = new SysNoticeDAL();
        public StuAttendDAL stuattendDAL = new StuAttendDAL();
        public LeaveDAL leaveDAL = new LeaveDAL();
        public Asset_RepairDAL repairDAL = new Asset_RepairDAL();
        public AbsentDAL absentDAL = new AbsentDAL();
        public AppointmentDAL appointmentDAL = new AppointmentDAL();
        public StudentDAL studentDAL = new StudentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();
        public Teacher_RewardDAL teacherRewardDAL = new Teacher_RewardDAL();
        public OverTimeDAL overTimeDAL = new OverTimeDAL();
        public Teacher_GuidanceDAL teacherGuidanceDAL = new Teacher_GuidanceDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public NoCardApplyDAL noCardApplyDAL = new NoCardApplyDAL();
        public ElectiverDAL eleDAL = new ElectiverDAL();
        public Electiver_CourseDAL electiver_CourseDAL = new Electiver_CourseDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public Project_CheckDAL project_CheckDAL = new Project_CheckDAL();


        public void ProcessRequest(HttpContext context)
        {
            // string method = context.Request.Params["method"];
            //MainDate(context);

            string method = context.Request.Params["method"];
            switch (method)
            {
                case "MainDate":
                    MainDate(context);
                    break;
                case "ListenVoice":
                    ListenVoice(context);
                    break;
                case "Egovernment":
                    Egovernment(context);
                    break;
                case "EgovernmentNum":
                    EgovernmentNum(context);
                    break;
                case "Work":
                    Work(context);
                    break;
                case "Affiche":
                    Affiche(context);
                    break;
                case "AfficheSend":
                    AfficheSend(context);
                    break;
                case "SpaceLog":
                    SpaceLog(context);
                    break;
                case "PeopleRepair":
                    PeopleRepair(context);
                    break;
                case "PeopleLeave":
                    PeopleLeave(context);
                    break;
                case "PeopleRecord":
                    PeopleRecord(context);
                    break;
                case "PeopleTrave":
                    PeopleTrave(context);
                    break;
                case "LeaveAudit":
                    LeaveAudit(context);
                    break;
                case "TraveAudit":
                    TraveAudit(context);
                    break;
                case "ExamData":
                    ExamData(context);
                    break;
                case "HomeWorkData":
                    HomeWorkData(context);
                    break;
                case "NoticeData":
                    NoticeData(context);
                    break;
                case "StuAttend":
                    StuAttend(context);
                    break;
                case "StuLeave":
                    StuLeave(context);
                    break;
                case "LJWC":
                    LJWC(context);
                    break;
                case "RepairPeople":
                    RepairPeople(context);
                    break;
                case "RepairYJ":
                    RepairYJ(context);
                    break;
                case "WorkWC":
                    WorkWC(context);
                    break;
                case "EgovernmentByFlag":
                    EgovernmentByFlag(context);
                    break;
                case "YY":
                    YY(context);
                    break;
                case "PersonSubstitute":
                    PersonSubstitute(context);
                    break;
                case "send":
                    send(context);
                    break;
                case "Appoint":
                    Appoint(context);
                    break;
                case "Sendzy":
                    Sendzy(context);
                    break;
                case "GetDKJL":
                    GetDKJL(context);
                    break;
                case "LeaveDel":
                    LeaveDel(context);
                    break;
                case "TeaReward":
                    TeaReward(context);
                    break;
                case "OverTime":
                    OverTime(context);
                    break;
                case "OverTimeAudit":
                    OverTimeAudit(context);
                    break;
                case "Guidance":
                    Guidance(context);
                    break;
                case "AnalysisCounts":
                    AnalysisCounts(context);
                    break;
                case "AnalysisDetails":
                    AnalysisDetails(context);
                    break;
                case "NoCardApplication":
                    NoCardApplication(context);
                    break;
                case "NoCardApplicationAudit":
                    NoCardApplicationAudit(context);
                    break;
                case "OnlineCourse":
                    OnlineCourse(context);
                    break;
                case "CourseOnline":
                    CourseOnline(context);
                    break;
                case "EgovernmentMain":
                    EgovernmentMain(context);
                    break;
                case "AfficheResearchAccept":
                    AfficheResearchAccept(context);
                    break;
                case "AfficheResearchSend":
                    AfficheResearchSend(context);
                    break;
                case "PurAccList":
                    PurAccList(context);
                    break;
            }
        }

        #region 手机端--验收管理
        public void PurAccList(HttpContext context)
        {
            int recordCount = -1;
            Project_CheckEntity model = new Project_CheckEntity();
            model.PID = "";
            //flag区分教装与采购，默认1 位教装
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            DataTable dt = project_CheckDAL.GetPaged(pagesize, pageindex, ref recordCount, model, 2);

            string name = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"PCID\":\"" + dt.Rows[i]["PCID"] + "\",";//
                    name += "\"PName\":\"" + dt.Rows[i]["PName"] + "\",";//
                    name += "\"Evaluate\":\"" + CommonFunction.CheckEnum<CommonEnum.ProjectCheck>(dt.Rows[i]["Evaluate"]) + "\",";//
                    name += "\"Opinion\":\"" + dt.Rows[i]["Opinion"] + "\",";//
                    name += "\"PCDate\":\"" + Convert.ToDateTime(dt.Rows[i]["PCDate"].ToString()).ToString("yyyy-MM-dd") + "\",";//                                        
                    name += "\"IsReport\":\"" + dt.Rows[i]["IsReport"] + "\"},";//                    
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion


        #region 手机端--补卡审核记录
        public void NoCardApplicationAudit(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            NoCardApplyEntity model = new NoCardApplyEntity();
            model.NoCardState = (int)CommonEnum.PraState.申请中;
            model.NoCardApplyUser = userid;

            string name = "";
            DataTable dt = noCardApplyDAL.GetPagedApp(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"ID\":\"" + dt.Rows[i]["ID"] + "\",";//
                    name += "\"NoCardApplyUserName\":\"" + dt.Rows[i]["NoCardApplyUserName"] + "\",";//
                    name += "\"NoCardAuditUserName\":\"" + dt.Rows[i]["NoCardAuditUserName"] + "\",";//
                    name += "\"NoCardStateID\":\"" + dt.Rows[i]["NoCardState"] + "\",";//
                    name += "\"NoCardStateName\":\"" + CommonFunction.CheckEnum<CommonEnum.PraState>(dt.Rows[i]["NoCardState"]) + "\",";//
                    name += "\"NoCardApplyDate\":\"" + Convert.ToDateTime(dt.Rows[i]["NoCardApplyDate"]).ToString("yyyy-MM-dd HH:mm") + "\",";//
                    //name += "\"NoCardAuditDate\":\"" + Convert.ToDateTime(dt.Rows[i]["NoCardAuditDate"]).ToString("yyyy-MM-dd HH:ss") + "\"},";//
                    name += "\"NoCardApplyDesc\":\"" + dt.Rows[i]["NoCardApplyDesc"] + "\",";//
                    name += "\"NoCardAuditDesc\":\"" + dt.Rows[i]["NoCardAuditDesc"] + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion



        #region 手机端--我的加班列表
        public void OverTime(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string username = System.Web.HttpUtility.UrlDecode(context.Request.Params["RealName"], System.Text.Encoding.UTF8);
            OverTimeEntity model = new OverTimeEntity();
            model.ApplyUser = username;
            model.OState = -2;
            DataTable dt = overTimeDAL.GetPaged(pagesize, pageindex, ref recordCount, model, Convert.ToDateTime("1900-01-01"), Convert.ToDateTime("9999-12-31"));

            string name = "";
            //DataTable dt = leaveDAL.GetPagedApp(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"LType\":\"" + dt.Rows[i]["OTypeName"] + "\",";//
                    name += "\"LeaveUserName\":\"" + dt.Rows[i]["ApplyUserName"] + "\",";//
                    name += "\"UsersName\":\"" + dt.Rows[i]["UsersName"] + "\",";//
                    name += "\"LID\":\"" + dt.Rows[i]["OID"] + "\",";//
                    name += "\"LeaveStateID\":\"" + dt.Rows[i]["OState"] + "\",";//
                    name += "\"LeaveState\":\"" + CommonFunction.CheckEnum<CommonEnum.AduitState>(dt.Rows[i]["OState"]) + "\",";//
                    name += "\"LeaveDays\":\"" + string.Format("{0:N1}", dt.Rows[i]["ODay"]) + "\",";//
                    //name += "\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd HH:mm") + "\",";//
                    //name += "\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd HH:mm") + "\"},";//
                    name += "\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd ") + "\",";//
                    name += "\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd ") + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion
        #region 手机端--我的加班审核列表
        public void OverTimeAudit(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            OverTimeEntity model = new OverTimeEntity();
            model.ApplyUser = "";
            model.BeginDate = Convert.ToDateTime("1900-01-01");
            model.EndDate = Convert.ToDateTime("9999-12-31");
            model.OType = -2;
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            model.OState = (int)CommonEnum.AduitState.未审核;
            int isdisplay = (int)CommonEnum.IsorNot.是;
            DataTable dt = leaveAuditDAL.GetPaged(pagesize, pageindex, ref recordCount, model, userid, isdisplay);

            string name = "";
            // DataTable dt = leaveDAL.GetPagedApp(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"LType\":\"" + dt.Rows[i]["OTypeName"] + "\",";//
                    name += "\"LeaveUserName\":\"" + dt.Rows[i]["ApplyUserName"] + "\",";//
                    name += "\"UsersName\":\"" + dt.Rows[i]["UsersName"] + "\",";//
                    name += "\"LID\":\"" + dt.Rows[i]["OID"] + "\",";//
                    name += "\"LAID\":\"" + dt.Rows[i]["LAID"] + "\",";//
                    name += "\"LeaveStateID\":\"" + dt.Rows[i]["OState"] + "\",";//
                    name += "\"LeaveState\":\"" + CommonFunction.CheckEnum<CommonEnum.AduitState>(dt.Rows[i]["OState"]) + "\",";//
                    name += "\"LeaveDays\":\"" + string.Format("{0:N1}", dt.Rows[i]["ODays"]) + "\",";//
                    name += "\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd ") + "\",";//
                    name += "\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd ") + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion


        #region 手机端--我的请假撤销
        public void LeaveDel(HttpContext context)
        {
            string name = "";
            string lid = context.Request.Params["id"];


            int result = leaveDAL.DeleteBat(lid, Convert.ToInt32(CommonEnum.Deleted.删除));
            if (result > 0)
            {
                string uid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除请假信息", uid));
                sb.Append("{\"result\":\"true\"}");
            }
            else
            {
                sb.Append("{\"result\":\"false\"}");

            }


            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        name += "{\"ARID\":\"" + row["ARID"] + "\",";
            //        name += "\"RecordDate\":\"" + Convert.ToDateTime(row["RecordDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",";
            //        name += "\"AnayName\":\"" + row["AnayName"].ToString() + "\",";
            //        name += "\"IsAnalysis\":\"" + row["IsAnalysis"].ToString() + "\",";
            //        name += "\"UserName\":\"" + row["UserName"].ToString() + "\"},";
            //    }
            //    sb.Append("{\"result\":\"true\",\"data\":[");
            //    sb.Append(name.TrimEnd(','));
            //    sb.Append("]}");
            //}
            //else
            //{
            //    sb.Append("{\"result\":\"false\",\"data\":[]}");
            //}
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion


        #region 手机端--教师获奖
        public void TeaReward(HttpContext context)
        {
            string uid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            int isdel = Convert.ToInt32(CommonEnum.IsorNot.否);
            DataTable dt = teacherRewardDAL.GetPagedApp(pagesize, pageindex, uid, isdel);
            if (dt != null && dt.Rows.Count > 0)
            {
                string name = "";
                foreach (DataRow row in dt.Rows)
                {
                    name += "{\"TPID\":\"" + row["TPID"] + "\",";
                    name += "\"RewardType\":\"" + row["RewardType"] + "\",";
                    name += "\"RewardTypeName\":\"" + CommonFunction.CheckEnum<CommonEnum.RewardType>(row["RewardType"]) + "\",";
                    name += "\"PubDate\":\"" + Convert.ToDateTime(row["PubDate"]).ToString("yyyy-MM-dd") + "\",";
                    name += "\"RewardName\":\"" + row["RewardName"] + "\",";
                    name += "\"RGrade\":\"" + row["RGrade"] + "\",";
                    name += "\"RGradeName\":\"" + CommonFunction.CheckEnum<CommonEnum.RGrade>(row["RGrade"]) + "\",";
                    name += "\"Ranking\":\"" + row["Ranking"] + "\",";
                    name += "\"RankingName\":\"" + CommonFunction.CheckEnum<CommonEnum.Ranking>(row["Ranking"]) + "\",";
                    name += "\"Lunit\":\"" + row["Lunit"] + "\",";
                    name += "\"IsReportName\":\"" + CommonFunction.CheckEnum<CommonEnum.IsorNot>(row["IsReport"]) + "\",";
                    name += "\"IsReport\":\"" + row["IsReport"] + "\"},";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"false\",\"data\":[]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString().TrimEnd(','));
            context.Response.End();
        }
        #endregion


        #region 手机端--指导学生获奖
        public void Guidance(HttpContext context)
        {
            string uid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            int isdel = Convert.ToInt32(CommonEnum.IsorNot.否);
            DataTable dt = teacherGuidanceDAL.GetPagedApp(pagesize, pageindex, isdel, uid);
            if (dt != null && dt.Rows.Count > 0)
            {
                string name = "";
                foreach (DataRow row in dt.Rows)
                {
                    name += "{\"TGID\":\"" + row["TGID"] + "\",";
                    name += "\"GRole\":\"" + row["GRole"] + "\",";
                    name += "\"GRoleName\":\"" + CommonFunction.CheckEnum<CommonEnum.URole>(row["GRole"]) + "\",";
                    name += "\"PubDate\":\"" + Convert.ToDateTime(row["PubDate"]).ToString("yyyy-MM-dd") + "\",";
                    name += "\"RewardName\":\"" + row["RewardName"] + "\",";
                    name += "\"RGrade\":\"" + row["RGrade"] + "\",";
                    name += "\"Lunit\":\"" + row["Lunit"] + "\",";
                    name += "\"GuiDesc\":\"" + row["GuiDesc"] + "\",";
                    name += "\"IsReportName\":\"" + CommonFunction.CheckEnum<CommonEnum.IsorNot>(row["IsReport"]) + "\",";
                    name += "\"IsReport\":\"" + row["IsReport"] + "\"},";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"false\",\"data\":[]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString().TrimEnd(','));
            context.Response.End();
        }
        #endregion


        #region 手机端--我的考勤记录
        public void GetDKJL(HttpContext context)
        {
            string name = "";
            string uid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int flag = Convert.ToInt32(context.Request.Params["flag"]);
            DataTable dt = attendRecordDAL.PagedByuid(uid, flag);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    name += "{\"ARID\":\"" + row["ARID"] + "\",";
                    name += "\"RecordDate\":\"" + Convert.ToDateTime(row["RecordDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",";
                    name += "\"AnayName\":\"" + row["AnayName"].ToString() + "\",";
                    name += "\"IsAnalysis\":\"" + row["IsAnalysis"].ToString() + "\",";
                    name += "\"UserName\":\"" + row["UserName"].ToString() + "\"},";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"false\",\"data\":[]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion

        #region 学生手机端--获取作业信息
        public void HomeWorkData(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            HomeWorkEntity model = new HomeWorkEntity();
            model.CID = -2;
            model.IsSend = 1;
            model.CreateUser = userid;
            string name = "";
            DataTable dt = homeWorkDAL.GetPaged(pagesize, pageindex, ref recordCount, model, Convert.ToDateTime("1900-01-01"), Convert.ToDateTime("9999-12-31"), 2);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"HWID\":\"" + dt.Rows[i]["HWID"] + "\",";//
                    name += "\"CIDName\":\"" + dt.Rows[i]["CIDName"] + "\",";//
                    name += "\"CompleteTime\":\"" + dt.Rows[i]["CompleteTime"] + "\",";//
                    name += "\"CreateDate\":\"" + dt.Rows[i]["CreateDate"] + "\"},";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion

        #region 学生手机端--获取考试信息
        public void ExamData(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            ExamEntity model = new ExamEntity();
            model.GID = -2;
            model.EYear = "";
            model.Term = -2;
            model.ExamName = "";
            model.BeginDate = Convert.ToDateTime("1900-01-01");
            model.EndDate = Convert.ToDateTime("9999-12-31");

            string name = "";
            DataTable dt = examDAL.GetMyPaged(pagesize, pageindex, ref recordCount, model, userid);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"Eyear\":\"" + dt.Rows[i]["Eyear"] + "\",";//
                    name += "\"Term\":\"" + dt.Rows[i]["Term"] + "\",";//
                    name += "\"ExamName\":\"" + dt.Rows[i]["ExamName"] + "\",";//
                    name += "\"EID\":\"" + dt.Rows[i]["EID"] + "\",";//
                    name += "\"BeginDate\":\"" + dt.Rows[i]["BeginDate"] + "\",";
                    name += "\"EndDate\":\"" + dt.Rows[i]["EndDate"] + "\"},";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion

        #region 学生手机端--获取系统通知信息
        public void NoticeData(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            SysNoticeEntity model = new SysNoticeEntity();
            model.AcceptUser = userid;

            string name = "";
            DataTable dt = sysNoticeDAL.GetPaged(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"NContent\":\"" + dt.Rows[i]["NContent"] + "\",";//
                    name += "\"SendUserName\":\"" + dt.Rows[i]["SendUserName"] + "\",";//
                    name += "\"SendDate\":\"" + dt.Rows[i]["SendDate"] + "\",";//
                    name += "\"SNID\":\"" + dt.Rows[i]["SNID"] + "\",";//
                    name += "\"IsRead\":\"" + dt.Rows[i]["IsRead"] + "\"},";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion

        #region 主界面未读政务等条数
        public void MainDate(HttpContext context)
        {
            string userid = context.Request.Params["user"];
            DataTable dt = mainDAL.GetPaged(userid);
            if (dt.Rows.Count > 0)
            {
                sb.Append("{\"result\":\"success\",");
                sb.Append("\"dzzw\":\"" + dt.Rows[0]["dzzw"] + "\",");//未读政务
                sb.Append("\"jsqj\":\"" + dt.Rows[0]["jsqj"] + "\",");//教师请假
                sb.Append("\"xsqj\":\"" + dt.Rows[0]["xsqj"] + "\",");//学生请假
                sb.Append("\"dkjl\":\"" + dt.Rows[0]["dkjl"] + "\",");//代课登记
                sb.Append("\"bxjl\":\"" + dt.Rows[0]["bxjl"] + "\"");//报修记录
                sb.Append("\"wzsh\":\"" + dt.Rows[0]["wzsh"] + "\"");//报修记录
                sb.Append("}");
                //sb.Append("{\"dzzw\":\"" + dt.Rows[0]["dzzw"] + "\",\"jsqj\":\"" + dt.Rows[0]["jsqj"] + "\",\"xsqj\":\"" + dt.Rows[0]["xsqj"] + "\",\"dkjl\":\"" + dt.Rows[0]["dkjl"] + "\",\"bxjl\":\"" + dt.Rows[0]["bxjl"] + "\"} ");

            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion

        #region 电子政务语言播报
        public void ListenVoice(HttpContext context)
        {
            string wdzw = context.Request.Params["wdzw"];

            Tts _ttsClient = new Tts("zBoqwIjlyXPT1cKeWxEYwnfg", "j99fGL2teCGk9QTaXfjY6McstdF51dvY");
            var option = new Dictionary<string, object>()
                {
                    {"spd", 5}, // 语速
                    {"vol", 7}, // 音量
                    {"per", 0}  // 发音人，4：情感度丫丫童声
                 };
            var result = _ttsClient.Synthesis(wdzw == "" ? "Hello World" : "您有" + wdzw + "份新的电子政务，请及时查收！", option);
            if (result.ErrorCode == 0)  // 或 result.Success
            {
                string pah = System.Web.HttpContext.Current.Server.MapPath("~/voice/voice.mp3");
                File.WriteAllBytes(pah, result.Data);
            }
            Speech("~/voice/voice.mp3");

        }

        public void Speech(string path)
        {
            //new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, System.Web.HttpContext.Current.Server.MapPath(path), UserID));
            //new MCI().Play(AppDomain.CurrentDomain.BaseDirectory + "\voice\voice.mp3", 1); 
            new MCI().Play(System.Web.HttpContext.Current.Server.MapPath(path), 1);
        }

        #endregion

        #region 手机端--已发和待处理
        //1 待处理 2 已发
        public void EgovernmentByFlag(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string didname = context.Request.Params["didname"];
            int flag = Convert.ToInt32(context.Request.Params["flag"]);
            Egovernment_FlowEntity model = new Egovernment_FlowEntity();
            model.ETitle = didname;
            model.Begin = Convert.ToDateTime("1900-12-01");
            model.End = Convert.ToDateTime("9999-12-01");
            model.AcceptUser = userid;
            string name = "";
            DataTable dt = egovernment_FlowDAL.GetPagedAPPByFlag(pagesize, pageindex, ref recordCount, model, flag);
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
                    name += "\"AcceptUserName\":\"" + dt.Rows[i]["AcceptUserName"] + "\",";//
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
        #endregion

        #region 手机端--政务列表前10条
        public void Egovernment(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string didname = context.Request.Params["didname"];
            Egovernment_FlowEntity model = new Egovernment_FlowEntity();
            model.ETitle = didname;
            model.Begin = Convert.ToDateTime("1900-12-01");
            model.End = Convert.ToDateTime("9999-12-01");
            model.AcceptUser = userid;
            string name = "";
            DataTable dt = egovernment_FlowDAL.GetPagedAPP(pagesize, pageindex, ref recordCount, model, 2);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //sb.Append("{\"result\":\"success\",");
                    name += "{\"FID\":\"" + dt.Rows[i]["FID"] + "\",";//
                    name += "\"IsApproved\":\"" + dt.Rows[i]["IsApproved"] + "\",";//
                    name += "\"Etitle\":\"" + dt.Rows[i]["Etitle"].ToString().Replace("\"", "\\\"") + "\",";//
                    name += "\"CreateDate\":\"" + Convert.ToDateTime(dt.Rows[i]["CreateDate"]).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"CreateUserName\":\"" + dt.Rows[i]["CreateUserName"] + "\",";//
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
        #endregion

        #region 手机端政务列表其余条数
        public void EgovernmentNum(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            Egovernment_FlowEntity model = new Egovernment_FlowEntity();
            model.ETitle = "";
            model.Begin = Convert.ToDateTime("1900-12-01");
            model.End = Convert.ToDateTime("9999-12-01");
            model.AcceptUser = userid;
            string name = "";
            DataTable dt = egovernment_FlowDAL.GetPagedAPP(pagesize, pageindex, ref recordCount, model, 2);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"FID\":\"" + dt.Rows[i]["FID"] + "\",";//
                    name += "\"IsApproved\":\"" + dt.Rows[i]["IsApproved"] + "\",";//
                    name += "\"Etitle\":\"" + dt.Rows[i]["Etitle"] + "\",";//
                    name += "\"CreateDate\":\"" + dt.Rows[i]["CreateDate"] + "\",";//
                    name += "\"CreateUserName\":\"" + dt.Rows[i]["CreateUserName"] + "\",";//
                    name += "\"Completed\":\"" + dt.Rows[i]["Completed"] + "\",";//
                    name += "\"State\":\"" + dt.Rows[i]["State"] + "\"},";//
                    //name += "\"EContent\":\"" + dt.Rows[i]["EContent"] + "\"},";//
                    // sb.Append("\"State\":\"" + dt.Rows[i]["State"] + "\"");//
                    //sb.Append("}");


                }
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            string a = "{\"result\":\"success\"}";
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion


        #region 手机端晨检申报
        public void StuAttend(HttpContext context)
        {
            int recordCount = 0;
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string DIDName = ((context.Request.Params["didname"] == "null") || (context.Request.Params["didname"] == "")) ? "" : context.Request.Params["didname"].ToString();
            DateTime begin = Convert.ToDateTime("1900 - 01 - 01");
            DateTime end = Convert.ToDateTime("9999 - 12 - 31");
            string name = "";
            DataTable dt = stuattendDAL.GetPaged(pagesize, pageindex, ref recordCount, DIDName, begin, end);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    name += "{\"DID\":\"" + row["DID"] + "\",";
                    name += "\"DIDName\":\"" + row["DIDName"] + "\",";
                    name += "\"CreateDate\":\"" + Convert.ToDateTime(row["CreateDate"]).ToString("yyyy-MM-dd") + "\",";
                    name += "\"AllIns\":\"" + row["AllIns"] + "\",";
                    name += "\"RealCOunt\":\"" + row["RealCOunt"] + "\"},";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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


        #region 手机端--我的代课
        public void PersonSubstitute(HttpContext context)
        {
            string name = "";
            int recordCount = -1;
            string uid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            AbsentEntity model = new AbsentEntity();
            model.Isdel = Convert.ToInt32(CommonEnum.IsorNot.否);
            model.SubUser = uid;
            DataTable dt = absentDAL.GetPagedAPP(pagesize, pageindex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    name += "{\"AbID\":\"" + row["AbID"] + "\",";
                    name += "\"SubDate\":\"" + Convert.ToDateTime(row["SubDate"]).ToString("yyyy-MM-dd") + "\",";
                    name += "\"SubCoruseName\":\"" + row["SubCoruseName"] + "\",";
                    name += "\"OtherName\":\"" + row["OtherName"] + "\",";
                    name += "\"SubNum\":\"" + row["SubNum"] + "\",";
                    name += "\"SubState\":\"" + row["SubState"] + "\",";
                    name += "\"SubStateName\":\"" + CommonFunction.CheckEnum<CommonEnum.PraState>(row["SubState"]) + "\"},";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"false\",\"data\":[]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion


        #region 手机端考勤统计
        public void StuLeave(HttpContext context)
        {
            int recordCount = 0;
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            int month = Convert.ToInt32(((context.Request.Params["month"] == "null") || (context.Request.Params["month"] == "")) ? "-2" : context.Request.Params["month"].ToString());
            string DIDName = "";
            string name = "";
            DataTable dt = stuattendDAL.GetPageds(pagesize, pageindex, ref recordCount, DIDName, month);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    name += "{\"DIDName\":\"" + row["DIDName"] + "\",";
                    name += "\"LeaveUser\":\"" + row["LeaveUser"] + "\",";
                    name += "\"Month\":\"" + Convert.ToInt32(row["months"].ToString()) + "\",";
                    name += "\"Compassionate\":\"" + row["Compassionate"] + "\",";
                    name += "\"Sick\":\"" + row["Sick"] + "\",";
                    name += "\"Infectious\":\"" + row["Infectious"] + "\"},";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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


        #region 手机端--工作计划
        public void Work(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            WorkPlanEntity model = new WorkPlanEntity();
            model.CreateUser = userid;
            model.Isdel = (int)CommonEnum.IsorNot.否;
            model.DutyUser = "";
            string begin = "1900-01-01 00:00";
            string end = "9999-12-31 23:59";

            string name = "";
            DataTable dt = workPlanDAL.GetPagedAPP(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"PlanID\":\"" + dt.Rows[i]["PlanID"] + "\",";//
                    name += "\"EYear\":\"" + dt.Rows[i]["EYear"] + "\",";//
                    name += "\"Term\":\"" + dt.Rows[i]["Term"] + "\",";//
                    name += "\"DepName\":\"" + dt.Rows[i]["DepName"] + "\",";//
                    name += "\"AllUsers\":\"" + dt.Rows[i]["AllUsers"] + "\",";//
                    name += "\"WeekNum\":\"" + dt.Rows[i]["WeekNum"] + "\",";//
                    name += "\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"ExamName\":\"" + dt.Rows[i]["ExamName"].ToString().Replace("\r", "").Replace("\n", "") + "\",";//
                    name += "\"IsComplete\":\"" + dt.Rows[i]["IsComplete"] + "\",";//
                    name += "\"CreateUserName\":\"" + dt.Rows[i]["CreateUserName"] + "\",";//
                    name += "\"DutyUserName\":\"" + dt.Rows[i]["DutyUserName"] + "\"},";//
                }
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion

        #region 手机端--已收通知公告
        public void Affiche(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            AfficheEntity model = new AfficheEntity();


            string name = "";
            DataTable dt = afficheDAL.GetPagedAPP(pagesize, pageindex, ref recordCount, model, 2, userid);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"AID\":\"" + dt.Rows[i]["AID"] + "\",";//
                    name += "\"SenduserName\":\"" + dt.Rows[i]["SenduserName"] + "\",";//
                    name += "\"ATypeName\":\"" + dt.Rows[i]["ATypeName"] + "\",";//
                    name += "\"AcceptUser\":\"" + dt.Rows[i]["AcceptUser"] + "\",";//
                    name += "\"IsRead\":\"" + dt.Rows[i]["IsRead"] + "\",";//
                    name += "\"AcceptUserName\":\"" + dt.Rows[i]["AcceptUserName"] + "\",";//
                    name += "\"AfficheTitle\":\"" + dt.Rows[i]["AfficheTitle"] + "\",";//
                    name += "\"SendDate\":\"" + dt.Rows[i]["SendDate"] + "\"},";//
                }
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion

        #region 手机端--已发通知公告
        public void AfficheSend(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            AfficheEntity model = new AfficheEntity();
            string name = "";
            DataTable dt = afficheDAL.GetPagedSendAPP(pagesize, pageindex, ref recordCount, model, userid);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"AID\":\"" + dt.Rows[i]["AID"] + "\",";//
                    name += "\"SenduserName\":\"" + dt.Rows[i]["SenduserName"] + "\",";//
                    name += "\"ATypeName\":\"" + dt.Rows[i]["ATypeName"] + "\",";//
                    name += "\"AcceptUser\":\"" + dt.Rows[i]["AcceptUser"] + "\",";//
                    name += "\"ReadOrNot\":\"" + dt.Rows[i]["ReadOrNot"] + "\",";//
                    name += "\"AcceptUserName\":\"" + dt.Rows[i]["AcceptUserName"] + "\",";//
                    name += "\"AfficheTitle\":\"" + dt.Rows[i]["AfficheTitle"] + "\",";//
                    name += "\"SendDate\":\"" + dt.Rows[i]["SendDate"] + "\"},";//
                }
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion


        #region 手机端--校内活动
        public void SpaceLog(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            StudentActivityEntity model = new StudentActivityEntity();
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.ActName = "";
            model.ActType = -2;


            string name = "";
            DataTable dt = studentActivityDAL.GetPagedAPP(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"SAID\":\"" + dt.Rows[i]["SAID"] + "\",";//
                    name += "\"ActName\":\"" + dt.Rows[i]["ActName"] + "\",";//
                    name += "\"ActTypeName\":\"" + dt.Rows[i]["ActTypeName"] + "\",";//
                    name += "\"ABegin\":\"" + dt.Rows[i]["ABegin"] + "\",";//
                    name += "\"AEnd\":\"" + dt.Rows[i]["AEnd"] + "\",";//
                    name += "\"CreateUserName\":\"" + dt.Rows[i]["CreateUserName"] + "\",";//
                    name += "\"CounselorName\":\"" + dt.Rows[i]["CounselorName"] + "\"},";//
                }
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            string a = "{\"result\":\"success\"}";
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion

        #region 手机端--我的报修立即完成
        public void LJWC(HttpContext context)
        {
            string arid = context.Request.Params["arid"];
            int state = Convert.ToInt32(context.Request.Params["state"]);
            int result = repairDAL.UpdateApp(arid, state + 1);
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


        #region 手机端--政务已阅
        public void YY(HttpContext context)
        {
            string fid = context.Request.Params["fid"];
            int result = egovernment_FlowDAL.Read(fid);
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


        #region 手机端--周计划完成
        public void WorkWC(HttpContext context)
        {
            string planid = context.Request.Params["planid"];
            int result = workPlanDAL.CompLete(planid, (int)CommonEnum.IsorNot.是);
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


        #region 手机端--场室预约
        public void Appoint(HttpContext context)
        {
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            int recordCount = 0;
            DataTable dt = appointmentDAL.GetPagedApp(pagesize, pageindex, ref recordCount);
            string name = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"AID\":\"" + dt.Rows[i]["AID"] + "\",";
                    name += "\"AppUserName\":\"" + dt.Rows[i]["AppUserName"] + "\",";
                    name += "\"MRName\":\"" + dt.Rows[i]["MRName"] + "\",";
                    name += "\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd hh:mm") + "\",";
                    name += "\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd hh:mm") + "\",";
                    name += "\"AppointmentDesc\":\"" + dt.Rows[i]["AppointmentDesc"] + "\",";
                    name += "\"IsUse\":\"" + dt.Rows[i]["IsUseName"] + "\",";
                    name += "\"IsUseName\":\"" + CommonFunction.CheckEnum<CommonEnum.IsorNot>(dt.Rows[i]["IsUseName"]) + "\"},";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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



        #region 手机端--我的报修
        public void PeopleRepair(HttpContext context)
        {
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            int recordCount = 0;
            Asset_RepairEntity model = new Asset_RepairEntity();
            model.RepairObj = "";
            DateTime begin = Convert.ToDateTime("1900-01-01");
            DateTime end = Convert.ToDateTime("9999-12-31");
            model.DutyUser = "";
            model.ARState = -2;
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            model.CreaterUser = userid;
            DataTable dt = repairDAL.GetPaged(pagesize, pageindex, ref recordCount, model, begin, end);
            string name = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"ARID\":\"" + dt.Rows[i]["ARID"] + "\",";//
                    name += "\"ARFile\":\"" + dt.Rows[i]["ARFile"].ToString().Replace("\\", "/") + "\",";//
                    name += "\"RepairObj\":\"" + dt.Rows[i]["RepairObj"] + "\",";//
                    name += "\"ARDate\":\"" + Convert.ToDateTime(dt.Rows[i]["ARDate"]).ToString("yyyy-MM-dd HH:mm") + "\",";//
                    name += "\"DutyDepName\":\"" + dt.Rows[i]["DutyDepName"] + "\",";//
                    name += "\"RealName\":\"" + dt.Rows[i]["RealName"] + "\",";//
                    name += "\"ARState\":\"" + dt.Rows[i]["ARState"] + "\",";//
                    name += "\"ARStateName\":\"" + CommonFunction.CheckEnum<CommonEnum.ARState>(dt.Rows[i]["ARState"]) + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion


        #region 手机端--我受理的报修
        public void RepairPeople(HttpContext context)
        {
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            int recordCount = 0;
            Asset_RepairEntity model = new Asset_RepairEntity();
            model.DutyUser = userid;
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            DataTable dt = repairDAL.GetPagedBywsld(pagesize, pageindex, ref recordCount, model);
            string name = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"ARID\":\"" + dt.Rows[i]["ARID"] + "\",";//
                    name += "\"ARFile\":\"" + dt.Rows[i]["ARFile"].ToString().Replace("\\", "/") + "\",";//
                    name += "\"RepairObj\":\"" + dt.Rows[i]["RepairObj"] + "\",";//
                    name += "\"CreaterUserName\":\"" + dt.Rows[i]["CreaterUserName"] + "\",";//
                    name += "\"ARDate\":\"" + Convert.ToDateTime(dt.Rows[i]["ARDate"]).ToString("yyyy-MM-dd HH:mm") + "\",";//
                    name += "\"DutyDepName\":\"" + dt.Rows[i]["DutyDepName"] + "\",";//
                    name += "\"RealName\":\"" + dt.Rows[i]["RealName"] + "\",";//
                    name += "\"ARState\":\"" + dt.Rows[i]["ARState"] + "\",";//
                    name += "\"ARStateName\":\"" + CommonFunction.CheckEnum<CommonEnum.ARState>(dt.Rows[i]["ARState"]) + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion

        #region 手机端--移交工单所有列表
        public void RepairYJ(HttpContext context)
        {
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            int recordCount = 0;
            Asset_RepairEntity model = new Asset_RepairEntity();
            model.DutyUser = userid;
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            DataTable dt = repairDAL.GetPagedByYJ(pagesize, pageindex, ref recordCount, model);
            string name = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"ARID\":\"" + dt.Rows[i]["ARID"] + "\",";//
                    name += "\"ARFile\":\"" + dt.Rows[i]["ARFile"].ToString().Replace("\\", "/") + "\",";//
                    name += "\"RepairObj\":\"" + dt.Rows[i]["RepairObj"] + "\",";//
                    name += "\"CreaterUserName\":\"" + dt.Rows[i]["CreaterUserName"] + "\",";//
                    name += "\"ARDate\":\"" + Convert.ToDateTime(dt.Rows[i]["ARDate"]).ToString("yyyy-MM-dd HH:mm") + "\",";//
                    name += "\"DutyDepName\":\"" + dt.Rows[i]["DutyDepName"] + "\",";//
                    name += "\"RealName\":\"" + dt.Rows[i]["RealName"] + "\",";//
                    name += "\"ARState\":\"" + dt.Rows[i]["ARState"] + "\",";//
                    name += "\"ARStateName\":\"" + CommonFunction.CheckEnum<CommonEnum.ARState>(dt.Rows[i]["ARState"]) + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion


        #region 手机端--我的请假
        public void PeopleLeave(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            LeaveEntity model = new LeaveEntity();
            model.Isdel = (int)CommonEnum.IsorNot.否;
            model.LeaveUser = userid;
            model.LFlag = (int)CommonEnum.LFlag.请假;

            string name = "";
            DataTable dt = leaveDAL.GetPagedApp(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"LType\":\"" + dt.Rows[i]["LTypeName"] + "\",";//
                    name += "\"LeaveUserName\":\"" + dt.Rows[i]["LeaveUserName"] + "\",";//
                    name += "\"LID\":\"" + dt.Rows[i]["LID"] + "\",";//
                    name += "\"LeaveStateID\":\"" + dt.Rows[i]["LeaveState"] + "\",";//
                    name += "\"LeaveState\":\"" + CommonFunction.CheckEnum<CommonEnum.AduitState>(dt.Rows[i]["LeaveState"]) + "\",";//
                    name += "\"LeaveDays\":\"" + string.Format("{0:N1}", dt.Rows[i]["LeaveDays"]) + "\",";//
                    name += "\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd") + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion
        #region 手机端--我的外出备案
        public void PeopleRecord(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            LeaveEntity model = new LeaveEntity();
            model.Isdel = (int)CommonEnum.IsorNot.否;
            model.LeaveUser = userid;
            model.LFlag = (int)CommonEnum.LFlag.外出备案;

            string name = "";
            DataTable dt = leaveDAL.GetPagedApp(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{";//
                    name += "\"LeaveUserName\":\"" + dt.Rows[i]["LeaveUserName"] + "\",";//
                    name += "\"LID\":\"" + dt.Rows[i]["LID"] + "\",";//
                    name += "\"LeaveDays\":\"" + string.Format("{0:N1}", dt.Rows[i]["LeaveDays"]) + "\",";//
                    name += "\"LeaveMark\":\"" + string.Format("{0:N1}", dt.Rows[i]["LeaveMark"]) + "\",";//
                    name += "\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd") + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion

        #region 手机端--我的外出
        public void PeopleTrave(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            LeaveEntity model = new LeaveEntity();
            model.Isdel = (int)CommonEnum.IsorNot.否;
            model.LeaveUser = userid;
            model.LFlag = (int)CommonEnum.LFlag.外出登记;

            string name = "";
            DataTable dt = leaveDAL.GetPagedApp(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"LeaveUserName\":\"" + dt.Rows[i]["LeaveUserName"] + "\",";//
                    name += "\"LID\":\"" + dt.Rows[i]["LID"] + "\",";//
                    name += "\"LeaveStateID\":\"" + dt.Rows[i]["LeaveState"] + "\",";//
                    name += "\"LeaveState\":\"" + CommonFunction.CheckEnum<CommonEnum.AduitState>(dt.Rows[i]["LeaveState"]) + "\",";//
                    name += "\"LeaveDays\":\"" + string.Format("{0:N1}", dt.Rows[i]["LeaveDays"]) + "\",";//
                    name += "\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd") + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion


        #region 手机端--请假审核
        public void LeaveAudit(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            LeaveEntity model = new LeaveEntity();
            model.Isdel = (int)CommonEnum.IsorNot.否;
            int isdisplay = 1;
            model.LFlag = 1;

            string name = "";
            DataTable dt = leaveAuditDAL.GetPagedAPP(pagesize, pageindex, ref recordCount, model, userid, isdisplay);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"LType\":\"" + dt.Rows[i]["LTypeName"] + "\",";//
                    name += "\"LeaveUserName\":\"" + dt.Rows[i]["LeaveUserName"] + "\",";//
                    name += "\"LID\":\"" + dt.Rows[i]["LID"] + "\",";//
                    name += "\"LAID\":\"" + dt.Rows[i]["LAID"] + "\",";//
                    name += "\"LeaveStateID\":\"" + dt.Rows[i]["LeaveState"] + "\",";//
                    name += "\"LeaveState\":\"" + CommonFunction.CheckEnum<CommonEnum.AduitState>(dt.Rows[i]["LeaveState"]) + "\",";//
                    name += "\"LeaveDays\":\"" + string.Format("{0:N1}", dt.Rows[i]["LeaveDays"]) + "\",";//
                    name += "\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd") + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion

        #region 手机端--外出审核
        public void TraveAudit(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            LeaveEntity model = new LeaveEntity();
            model.Isdel = (int)CommonEnum.IsorNot.否;
            int isdisplay = 1;
            model.LFlag = 2;

            string name = "";
            DataTable dt = leaveAuditDAL.GetPagedAPP(pagesize, pageindex, ref recordCount, model, userid, isdisplay);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"LeaveUserName\":\"" + dt.Rows[i]["LeaveUserName"] + "\",";//
                    name += "\"LID\":\"" + dt.Rows[i]["LID"] + "\",";//
                    name += "\"LAID\":\"" + dt.Rows[i]["LAID"] + "\",";//
                    name += "\"LeaveStateID\":\"" + dt.Rows[i]["LeaveState"] + "\",";//
                    name += "\"LeaveState\":\"" + CommonFunction.CheckEnum<CommonEnum.AduitState>(dt.Rows[i]["LeaveState"]) + "\",";//
                    name += "\"LeaveDays\":\"" + string.Format("{0:N1}", dt.Rows[i]["LeaveDays"]) + "\",";//
                    name += "\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd") + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion


        #region 手机端--作业布置
        public void Sendzy(HttpContext context)
        {
            bool results = true;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int cid = Convert.ToInt32(context.Request.Params["cid"]);
            string homework = context.Request.Params["homework"];
            int completeTime = Convert.ToInt32(context.Request.Params["completeTime"]);
            string did = context.Request.Params["did"].TrimEnd(',');
            string claname = context.Request.Params["claname"].TrimEnd(',');
            string serverid = context.Request.Params["serverid"];
            string accessToken = context.Request.Params["accessToken"];
            DataTable dt = studentDAL.GetUIDByDid(did);
            if (serverid != "")
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Notice", 1);
                    if (model1 != null)
                    {
                        string msg = WeixinQYAPI.SendMessageMEDIA_ID(accessToken, dt.Rows[0][0].ToString().TrimEnd(',').Replace(",", "|"), model1.Agent, serverid);
                        if (msg == "ok")
                        {
                            results = true;
                        }
                        else
                        {
                            results = false;
                        }
                    }

                }
                else
                {
                    results = false;
                }
            }
            HomeWorkEntity model = new HomeWorkEntity();
            model.CID = cid;
            model.HWID = "";
            model.IsSend = 0;
            model.HomeWork = homework;
            model.CompleteTime = completeTime;
            model.CreateUser = userid;
            model.Claids = did;
            model.ClaName = claname;
            int result = homeWorkDAL.EditApp(model, dt.Rows[0][0].ToString().TrimEnd(','));
            if (result == 0 && results == true)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加作业信息", userid));
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

        #region 手机端--考勤统计页面
        public void AnalysisCounts(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string begindate = Convert.ToString(context.Request.Params["begindate"]);
            AttendRecordEntity model = new AttendRecordEntity();
            string name = "";
            model.UserName = userid;
            model.Begin = Convert.ToDateTime(begindate);
            model.End = Convert.ToDateTime(begindate);

            DataTable dt = attendRecordDAL.AnalysisCounts(pagesize, pageindex, ref recordCount, model, (int)CommonEnum.UserType.老师);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"LID\":\"" + dt.Rows[i]["LID"] + "\",";//
                    name += "\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd ") + "\",";//
                    name += "\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd ") + "\",";//
                    name += "\"LeaveDays\":\"" + dt.Rows[i]["LeaveDays"] + "\",";//
                    name += "\"LTypeName\":\"" + dt.Rows[i]["LTypeName"] + "\",";//
                    name += "\"LFlag\":\"" + dt.Rows[i]["LFlag"] + "\"},";//
                }
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion

        #region 手机端--考勤详细页面
        public void AnalysisDetails(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string begindate = Convert.ToString(context.Request.Params["begindate"]);
            AttendRecordEntity model = new AttendRecordEntity();
            string name = "";
            model.UserName = userid;
            model.Begin = Convert.ToDateTime(begindate);
            // model.End = Convert.ToDateTime(begindate);

            DataTable dt = attendRecordDAL.AnalysisDetails(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"ARID\":\"" + dt.Rows[i]["ARID"] + "\",";//
                    //name += "\"RecordDate\":\"" + Convert.ToDateTime(dt.Rows[i]["RecordDate"]).ToString("yyyy-MM-dd hh:mm") + "\",";//
                    name += "\"RecordDate\":\"" + Convert.ToDateTime(dt.Rows[i]["RecordDate"]).ToString("HH:mm") + "\",";//
                    name += "\"UserName\":\"" + dt.Rows[i]["UserName"] + "\",";//
                    name += "\"AnayName\":\"" + dt.Rows[i]["AnayName"] + "\",";//
                    name += "\"MachineCode\":\"" + dt.Rows[i]["MachineCode"] + "\",";//
                    name += "\"UserNum\":\"" + dt.Rows[i]["UserNum"] + "\",";//
                    name += "\"CardNum\":\"" + dt.Rows[i]["CardNum"] + "\"},";//
                }
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion


        #region 手机端--补卡记录
        public void NoCardApplication(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            NoCardApplyEntity model = new NoCardApplyEntity();
            model.NoCardState = -2;
            model.NoCardApplyUser = userid;

            string name = "";
            DataTable dt = noCardApplyDAL.GetPagedApp(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"ID\":\"" + dt.Rows[i]["ID"] + "\",";//
                    name += "\"NoCardApplyUserName\":\"" + dt.Rows[i]["NoCardApplyUserName"] + "\",";//
                    name += "\"NoCardAuditUserName\":\"" + dt.Rows[i]["NoCardAuditUserName"] + "\",";//
                    name += "\"NoCardStateID\":\"" + dt.Rows[i]["NoCardState"] + "\",";//
                    name += "\"NoCardStateName\":\"" + CommonFunction.CheckEnum<CommonEnum.PraState>(dt.Rows[i]["NoCardState"]) + "\",";//
                    name += "\"NoCardApplyDate\":\"" + Convert.ToDateTime(dt.Rows[i]["NoCardApplyDate"]).ToString("yyyy-MM-dd HH:mm") + "\",";//
                    //name += "\"NoCardAuditDate\":\"" + Convert.ToDateTime(dt.Rows[i]["NoCardAuditDate"]).ToString("yyyy-MM-dd HH:ss") + "\"},";//
                    name += "\"NoCardApplyDesc\":\"" + dt.Rows[i]["NoCardApplyDesc"] + "\",";//
                    name += "\"NoCardAuditDesc\":\"" + dt.Rows[i]["NoCardAuditDesc"] + "\"},";//
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion


        #region 手机端--在线选课
        public void OnlineCourse(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            ElectiverEntity model = new ElectiverEntity();
            model.EState = 3;
            //model.NoCardApplyUser = userid;

            string name = "";
            DataTable dt = eleDAL.PagedOnlineAPP(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"EleID\":\"" + dt.Rows[i]["EleID"] + "\",";//
                    name += "\"ElectiverName\":\"" + dt.Rows[i]["ElectiverName"] + "\",";//
                    name += "\"EBegin\":\"" + Convert.ToDateTime(dt.Rows[i]["EBegin"]).ToString("yyyy-MM-dd HH:mm") + "\",";//
                    name += "\"EEnd\":\"" + Convert.ToDateTime(dt.Rows[i]["EEnd"]).ToString("yyyy-MM-dd HH:mm") + "\",";//
                    name += "\"EstimateBDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EstimateBDate"]).ToString("yyyy-MM-dd HH:mm") + "\",";//
                    name += "\"EstimateEDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EstimateEDate"]).ToString("yyyy-MM-dd HH:mm") + "\",";//
                    name += "\"EStopDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EStopDate"]).ToString("yyyy-MM-dd HH:mm") + "\",";//

                    //name += "\"NoCardStateID\":\"" + dt.Rows[i]["NoCardState"] + "\",";//
                    //name += "\"NoCardStateName\":\"" + CommonFunction.CheckEnum<CommonEnum.PraState>(dt.Rows[i]["NoCardState"]) + "\",";//
                    //name += "\"NoCardApplyDesc\":\"" + dt.Rows[i]["NoCardApplyDesc"] + "\",";//
                    name += "\"EState\":\"" + dt.Rows[i]["EState"] + "\"},";//

                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion

        #region 手机端--课程选择
        public void CourseOnline(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            int eleID = Convert.ToInt32(context.Request.Params["EleID"]);

            ElectiverEntity model = new ElectiverEntity();
            //model.EState = 3;

            string name = "";
            DataTable dt = electiver_CourseDAL.GetList(eleID);
            //DataTable dt = eleDAL.PagedOnlineAPP(pagesize, pageindex, ref recordCount, model);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"EleID\":\"" + dt.Rows[i]["EleID"] + "\",";//
                    name += "\"ECID\":\"" + dt.Rows[i]["ECID"] + "\",";//
                    name += "\"CourseName\":\"" + dt.Rows[i]["CourseName"] + "\",";//
                    name += "\"CourseID\":\"" + dt.Rows[i]["CourseID"] + "\",";//
                    name += "\"ClevelName\":\"" + dt.Rows[i]["ClevelName"] + "\",";//
                    name += "\"MaxCount\":\"" + dt.Rows[i]["MaxCount"] + "\",";//
                    name += "\"DY\":\"" + dt.Rows[i]["DY"] + "\"},";//
                    // name += "\"EState\":\"" + dt.Rows[i]["EState"] + "\"},";//

                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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
        #endregion



        #region 手机端--发送
        public void send(HttpContext context)
        {
            try
            {
                string uid = context.Request.Params["uid"];
                string serverid = context.Request.Params["serverid"];
                string accessToken = context.Request.Params["accessToken"];
                WeiXinInfoEntity model = XMLHelper.Get("~/QYWX.xml", "Notice", 1);
                if (model != null)
                {
                    string msg = WeixinQYAPI.SendMessageMEDIA_ID(accessToken, uid, model.Agent, serverid);
                    if (msg == "ok")
                    {
                        sb.Append("{\"result\":\"true\"}");
                    }
                    else
                    {
                        sb.Append("{\"result\":\"false\"}");
                    }
                }
            }
            catch (Exception ex)
            {
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, ""));
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion

        #region 手机端
        private void GetCamera(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                int recordCount = -1;
                string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
                int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
                int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

                Egovernment_FlowEntity model = new Egovernment_FlowEntity();
                model.ETitle = "";
                model.Begin = Convert.ToDateTime("1900-12-01");
                model.End = Convert.ToDateTime("9999-12-01");
                model.AcceptUser = userid;

                DataTable dt = egovernment_FlowDAL.GetPaged(pagesize, pageindex, ref recordCount, model, 2);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"FID\":\"" + dt.Rows[i]["FID"].ToString() + "\"" +
                        ",\"IsApproved\":\"" + dt.Rows[i]["IsApproved"].ToString() + "\"" +
                        ",\"Etitle\":\"" + dt.Rows[i]["Etitle"].ToString() + "\"" +
                        ",\"CreateDate\":\"" + dt.Rows[i]["CreateDate"].ToString() + "\"" +
                        ",\"CreateUserName\":\"" + dt.Rows[i]["CreateUserName"].ToString() + "\"" +
                        ",\"Completed\":\"" + dt.Rows[i]["Completed"].ToString() + "\"" +
                         ",\"State\":\"" + dt.Rows[i]["State"].ToString() + "\"},";
                        //",\"EContent\":\"" + dt.Rows[i]["EContent"].ToString() + "\"},";
                    }
                }
                else
                {
                    name = "";
                }
                sb.Append("[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion


        #region 获取首页政务信息
        public void EgovernmentMain(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = 1;
            int pagesize = 2;
            int flag = 1;
            Egovernment_FlowEntity model = new Egovernment_FlowEntity();
            model.ETitle = "";
            model.Begin = Convert.ToDateTime("1900-12-01");
            model.End = Convert.ToDateTime("9999-12-01");
            model.AcceptUser = userid;
            DataTable dt = egovernment_FlowDAL.GetPagedAPPByFlag(pagesize, pageindex, ref recordCount, model, flag);

            string data = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string content = "";
                    Regex replaceSpace = new Regex(@"</?[p|P][^>]*>", RegexOptions.IgnoreCase);
                    content = replaceSpace.Replace(row["EContent"].ToString(), "");

                    //data += "{h4:'" + row["Etitle"] + "',src: '#',p1: '" + row["Comment"] + "', p2: '" + (row["EContent"].ToString().Length > 30 ? row["EContent"].ToString().Substring(0, 30) + "..." : row["EContent"].ToString()) + "', zhuangtai1: '已完成', zhuangtai2: '空闲'},";
                    //data += "{h4:'" + row["Etitle"] + "',src: '#', p2: '" + (content.Length > 30 ? content.Substring(0, 30) + "..." : content) + "', zhuangtai1: '待处理'},";

                    data += "{\"h4\":\"" + row["Etitle"] + "\"" +
                       ",\"src\":\"" + "app/TreatedEgovernmentManage.aspx" + "\"" +
                       ",\"p2\":\"" + (content.Length > 30 ? content.Substring(0, 30) + "..." : content) + "\"" +
                       ",\"zhuangtai1\":\"" + "待处理" + "\"},";
                }
            }
            sb.Append("[");
            sb.Append(data.ToString().TrimEnd(','));
            sb.Append("]");

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();

        }
        #endregion


        #region 手机端--已收教研
        public void AfficheResearchAccept(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);

            AfficheEntity model = new AfficheEntity();


            int sdid = 0;
            DataTable rt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.通知公告);
            foreach (DataRow dr in rt.Rows)
            {
                string bb = dr["DataName"].ToString();
                if (dr["DataName"].ToString() == "教研活动")
                {
                    sdid = Convert.ToInt32(dr["SDID"].ToString());
                }
            }
            //model.AType = 2088;//教研通知
            model.AType = sdid;//教研通知


            string name = "";
            DataTable dt = afficheDAL.GetAfficheAcceptAPP(pagesize, pageindex, ref recordCount, model, userid);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"AID\":\"" + dt.Rows[i]["AID"] + "\",";//
                    name += "\"SenduserName\":\"" + dt.Rows[i]["SenduserName"] + "\",";//
                    name += "\"ATypeName\":\"" + dt.Rows[i]["ATypeName"] + "\",";//
                    name += "\"AcceptUser\":\"" + dt.Rows[i]["AcceptUser"] + "\",";//
                    name += "\"IsRead\":\"" + dt.Rows[i]["IsRead"] + "\",";//

                    name += "\"AuditMark\":\"" + dt.Rows[i]["AuditMark"] + "\",";//

                    name += "\"AcceptUserName\":\"" + dt.Rows[i]["AcceptUserName"] + "\",";//
                    name += "\"AfficheTitle\":\"" + dt.Rows[i]["AfficheTitle"] + "\",";//
                    name += "\"SendDate\":\"" + dt.Rows[i]["SendDate"] + "\"},";//
                }
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion

        #region 手机端--已发教研
        public void AfficheResearchSend(HttpContext context)
        {
            int recordCount = -1;
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            AfficheEntity model = new AfficheEntity();

            int sdid = 0;
            DataTable rt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.通知公告);
            foreach (DataRow dr in rt.Rows)
            {
                string bb = dr["DataName"].ToString();
                if (dr["DataName"].ToString() == "教研活动")
                {
                    sdid = Convert.ToInt32(dr["SDID"].ToString());
                }
            }
            //model.AType = 2088;//教研通知
            model.AType = sdid;//教研通知

            string name = "";
            DataTable dt = afficheDAL.GetAfficheSendAPP(pagesize, pageindex, ref recordCount, model, userid);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"AID\":\"" + dt.Rows[i]["AID"] + "\",";//
                    name += "\"SenduserName\":\"" + dt.Rows[i]["SenduserName"] + "\",";//
                    name += "\"ATypeName\":\"" + dt.Rows[i]["ATypeName"] + "\",";//
                    name += "\"AcceptUser\":\"" + dt.Rows[i]["AcceptUser"] + "\",";//
                    name += "\"ReadOrNot\":\"" + dt.Rows[i]["ReadOrNot"] + "\",";//
                    name += "\"AcceptUserName\":\"" + dt.Rows[i]["AcceptUserName"] + "\",";//
                    name += "\"AfficheTitle\":\"" + dt.Rows[i]["AfficheTitle"] + "\",";//
                    name += "\"SendDate\":\"" + dt.Rows[i]["SendDate"] + "\"},";//
                }
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result:\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
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