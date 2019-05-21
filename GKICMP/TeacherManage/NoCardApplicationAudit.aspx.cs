using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.teachermanage
{
    public partial class NoCardApplicationAudit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public NoCardApplyDAL applyDAL = new NoCardApplyDAL();



        #region 参数集合
        /// <summary>
        /// LID 请假ID
        /// </summary>
        public string LID
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
                CommonFunction.BindEnum<CommonEnum.PraState>(this.ddl_AuditResult, "-99");
                //this.ddl_AuditResult.Items.Remove(new ListItem("未审核", "1"));
                //this.ddl_AuditResult.Items.Remove(new ListItem("审核中", "4"));
            }
        }
        #endregion


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
                NoCardApplyEntity model = new NoCardApplyEntity();
                model.ID = LID;
                model.NoCardAuditDesc = this.txt_AuditMark.Text;
                if (this.ddl_AuditResult.SelectedValue == "")
                {
                    ShowMessage("请选择审核结果");
                    return;
                }
                else
                {
                    model.NoCardState = Convert.ToInt32(this.ddl_AuditResult.SelectedValue);
                }

               
                int result = applyDAL.Audit(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核补卡信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("提交失败");
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