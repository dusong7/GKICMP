
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace GKICMP.ashx
{
    /// <summary>
    /// BigData 的摘要说明
    /// </summary>
    public class BigData : IHttpHandler
    {
        public BigDataDAL bigDataDAL = new BigDataDAL();
        public AbsentDAL absentDAL = new AbsentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public TeacherEducationDAL teacherEducationDAL = new TeacherEducationDAL();
        public StudentDAL studentDAL = new StudentDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public StuLeaveDAL stuLeaveDAL = new StuLeaveDAL();
        public LeaveDAL leaveDAL = new LeaveDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        public AfficheDAL afficheDAL = new AfficheDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "zy":
                    GetzZiYuanList(context);
                    break;
                case "jky":
                    GetJiaoKeYanList(context);
                    break;
                case "gzl":
                    GetGongZuoLiangList(context);
                    break;
                case "GetTeacherAndStudent":
                    GetTeacherAndStudent(context);
                    break;
                case "jw":
                    GetJiaoWuList(context);
                    break;
            }
        }
        private void GetzZiYuanList(HttpContext context)
        {
            //DataTable dt = new ClassRoomDAL().GetTable((int)CommonEnum.IsorNot.否, 0);
            StringBuilder sb = new StringBuilder("");
            string name = "";
            string begin1 = "";
            string end1 = "";
            if (string.IsNullOrEmpty(context.Request.Params["begin"]))
                begin1 = DateTime.Now.Year + "-01-01 00:00:01";
            else
                begin1 = context.Request.Params["begin"];
            if (string.IsNullOrEmpty(context.Request.Params["end"]))
                end1 = DateTime.Now.Year + "-12-31 23:59:59";
            else
                end1 = context.Request.Params["end"];
            try
            {
                DateTime begin = Convert.ToDateTime(begin1);
                DateTime end = Convert.ToDateTime(end1);
                DataTable dt = bigDataDAL.GetzZiYuanList(begin, end);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"RCount\":\"" + dt.Rows[i]["RCount"].ToString() +
                             "\",\"UserName\":\"" + dt.Rows[i]["UserName"].ToString() +
                           "\",\"RKJ\":\"" + dt.Rows[i]["RKJ"].ToString() +
                            "\",\"RJA\":\"" + dt.Rows[i]["RJA"].ToString() +
                             "\",\"RSJ\":\"" + dt.Rows[i]["RSJ"].ToString() +
                              "\",\"RSC\":\"" + dt.Rows[i]["RSC"].ToString() +
                               "\",\"RWKC\":\"" + dt.Rows[i]["RWKC"].ToString() +
                                "\",\"RQT\":\"" + dt.Rows[i]["RQT"].ToString()
                           + "\"},";
                    }
                }
                //else
                //{
                //    name = "[]";
                //}
                sb.Append("{\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        private void GetJiaoKeYanList(HttpContext context)
        {
            //DataTable dt = new ClassRoomDAL().GetTable((int)CommonEnum.IsorNot.否, 0);
            StringBuilder sb = new StringBuilder("");
            string name = "";
            string begin1 = "";
            string end1 = "";
            if (string.IsNullOrEmpty(context.Request.Params["begin"]))
                begin1 = DateTime.Now.Year + "-01-01 00:00:01";
            else
                begin1 = context.Request.Params["begin"];
            if (string.IsNullOrEmpty(context.Request.Params["end"]))
                end1 = DateTime.Now.Year + "-12-31 23:59:59";
            else
                end1 = context.Request.Params["end"];
            try
            {
                DateTime begin = Convert.ToDateTime(begin1);
                DateTime end = Convert.ToDateTime(end1);
                DataTable dt = bigDataDAL.GetJiaoKeYanList(begin, end);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"sl\":\"" + dt.Rows[i]["sl"].ToString() +
                                "\",\"lx\":\"" + dt.Rows[i]["lx"].ToString() +
                                "\",\"lxmc\":\"" + dt.Rows[i]["lxmc"].ToString() +
                                "\",\"fl\":\"" + dt.Rows[i]["fl"].ToString() + "\"},";
                    }
                }
                //else
                //{
                //    name = "[]";
                //}
                sb.Append("{\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        private void GetGongZuoLiangList(HttpContext context)
        {
            //DataTable dt = new ClassRoomDAL().GetTable((int)CommonEnum.IsorNot.否, 0);
            StringBuilder sb = new StringBuilder("");
            string name = "";
            string begin1 = "";
            string end1 = "";
            if (string.IsNullOrEmpty(context.Request.Params["begin"]))
                begin1 = DateTime.Now.Year + "-01-01 00:00:01";
            else
                begin1 = context.Request.Params["begin"];
            if (string.IsNullOrEmpty(context.Request.Params["end"]))
                end1 = DateTime.Now.Year + "-12-31 23:59:59";
            else
                end1 = context.Request.Params["end"];
            try
            {
                int recordCount = 0;
                AbsentEntity model = new AbsentEntity();
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.SubState = (int)CommonEnum.PraState.通过;
                model.SubUserName = "";
                DateTime begin = Convert.ToDateTime(begin1);
                DateTime end = Convert.ToDateTime(end1);
                DataTable dt = absentDAL.GetAcount(1, 999, ref recordCount, model, begin, end);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"SubUserName\":\"" + dt.Rows[i]["SubUserName"].ToString() +
                           "\",\"Allowance\":\"" + dt.Rows[i]["Allowance"].ToString() +
                            "\",\"Plus\":\"" + dt.Rows[i]["Plus"].ToString() +
                             "\",\"ACount\":\"" + dt.Rows[i]["ACount"].ToString() +
                              "\",\"DepName\":\"" + dt.Rows[i]["DepName"].ToString() +
                           "\"},";
                    }
                }

                sb.Append("{\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }
            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        private void GetJiaoWuList(HttpContext context)
        {
            //DataTable dt = new ClassRoomDAL().GetTable((int)CommonEnum.IsorNot.否, 0);
            StringBuilder sb = new StringBuilder("");
            string name = "";
            string begin1 = "";
            string end1 = "";
            if (string.IsNullOrEmpty(context.Request.Params["begin"]))
                begin1 = DateTime.Now.Year + "-01-01 00:00:01";
            else
                begin1 = context.Request.Params["begin"];
            if (string.IsNullOrEmpty(context.Request.Params["end"]))
                end1 = DateTime.Now.Year + "-12-31 23:59:59";
            else
                end1 = context.Request.Params["end"];
            try
            {
                DateTime begin = Convert.ToDateTime(begin1);
                DateTime end = Convert.ToDateTime(end1);
                DataTable dt = bigDataDAL.GetJiaoWuList(begin, end);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"louyu\":\"" + dt.Rows[i]["louyu"].ToString() +
                           "\",\"jiaoshi\":\"" + dt.Rows[i]["jiaoshi"].ToString() +
                            "\",\"dgnjiaoshi\":\"" + dt.Rows[i]["dgnjiaoshi"].ToString() +
                             "\",\"zichan\":\"" + dt.Rows[i]["zichan"].ToString() +
                              "\",\"jine\":\"" + dt.Rows[i]["jine"].ToString() +
                              "\",\"baofei\":\"" + dt.Rows[i]["baofei"].ToString() +
                           "\"},";
                    }
                }

                sb.Append("{\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }
            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }


        #region 获取教师学生和教室信息
        private void GetTeacherAndStudent(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                string selecttype = context.Request.Params["type"];
                DataTable teacherdt = teacherDAL.GetTStatistics(1);
                DataTable studentdt = studentDAL.GetList();
                //DataTable teachereducationdt = teacherEducationDAL.GetList();
                DataTable gradedt = gradeDAL.GetListAll(0);

                //按教师学历统计        
                JArray teacherByEducationArray = new JArray();
                teacherByEducationArray.Add("研究生");
                teacherByEducationArray.Add("本科");
                teacherByEducationArray.Add("大专");
                teacherByEducationArray.Add("中师");

                JArray teacherByEducationDataArray = new JArray();
                teacherByEducationDataArray.Add(teacherdt.Rows[0]["YJS"].ToString());
                teacherByEducationDataArray.Add(teacherdt.Rows[0]["BK"].ToString());
                teacherByEducationDataArray.Add(teacherdt.Rows[0]["DZ"].ToString());
                teacherByEducationDataArray.Add(teacherdt.Rows[0]["ZS"].ToString());

                //按教师转技统计
                JArray teacherByCurrentProfessionalArray = new JArray();
                teacherByCurrentProfessionalArray.Add(teacherdt.Rows[0]["ZGJ"].ToString());
                teacherByCurrentProfessionalArray.Add(teacherdt.Rows[0]["GJ"].ToString());
                teacherByCurrentProfessionalArray.Add(teacherdt.Rows[0]["YJ"].ToString());
                teacherByCurrentProfessionalArray.Add(teacherdt.Rows[0]["EJ"].ToString());
                teacherByCurrentProfessionalArray.Add(teacherdt.Rows[0]["SJ"].ToString());
                teacherByCurrentProfessionalArray.Add(teacherdt.Rows[0]["WD"].ToString());




                //按教师转技统计
                //foreach (GK.GKICMP.Common.CommonEnum.CurrentProfessional item in Enum.GetValues(typeof(GK.GKICMP.Common.CommonEnum.CurrentProfessional)))
                //{
                //    JObject JObject = new JObject();
                //    JObject.Add(item.ToString().Replace("教师", ""), teacherdt.Select("CurrentProfessional=" + (int)item).Count());
                //    teacherByCurrentProfessionalArray.Add(JObject);
                //}

                //按教师学历统计                
                //JArray teacherByEducationArray = new JArray();
                //JObject tracherXL1 = new JObject();
                //tracherXL1.Add("研究生人数", teachereducationst.Select("Education=11 or Education=14").Count());
                //teacherByEducationArray.Add(tracherXL1);

                //JObject tracherXL2 = new JObject();
                //tracherXL2.Add("本科人数", teachereducationst.Select("Education=21").Count());
                //teacherByEducationArray.Add(tracherXL2);

                //JObject tracherXL3 = new JObject();
                //tracherXL3.Add("大专人数", teachereducationst.Select("Education=31").Count());
                //teacherByEducationArray.Add(tracherXL3);

                //JObject tracherXL4 = new JObject();
                //tracherXL4.Add("中师人数", teachereducationst.Select("Education=41").Count());
                //teacherByEducationArray.Add(tracherXL4);

                //按学生年级性别统计
                JArray boyArray = new JArray();
                JArray girlArray = new JArray();
                JArray gradeArray = new JArray();
                for (int i = 0; i < gradedt.Rows.Count; i++)
                {
                    boyArray.Add(studentdt.Select("GID=" + Convert.ToInt32(gradedt.Rows[i]["GID"]) + " and UserSex=" + (int)GK.GKICMP.Common.CommonEnum.XB.男).Count());
                    girlArray.Add(studentdt.Select("GID=" + Convert.ToInt32(gradedt.Rows[i]["GID"]) + " and UserSex=" + (int)GK.GKICMP.Common.CommonEnum.XB.女).Count());
                    gradeArray.Add(gradedt.Rows[i]["ShortGName"]);
                }

                //班级数
                DepartmentEntity departmentmodel = new DepartmentEntity();
                departmentmodel.DepName = "";
                departmentmodel.Isdel = (int)CommonEnum.Deleted.未删除;
                departmentmodel.DepType = (int)CommonEnum.DepType.普通班级;
                int recordCount = -1;
                DataTable departmentdt = departmentDAL.GetPaged(9999, 1, ref recordCount, departmentmodel);

                //教师请假数
                int teacherleavecout = leaveDAL.GetCount(DateTime.Now);

                //学生请假数
                int stuleavecount = stuLeaveDAL.GetCount(DateTime.Now);

                JArray teacherleavestateArray = new JArray();
                DataTable teacherleavetypedt = baseDataDAL.GetList((int)CommonEnum.BaseDataType.请假类型, -1);
                foreach (DataRow teacherleavetype in teacherleavetypedt.Rows)
                {
                    teacherleavestateArray.Add(teacherleavetype["DataName"].ToString());
                }


                //教师请假折线图
                JArray teacherleavearray = new JArray();
                JArray XData = new JArray();
                if (selecttype == "year")
                {
                    int Month = DateTime.Now.Month;
                    for (int i = 1; i <= Month; i++)
                    {
                        XData.Add(i + "月");
                    }
                    for (int j = 0; j < teacherleavetypedt.Rows.Count; j++)
                    {
                        JArray temp = new JArray();
                        for (int i = 1; i <= Month; i++)
                        {
                            DateTime BeginDate = DateTime.Now.AddMonths(Month * -1 + i).Date.AddDays(DateTime.Now.AddMonths(Month * -1 + i).Day * -1 + 1);
                            temp.Add(leaveDAL.GetCountByLType(BeginDate, BeginDate.AddMonths(1), Convert.ToInt32(teacherleavetypedt.Rows[j]["SDID"])));
                        }
                        teacherleavearray.Add(temp);
                    }

                }
                if (selecttype == "quarter")
                {
                    int Month = DateTime.Now.Month;
                    int BeginMonth = Convert.ToInt32(Month / 3) * 3 == Month ? Month - 2 : Convert.ToInt32(Month / 3) * 3 + 1;
                    int EndMonth = BeginMonth + 2;
                    for (int i = BeginMonth; i <= EndMonth; i++)
                    {
                        XData.Add(i + "月");
                    }
                    for (int j = 0; j < teacherleavetypedt.Rows.Count; j++)
                    {
                        JArray temp = new JArray();
                        for (int i = BeginMonth; i <= EndMonth; i++)
                        {
                            DateTime BeginDate = DateTime.Now.AddMonths(Month * -1 + i).Date.AddDays(DateTime.Now.AddMonths(Month * -1 + i).Day * -1 + 1);
                            temp.Add(leaveDAL.GetCountByLType(BeginDate, BeginDate.AddMonths(1), Convert.ToInt32(teacherleavetypedt.Rows[j]["SDID"])));
                        }
                        teacherleavearray.Add(temp);
                    }
                }
                if (selecttype == "month")
                {
                    //这个按天统计
                    for (int i = 1; i <= DateTime.Now.Day; i++)
                    {
                        XData.Add(i + "日");
                    }
                    for (int j = 0; j < teacherleavetypedt.Rows.Count; j++)
                    {
                        JArray temp = new JArray();
                        for (int i = 1; i <= DateTime.Now.Day; i++)
                        {
                            DateTime BeginDate = DateTime.Now.AddDays(DateTime.Now.Day * -1 + i);
                            temp.Add(leaveDAL.GetCountByLType(BeginDate, BeginDate.AddDays(1), Convert.ToInt32(teacherleavetypedt.Rows[j]["SDID"])));
                        }
                        teacherleavearray.Add(temp);
                    }
                }
                //OA
                //电子政务
                //全体公告
                //班级公告
                //通知


                recordCount = -1;
                //EgovernmentEntity model = new EgovernmentEntity();
                //model.Etitle = "";
                //model.Begin = Convert.ToDateTime(ViewState["Begin"]);
                //model.End = Convert.ToDateTime(ViewState["End"]);
                //model.CreateUser = UserID;
                ////DataTable dt = egovernment_FlowDAL.GetSendPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
                //DataTable dt = egovernment_FlowDAL.GetALLPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);

                DateTime Begin = DateTime.Now;
                DateTime End = DateTime.Now;
                if (selecttype == "year")
                {
                    Begin = Begin.Date.AddDays(Begin.DayOfYear * -1 + 1);
                    End = Begin.AddYears(1);
                }
                if (selecttype == "quarter")
                {
                    int Month = DateTime.Now.Month;
                    int BeginMonth = Convert.ToInt32(Month / 3) * 3 == Month ? Month - 2 : Convert.ToInt32(Month / 3) * 3 + 1;
                    Begin = Begin.Date.AddDays(Begin.DayOfYear * -1 + 1).AddMonths(BeginMonth - 1);
                    End = Begin.AddMonths(3);
                }
                if (selecttype == "month")
                {
                    Begin = Begin.Date.AddDays(Begin.Day * -1 + 1);
                    End = Begin.AddMonths(1);
                }

                //电子政务
                EgovernmentEntity model = new EgovernmentEntity();
                model.Etitle = "";
                model.Begin = Begin;
                model.End = End;
                model.CreateUser = "";
                //DataTable dt = egovernment_FlowDAL.GetSendPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
                DataTable dt = egovernment_FlowDAL.GetALLPaged(9999, 1, ref recordCount, model);
                int egovermentcount = dt.Rows.Count;
                int completedegovermentcount = dt.Select("Completed=1").Count();
                int readegovermentcount = dt.Select("ReadOrNot=1").Count();


                DataTable affichetypedt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.通知公告);

                //全体公告
                int afficheallcount = afficheDAL.GetCount(Begin, End, Convert.ToInt32(affichetypedt.Select("DataName='全体公告'").FirstOrDefault()["SDID"]));
                //班级公告
                int afficheclasscount = 0;
                //int afficheclasscount = afficheDAL.GetCount(Begin, End, Convert.ToInt32(affichetypedt.Select("DataName='班级公告'").FirstOrDefault()["SDID"]));
                //通知
                int affichealertcount = afficheDAL.GetCount(Begin, End, Convert.ToInt32(affichetypedt.Select("DataName='通知'").FirstOrDefault()["SDID"]));
                //JObject list = new JObject();
                JArray list =new  JArray();
                foreach (DataRow dr in affichetypedt.Rows)
                {
                    JArray temp = new JArray();
                    temp.Add(dr["DataName"]);
                        temp.Add(afficheDAL.GetCount(Begin, End, Convert.ToInt32(dr["SDID"])));

                        list.Add(temp);
                    //var DataName = dr["DataName"];
                    //var Count = afficheDAL.GetCount(Begin, End, Convert.ToInt32(dr["SDID"]));
                    //list.Add(new { DataName = DataName, Count = Count });
                }


                JObject ReturnJarray = new JObject();
                ReturnJarray.Add("ClassCount", departmentdt.Rows.Count);
                ReturnJarray.Add("StudentCount", studentdt.Rows.Count);
                ReturnJarray.Add("TeacherCount", Convert.ToInt32(teacherdt.Rows[0]["SYZB"]) + Convert.ToInt32(teacherdt.Rows[0]["QP"]));
                ReturnJarray.Add("StudentLeaveCount", stuleavecount);
                ReturnJarray.Add("TeacherLeaveCount", teacherleavecout);

                //ReturnJarray.Add("TeacherDetail", "");
                ReturnJarray.Add("TeacherByEducationArray", teacherByEducationArray);
                ReturnJarray.Add("TeacherByEducationDataArray", teacherByEducationDataArray);
                ReturnJarray.Add("TeacherByCurrentProfessionalArray", teacherByCurrentProfessionalArray);

                ReturnJarray.Add("StudentBoyDetail", boyArray);
                ReturnJarray.Add("StudentGirlDetail", girlArray);
                ReturnJarray.Add("GradeArray", gradeArray);

                ReturnJarray.Add("TeacherLeaveDetail", teacherleavearray);
                ReturnJarray.Add("TeacherLeaveStateArray", teacherleavestateArray);
                ReturnJarray.Add("TeacherLeaveXDetail", XData);

                ReturnJarray.Add("EGovermentCount", egovermentcount);
                ReturnJarray.Add("CompletedEGovermentCount", completedegovermentcount);
                ReturnJarray.Add("ReadEGovermentCount", readegovermentcount);
                ReturnJarray.Add("AfficheAllCount", afficheallcount);
                ReturnJarray.Add("AfficheClassCount", afficheclasscount);
                ReturnJarray.Add("AfficheAlertCount", affichealertcount);
                ReturnJarray.Add("Affiche",(JToken)list);
                //ReturnJarray.Add();

                sb.Append(ReturnJarray);
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.ApplicationInstance.CompleteRequest();
            return;
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