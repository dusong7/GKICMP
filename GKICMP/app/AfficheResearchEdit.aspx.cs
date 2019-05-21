using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace GKICMP.app
{
    public partial class AfficheResearchEdit : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveAuditDAL leaveAuditDAL = new LeaveAuditDAL();
        public LeaveDAL leaveDAL = new LeaveDAL();

        public AfficheDAL afficheDAL = new AfficheDAL();
     

        #region 参数集合
        public string AID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public string Users
        {
            get
            {
                return GetQueryString<string>("users", "");
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AfficheEntity model = afficheDAL.GetObjByID(AID, Users);
                if (model != null)
                {
                    this.ltl_AType.Text = model.ATypeName;
                    this.lbl_AfficheTitle.Text = model.AfficheTitle;
                    this.lbl_SendUserName.Text = model.SendUserName;
                    this.lbl_SendDate.Text = model.SendDate.ToString("yyyy-MM-dd HH:mm");
                    this.lbl_AContent.Text = model.AContent;
                   
                    //this.lbl_IsDisplay.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsDisplay);
                    //afficheDAL.Update(AID, Users, (int)CommonEnum.IsorNot.是);//是否已读
                }
               
            }
        }
    

        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                AfficheEntity model = new AfficheEntity();
                model.AID = AID.ToString();
                model.IsRead = Convert.ToInt32(this.hf_AuditResult.Value);
                model.AuditMark = this.txt_AuditMark.Text;
                model.AcceptUser = Users;
                if (model.IsRead == (int)CommonEnum.IsorNot.否 && model.AuditMark == "")
                {
                    ShowMessage("不参与请说明原因");
                    return;
                }

                int result = afficheDAL.AuditEdit(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "教研活动参与信息", UserID));
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='AfficheResearchAccept.aspx';", true);
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion

    }
}