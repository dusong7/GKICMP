/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      fsc
** 创建日期:    2017年02月27日
** 描 述:       用户管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.sysmanage
{
    public partial class WSysUserManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public SysUserDAL sysUsergDAL = new SysUserDAL();
        public myDirectory mDirectory = new myDirectory();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_Flag.Value ="3";
         
                ViewState["UserName"] = CommonFunction.GetCommoneString(this.txt_UserName.Text.Trim());//用户名
                ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_RealName.Text.Trim());//姓名
    
                DataBindList();
            }
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            SysUserEntity model = new SysUserEntity();
          
           model.UserType = (int)CommonEnum.UserType.校外人士;
           
            model.DepID = "-2";
            model.RoleID = "-2";
            model.ClassID = "-2";
            model.Isdel = (int)CommonEnum.IsorNot.否;
            model.UserName = ViewState["UserName"].ToString();
            model.RealName = ViewState["RealName"].ToString();
            DataTable dt = sysUserDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion

        #region 查询事件
        /// <summary>
        /// 点击查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            ViewState["UserName"] = CommonFunction.GetCommoneString(this.txt_UserName.Text.Trim());//用户名
            ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_RealName.Text.Trim());//姓名
            DataBindList();
        }
        #endregion

        #region 分页
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion



        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string ids = hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                string[] rid = ids.Split(',');
                string content = "";
                for (int i = 0; i < rid.Length; i++)
                {
                    SysUserEntity sysUser = sysUserDAL.GetObjByID(rid[i].ToString());
                    if (sysUser.UserName == "admin")
                    {
                        ShowMessage("删除失败！管理员账号不能删除！");
                        this.hf_CheckIDS.Value = "";
                        return;
                    }
                    if (i == rid.Length - 1)
                    {
                        content += sysUser.UserName;
                    }
                    else
                    {
                        content += sysUser.UserName + "、";
                    }
                    if (ConfigurationManager.AppSettings["LDAP"] == "1")
                    {
                        DataTable dt = sysUsergDAL.GetLDAP();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            LDapEntity model = new LDapEntity();
                            model.Path = dt.Rows[0]["Path"].ToString();
                            model.DN = dt.Rows[0]["DN"].ToString();
                            model.OU = dt.Rows[0]["OU"].ToString();
                            model.UserName = dt.Rows[0]["UserName"].ToString();
                            model.Psw = dt.Rows[0]["Psw"].ToString();
                            string Lresult = mDirectory.DeleteUser(model, sysUser.UserName);
                            if (Lresult == "")
                            { }
                            else
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.登录日志, "删除ldap用户【" + sysUser.UserName + "】失败。原因：" + Lresult, UserID));
                            }
                        }
                    }
                }
                int delresult = sysUserDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (delresult > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除【" + content + "】的用户信息", UserID));
                    ShowMessage("删除成功");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion

        #region 密码重置
        /// <summary>
        /// 密码重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_PassWord_Click(object sender, EventArgs e)
        {
            string ids = hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                string[] rid = ids.Split(',');
                string content = "";
                for (int i = 0; i < rid.Length; i++)
                {
                    SysUserEntity sysUser = sysUserDAL.GetObjByID(rid[i].ToString());
                    if (i == rid.Length - 1)
                    {
                        content += sysUser.UserName;
                    }
                    else
                    {
                        content += sysUser.UserName + "、";
                    }
                }

                string pwd = CommonFunction.Encrypt("888888");
                int delresult = sysUserDAL.PwdSet(ids, pwd);
                if (delresult > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "重置【" + content + "】的用户密码", UserID));
                    ShowMessage("密码重置成功");
                }

                else
                {
                    ShowMessage("密码重置失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "密码重置用户信息", UserID));
                return;
            }
        }
        #endregion

        #region 判断复选框是否可用
        /// <summary>
        /// 判断复选框是否可用
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetState(object state)
        {
            string usertype = state.ToString();
            if (Convert.ToInt32(usertype) == (int)CommonEnum.UserType.老师)
            {
                return "";
            }
            else
            {
                // return "disabled";
                return "";
            }
        }
        #endregion

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Response.Write("<script language=javascript>window.open('SysUserEdit.aspx?flag=3&ID=', '_self')</script>");
        }

        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string uid = lbtn.CommandArgument;
            Response.Write("<script language=javascript>window.open('SysUserEdit.aspx?flag=3&ID=" + uid + "', '_self')</script>");
        }


        #region 禁用
        protected void btn_Detain_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = sysUserDAL.UpdateUState(ids, (int)CommonEnum.UState.禁用);
                if (result > 0)
                {
                    ShowMessage("禁用成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "修改姓名为：" + UserRealName + "的状态为禁用", UserID));
                }
                else
                {
                    ShowMessage("禁用失败");
                    return;
                }
                DataBindList();
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