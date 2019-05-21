/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月04日 09点24分
** 描   述:      Top页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Web.UI;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;
using System.Web;

namespace GKICMP
{
    public partial class WebMain : NullPageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL UserDal = new SysUserDAL();
        public SysModuleDAL sysModuleDAL = new SysModuleDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_uid.Value = UserID;
                this.ltl_UserName.Text = UserRealName;
                SysUserEntity model = UserDal.GetObjByID(UserID);
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
                DataTable dvmodules = sysModuleDAL.GetListByUserID(1, UserID);
                this.rpmodule.DataSource = dvmodules;
                this.rpmodule.DataBind();
                this.rpList.DataSource = dvmodules;
                this.rpList.DataBind();
            }
        }
        #region 一级模块绑定
        /// <summary>
        /// 一级模块绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hfModuleID = (HiddenField)e.Item.FindControl("hffid");
                HiddenField hfCss = (HiddenField)e.Item.FindControl("Iscss");
                Repeater rpnextModule = (Repeater)e.Item.FindControl("rpnextModule");
                DataTable dvmodules = sysModuleDAL.GetListByUserID(Convert.ToInt32(hfModuleID.Value), UserID);
                rpnextModule.DataSource = dvmodules;
                rpnextModule.DataBind();
            }
        }
        #endregion

        #region 注销
        protected void lbtn_Out_Click(object sender, EventArgs e)
        {
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.注销日志, "用户【" + UserRealName + "】于北京时间" + DateTime.Now.ToString() + "注销登陆", UserID));
            Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["SysUserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["RealName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["UserType"].Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Remove("UserID");
            //Response.Cookies.Remove("SysUserName");
            //Response.Cookies.Remove("RealName");
            //Response.Cookies.Remove("UserType");
            Request.Cookies.Clear();
            string a = Request.Url.ToString();
            string b = a.Replace("WebMain", "Default");
            //int c = Request.Url.Port;
            //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, a+","+c, UserID));
            Response.Redirect(b, false);

            // Page.ClientScript.RegisterStartupScript(GetType(), "", " window.location.href= '/Default.aspx'", true);
        }
        #endregion

        #region 获取连接地址
        /// <summary>
        /// 获取连接地址
        /// </summary>
        /// <param name="url1"></param>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        public string GetMList(object moduleID, object url1, object mname, object iscss,object isclick)
        {




            StringBuilder alllist = new StringBuilder("");
            int mid = Convert.ToInt32(moduleID);

            if (iscss.ToString() == "1")
            {
                alllist.Append("   <dd class='menulist'>");
            }
            else
            {
                alllist.Append("   <dd class='menulist1'>");
            }

            DataTable dvmodules = sysModuleDAL.GetListByUserID(mid, UserID);
            if (dvmodules != null && dvmodules.Rows.Count > 0)
            {

                alllist.AppendFormat("<a>{0}</a>", mname.ToString());
                alllist.Append(" <dl>");

                foreach (DataRow row in dvmodules.Rows)
                {
                    alllist.AppendFormat("<dd><a class='menuItem " + (row["IsClick"].ToString() == "1" ? "notice2" : "" )+ "' target='mainiframe' href='{1}' id='{2}'>{0}</a></dd>", row["ModuleName"].ToString(), GetUrl(row["ModuleUrl"], row["ModuleID"]), row["ModuleID"]);
                }

                alllist.Append(" </dl>");


            }
            else
            {

                alllist.AppendFormat("<a class='menuItem " +( isclick.ToString() == "1" ? "notice2" : "" )+ "'  href='{0}' id='{2}' target='mainiframe'>{1}</a>", GetUrl(url1, moduleID), mname.ToString(), moduleID);

            }

            alllist.Append(" </dd>");
            return alllist.ToString();

        }
        #endregion



        #region 获取连接地址
        /// <summary>
        /// 获取连接地址
        /// </summary>
        /// <param name="url1"></param>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        public string GetUrl(object url1, object moduleID)
        {
            string url = url1.ToString();
            if (url.IndexOf('?') > 0)
            {
                url = url + "&SysMUID=" + moduleID.ToString();

            }
            else
            {
                url = url + "?SysMUID=" + moduleID.ToString();
            }


            return url;

        }
        #endregion
    }
}