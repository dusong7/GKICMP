/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月8日 18时04分
** 描 述:       调课显示管理
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
using System.Web.UI.WebControls;

namespace GKICMP.educational
{
    public partial class SubstituteSet : PageBase
    {
        public GradeDAL gradeDAL = new GradeDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SubstituteDAL subDAL = new SubstituteDAL();
        /// <summary>
        /// SCID 课程表ID
        /// </summary>
        public string SCID
        {
            get
            {
                return GetQueryString<string>("scid", "");
            }
        }
        public int JC
        {
            get
            {
                return GetQueryString<int>("jc", -1);
            }
        }
        public string Time
        {
            get
            {
                return GetQueryString<string>("date", "");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Time"] = this.txt_TKDate.Text =Time;
                this.hf_scid.Value = SCID.ToString();
                this.hf_UserID.Value = UserID.ToString();
                LoadClassSchedule();
            }
        }

        #region 班级排课信息加载
        /// <summary>
        /// 班级排课信息加载
        /// </summary>
        public void LoadClassSchedule()
        {
           // this.tab = null;
            string tt = ViewState["Time"].ToString();
            DateTime startweek = Convert.ToDateTime(tt).AddDays(1 - Convert.ToInt32(Convert.ToDateTime(tt).DayOfWeek.ToString("d")));  //本周周一
            int WeekDays = 0;
            int SWnum = 0;
            int XWnum = 0;
            int WSnum = 0;
            ScheduleSetEntity smodel = setDAL.GetObjByID();//获取基础设置信息
            if (smodel != null)
            {
                WeekDays = smodel.CourseDay;
                SWnum = smodel.MorningPitch;
                XWnum = smodel.AfterPitch;
                WSnum = smodel.EveningPitch;
            }
            string[] arryStr = new string[] { "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };

            this.tab1.Height = ((4 + 4 + 2) * 35 + 40);
            this.tab1.Width = (6 * 100 + 20);

            for (int a = 0; a <= (SWnum + XWnum + WSnum); a++)
            {
                TableRow myRow = new TableRow();
                if (a == 0)
                {
                    for (int b = 0; b < WeekDays + 1; b++)
                    {
                        TableCell myCell = new TableCell();
                        if (b == 0)
                        {
                            myCell.Text = "";
                        }
                        else
                        {
                            myCell.Text = arryStr[b - 1] + "<br/>" + startweek.AddDays(b - 1).ToString("MM月dd日");
                        }
                        myRow.Cells.Add(myCell);
                    }
                }
                else
                {
                    for (int c = 0; c < WeekDays + 1; c++)
                    {
                        TableCell myCell = new TableCell();
                        if (c == 0)
                        {
                            myCell.Text = "第" + a + "节课";
                        }
                        else
                        {
                            //根据课程表ID从课程表中获取选取的课程信息
                            string sql0 = " and SCID='" + SCID + "'";
                            DataTable dt0 = scourseDAL.GetAllScheduleCourseByWhere(sql0);
                            //如果是被选中的课程，标记为红色
                            if (LoadClassScheduleData(a, c).Contains(dt0.Rows[0][8].ToString()))
                            {
                                myCell.Text = "<label style='color:red; '>" + LoadClassScheduleData(a, c).Replace("连续", "") + "</label>";
                                this.hf_cname.Value = dt0.Rows[0][8].ToString();
                            }
                            else
                            {
                                myCell.Text = LoadClassScheduleData(a, c).Replace("连续", "");
                            }
                           // myCell.Attributes.Add("onmouseover", "this.style.background='#C4C6C8'");
                           // myCell.Attributes.Add("onmouseout", "this.style.background=''");
                          //  myCell.Attributes.Add("id",a+"0"+c);
                            myCell.Attributes.Add("onclick", "CellText1(this.innerHTML);");
                        }
                        myRow.Cells.Add(myCell);
                    }
                }
                tab1.Rows.Add(myRow);
            }
        }
        #endregion



        #region 班级排课数据加载
        /// <summary>
        /// 班级排课数据加载
        /// </summary>
        /// <param name="a">节</param>
        /// <param name="b">星期</param>
        /// <returns></returns>
        public string LoadClassScheduleData(int a, int b)
        {
            //string CourseID = Session["CourseID"].ToString();
            string str = "";
            
            //string sql0 = "SELECT [ID],[ClassName],[SubjectName],[TeacherName],[AreaName],[Position],[ShouKeZhou],[CourseID] FROM [dbo].[tbSheepofCourse] where CourseID=" + CourseID + " and ClassName = '" + ClaID + "'";
            /*注释部分 DataTable dt = scourseDAL.GetTable(ClaID);*/
            // public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
            //根据课程表ID从课程表中获取选取的课程信息
            string sql0 = " and SCID='" + SCID + "'";
            DataTable dt0 = scourseDAL.GetAllScheduleCourseByWhere(sql0);
            //根据班级编号从班级表中获取班级名称
            DepartmentEntity model = departmentDAL.GetObj(Convert.ToInt32(dt0.Rows[0][1].ToString()));
            if (model != null)
            {
                this.ltl_NowClass.Text = model.DepName.ToString();
            }

            //根据班级编号从课程表中获取班级信息
            // string sql = " and ClaID=" + dt0.Rows[0][1].ToString();
            string strpos = "";
            string sqlpos = " and ClaID='" + dt0.Rows[0][1].ToString() + "'";
            DataTable dtpos = scourseDAL.GetAllScheduleCourseByWhere(sqlpos);
            for (int i = 0; i < dtpos.Rows.Count; i++)
            {
                strpos += dtpos.Rows[i][5].ToString() + ",";
            }

            string pos = b.ToString() + "0" + a.ToString();
            //bool isContain = strpos.Contains(pos);

            //if (!strpos.Contains(pos))
            //{
            //    string sqlnull = " and TID='" + dt0.Rows[0][3].ToString() + "' and Position=" + pos;
            //    DataTable dtnull = scourseDAL.GetAllScheduleCourseByWhere(sqlnull);
            //    if (dtnull.Rows.Count == 0)
            //    {
            //        str = "可安排" + "<label  style='display:none;'>:a:c" + pos + ":b:c</label>";
            //    }
            //    return str;
            //}

            //获取本班级的课程表，且被选中教师在本班级或其他班级没有安排课程的信息
            // string sql = " and ClaID='" + dt0.Rows[0][1].ToString() + "' and Position not in ( Select Position from dbo.Tb_ScheduleCourse where TID='" + dt0.Rows[0][3] + "')";
            //获取本班级的课程表，且被选中教师在其他班级没有安排课程信息(允许调换课表中出现教师在本班级所带课程的信息)。
            string sql = " and ClaID='" + dt0.Rows[0][1].ToString() + "'and Position <> "+JC+" and Position not in ( Select Position from dbo.Tb_ScheduleCourse where TID='" + UserID + "')";

            DataTable dt = scourseDAL.GetAllScheduleCourseByWhere(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int x = 0;
                int y = 0;

                string p = dt.Rows[i]["Position"].ToString();

                x = Convert.ToInt32(dt.Rows[i]["Position"].ToString().Substring(0, 1));
                y = Convert.ToInt32(dt.Rows[i]["Position"].ToString().Substring(1, 2));
                //获取在101位置没有安排课程的教师
                //string sqlp = " and TID='" + dt.Rows[i][3].ToString() + "' and Position=" + dt0.Rows[0][5].ToString();
                //获取在101位置没有安排课程的教师（不包括被选中教师信息）
                //string sqlp = " and TID='" + dt.Rows[i][3].ToString() + "' and Position=" + dt0.Rows[0][5].ToString() + " and ClaID!='" + dt0.Rows[0][1].ToString() + "'";
                //DataTable dtp = scourseDAL.GetAllScheduleCourseByWhere(sqlp);

                if ((a == y) && (b == x))
                {
                    DateTime jctime = Convert.ToDateTime(ViewState["Time"]).AddDays(1 - Convert.ToInt32(Convert.ToDateTime(ViewState["Time"]).DayOfWeek.ToString("d"))).AddDays(b - 1);
                    if (DateTime.Now < jctime)
                    {
                        //str = dt.Rows[i]["CourseName"].ToString();
                        //str = dt.Rows[i]["CourseName"].ToString() +"<br />" + dt.Rows[i]["TeacherName"].ToString() + "<label style='display:none;'>:a:c" + dt.Rows[i]["SCID"].ToString() + ":b:c</label>";
                        str = dt.Rows[i]["CourseRepeat"].ToString() + "<br />" + "<label style='display:none;'>:a:c" + dt.Rows[i]["SCID"].ToString() + ":b:c" +
                            jctime.ToString("yyyy-MM-dd")
                             + "xy</label>";
                        break;
                    }
                }
            }
            return str;
        }
        #endregion

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                SubstituteEntity model = new SubstituteEntity();
                string value = this.hf_TK.Value;
                model.ApplyUser = UserID;
                model.ApplyReason = this.txt_ApplyReason.Text.ToString().Trim();
                model.SubBegin = Convert.ToDateTime(Time);//调课日期
                model.SubEnd = Convert.ToDateTime(Time);//调课日期
                model.SubBegin1 = Convert.ToDateTime(value.Split(',')[1]);//所调课的日期
                model.SubEnd1 = Convert.ToDateTime(value.Split(',')[1]);//所调课的日期
                //model.SubUser = this.ddl_SubUser.SelectedValue.ToString();
                model.SubCount = 1;
                model.SubState = (int)CommonEnum.PraState.申请中;
               // model.SubCoruse = JC;
                model.SubName = JC.ToString();
                model.SubType = 1;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
               // model.SubName = value.Split(',')[0];//课表id，为了不麻烦用节次代替，
                int result = subDAL.Edit(model, value.Split(',')[0]);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加调课信息", UserID));
                    RegisterStartupScript("false", "<script>alert('提交成功');window.parent.location.href='SubstituteManage.aspx'</script>"); 
                    //ShowMessage();
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage("系统出错，请稍候再试");
                return;
            }

        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            ViewState["Time"] = this.txt_TKDate.Text == "" ? DateTime.Now.ToString("yyyy-MM-dd") : this.txt_TKDate.Text;
            LoadClassSchedule();

        }
    }
}