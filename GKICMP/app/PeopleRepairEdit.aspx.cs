using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Web.UI;

namespace GKICMP.app
{
    public partial class PeopleRepairEdit : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_RepairDAL repairDAL = new Asset_RepairDAL();

        #region 参数集合
        public string ARID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", 0);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion



        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_AuditMark.Text.Trim() == "")
                {
                    ShowMessage("请输入说明");
                    return;
                }
                int result = repairDAL.Update(ARID, this.txt_AuditMark.Text.Trim(), Convert.ToInt32(CommonEnum.ARState.完成));
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "完成受理的报修信息", UserID));
                    if (Flag == 3)
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='RepairTransfer.aspx';", true);
                    else
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='PeopleRepail.aspx';", true);

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