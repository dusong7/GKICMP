/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年1月4日 14时34分24秒
** 描    述:      学生通讯录管理
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.appstu
{
    public partial class LinkManage : PageBaseApp
    {
        public SysUserDAL sysUserDAL = new SysUserDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["Name"] = CommonFunction.GetCommoneString(this.txt_Name.Text.ToString().Trim());
            DataBindList();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            SysUserEntity model = sysUserDAL.GetObjByID(UserID);

            DataTable dt = sysUserDAL.GetLink(model.DepID, (string)ViewState["Name"]);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.ul_null.Visible = false;
            }
            else
            {
                this.ul_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();
        }
        #endregion


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            ViewState["Name"] = CommonFunction.GetCommoneString(this.txt_Name.Text.ToString().Trim());
            DataBindList();
        }
        #endregion
    }
}