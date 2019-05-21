
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;

namespace GKICMP.office
{
    public partial class RepairTransfer : PageBase
    {
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_RepairDAL repairDAL = new Asset_RepairDAL();
        public SysUser_TypeDAL typeDAL = new SysUser_TypeDAL();
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
            if (!IsPostBack) 
            {
                DataTable dt = sysUserDAL.GetSysUserByTeac((int)CommonEnum.UserType.校外人士, (int)CommonEnum.IsorNot.否);
                //DataTable dt =typeDAL.GetList((int)CommonEnum.HumanType.请假审核人)
                CommonFunction.DDlTypeBind(this.ddl_TransferUser, dt, "UID", "RealName", "-2");
            }


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
                model.TransferUser = this.ddl_TransferUser.SelectedValue;
                int result = repairDAL.UpdateYJ(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "报修信息移交操作，移交给【" + this.ddl_TransferUser.SelectedItem.Text + "】", UserID));
                    ShowMessage();
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