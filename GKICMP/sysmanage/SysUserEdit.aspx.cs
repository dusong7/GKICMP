/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      fsc
** 创建日期:    2017年02月27日
** 描 述:       用户编辑页面
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
using System.Data;
using System.Configuration;
using System.Transactions;

namespace GKICMP.sysmanage
{
    public partial class SysUserEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysRoleDAL sysRoleDAL = new SysRoleDAL();
        public CampusDAL campusDAL = new CampusDAL();
        public myDirectory A = new myDirectory();

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

        /// <summary>
        /// 1:教师 2：学生
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", 0);
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.XB>(this.ddl_UserSex, "-2");//性别

                CommonFunction.BindEnum<CommonEnum.MZ>(this.ddl_UserNation, "-2");//民族
    
                ddl_UserNation.Items.Remove(ddl_UserNation.Items.FindByText("--请选择--"));

                DataTable dt = campusDAL.GetList((int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_CID, dt, "CID", "CampusName", "-2");
                cblBand();//角色绑定

                if (Flag == 1)
                {
                    this.IsNot.Visible = true;
                }
                else 
                {
                    this.cb_IsOrNot.Checked = false;
                }

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

                this.DepID.Text = model.DepID;
                this.hf_UsersPwd.Value = CommonFunction.Decrypt(model.UserPwd);//密码
                this.txt_CellPhone.Text = model.CellPhone;//手机号
                this.txt_Address.Text = model.Address;//家庭地址
                this.txt_CompanyNum.Text = model.CompanyNum;//公司座机
                this.txt_MailNum.Text = model.MailNum;//邮箱
                this.txt_QQNum.Text = model.QQNum;//QQ号
                this.txt_WeiNum.Text = model.WeiNum;//微信号
                this.txt_CardNum.Text = model.CardNum;
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
                this.ddl_CID.SelectedValue = model.CID.ToString();
                this.txt_RealName.Text = model.RealName;//姓名 
                this.ddl_UserNation.SelectedValue = Convert.ToString(model.Nation.ToString());//民族
                this.hf_UState.Value = model.UState.ToString();//状态
                this.txt_UserDesc.Text = model.UserDesc;//描述
                if (model.Photos!=null&&model.Photos.ToString() != "")
                {
                    this.Image1.Visible = true;
                    this.Image1.ImageUrl = this.hf_UpFile.Value = model.Photos;
                }
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
            string a = "";
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
                model.CompanyNum = this.txt_CompanyNum.Text.Trim();
                model.MailNum = this.txt_MailNum.Text.Trim();
                model.QQNum = this.txt_QQNum.Text.Trim();
                model.WeiNum = this.txt_WeiNum.Text.Trim();
                model.BirthDay = Convert.ToDateTime(this.txt_BirthDay.Text.Trim());
                model.UserSex = Convert.ToInt32(this.ddl_UserSex.SelectedValue.ToString());
                //model.CardNum = this.txt_CardNum.Text;
                model.UserType = Flag;
                int isnot = 0;

                if (Flag == 1)
                {
               
                    if (this.cb_IsOrNot.Checked)
                        isnot = 1;

                }
             
                model.RealName = this.txt_RealName.Text.Trim();
                model.CreateUser = UserID;//UserID
                model.Nation = Convert.ToInt32(this.ddl_UserNation.SelectedValue.ToString());
                model.UState = (int)CommonEnum.UState.正常;
                model.UserDesc = this.txt_UserDesc.Text.Trim();
                //model.DepID = int.Parse(this.ddl_DepID.SelectedValue);
                // model.DepID = this.hf_SelectedValue.Value.TrimEnd(',');

                model.DepID = this.DepID.Text;

                //if (this.DepID.Text != "")
                //{
                //    model.DepID = this.DepID.Text;
                //}
                //else 
                //{
                //    ShowMessage("请选择所属部门");
                //    return;
                //}
               
                model.CardNum = this.txt_CardNum.Text.Trim();
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.CID = Convert.ToInt32(this.ddl_CID.SelectedValue.ToString());

                string roles = "";
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
                if (ConfigurationManager.AppSettings["IsOpenC"] == "1")
                {
                    if (model.Photos == "")
                    {
                        ShowMessage("请选择照片");
                        return;
                    }
                    a = HttpContext.Current.Server.MapPath(model.Photos);
                    string token = Face.Detect(HttpContext.Current.Server.MapPath(model.Photos));
                    if (token.IndexOf("$error:") < 0)
                    {
                        //成功,记录facesettoken
                        int addresult = Face.AddFaceSet(ConfigurationManager.AppSettings["faceset_token"], token);
                        if (addresult > 0)
                            model.FaceNum = token;
                        else
                            model.FaceNum = "";
                    }
                    else
                    {
                        model.FaceNum = "";
                    }
                }
                else { model.FaceNum = ""; }
                int result = 0;
                string mssg = "";
                string ld = "";
                //if (ConfigurationManager.AppSettings["LDAP"] == "1")
                //{
                //    using (TransactionScope ts = new TransactionScope())
                //    {
                //        try
                //        {
                //            result = sysUserDAL.Edit(model, id, isnot);
                //            if (result == 0)
                //            {
                //                DataTable dt = sysUserDAL.GetLDAP();
                //                if (dt != null && dt.Rows.Count > 0)
                //                {
                //                    LDapEntity lmodel = new LDapEntity();
                //                    lmodel.Path = dt.Rows[0]["Path"].ToString();
                //                    lmodel.DN = dt.Rows[0]["DN"].ToString();
                //                    lmodel.OU = dt.Rows[0]["OU"].ToString();
                //                    lmodel.UserName = dt.Rows[0]["UserName"].ToString();
                //                    lmodel.Psw = dt.Rows[0]["Psw"].ToString();
                //                    ld = A.CreateNewUser(lmodel, model.UserName, model.RealName, lmodel.OU, UID == "" ? "888888" : this.hf_UsersPwd.Value, model.RealName.Substring(0, 1));
                //                    if (ld == "")
                //                    {
                //                    }
                //                    else 
                //                    {
                //                        ShowMessage(ld);
                //                        return;
                //                    }
                //                }
                //                else
                //                {
                //                    ShowMessage("请配置LDAP地址"); return;
                //                }
                //                if (mssg == "")
                //                {
                //                    ts.Complete();
                //                }
                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            ShowMessage(ex.Message);
                //            ld += "," + ex.Message;
                //            //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                //        }
                //        finally
                //        {
                //            ts.Dispose();
                //            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ld, UserID));
                //        }
                //    }
                //}
                //else
                //{
                //    result = sysUserDAL.Edit(model, id, isnot);
                //}
                result = sysUserDAL.Edit(model, id, isnot);
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
                    //是否开启ldap服务
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
                            if (UID == "")
                                ld = A.CreateNewUser(lmodel, model.UserName, model.RealName, lmodel.OU, "888888", model.RealName.Substring(0, 1));
                            else
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
                    //是否启用企业号
                    //string isopen = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "WX//IsOpen");
                    WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "TXL", 2);
                    string url = "SysUserManage.aspx";
                    if (Flag == 3)
                    {
                        url = "WSysUserManage.aspx";
                    }
                    if (model1.IsOpen == 1)
                    {
                        string message = WXEdit(model);
                        if (message == "0")
                        {
                            if (UID == "")
                            {
                                int uid = sysUserDAL.UpdateUserID(this.hf_ID.Value);
                            }
                            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加,(UID==""?"添加":"修改")+ "【" + this.txt_UserName.Text + "】的用户", UserID));
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功');window.location='"+url+"';", true);
                        }
                        else 
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('保存成功，但未同步到微信！');window.location='" + url + "';", true);
                            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, message, UserID));
                            return;
                        }
                        
                    }
                    else
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, UID == "" ? "增加" : "修改" + "【" + this.txt_UserName.Text + "】的用户", UserID));
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='" + url + "';", true);
                    }
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message + a, UserID));
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
            string token = WeixinQYAPI.GetToken(2, "0");
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
                   return WeixinQYAPI.CreateUser(token, json);
                    //if (msg == "0")
                    //{
                    //    int message = sysUserDAL.UpdateUserID(this.hf_ID.Value);
                    //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "增加【" + this.txt_UserName.Text + "】的用户", UserID));
                    //    return "提交成功";
                    //    // Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！但未同步到微信');window.location='SysUserManage.aspx';", true);
                    //}
                    //else
                    //{
                    //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "增加【" + this.txt_UserName.Text + "】的用户", UserID));
                    //    //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！但未同步到微信');window.location='SysUserManage.aspx';", true);
                    //    return "提交成功！但未同步到微信";
                    //}
                }
                else//修改
                {
                   return WeixinQYAPI.UpdateUser(token, json);
                    //if (msg == "0")
                    //{
                    //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改【" + this.txt_UserName.Text + "】的用户", UserID));
                    //    return "提交成功";
                    //    //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功');window.location='SysUserManage.aspx';", true);
                    //}
                    //else
                    //{
                    //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改【" + this.txt_UserName.Text + "】的用户", UserID));
                    //    return "提交成功！但未同步到微信";
                    //    // Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！但未同步到微信');window.location='SysUserManage.aspx';", true);
                    //}
                }
            }
            else
            {
                //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, UID == "" ? "增加" : "修改" + "【" + this.txt_UserName.Text + "】的用户", UserID));
                return "提交成功，但微信凭证调用失败";
            }
        }
        #endregion
    }
}