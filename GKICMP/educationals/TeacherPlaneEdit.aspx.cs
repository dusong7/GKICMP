/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月7日 18时04分
** 描 述:       排课计划
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;

namespace GKICMP.educationals
{
    public partial class TeacherPlaneEdit : PageBase
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public TeacherPlaneDAL planeDAL = new TeacherPlaneDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public ClassRoomDAL croomDAL = new ClassRoomDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public static string EYear;
        public static int term;

        #region 参数集合
        /// <summary>
        /// TPID 排课计划ID
        /// </summary>
        public string TPID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// DID 班级ID
        /// </summary>
        public int DID
        {
            get
            {
                return GetQueryString<int>("did", -1);
            }
        }

        /// <summary>
        /// 总节数
        /// </summary>
        public int TotelHour
        {
            get
            {
                return GetQueryString<int>("totelhour", -1);
            }
        }
        #endregion


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTerm(out EYear, out term);
                this.hf_DID.Value = DID.ToString();
                DDLBind();
                if (TPID != "")
                {
                    InfoBind();
                }
                //this.ddl_LianJie.Items.Insert(0, "0");
                this.ddl_LianCi.Items.Insert(0, "0");
            }
        }
        #endregion


        #region 设置初始值
        private void SetValue()
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#Series').combotree('setValues', [");
            sb1.Append(this.hf_TID.Value.Trim(','));
            sb1.Append("]);");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        }
        #endregion


        #region 下拉框绑定
        /// <summary>
        /// 下拉框绑定
        /// </summary>
        private void DDLBind()
        {
            DataTable dtCourse = courseDAL.GetList();
            CommonFunction.DDlTypeBind(this.ddl_CourseName, dtCourse, "CID", "CourseName", "-2");
            DataTable dtCRoom = croomDAL.Table((int)CommonEnum.IsorNot.否, (int)CommonEnum.DorState.可用);
            CommonFunction.DDlTypeBind(this.ddl_CRID, dtCRoom, "CRID", "RoomName", "-2");

            //for (int i = 2; i < 5; i++)
            //{
            //    this.ddl_LianJie.Items.Insert(i - 2, i.ToString());
            //}

            for (int i = 0; i < 4; i++)
            {
                this.ddl_LianCi.Items.Insert(i, (i + 1).ToString());
            }


            ScheduleSetEntity ssmodel = setDAL.GetObjByID();
            if (ssmodel != null)
            {
                this.hf_Week.Value = ssmodel.CourseDay.ToString();
                this.hf_MorningPitch.Value = ssmodel.MorningPitch.ToString();
                this.hf_AfterPitch.Value = ssmodel.AfterPitch.ToString();
                this.hf_EveningPitch.Value = ssmodel.EveningPitch.ToString();
                this.hf_deffordibts.Value = ssmodel.NoTimetable;
            }
        }
        #endregion



        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            TeacherPlaneEntity model = planeDAL.GetObjByID(TPID);
            if (model != null)
            {
                this.ddl_CourseName.SelectedValue = model.CourseID.ToString();
                this.hf_TID.Value = model.TeacherID;
                this.txt_Jieshu.Text = model.JieShu.ToString();
                this.ddl_CRID.SelectedValue = model.CRID.ToString();
                //this.ddl_LianJie.SelectedValue = model.LianJie.ToString();
                this.ddl_LianCi.SelectedValue = model.LianCi.ToString();
                this.hf_DID.Value = model.ClaID.ToString();
                this.hf_JieShu.Value = model.JieShu.ToString();
                ViewState["tid"] = model.TeacherID;
                ViewState["crid"] = model.CRID.ToString();
            }



            DataTable dt = new TeacherPlane_InfoDAL().Get(TPID);
            string recstr = "", forbidstr = "", necstr = "";
            foreach (DataRow dr in dt.Rows)
            {
                int week = Convert.ToInt32(dr["Position"].ToString().Substring(0, 1));
                int number = Convert.ToInt32(dr["Position"].ToString().Substring(1));
                int type = Convert.ToInt32(dr["PType"].ToString());
                switch (type)
                {
                    case 1:
                        necstr = necstr + week + "0" + number + "|";
                        break;
                    case 2:
                        recstr = recstr + week + "0" + number + "|";
                        break;
                    case 3:
                        forbidstr = forbidstr + week + "0" + number + "|";
                        break;
                }
            }

            this.hf_forbid.Value = forbidstr.Length > 0 ? forbidstr.Substring(0, forbidstr.Length - 1) : "";
            this.hf_nec.Value = necstr.Length > 0 ? necstr.Substring(0, necstr.Length - 1) : "";
            this.hf_rec.Value = recstr.Length > 0 ? recstr.Substring(0, recstr.Length - 1) : "";


        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                ScheduleSetEntity model1 = setDAL.GetObjByID();
                if (model1 == null)
                {
                    ShowMessage("请先录入排课设置，才能录入排课计划");
                    return;
                }
                else
                {
                    DataTable dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.IsorNot.否);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (this.hf_TID.Value == dt.Rows[i]["DID"].ToString())
                        {
                            ShowMessage("部门不可选做任课教师");
                            return;
                        }
                    }
                    if (this.chk_TbTeacher.Checked)
                    {
                        DataTable dt1 = planeDAL.UpdateTeacher(ViewState["tid"].ToString(), this.hf_TID.Value, Convert.ToInt32(this.ddl_CRID.SelectedValue), term, EYear);
                        if (dt1 != null && dt1.Rows.Count > 0 && dt1.Rows[0]["name"].ToString() != "")
                        {
                            ShowMessage(dt1.Rows[0]["name"].ToString());
                            return;
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('同步成功！');winclose();", true);
                        }
                    }
                    else
                    {
                        TeacherPlaneEntity model = new TeacherPlaneEntity();
                        model.TPID = TPID;
                        model.CTID = "";
                        model.CourseID = Convert.ToInt32(this.ddl_CourseName.SelectedValue);
                        model.TeacherID = this.hf_TID.Value;
                        model.ClaID = Convert.ToInt32(this.hf_DID.Value);
                        model.JieShu = Convert.ToInt32(this.txt_Jieshu.Text);
                        //model.LianJie = Convert.ToInt32(this.ddl_LianJie.SelectedValue);
                        model.LianJie = 0;
                        model.LianCi = Convert.ToInt32(this.ddl_LianCi.SelectedValue);
                        model.CRID = Convert.ToInt32(this.ddl_CRID.SelectedValue);
                        if (model.JieShu <= 0)
                        {
                            ShowMessage("每周节数必须大于0");
                            return;
                        }
                        ScheduleSetEntity smodel = setDAL.GetObjByID();
                        int basehour = (smodel.MorningPitch + smodel.AfterPitch + smodel.EveningPitch) * smodel.CourseDay;
                        if (TPID == "")
                        {
                            if ((TotelHour + model.JieShu) > basehour)//已有总节数加上当前节数    基础设置总节数
                            {
                                ShowMessage("如果加上本科目的的节数，则该班级课时总数已超过基础设置总数，请重新设置节数");
                                return;
                            }
                        }
                        else
                        {
                            int oldhour = Convert.ToInt32(this.hf_JieShu.Value.ToString());//修改时原始节数信息
                            if ((TotelHour - oldhour + model.JieShu) > basehour)//已有总节数减去原始节数加上当前节数   基础设置总节数
                            {
                                ShowMessage("如果加上本科目的的节数，则该班级课时总数已超过基础设置总数，请重新设置节数");
                                return;
                            }
                        }
                        int result = planeDAL.Edit(model, this.hf_nec.Value.TrimEnd('|'), this.hf_forbid.Value.TrimEnd('|'), this.hf_rec.Value.TrimEnd('|'));
                        if (result == 0)
                        {
                            int log = TPID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                            sysLogDAL.Edit(new SysLogEntity(log, (TPID == "" ? "添加" : "修改") + "排课计划信息", UserID));
                            ShowMessage();
                        }
                        else if (result == -2)
                        {
                            ShowMessage("数据库中已存在该学科名称、任课教师的排课计划，请重新输入");
                            return;
                        }
                        else
                        {
                            ShowMessage("提交失败");
                            return;
                        }
                    }
                }
                this.hf_rec.Value = "";
                this.hf_forbid.Value = "";
                this.hf_nec.Value = "";

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
    }
}