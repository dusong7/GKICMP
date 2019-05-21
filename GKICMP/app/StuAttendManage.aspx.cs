/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      yzr
** 创建日期:     2017年03月03日
** 描 述:       晨检申报页面
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
using System.Text;
using System.Web;
using System.Globalization;

namespace GKICMP.app
{
    public partial class StuAttendManage : PageBaseApp
    {
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public StudentDAL studentDAL = new StudentDAL();
        public StuAttendDAL stuAttendDAL = new StuAttendDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.txt_CreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //GetGrade();
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            //{
            //    try
            //    {
            //        StuAttendEntity model = new StuAttendEntity();
            //        model.STID = "";
            //        model.CreateDate = Convert.ToDateTime(this.txt_CreateDate.Text);
            //        model.CreateUser = UserID;
            //        model.AllIns = Convert.ToInt32(this.txt_AllIns.Text);
            //        model.RealCOunt = Convert.ToInt32(this.txt_RealCOunt.Text);
            //        model.DID = Convert.ToInt32(this.hf_DID.Value.TrimEnd(','));
            //        model.LeaveUserName = this.hf_LeaveUser.Value.TrimEnd(',');
            //        model.InfectiousName = this.hf_Infectious.Value.TrimEnd(',');
            //        model.CompassionateName = this.hf_Compassionate.Value.TrimEnd(',');
            //        model.SickName = this.hf_Sick.Value.TrimEnd(',');
            //        int result = stuAttendDAL.Edit(model);
            //        if (result == 0)
            //        {
            //            int log = model.STID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
            //            sysLogDAL.Edit(new SysLogEntity(log, model.STID == "" ? "添加" : "修改" + "班级为" + this.hf_DIDName.Value.TrimEnd(',') + "晨检申报信息", UserID));
            //            ShowMessage();
            //        }
            //        else
            //        {
            //            ShowMessage("保存失败");
            //            return;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            //        ShowMessage(ex.Message);
            //    }
        }
        #endregion

        protected void btn_Search_Click(object sender, EventArgs e)
        {

        }
    }
}