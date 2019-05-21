
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.app
{
    public partial class RepairReject : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_RepairDAL repairDAL = new Asset_RepairDAL();

        #region 参数集合
        /// <summary>
        /// LAID 审核ID
        /// </summary>
        public string ARID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int result = repairDAL.Reject(ARID, this.txt_AuditMark.Text, (int)CommonEnum.ARState.驳回);
                if (result > 0)
                {
                    if (result > 0)
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "驳回报修数据【微信端操作】", UserID));
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='PeopleRepail.aspx';", true);
                    }
                    else
                    {
                        ShowMessage("提交失败");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
    }
}