/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      评语库界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.studentmanage
{
    public partial class RemarkDetail : PageBase
    {
        public SysRoleDAL sysRoleDAL = new SysRoleDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public RemarkDAL RemarkDAL = new RemarkDAL();

        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public int RID
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
                if (RID != -1)
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
            RemarkEntity model = new RemarkEntity();
            model = RemarkDAL.GetObjByID(RID);
            if (model != null)
            {
                this.ltl_RemarkContent.Text = model.RemarkContent;//
                this.ltl_CreateUser.Text = model.CreateUserName;//
                this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd"); ;//
            }
        }
        #endregion
    }
}