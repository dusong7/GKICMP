
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.sysmanage
{
    public partial class SysUserTypeEdit : PageBase
    {
        public SysUser_TypeDAL sysUser_TypeDAL = new SysUser_TypeDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        #region 参数集合
        public int UTID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.HumanType>(this.ddl_SType, "-2");
                if (UTID != -1) 
                {
                    DataBindList();
                }
            }
        }

        public void DataBindList()
        {
            SysUser_TypeEntity model = sysUser_TypeDAL.GetObjByID(UTID);
            if (model != null) 
            {
                this.ddl_SType.SelectedValue = model.SType.ToString();
                //this.hf_SelectedValue.Value = model.UID;
                this.Series.Text = model.UID;
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                SysUser_TypeEntity model = new SysUser_TypeEntity();
                model.UTID = UTID;
                //model.UID = this.hf_SelectedValue.Value;
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.UID = this.Series.Text;

                model.SType = int.Parse(this.ddl_SType.SelectedValue);
                int result = sysUser_TypeDAL.Edit(model);
                if (result == 0)
                {
                    int log = UTID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity(log, UTID == -1 ? "添加" : "修改" + "人员分类信息", UserID));
                }
                else if (result == -1)
                {
                    ShowMessage("系统已存在此分类人员");

                }
                else
                {
                    ShowMessage("提交出错，请稍候再试");
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