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
    public partial class CommentPublish : PageBase
    {
        public Web_CommentDAL commentDAL = new Web_CommentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// CID 评论留言ID
        /// </summary>
        public string CIDs
        {
            get
            {
                return GetQueryString<string>("ids", "");
            }
        }

        /// <summary>
        /// flag 1:留言 2：评论
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
                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsPublish, "-2");//是否公开

                if (Flag == 1)
                {
                    this.ltl_ComTitle.Text = "留言";
                }
                else
                {
                    this.ltl_ComTitle.Text = "评论";
                }
            }
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Web_CommentEntity model = new Web_CommentEntity();
                //model.CID = CID.ToString();
                if (Convert.ToInt32(this.ddl_IsPublish.SelectedValue) == (int)CommonEnum.IsorNot.是)
                {
                    model.ConState = (int)CommonEnum.AduitState.通过;
                }
                else
                {
                    model.ConState = (int)CommonEnum.AduitState.驳回;
                }

                model.IsPublish = Convert.ToInt32(this.ddl_IsPublish.SelectedValue);
                model.AuditUser = UserID;

                int result = commentDAL.UpdatePublish(model, CIDs);
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion

    }
}