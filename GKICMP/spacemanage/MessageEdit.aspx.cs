/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月25日 9点29分
** 描   述:      评论留言编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.spacemanage
{
    public partial class MessageEdit : PageBase
    {
        public SpaceCommentDAL commentDAL = new SpaceCommentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// 1:日志 2：照片 3：留言
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }

        /// <summary>
        /// 日志1照片2评论id，留言3班级id
        /// </summary>
        public int ObjectID
        {
            get
            {
                return GetQueryString<int>("id", -1); ;
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
                if (Flag == 3)
                {
                    this.ltl_Top.Text = "留言";
                    this.ltl_Name.Text = "留言";
                }
                else
                {
                    this.ltl_Top.Text = "评论";
                    this.ltl_Name.Text = "评论";
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
                SpaceCommentEntity model = new SpaceCommentEntity();
                model.SysID = UserID;
                model.MContent = this.txt_Content.Text.ToString().Trim();
                if (model.MContent == "")
                {
                    ShowMessage("请填写" + (Flag == 3 ? "留言" : "评论") + "内容");
                    return;
                }
                model.ObjectID = ObjectID;
                model.SCFlag = Flag;

                int result = commentDAL.Edit(model);
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "用户【" + UserRealName + "】于北京时间" + DateTime.Now + "添加" + (Flag == 3 ? "留言" : "评论") + "信息", UserID));
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}