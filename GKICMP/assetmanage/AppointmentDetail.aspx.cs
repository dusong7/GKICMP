/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师合同管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.assetmanage
{
    public partial class AppointmentDetail : PageBase
    {

        public ClassRoomDAL classDAL = new ClassRoomDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public AppointmentDAL appointmentDAL = new AppointmentDAL();


        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public int AID
        {
            get
            {
                return GetQueryString<int>("id", -1);
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
                if (AID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {

            AppointmentEntity model = appointmentDAL.GetObjByID(AID);
            if (model != null)
            {
                this.ltl_TeacherName.Text = model.AppUserName.ToString();

                this.ltl_CreateDate.Text = model.CreateDate.ToString() == "0001/1/1 0:00:00" ? "" : model.CreateDate.ToString("yyyy-MM-dd");
                this.ltl_BeginDate.Text = model.BeginDate.ToString() == "0001/1/1 0:00:00" ? "" : model.BeginDate.ToString("yyyy-MM-dd");
                this.ltl_End.Text = model.EndDate.ToString() == "0001/1/1 0:00:00" ? "" : model.EndDate.ToString("hh:mm");
                this.ltl_begin.Text = model.BeginDate.ToString() == "0001/1/1 0:00:00" ? "" : model.BeginDate.ToString("hh:mm");

                //this.ltl_CType.Text = CommonFunction.CheckEnum<CommonEnum.BaseDataType>(model.CType);
                this.ltl_MRID.Text = model.MRName.ToString();
                this.lbl_AppointmentDesc.Text = model.AppointmentDesc.ToString();

            }
        }
        #endregion
    }
}