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
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.cms
{
    public partial class CommentDetail : PageBase
    {
        public Web_CommentDAL web_CommentDAL = new Web_CommentDAL();

        #region 参数集合
        /// <summary>
        /// CID
        /// </summary>
        public int CID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        /// <summary>
        /// Flag 标示 1：留言 2：评论
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);

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
                if (Flag == 1)
                {
                    this.ltl_Name.Text = "留言";
                }
                else if (Flag == 2)
                {
                    this.ltl_Name.Text = "评论";
                }
                InfoBind();
            }
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void InfoBind()
        {
            Web_CommentEntity model = web_CommentDAL.Get(CID);
            if (model != null)
            {
                this.ltl_title.Text = model.ComTitle.ToString();
                this.ltl_ComContent.Text = model.ComContent.ToString();
                this.ltl_LinkUser.Text = model.LinkUser.ToString();
                this.ltl_LinkType.Text = model.LinkType.ToString();
                this.ltl_IsPublish.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsPublish.ToString()); ;
                this.ltl_ReplyContent.Text = model.ReplyContent == null ? "" : model.ReplyContent.ToString();
            }
        }
        #endregion
    }
}