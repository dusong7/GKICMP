/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2017年6月29日 09时26分24秒
** 描    述:      项目文件管理
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;

namespace GKICMP.app
{
    public partial class AppMailList : PageBaseApp
    {
        public TeacherDAL teacherDAL = new TeacherDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ViewState["Name"] = CommonFunction.GetCommoneString(this.txt_Name.Text.ToString().Trim());
                DataBindList();
            }
        }
        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            DataTable dt = teacherDAL.GetMailList((string)ViewState["Name"]);
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