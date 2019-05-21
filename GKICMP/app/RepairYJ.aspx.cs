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
    public partial class RepairYJ : PageBaseApp
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
        //public int Flag
        //{
        //    get
        //    {
        //        return GetQueryString<int>("flag", 0);
        //    }
        //}
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Asset_RepairEntity model = new Asset_RepairEntity();
                model.ARID = ARID;
                model.TransferDate = DateTime.Now;
                model.TransferDesc = this.txt_TransferDesc.Text;
                model.ARState = (int)CommonEnum.ARState.移交;
                model.TransferUser = this.hf_SelectedValue.Value;
                int result = repairDAL.UpdateYJ(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "报修信息移交操作，移交给【" + this.hf_SelectedText.Value+ "】", UserID));
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
    }
}