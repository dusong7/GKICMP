using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP
{
    public partial class Stu_WebMain : NullPageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysuseDAL = new SysUserDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ltl_UserName.Text = UserRealName;
            SysUserEntity model = sysuseDAL.GetObjByID(UserID);
            if (model != null)
            {
                try
                {
                    this.image1.ImageUrl = model.Photos.ToString() == "" ? "images/t_male.png" : model.Photos.ToString();
                }
                catch (Exception)
                {
                    this.image1.ImageUrl = "images/t_male.png";
                }
            }


        }

        #region 注销
        protected void lbtn_Out_Click(object sender, EventArgs e)
        {
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.注销日志, "用户【" + UserRealName + "】于北京时间" + DateTime.Now.ToString() + "注销登陆", UserID));
            Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["SysUserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["RealName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["UserType"].Expires = DateTime.Now.AddDays(-1);
            Request.Cookies.Clear();
            string a = Request.Url.ToString();
            string b = a.Replace("Stu_WebMain", "Default");
            Response.Redirect(b, false);
        }
        #endregion
    }
}