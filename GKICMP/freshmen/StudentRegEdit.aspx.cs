/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       学生信息管理编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;

namespace GKICMP.freshmen
{
    public partial class StudentRegEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysRoleDAL sysRoleDAL = new SysRoleDAL();
        #region 参数集合
        /// <summary>
        /// UID
        /// </summary>
        public string UID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //DataTable dt = departmentDAL.GetDepList((int)CommonEnum.IsorNot.否);
                //CommonFunction.DDlTypeBind(this.ddl_DepID,dt,"DID","DepName","-2");
                //CommonFunction.BindEnum<CommonEnum.UserType>(this.ddl_UserType, "-2");//用户类别
                
                CommonFunction.BindEnum<CommonEnum.XB>(this.ddl_UserSex, "-2");//性别
                CommonFunction.BindEnum<CommonEnum.MZ>(this.ddl_UserNation, "-2");//民族
                cblBand();

                if (UID != "")
                {
                    this.hf_ID.Value = UID;
                    this.txt_UserName.Enabled = false;
                    InfoBind();
                }
                else
                {
                    this.hf_ID.Value = Guid.NewGuid().ToString();
                }

            }
        }

        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            SysUserEntity model = sysUserDAL.GetObjByID(UID);
            if (model != null)
            {
                this.txt_UserName.Text = model.UserName;//有用户名
                if (model.IDCard != null && model.IDCard != "")
                {
                    this.txt_IDCard.Text = model.IDCard;//身份证
                }
                else
                {
                    this.txt_IDCard.Text = "";
                }
                //this.ddl_DepID.SelectedValue = model.DepID.ToString();
               // this.hf_SelectedValue.Value = model.DepID.ToString();
                this.hf_UsersPwd.Value = CommonFunction.Decrypt(model.UserPwd);//密码
                this.txt_CellPhone.Text = model.CellPhone;//手机号
                this.txt_Address.Text = model.Address;//家庭地址
            //    this.txt_CompanyNum.Text = model.CompanyNum;//公司座机
                this.txt_MailNum.Text = model.MailNum;//邮箱
                this.txt_QQNum.Text = model.QQNum;//QQ号
                this.txt_WeiNum.Text = model.WeiNum;//微信号
                this.txt_Mark.Text = model.Mark.ToString();
                if (model.BirthDay != null && model.BirthDay.ToString("yyyy-MM") != "0001-01")
                {
                    this.txt_BirthDay.Text = model.BirthDay.ToString("yyyy-MM");//出生日期
                }
                else
                {
                    this.txt_BirthDay.Text = "";
                }
                this.ddl_UserSex.SelectedValue = Convert.ToString(model.UserSex.ToString());//性别
                //this.ddl_UserType.SelectedValue = model.UserType.ToString();//类型
                this.txt_RealName.Text = model.RealName;//姓名 
                this.ddl_UserNation.SelectedValue = Convert.ToString(model.Nation.ToString());//民族
                this.hf_UState.Value = model.UState.ToString();//状态
                this.txt_UserDesc.Text = model.UserDesc;//描述
                //this.txt_CardNum.Text = model.CardNum;//一卡通
                DataTable TypeR = sysRoleDAL.GetTable(UID);
                foreach (DataRow dr in TypeR.Rows)
                {
                    string value = dr["RoleID"].ToString();
                    foreach (ListItem li in this.cbl_Role.Items)
                    {
                        if (value == li.Value)
                        {
                            li.Selected = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region 角色绑定


        /// <summary>
        /// 角色绑定
        /// </summary>
        private void cblBand()
        {
            //checkboxlist 绑定
            DataTable TypeR = sysRoleDAL.GetList(1, (int)CommonEnum.Deleted.未删除);
            CommonFunction.CBLTypeBind(this.cbl_Role, TypeR, "RoleID", "RoleName");
        }

        #endregion

        #region 提交
        /// <summary>
        /// 点击提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                SysUserEntity model = new SysUserEntity();
                model.UID = this.hf_ID.Value;
                model.UserName = this.txt_UserName.Text.Trim();
                if (this.txt_IDCard.Text.Trim().Length < 18 || this.txt_IDCard.Text.Trim().Length > 18)
                {
                    ShowMessage("身份证号为18位,请重新输入");
                    return;
                }
                else
                {
                    model.IDCard = this.txt_IDCard.Text.Trim();//身份证
                }
                if (UID == "")
                {
                    model.UserPwd = CommonFunction.Encrypt("888888");
                    id = 1;
                }
                else
                {
                    model.UserPwd = CommonFunction.Encrypt(this.hf_UsersPwd.Value.Trim().ToString());
                }
                model.CellPhone = this.txt_CellPhone.Text.Trim();
                model.Address = this.txt_Address.Text.Trim();
                model.CompanyNum = "";
                model.MailNum = this.txt_MailNum.Text.Trim();
                model.QQNum = this.txt_QQNum.Text.Trim();
                model.WeiNum = this.txt_WeiNum.Text.Trim();
                model.BirthDay = Convert.ToDateTime(this.txt_BirthDay.Text.Trim());
                model.UserSex = Convert.ToInt32(this.ddl_UserSex.SelectedValue.ToString());
                model.UserType = 3;
                model.RealName = this.txt_RealName.Text.Trim();
                model.CreateUser = UserID;//UserID
                model.Nation = Convert.ToInt32(this.ddl_UserNation.SelectedValue.ToString());
                model.UState = (int)CommonEnum.UState.正常;
                model.UserDesc = this.txt_UserDesc.Text.Trim();
                //model.DepID = int.Parse(this.ddl_DepID.SelectedValue);
                model.DepID = "0";
                //model.CardNum = this.txt_CardNum.Text.Trim();
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                string roles = "";
                decimal mark;
                try
                {
                    mark = decimal.Parse(this.txt_Mark.Text == "" ? "0" : this.txt_Mark.Text);
                }
                catch (Exception)
                {
                    ShowMessage("请填写正确的分数");
                    return;
                }
                //绑定角色
                foreach (ListItem li in this.cbl_Role.Items)
                {
                    if (li.Selected)
                    {
                        roles = roles + li.Value + ",";
                    }
                }

                if (roles.Length > 0)
                {
                    roles = roles.Substring(0, roles.Length);
                }
                model.Roles = roles;

                int result = sysUserDAL.StuRegAdd(model,id,mark);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该用户名已经存在，请重新输入");
                    return;
                }
                else if (result == -3)
                {
                    ShowMessage("该身份证已经存在，请重新输入");
                    return;
                }
                else
                {
                    //是否启用企业号
                    WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Main", 2);
                    if (model1.IsOpen == 1)
                    {
                        string message = WXEdit(model);
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('" + message + "');window.location='SysUserManage.aspx';", true);
                    }
                    else
                    {
                        int log = UID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                        sysLogDAL.Edit(new SysLogEntity(log, UID == "" ? "增加" : "修改" + "【" + this.txt_UserName.Text + "】的用户", UserID));
                        ShowMessage();
                       // Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='SysUserManage.aspx';", true);
                    }
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
                return;
            }
        }
        /// <summary>
        /// 增加或修改企业微信用户信息
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns>返回结果是否成功</returns>
        private string WXEdit(SysUserEntity model)
        {
            string token = WeixinQYAPI.GetToken(2,"0");
            if (token != "")
            {
                string json = "{ \"userid\": \"" + model.CellPhone
                                + "\", \"name\": \"" + model.RealName
                                + "\",\"department\": [" + model.DepID
                                + "],\"position\": \"\",\"mobile\": \"" + model.CellPhone
                                + "\",\"gender\": \"" + model.UserSex
                                + "\",\"email\": \"" + model.MailNum
                                + "\", \"weixinid\": \"" + model.WeiNum + "\"}";
                if (UID == "")//新增用户
                {
                    string msg = WeixinQYAPI.CreateUser(token, json);
                    if (msg == "0")
                    {
                        int message = sysUserDAL.UpdateUserID(this.hf_ID.Value);
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "增加【" + this.txt_UserName.Text + "】的用户", UserID));
                        return "提交成功";
                        // Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！但未同步到微信');window.location='SysUserManage.aspx';", true);
                    }
                    else
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "增加【" + this.txt_UserName.Text + "】的用户", UserID));
                        //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！但未同步到微信');window.location='SysUserManage.aspx';", true);
                        return "提交成功！但未同步到微信";
                    }
                }
                else//修改
                {
                    string msg = WeixinQYAPI.UpdateUser(token, json);
                    if (msg == "0")
                    {

                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "修改【" + this.txt_UserName.Text + "】的用户", UserID));
                        return "提交成功";
                        //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功');window.location='SysUserManage.aspx';", true);
                    }
                    else
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改【" + this.txt_UserName.Text + "】的用户", UserID));
                        return "提交成功！但未同步到微信";
                        // Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！但未同步到微信');window.location='SysUserManage.aspx';", true);
                    }
                }
            }
            else
            {
                int log = UID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                sysLogDAL.Edit(new SysLogEntity(log, UID == "" ? "增加" : "修改" + "【" + this.txt_UserName.Text + "】的用户", UserID));
                return "提交成功，但微信凭证调用失败";
            }

        }
        #endregion
    }
}