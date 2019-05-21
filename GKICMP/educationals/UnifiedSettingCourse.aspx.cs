/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 09点30分
** 描   述:       统一设置学科
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;
using System.Collections.Generic;

namespace GKICMP.educationals
{
    public partial class UnifiedSettingCourse : PageBase
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherPlaneDAL planeDAL = new TeacherPlaneDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        public int GID
        {
            get
            {
                return GetQueryString<int>("gid", -1);
            }
        }
        public string TPID
        {
            get
            {
                return GetQueryString<string>("tpid", "");
            }
        }
        public int CID
        {
            get
            {
                return GetQueryString<int>("cid", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDLBind();
                if (TPID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 下拉框绑定
        /// <summary>
        /// 下拉框绑定
        /// </summary>
        private void DDLBind()
        {

            this.cbx_IsTB.Checked = false;
            DataTable dtCourse = courseDAL.GetList();
            CommonFunction.DDlTypeBind(this.ddl_CourseName, dtCourse, "CID", "CourseName", "-2");
            ScheduleSetEntity model = setDAL.GetObjByID();
            if (model != null)
            {
                this.hf_Week.Value = model.CourseDay.ToString();
                this.hf_MorningPitch.Value = model.MorningPitch.ToString();
                this.hf_AfterPitch.Value = model.AfterPitch.ToString();
                this.hf_EveningPitch.Value = model.EveningPitch.ToString();
                this.hf_deffordibts.Value = model.NoTimetable;
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            this.ddl_CourseName.Enabled = false;
            TeacherPlaneEntity model = planeDAL.GetPLXG(GID, CID);
            if (model != null)
            {
                this.ddl_CourseName.SelectedValue = model.CourseID.ToString();
                this.txt_Jieshu.Text = model.JieShu.ToString();
                this.hf_DID.Value = model.ClaID.ToString();
                this.hf_JieShu.Value = model.JieShu.ToString();
                ViewState["tid"] = model.TeacherID;
                ViewState["crid"] = model.CRID.ToString();
            }

        }
        #endregion



        #region 提交
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
                    if (Convert.ToInt32(this.txt_Jieshu.Text) <= 0)
                    {
                        ShowMessage("每周节数必须大于0");
                        return;
                    }
                    ScheduleSetEntity smodel = setDAL.GetObjByID();
                    List<TeacherPlaneEntity> list = new List<TeacherPlaneEntity>();
                    int basehour = (smodel.MorningPitch + smodel.AfterPitch + smodel.EveningPitch) * smodel.CourseDay;


                    DataTable dt = null;
                    if (this.cbx_IsTB.Checked == false)
                    {
                        dt = departmentDAL.GetClass((int)CommonEnum.IsorNot.否, -1, GID);
                    }
                    else
                    {
                        dt = departmentDAL.GetList((int)CommonEnum.IsorNot.否, -1);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            int count = 0;
                            DataTable dt1 = planeDAL.GetCountByClaid(Convert.ToInt32(row["DID"].ToString()), Convert.ToInt32(this.ddl_CourseName.SelectedValue), ref count);
                            if (TPID == "")
                            {
                                if ((count + Convert.ToInt32(this.txt_Jieshu.Text)) > basehour)//已有总节数加上当前节数    基础设置总节数
                                {
                                    ShowMessage("如果加上本科目的的节数，则班级" + row["otherName"].ToString() + "课时总数已超过基础设置总数，请重新设置节数");
                                    return;
                                }
                                else
                                {
                                    if (dt1 != null && dt1.Rows.Count > 0)
                                    {
                                        ShowMessage("当前课程在则班级" + row["otherName"].ToString() + "已经添加过，请重新统一添加");
                                        return;
                                    }
                                    else
                                    {
                                        TeacherPlaneEntity model = new TeacherPlaneEntity();

                                        model.TPID = "";
                                        model.CTID = "";
                                        model.CourseID = Convert.ToInt32(this.ddl_CourseName.SelectedValue);
                                        model.ClaID = Convert.ToInt32(row["DID"].ToString());
                                        string sql = " and ClaID=" + model.ClaID + " and CourseID=" + model.CourseID;
                                        DataTable dts = planeDAL.GetAllPlanByWhere(sql);
                                        if (dts != null && dts.Rows.Count > 0)
                                        {
                                            model.TeacherID = dts.Rows[0]["TeacherID"].ToString();
                                        }
                                        else
                                        {
                                            model.TeacherID = "";
                                        }
                                        model.JieShu = Convert.ToInt32(this.txt_Jieshu.Text);
                                        model.LianJie = 0;
                                        model.LianCi = 0;
                                        model.CRID = -2;
                                        list.Add(model);
                                    }
                                }
                            }
                            else
                            {
                                if ((count + Convert.ToInt32(this.txt_Jieshu.Text) - Convert.ToInt32(this.hf_JieShu.Value)) > basehour)//已有总节数加上当前节数    基础设置总节数
                                {
                                    ShowMessage("如果加上本科目的的节数，则班级" + row["otherName"].ToString() + "课时总数已超过基础设置总数，请重新设置节数");
                                    return;
                                }
                                else
                                {
                                    TeacherPlaneEntity model = new TeacherPlaneEntity();
                                    model.TPID = TPID;
                                    model.CTID = "";
                                    model.CourseID = Convert.ToInt32(this.ddl_CourseName.SelectedValue);
                                    model.ClaID = Convert.ToInt32(row["DID"].ToString());
                                    string sql = " and ClaID=" + model.ClaID + " and CourseID=" + model.CourseID;
                                    DataTable dts = planeDAL.GetAllPlanByWhere(sql);
                                    if (dts != null && dts.Rows.Count > 0)
                                    {
                                        model.TeacherID = dts.Rows[0]["TeacherID"].ToString();
                                    }
                                    else
                                    {
                                        model.TeacherID = "";
                                    }
                                    model.JieShu = Convert.ToInt32(this.txt_Jieshu.Text);
                                    model.LianJie = 0;
                                    model.LianCi = 0;
                                    model.CRID = -2;
                                    list.Add(model);
                                }
                            }
                        }
                        string resultvalue = planeDAL.TyAdd(list, this.hf_nec.Value.TrimEnd('|'), this.hf_forbid.Value.TrimEnd('|'), this.hf_rec.Value.TrimEnd('|'));
                        if (resultvalue == "")
                        {
                            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加" + "排课计划信息", UserID));
                            ShowMessage();
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
    }
}