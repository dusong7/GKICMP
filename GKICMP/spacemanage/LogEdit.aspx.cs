/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年04月21日 10时49分
** 描 述:       班级日志
** 修改人:      
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
    public partial class LogEdit : PageBase
    {
        public SpaceLogDAL logDAL = new SpaceLogDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// 班级ID
        /// </summary>
        public int ClaID
        {
            get
            {
                return GetQueryString<int>("claid", -2);
            }
        }

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
                if (EGID != -1)
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
            SpaceLogEntity model = logDAL.GetObjByID(EGID);
            if (model != null)
            {
                this.txt_LogTitle.Text = model.LogTitle.ToString();
                this.txt_Content.Text = model.LogText.ToString();
                this.rdo_IsPublish.SelectedValue = model.IsPublish.ToString();
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
                SpaceLogEntity model = new SpaceLogEntity();
                model.EGID = EGID;
                model.SysID = UserID;
                model.LogText = this.txt_Content.Text.ToString().Trim();
                model.IsPublish = Convert.ToInt32(this.rdo_IsPublish.SelectedValue.ToString());
                model.LogTitle = this.txt_LogTitle.Text.ToString().Trim();
                model.ClaID = ClaID;
                model.IsAduit = (int)CommonEnum.IsorNot.否;
                model.AduitState = (int)CommonEnum.AduitState.未审核;
                model.SFlag = 1;//1：空间日志 2：学生活动日志
                model.SAID = "";
                if (this.txt_Content.Text.ToString().Trim() == "")
                {
                    ShowMessage("请填写日志内容");
                    return;
                }

                int result = logDAL.Edit(model);
                if (result > 0)
                {
                    ShowScript("alert('提交成功！审核通过的日志将会显示在班级文化墙列表！');winclose();");
                    int log = EGID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (EGID == -1 ? "添加" : "修改") + "标题为：【" + this.txt_LogTitle.Text + "】的日志信息", UserID));
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