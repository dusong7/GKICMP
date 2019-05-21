/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月8日 18时04分
** 描 述:       年级课程设置管理
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Web;
using PaikeTest.Utils;
using PaikeTest.Model;
using System.Collections.Generic;
using System.Threading;

namespace GKICMP.educationals
{
    public partial class NJTeacherManage : PageBase
    {
        public TeacherPlaneDAL teacherPlanDAL = new TeacherPlaneDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public ScheduleSetDAL scheduleSetDAL = new ScheduleSetDAL();
        public TeacherPlane_InfoDAL teacherPlaneInfoDAL = new TeacherPlane_InfoDAL();
        public ScheduleCourseDAL scheduleCourseDAL = new ScheduleCourseDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public static string message = "";


        #region 参数集合
        public int GID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_GID.Value = GID.ToString();
                GradeEntity model = gradeDAL.GetObjByID(GID);
                if (model != null)
                {
                    this.lbl_GIDName.Text = model.ShortGName;
                }
                DataBindList();
                if (Session["IsPK"] != null)
                {
                    ShowMessage(Session["IsPK"].ToString());
                    if (Session["IsPK"].ToString() != "正在排课……")
                    {
                        HttpContext.Current.Session.Remove("IsPK");

                    }
                    else
                    {
                        this.btn_SCAll.Visible = false;
                    }

                }
            }
        }
        #endregion

        #region 数据绑定
        public void DataBindList()
        {
            int totalcount = 0;
            DataTable dt = teacherPlanDAL.GetNJPaged(GID, ref totalcount);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            this.ltl_TotelHour.Text = totalcount.ToString();
            this.rp_List.DataBind();
        }
        #endregion



        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = teacherPlanDAL.NJDeleteByID(ids, GID);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除课程信息", UserID));
                    ShowMessage("删除成功");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 全部排课
        protected void btn_ScheduleCourseAll_Click(object sender, EventArgs e)
        {
            try
            {
                string EYear;
                int term;
                GetTerm(out EYear, out term);
                if (GetName() != "")
                {
                    ShowMessage(GetName().TrimEnd(',') + "没有选择对应的老师，请先设置老师再排课");
                    return;
                }
                PK(EYear, term);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "全部排课", UserID));
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 获取当前学期
        private static void GetTerm(out string EYear, out int term)
        {
            EYear = "";
            term = 0;
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            if (month < 8 && month >= 2)
            {
                EYear = (year - 1) + "-" + year;
                term = (int)CommonEnum.XQ.下学期;
            }
            else
            {
                if (month <= 12 && month >= 8)
                {
                    EYear = year + "-" + (year + 1);
                }
                else
                {
                    EYear = (year - 1) + "-" + year;
                }
                term = (int)CommonEnum.XQ.上学期;
            }
        }
        #endregion


        #region 判断所排课程是否没有老师
        public string GetName()
        {
            string aa = "";
            DataTable dt = teacherPlanDAL.GetDatatable();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    aa += row[0].ToString() + row[1].ToString().Replace("\r\n","") + ",";
                }
            }
            return aa;
        }
        #endregion


        #region 排课
        public void PK(string EYear, int term)
        {
            BaseUtils test = new BaseUtils();

            BaseInfo bi = new BaseInfo();
            ScheduleSetEntity model = scheduleSetDAL.GetObjByID();
            if (model != null)
            {
                bi.TotalClass = model.MorningPitch + model.AfterPitch + model.EveningPitch;
                bi.TotalDays = model.CourseDay;
            }

            List<TimeBase> tblist = TestTimeBase();
            bi.TimeBaseList = tblist;

            List<TimeSlice> tslist = TestTimeSlice();
            bi.TSList = tslist;


            List<CommonSubject> cslist = TestCommonSubject();
            DateTime now = DateTime.Now;
            List<NowClass> nclist = new List<NowClass>();
            Thread t = new Thread(
                                    delegate()
                                    {
                                        nclist = PKHandle(bi, cslist);
                                        //PKDelegate dele = new PKDelegate(PKHandle);
                                        //IAsyncResult refdata = dele.BeginInvoke(bi, cslist, null, null);
                                    });
            t.Start();

            Session["IsPK"] = "正在排课……";
            //SetCookie("IsPK", "正在排课……");
            this.btn_SCAll.Visible = false;
            Thread ts = new Thread(
                                    delegate()
                                    {
                                        while ((DateTime.Now - now).TotalMilliseconds < 60000 && !isfinish)
                                        {
                                            //未执行完成
                                        }
                                        if (isfinish)
                                        {
                                            //List<NowClass> nclist = dele.EndInvoke(refdata);
                                            //HttpCookie cookie = new HttpCookie("IsPK", "排课成功");
                                            //Response.Cookies.Add(cookie);
                                            Session["IsPK"] = "排课成功";

                                            if (message == "排课成功" || message == "排课成功，存在不完全满足排课设置的课程")
                                            {
                                                scheduleCourseDAL.Tb_ScheduleCourseDelete(EYear, term);

                                                foreach (NowClass nc in nclist)
                                                {
                                                    ScheduleCourseEntity model1 = new ScheduleCourseEntity();
                                                    for (int i = 0; i < nc.Class.GetLength(0); i++)
                                                    {
                                                        for (int j = 0; j < nc.Class.GetLength(1); j++)
                                                        {
                                                            if (nc.Class[i, j] != null && nc.Class[i, j].ID != 0)
                                                            {
                                                                model1.SCID = "";
                                                                model1.ClaID = nc.CSID;
                                                                model1.CID = nc.Class[i, j].ID;
                                                                model1.TID = nc.Class[i, j].TeacherIDList[0];
                                                                if (nc.Class[i, j].RoomList == null)
                                                                {
                                                                    model1.CRID = -2;
                                                                }
                                                                else
                                                                {
                                                                    model1.CRID = nc.Class[i, j].RoomList[0];
                                                                }
                                                                model1.Position = Convert.ToInt32((i + "0" + j));
                                                                model1.ShouKeZhou = "";
                                                                model1.CourseID = 0;
                                                                model1.Isdel = 0;
                                                                model1.Term = term;
                                                                model1.EYear = EYear;
                                                                scheduleCourseDAL.Edit(model1);
                                                            }
                                                        }
                                                    }
                                                }
                                                Session["IsPK"] = message;
                                            }
                                            else
                                            {
                                                Session["IsPK"] = message;
                                            }
                                            //ShowMessage("排课成功");
                                        }
                                        else
                                        {
                                            t.Abort();
                                            Session["IsPK"] = "排课失败";
                                            //HttpCookie cookie = new HttpCookie("IsPK", "排课失败");
                                            //Response.Cookies.Add(cookie);
                                        }
                                    });
            ts.Start();

        }
        #endregion


        #region 获取课表时间段
        public List<TimeBase> TestTimeBase()
        {
            List<TimeBase> tblist = new List<TimeBase>();
            ScheduleSetEntity model = scheduleSetDAL.GetObjByID();
            if (model != null)
            {
                TimeBase tb = new TimeBase();
                if (model.MorningPitch > 0)
                {
                    tb.TimeSection = TimeSectionEnum.上午;
                    tb.Count = model.MorningPitch;
                    tblist.Add(tb);
                }

                if (model.AfterPitch > 0)
                {
                    tb = new TimeBase();
                    tb.TimeSection = TimeSectionEnum.下午;
                    tb.Count = model.AfterPitch;
                    tblist.Add(tb);
                }

                if (model.EveningPitch > 0)
                {
                    tb = new TimeBase();
                    tb.TimeSection = TimeSectionEnum.晚自习;
                    tb.Count = model.EveningPitch;
                    tblist.Add(tb);
                }

            }
            return tblist;
        }
        #endregion


        #region 获取节课时间段
        public List<TimeSlice> TestTimeSlice()
        {
            List<TimeSlice> tslist = new List<TimeSlice>();
            ScheduleSetEntity model = scheduleSetDAL.GetObjByID();
            if (model != null)
            {
                for (int i = 1; i <= model.CourseDay; i++)
                {
                    for (int j = 1; j <= model.MorningPitch + model.AfterPitch + model.EveningPitch; j++)
                    {
                        TimeSlice ts = new TimeSlice();
                        ts.Day = i;
                        ts.Number = j;
                        if (!Istrue(i.ToString() + "0" + j.ToString()))
                        {
                            if (j <= model.MorningPitch)
                            {
                                ts.TimeSelect = TimeSectionEnum.上午;
                            }
                            else if (j <= model.MorningPitch + model.AfterPitch)
                            {
                                ts.TimeSelect = TimeSectionEnum.下午;
                            }
                            else
                            {
                                ts.TimeSelect = TimeSectionEnum.晚自习;
                            }
                            tslist.Add(ts);
                        }
                    }
                }
            }
            return tslist;
        }
        #endregion


        #region 获取所有班级的ID
        public List<CommonSubject> TestCommonSubject()
        {
            List<CommonSubject> cslist = new List<CommonSubject>();

            CommonSubject cs = new CommonSubject();
            DataTable dt = teacherPlanDAL.GetAllPlanClaIDByWhere();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cs = new CommonSubject();
                    cs.ID = Convert.ToInt32(dt.Rows[i][0].ToString());
                    cs.Name = dt.Rows[i][1].ToString();
                    List<Class> classlist = TestClass(cs.ID);
                    cs.ClassList = classlist;
                    cslist.Add(cs);
                }
            }
            return cslist;
        }
        #endregion


        #region 判断是否存在
        public bool Istrue(string position)
        {
            bool b1 = true;
            bool b2 = true;
            ScheduleSetEntity model = scheduleSetDAL.GetObjByID();
            if (model != null)
            {
                if (model.NoTimetable != null)
                {
                    string[] arr = model.NoTimetable.Split('|');
                    for (int k = 0; k < arr.Length; k++)
                    {
                        if (arr[k].Contains(position))
                        {
                            b1 = false;
                            b2 = false;
                        }
                        else
                        {
                            b1 = true;
                        }
                    }
                }
                else
                {
                    b2 = true;
                }
            }
            if (b2 == false)
            {
                b1 = true;
            }
            else
            {
                b1 = false;
            }
            return b1;
        }
        #endregion


        #region 获取班级中的排课计划
        public List<Class> TestClass(int id)
        {
            List<Class> classlist = new List<Class>();

            Class _class = new Class();

            DataTable dt = teacherPlanDAL.GetClByClaID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _class = new Class();
                    _class.ID = Convert.ToInt32(dt.Rows[i]["CourseID"].ToString());
                    _class.Name = dt.Rows[i]["CourseIDName"].ToString();
                    _class.Count = Convert.ToInt32(dt.Rows[i]["JieShu"].ToString());
                    _class.TeacherIDList = new List<string>() { dt.Rows[i]["TeacherID"].ToString() };
                    if (Convert.ToInt32(dt.Rows[i]["CRID"]) != -2)
                    {
                        _class.RoomList = new List<int>() { Convert.ToInt32(dt.Rows[i]["CRID"]) };
                    }

                    int isnear = Convert.ToInt32(dt.Rows[i]["LianCi"].ToString());

                    if (isnear > 0)
                    {
                        _class.IsNear = true;
                        _class.NearCount = isnear;
                    }

                    List<TimeSlice> tslist = new List<TimeSlice>();
                    DataTable dt1 = teacherPlaneInfoDAL.Get(dt.Rows[i]["TPID"].ToString());
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt1.Rows)
                        {
                            //tslist.Add(new TimeSlice
                            //{
                            //    Day = Convert.ToInt32(row[4].ToString().Substring(0, 1)),
                            //    Number = Convert.ToInt32(row[4].ToString().Substring(2, row[4].ToString().Length - 2)),
                            //    TimeSelect = TimeSectionEnum.上午,
                            //    TimeType = (TimeTypeEnum)Convert.ToInt32((row[5].ToString()))
                            //});
                            tslist.AddRange(this.TestClassTimeSlice(Convert.ToInt32(row[4].ToString().Substring(0, 1)), new int[] { Convert.ToInt32(row[4].ToString().Substring(2, row[4].ToString().Length - 2)) }, TimeSectionEnum.上午, (TimeTypeEnum)Convert.ToInt32((row[5].ToString()))));
                        }
                    }
                    _class.TSList = tslist;
                    classlist.Add(_class);
                }

            }
            return classlist;
        }
        #endregion


        #region 获取排课计划的节数的安排情况
        public List<TimeSlice> TestClassTimeSlice(int day, int[] numberlist, TimeSectionEnum tse, TimeTypeEnum tte)
        {
            List<TimeSlice> tslist = new List<TimeSlice>();

            foreach (int number in numberlist)
            {
                TimeSlice ts = new TimeSlice();
                ts.Day = day;
                ts.Number = number;
                ts.TimeSelect = tse;
                ts.TimeType = tte;
                tslist.Add(ts);
            }
            return tslist;
        }
        #endregion


        public List<NowClass> PKHandle(BaseInfo bi, List<CommonSubject> cslist)
        {
            BaseUtils test = new BaseUtils();
            List<NowClass> nclist = new List<NowClass>();
            //Thread.Sleep(10000);
            try
            {
                nclist = test.main(bi, cslist, out message);
                isfinish = true;
            }
            catch
            {

            }

            return nclist;
        }
        public bool isfinish = false;
    }
}