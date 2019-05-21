
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
namespace GKICMP.educational
{
    public partial class SubstituteAuditEdit : PageBase
    {
        public  int SubID{get{ return GetQueryString<int>("id", -1);}}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                CommonFunction.BindEnum<CommonEnum.PraState>(this.ddl_AuditResult,"-99");
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int result = new SubstituteDAL().Audit(SubID,int.Parse(this.ddl_AuditResult.SelectedValue),UserID);
                if (result > 0)
                {
                    new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核调课信息", UserID));
                    ShowMessage();
                }
                else { ShowMessage("提交失败"); return; }
            }
            catch (Exception ex)
            {
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志,ex.Message, UserID));
                ShowMessage("系统出错，请稍后再试");
            }
        }
    }
}