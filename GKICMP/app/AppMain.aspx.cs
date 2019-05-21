using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using System;
using GK.GKICMP.Entities;

namespace GKICMP.app
{
    public partial class AppMain : PageBaseApp
    {
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public SysUser_TypeDAL sysusertypeDAL = new SysUser_TypeDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                SysUserEntity model = sysUserDAL.GetObjByID(UserID);
                if (model.UserType == (int)CommonEnum.UserType.学生)
                {
                    Response.Redirect("../appstu/Stu_AppMain.aspx", false);
                }
                else if(model.UserType == (int)CommonEnum.UserType.校外人士)
                {
                    Response.Redirect("RepairTransfer.aspx", false);
                }
                //ShowMessage(UserRealName);
               
                DataTable dt = new MainDAL().GetPaged(UserID);
                if (dt.Rows[0]["dzzw"].ToString() != "0")
                {
                    this.ltl_wdzw.Text = dt.Rows[0]["dzzw"].ToString();
                }
                SysUser_TypeEntity modelType = sysusertypeDAL.GetByUIDstype((int)CommonEnum.HumanType.考勤管理, UserID);
                if (modelType == null)
                {
                    this.record.Visible = false;
                }
            }
        }
    }
}