/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      czz
** 创建日期:    2017年03月13日
** 描 述:       用户个人编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Data;

namespace GKICMP.sysmanage
{
    public partial class SysUserInfo : NullPageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public myDirectory A = new myDirectory();
        #region 参数集合
        /// <summary>
        /// UID
        /// </summary>
        public string UID
        {
            get
            {
                return UserID;

            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            
            string pwd = CommonFunction.Encrypt("123");
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.UserType>(this.ddl_UserType, "-2");//用户类别
                CommonFunction.BindEnum<CommonEnum.XB>(this.ddl_UserSex, "-2");//性别
                CommonFunction.BindEnum<CommonEnum.MZ>(this.ddl_UserNation, "-2");//民族

                if (UID != "")
                {
                    this.txt_UserName.Enabled = false;
                    InfoBind();
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
                this.txt_IDCard.Enabled = false;
                this.hf_UsersPwd.Value = CommonFunction.Decrypt(model.UserPwd);//密码
                this.txt_CellPhone.Text = model.CellPhone;//手机号
                this.txt_Address.Text = model.Address;//家庭地址
                this.txt_CompanyNum.Text = model.CompanyNum;//公司座机
                this.txt_MailNum.Text = model.MailNum;//邮箱
                this.txt_QQNum.Text = model.QQNum;//QQ号
                this.txt_WeiNum.Text = model.WeiNum;//微信号
                if (model.BirthDay != null && model.BirthDay.ToString("yyyy-MM") != "0001-01")
                {
                    this.txt_BirthDay.Text = model.BirthDay.ToString("yyyy-MM");//出生日期
                }
                else
                {
                    this.txt_BirthDay.Text = "";
                }
                this.ddl_UserSex.SelectedValue = Convert.ToString(model.UserSex.ToString());//性别
                this.ddl_UserType.SelectedValue = model.UserType.ToString();//类型
                this.ddl_UserType.Enabled = false;
                this.txt_RealName.Text = model.RealName;//姓名 
                this.ddl_UserNation.SelectedValue = Convert.ToString(model.Nation.ToString());//民族
                this.hf_UState.Value = model.UState.ToString();//状态
                this.txt_CardNum.Text = model.CardNum;//一卡通
                if (model.Photos != null && model.Photos.ToString() != "")
                {
                    this.Image1.Visible = true;
                    this.Image1.ImageUrl = this.hf_UpFile.Value = model.Photos;
                }
            }
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
            if (UID == "")
            {
                return;
            }
            try
            {
                SysUserEntity model = new SysUserEntity();
                model.UID = UID;
                model.UserName = this.txt_UserName.Text.Trim();
                string pwd = sysUserDAL.GetObjByID(UID).UserPwd;
                if (this.txt_OldPwd.Text.Trim() != "")
                {
                    if (CommonFunction.Encrypt(this.txt_OldPwd.Text) != pwd)
                    {
                        ShowMessage("原密码输入错误，请重新输入！");
                        return;
                    }
                    if (this.txt_SysPwd.Text.Trim() == "")
                    {
                        ShowMessage("新密码不能为空，请重新输入！");
                        return;
                    }
                    if (this.txt_SysPwd.Text != this.txt_AgainPwd.Text)
                    {
                        ShowMessage("两次输入密码不一致，请重新输入！");
                        return;
                    }
                    model.UserPwd = CommonFunction.Encrypt(this.txt_SysPwd.Text);
                }
                else
                {
                    model.UserPwd = pwd;
                }
                if (this.txt_IDCard.Text.Trim().Length < 18 || this.txt_IDCard.Text.Trim().Length > 18)
                {
                    ShowMessage("身份证号为18位,请重新输入");
                    return;
                }
                else
                {
                    model.IDCard = this.txt_IDCard.Text.Trim();//身份证
                }

                model.CellPhone = this.txt_CellPhone.Text.Trim();
                model.Address = this.txt_Address.Text.Trim();
                model.CompanyNum = this.txt_CompanyNum.Text.Trim();
                model.MailNum = this.txt_MailNum.Text.Trim();
                model.QQNum = this.txt_QQNum.Text.Trim();
                model.WeiNum = this.txt_WeiNum.Text.Trim();
                model.BirthDay = Convert.ToDateTime(this.txt_BirthDay.Text.Trim());
                model.UserSex = Convert.ToInt32(this.ddl_UserSex.SelectedValue.ToString());
                model.UserType = Convert.ToInt32(this.ddl_UserType.SelectedValue.ToString());
                model.RealName = this.txt_RealName.Text.Trim();
                model.CreateUser = UserID;//UserID
                model.Nation = Convert.ToInt32(this.ddl_UserNation.SelectedValue.ToString());
                model.UState = (int)CommonEnum.State.启用;
                //model.UserDesc = sysUserDAL.GetObjByID(UID).UserDesc;
                model.CardNum = this.txt_CardNum.Text.Trim();
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.DepID = "";
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_UpFile, "ImageUrl");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_UpFile.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_UpFile.HasFile)
                        model.Photos = accessinfo.AccessUrl;
                    else
                        model.Photos = this.hf_UpFile.Value;
                }
                int result = sysUserDAL.Update(model);
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
                    int log = UID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (UID == "" ? "添加" : "修改") + "【" + this.txt_UserName.Text + "】的用户", UserID));
                    string ld = "";
                    if (ConfigurationManager.AppSettings["LDAP"] == "1")
                    {
                        DataTable dt = sysUserDAL.GetLDAP();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            LDapEntity lmodel = new LDapEntity();
                            lmodel.Path = dt.Rows[0]["Path"].ToString();
                            lmodel.DN = dt.Rows[0]["DN"].ToString();
                            lmodel.OU = dt.Rows[0]["OU"].ToString();
                            lmodel.UserName = dt.Rows[0]["UserName"].ToString();
                            lmodel.Psw = dt.Rows[0]["Psw"].ToString();
                            ld = A.ModifyUser(lmodel, model.UserName, model.RealName, lmodel.OU, model.UserPwd, model.RealName.Substring(0, 1));
                            if (ld == "")
                            {
                            }
                            else
                            {
                                ShowMessage(ld);
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ld, UserID));
                                //return;
                            }
                        }
                        else
                        {
                            ShowMessage("请配置LDAP地址");
                            // return;
                        }
                    }
                    ShowScript("alert('保存成功！');window.location='sysmanage/SysUserManage.aspx'");
                    Response.Cookies["SysUserPwd"].Value = model.UserPwd;

                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}