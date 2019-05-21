/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      yzr
** 创建日期:     2017年03月03日
** 描 述:       晨检申报编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.app
{
    public partial class StuAttendEdit : PageBaseApp
    {
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public StudentDAL studentDAL = new StudentDAL();
        public StuAttendDAL stuAttendDAL = new StuAttendDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        public string STID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txt_CreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                GetGrade();
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.hf_DID.Value.TrimEnd(',') == "" || Convert.ToInt32(this.hf_DID.Value.TrimEnd(',')) <= 0)
                {
                    ShowMessage("请选择班级");
                    return;
                }
                StuAttendEntity model = new StuAttendEntity();
                model.STID = STID;
                model.CreateDate = Convert.ToDateTime(this.txt_CreateDate.Text);
                model.CreateUser = UserID;
                model.AllIns = Convert.ToInt32(this.txt_AllIns.Text);
                model.RealCOunt = Convert.ToInt32(this.txt_RealCOunt.Text);
                model.DID = Convert.ToInt32(this.hf_DID.Value.TrimEnd(','));
                model.LeaveUserName = this.hf_LeaveUser.Value.TrimEnd(',');
                model.InfectiousName = this.hf_Infectious.Value.TrimEnd(',');
                model.CompassionateName = this.hf_Compassionate.Value.TrimEnd(',');
                model.SickName = this.hf_Sick.Value.TrimEnd(',');
                int result = stuAttendDAL.Edit(model);
                if (result == 0)
                {
                    int log = STID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (STID == "" ? "添加" : "修改") + "班级为:" + this.hf_DIDName.Value.TrimEnd(',') + "晨检申报信息", UserID));
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='StuAttendManage.aspx';", true);
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion

        #region 获取学生根据班级
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            StuAttendEntity model = stuAttendDAL.GetByDIDanddate(Convert.ToInt32(this.hf_DID.Value.TrimEnd(',')), Convert.ToDateTime(this.txt_CreateDate.Text));
            if (model != null)
            {
                ShowMessage(this.hf_DIDName.Value.TrimEnd(',') + "在今天已经添加过晨检申报了");
                this.hf_DID.Value = "0";
                this.classseclet.Value = "";
            }
            else
            {
                this.Compassionate.Value = this.Infectious.Value = this.LeaveUser.Value = this.Sick.Value = this.hf_DIDName.Value.TrimEnd(',');
                this.txt_AllIns.Text = studentDAL.GetStuByClass(Convert.ToInt32(this.hf_DID.Value.TrimEnd(','))).Rows.Count.ToString();
                GetLeave();
            }
        }
        #endregion


        #region 获取年级
        public void GetGrade()
        {
            DataTable dt = gradeDAL.GetListAll((int)CommonEnum.IsorNot.否);
            if (dt != null && dt.Rows.Count > 0)
            {
                rp_Class.DataSource = dt;
                rp_Class.DataBind();
            }
        }
        #endregion


        #region 根据年级获取班级
        protected void rp_Class_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hf_GID = (HiddenField)e.Item.FindControl("hf_GID");
            Repeater rp_Classall = (Repeater)e.Item.FindControl("rp_Classall");
            DataTable dt = departmentDAL.GetByGID(Convert.ToInt32(hf_GID.Value), (int)CommonEnum.IsorNot.否);
            if (dt != null && dt.Rows.Count > 0)
            {
                rp_Classall.DataSource = dt;
                rp_Classall.DataBind();
            }
        }
        #endregion


        #region 获取迟到人员
        public void GetLeave()
        {
            DataTable dt = sysUserDAL.GetTeacherByDepID(Convert.ToInt32(this.hf_DID.Value.TrimEnd(',')));
            if (dt != null && dt.Rows.Count > 0)
            {
                rp_LeaveUserall.DataSource = dt;
                rp_LeaveUserall.DataBind();

                rp_Compassionateall.DataSource = dt;
                rp_Compassionateall.DataBind();

                rp_Sickall.DataSource = dt;
                rp_Sickall.DataBind();

                rp_Infectious.DataSource = dt;
                rp_Infectious.DataBind();
            }
        }
        #endregion

    }
}