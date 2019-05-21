/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      czz
** 创建日期:    2017年03月02日
** 描 述:       用户角色编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;

namespace GKICMP.sysmanage
{
    public partial class SysRoleEdit : PageBase
    {
        public SysRoleDAL sysRoleDAL = new SysRoleDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL UserDal = new SysUserDAL();
        public SysModuleDAL AppModule = new SysModuleDAL();
        #region 参数集合
        public int RoleID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.CBLTypeBind(this.cbl_Button, AppModule.GetAPPs(), "ModuleID", "ModuleName");
                if (RoleID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 提交
        /// <summary>
        ///   提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string apps = "";
                foreach (ListItem li in this.cbl_Button.Items)
                {
                    if (li.Selected)
                    {
                        apps = apps + li.Value + ",";
                    }
                }
                if (apps.Length > 0)
                {
                    apps = apps.Substring(0, apps.Length - 1);
                }

                SysRoleEntity model = new SysRoleEntity();
                if (RoleID != -1)
                    model.RoleID = Convert.ToInt32(RoleID);
                else
                    model.RoleID = 0;
                model.RoleName = GetStr(this.txt_RoleName.Text.Trim());//角色名称
                model.RoleDesc = GetStr(this.txt_RoleDesc.Text.Trim());//角色备注
                model.RoleType = 1;//角色类型
                model.AppRole = apps;//手机端权限
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                int result = sysRoleDAL.Edit(model);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该角色名称已存在，请重新输入");
                    return;
                }
                else
                {
                    if (RoleID == -1)
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加角色【" + this.txt_RoleName.Text + "】信息", UserID));
                    else
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改角色【" + this.txt_RoleName.Text + "】信息", UserID));
                    ShowMessage();
                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
            }
        }
        #endregion


        #region 转换HTML标签
        private string GetStr(string str)
        {
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");

            return str.ToString();
        } 
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            SysRoleEntity model = new SysRoleEntity();
            model = sysRoleDAL.GetObjByID(RoleID);
            if (model != null)
            {
                this.txt_RoleName.Text = model.RoleName;//角色名称
                this.txt_RoleDesc.Text = model.RoleDesc;//角色备注

                string[] apps = model.AppRole.Split(',');//手机端权限
                if (apps != null && apps.Length > 0)
                {
                    foreach (string app in apps)
                    {
                        foreach (ListItem li in this.cbl_Button.Items)
                        {
                            if (app == li.Value)
                            {
                                li.Selected = true;
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}