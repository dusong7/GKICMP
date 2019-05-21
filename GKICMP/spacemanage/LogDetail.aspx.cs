/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年04月22日 10时19分04秒
** 描    述:      空间日志操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.spacemanage
{
    public partial class LogDetail : PageBase
    {
        public SpaceLogDAL logDAL = new SpaceLogDAL();
        public SpaceCommentDAL commentDAL = new SpaceCommentDAL();


        #region 参数集合
        /// <summary>
        /// 日志ID
        /// </summary>
        public int EGID
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
                InfoBind();
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            SpaceLogEntity model = logDAL.GetObjByID(EGID);
            if (model != null)
            {
                this.ltl_LogTitle.Text = model.LogTitle.ToString();
                this.ltl_LogText.Text = model.LogText.ToString();
                this.ltl_SysUserName.Text = model.SysUserName.ToString();
                this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
            }
            DataTable dtComment = commentDAL.GetList(1, EGID);// 1:日志 2：照片 3：留言
            if (dtComment != null && dtComment.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dtComment;
            this.rp_List.DataBind();
        }
        #endregion
    }
}