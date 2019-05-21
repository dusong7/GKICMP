/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月17日 09点30分
** 描   述:      招标详情
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;


namespace GKICMP.purchase
{
    public partial class PurchaseTenderReturn : PageBase
    {
        public Project_TenderDAL project_TenderDAL = new Project_TenderDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public string PTID
        {
            get { return GetQueryString<string>("id", ""); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = project_TenderDAL.getReturn(PTID);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["IsReturn"].ToString() == "1")
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('此项目保证金已归还，请勿重复操作！');winclose();", true);
                    }
                }
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int result = project_TenderDAL.Update(PTID, Convert.ToDateTime(this.txt_BondDate.Text));
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "退还保证金", UserID));
                }
                else
                {
                    ShowMessage("提交出错，请稍后再试");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }

    }
}