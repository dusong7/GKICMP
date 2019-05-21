using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Web.UI;

namespace GKICMP.app
{
    public partial class PersonSubstituteEdit : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AbsentDAL absentDAL = new AbsentDAL();

        #region 参数集合

        public int ABID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {

            try
            {
                AbsentEntity model = new AbsentEntity();
                model.AbID = ABID;
                model.SubState = Convert.ToInt32(this.hf_AuditResult.Value);
                model.Reason = this.txt_AuditMark.Text.Trim();
                if (model.SubState == (int)CommonEnum.PraState.驳回 && model.Reason == "")
                {
                    ShowMessage("驳回请录入原因");
                    return;
                }
                int result = absentDAL.Audit(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核代课信息", UserID));
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='PersonSubstituteManage.aspx';", true);
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
    }
}