/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年8月26日 9点17分
** 描   述:      照片详情页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;

namespace GKICMP.spacemanage
{
    public partial class PhotoDetail : PageBase
    {
        public SpaceCommentDAL commentDAL = new SpaceCommentDAL();
        public SpacePhotosDAL photoDAL = new SpacePhotosDAL();

        #region 参数集合
        /// <summary>
        /// 照片ID
        /// </summary>
        public int TID
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
            DataTable dt = photoDAL.GetObjByID(TID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.ltl_PhotoName.Text = dt.Rows[0]["PhotoName"].ToString();
                this.ltl_PhotoDesc.Text = dt.Rows[0]["PhotoDesc"].ToString();
                this.ltl_SysUserName.Text = dt.Rows[0]["UserName"].ToString();
                this.img_photoUrl.ImageUrl = dt.Rows[0]["PhotoUrl"].ToString();
                this.ltl_CreateDate.Text = Convert.ToDateTime(dt.Rows[0]["CreateDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            DataTable dtComment = commentDAL.GetList(2, TID);// 1:日志 2：照片 3：留言
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