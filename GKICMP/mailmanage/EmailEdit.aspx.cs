/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年8月19日 9时46分
** 描 述:       邮件管理编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.mailmanage
{
    public partial class EmailEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public EmailDAL emailDAL = new EmailDAL();

        #region 参数集合
        /// <summary>
        /// EID
        /// </summary>
        public string EID
        {
            get
            {
                return GetQueryString<string>("id", "");
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
                CommonFunction.BindEnum<CommonEnum.RecType>(this.rbl_EType);
                this.rbl_EType.SelectedIndex = 0;

                if (EID != "")
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
            EmailEntity model = emailDAL.GetObjByID(EID);
            if (model != null)
            {
                this.txt_EmailTitle.Text = model.EmailTitle;
                this.rbl_EType.SelectedValue = model.EType.ToString();
                this.hf_AcceptUser.Value = model.AcceptUser;
                this.txt_Content.Text = model.EmailContent.ToString().Trim();
            }
        }
        #endregion


        #region 保存事件
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                int isadd = EID == "" ? 0 : 1;
                if (this.hf_AcceptUser.Value == "" && this.rbl_EType.SelectedValue.ToString() == "1")
                {
                    ShowMessage("请选择发送对象");
                    return;
                }
                if (this.txt_Content.Text == "")
                {
                    ShowMessage("请填写邮件内容");
                    return;
                }
                EmailEntity model = new EmailEntity();
                model.EID = EID;
                model.EmailContent = this.txt_Content.Text.ToString();
                model.EmailTitle = this.txt_EmailTitle.Text.ToString();
                model.SendUser = UserID;
                model.EType = Convert.ToInt32(this.rbl_EType.SelectedValue.ToString());
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.AcceptUser = this.hf_AcceptUser.Value.ToString();
                model.IsSubmit = (int)CommonEnum.IsorNot.否;

                int result = emailDAL.Edit(model,isadd);
                if (result > 0)
                {
                    ShowMessage("保存成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "发送标题为：【" + this.txt_EmailTitle.Text.ToString().Trim() + "】的邮件信息", UserID));
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.登录日志, ex.Message, UserID));
                return;
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
                int isadd = EID == "" ? 0 : 1;
                if (this.hf_AcceptUser.Value == "" && this.rbl_EType.SelectedValue.ToString() == "1")
                {
                    ShowMessage("请选择发送对象");
                    return;
                }
                if (this.txt_Content.Text == "")
                {
                    ShowMessage("请填写邮件内容");
                    return;
                }
                EmailEntity model = new EmailEntity();
                model.EID = EID;
                model.EmailContent = this.txt_Content.Text.ToString();
                model.EmailTitle = this.txt_EmailTitle.Text.ToString();
                model.SendUser = UserID;
                model.EType = Convert.ToInt32(this.rbl_EType.SelectedValue.ToString());
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.AcceptUser = this.hf_AcceptUser.Value.ToString();
                model.IsSubmit = (int)CommonEnum.IsorNot.是;

                int result = emailDAL.Edit(model,isadd);
                if (result > 0)
                {
                    ShowMessage("提交成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "发送标题为：【" + this.txt_EmailTitle.Text.ToString().Trim() + "】的邮件信息", UserID));
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


        #region 判断是否需选教师
        /// <summary>
        /// 判断是否需选教师
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rbl_IsorNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rbl_EType.SelectedValue == Convert.ToInt32(CommonEnum.RecType.群发消息).ToString())
            {
                this.aa.Visible = false;
            }
            else
            {
                this.aa.Visible = true;
            }
        }
        #endregion
    }
}