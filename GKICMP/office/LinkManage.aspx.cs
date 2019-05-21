/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      项目文件管理
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace GKICMP.office
{
    public partial class LinkManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_JournalDAL journalDAL = new Teacher_JournalDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MList();
            }
        }
        #endregion


        #region 绑定职能部门信息
        private void MList()
        {
            DataTable dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.IsorNot.否);
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();
        }
        #endregion


        #region 绑定教师姓名
        /// <summary>
        /// 二级模块绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rp_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hfModuleID = (HiddenField)e.Item.FindControl("hffid");
                Repeater rpnextModule = (Repeater)e.Item.FindControl("rp_ListFile");
                DataTable st = teacherDAL.GetByDepID(int.Parse(hfModuleID.Value), (int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
                rpnextModule.DataSource = st;
                rpnextModule.DataBind();
            }
        }
        #endregion


    }
}