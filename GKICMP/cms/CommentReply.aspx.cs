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
using System.Web.UI.WebControls;

namespace GKICMP.cms
{
    public partial class CommentReply : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
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

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            Web_CommentEntity model = new Web_CommentEntity();
            model.CID = CID;
            if (this.txt_ReplyContent.Text == "")
            {
                ShowMessage("请填写回复内容");
                return;
            }
            else
            {
                model.ReplyContent = this.txt_ReplyContent.Text.Trim();//回复内容
            }
            int result = web_CommentDAL.Update(model);
            if (result == -1)
            {
                ShowMessage("提交失败");
                return;
            }
            else
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, Flag == 1 ? "回复留言信息" : "回复评论信息", UserID));
                ShowMessage();
            }
        }
        #endregion
    }
}