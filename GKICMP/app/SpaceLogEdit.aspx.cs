/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年11月4日 16时20分
** 描 述:       学生活动日志
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.app
{
    public partial class SpaceLogEdit : PageBaseApp
    {
        public SpaceLogDAL logDAL = new SpaceLogDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public StudentActivityDAL studentActivityDAL = new StudentActivityDAL();

        #region 参数集合
        /// <summary>
        /// 活动ID
        /// </summary>
        public string SAID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InfoBind();
            }
        }
        #endregion


        private void InfoBind()
        {
            StudentActivityEntity model = studentActivityDAL.GetObjByID(SAID);
            if (model != null)
            {
                this.lbl_ActName.Text = model.ActName;
                this.lbl_Counselor.Text = model.CounselorName;
                this.lbl_ClosingDate.Text = model.ClosingDate.ToString("yyyy-MM-dd");
                this.lbl_ActType.Text = model.ActTypeName.ToString();
                this.lbl_ActContent.Text = model.ActContent;
                //this.lbl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
                //this.lbl_CreateUser.Text = model.CreateUserName;
            }
        }


        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                SpaceLogEntity model = new SpaceLogEntity();
                model.EGID = -1;
                model.SysID = UserID;
                model.LogText = this.txt_Content.Text.ToString().Trim();
                model.IsPublish = (int)CommonEnum.IsorNot.是;
                model.LogTitle = this.txt_LogTitle.Text.ToString().Trim();
                model.ClaID = -2;
                model.IsAduit = (int)CommonEnum.IsorNot.是;
                model.AduitState = (int)CommonEnum.AduitState.通过;
                model.SFlag = 2;//1：空间日志 2：学生活动日志
                model.SAID = SAID;
                if (this.txt_Content.Text.ToString().Trim() == "")
                {
                    ShowMessage("请填写日志内容");
                    return;
                }

                int result = logDAL.Edit(model);
                if (result > 0)
                {
                    ShowScript("alert('提交成功！');window.location.href='SpaceLogList.aspx'");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加标题为：【" + this.txt_LogTitle.Text + "】的日志信息", UserID));
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