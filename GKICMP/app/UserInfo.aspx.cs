using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Text;

namespace GKICMP.app
{
    public partial class UserInfo : PageBaseApp
    {
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
                if (UserID != "")
                {
                    InfoBind();//信息绑定
                }
            }
        }
        #endregion


        #region 信息绑定
        /// <summary>
        /// 信息绑定
        /// </summary>
        protected void InfoBind()
        {
            try
            {
                SysUserEntity model = new SysUserDAL().GetObjByID(UserID);
                if (model != null)
                {
                    hf_OldPwd.Value = model.UserPwd;
                    // this.hf_Face.Value = model.PreStr;
                    //this.hf_RealName.Value = model.RealName;
                    //this.hf_depart.Value = model.DepIDs;
                    //this.hf_SysBirth.Value = model.SysBirth;
                    //this.hf_MState.Value = model.SysSex.ToString();
                    //this.hf_JobDate.Value = model.JobDate.ToString("yyyy-MM-dd");

                    // DirectoriesEntity dmodel = DirectoriesBLL.GetObj(UserID, 2);

                    this.txt_RealName.Text = model.RealName;
                    this.txt_CellPhone.Text = model.CellPhone;  //手机号码
                    this.txt_CellPhone.Enabled = true;
                    // this.txt_TellPhone.Text = model.TellPhone;  //备用号码
                    this.txt_Address.Text = model.Address;     //家庭地址
                    this.txt_CompanyNum.Text = model.CompanyNum;//公司座机
                    this.txt_MailNum.Text = model.MailNum;  //邮箱
                    this.txt_QQNum.Text = model.QQNum;      //QQ号
                    this.txt_WeiNum.Text = model.WeiNum;   //微信号
                }
            }
            catch (Exception ex )
            {

                ShowMessage("系统出错，请稍后再试");
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                SysUserEntity model = new SysUserEntity();

                if (txt_OldPwd.Text.Trim() != "" && CommonFunction.Encrypt(txt_OldPwd.Text.Trim()) != hf_OldPwd.Value)
                {
                    ShowMessage("原密码输入错误，请重新输入");
                    return;
                }
                else if (txt_OldPwd.Text.Trim() != "" && txt_SysPwd.Text.Trim() != txt_AgainPwd.Text.Trim())
                {
                    ShowMessage("两次输入密码不一致，请重新输入");
                    return;
                }
                //else
                //{
                //   if(this.txt)
                if (txt_SysPwd.Text.Trim() == "")
                    model.UserPwd = hf_OldPwd.Value;
                else
                    model.UserPwd = CommonFunction.Encrypt(txt_SysPwd.Text.Trim());
                model.Address = this.txt_Address.Text;//家庭地址
                model.CompanyNum = this.txt_CompanyNum.Text;//公司座机
                model.MailNum = this.txt_MailNum.Text;//邮箱
                model.QQNum = this.txt_QQNum.Text; //QQ号
                model.WeiNum = this.txt_WeiNum.Text;//微信号
                model.UID = UserID;
                model.RealName = this.txt_RealName.Text;
                int result = new SysUserDAL().EditAPP(model);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else
                {
                    Response.Cookies["SysUserPwd"].Value = model.UserPwd;
                    ShowMessage("提交成功");
                    InfoBind();
                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message+"【微信操作】", UserID));
                return;
            }
        }
        #endregion

        protected void btn_UChange_Click(object sender, EventArgs e)
        {
            if (this.hf_UserID.Value != "")
            {
                SysUserEntity model = new SysUserDAL().GetObjByID(this.hf_UserID.Value);
                if (model != null)
                {
                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", "登录名:" + model.RealName + "\t\n", false);
                    Response.Cookies["UserType"].Value = model.UserType.ToString();
                    Response.Cookies["UserID"].Value = CommonFunction.Encrypt(model.UID.ToString());
                    Response.Cookies["SysUserName"].Value = model.UserName;
                    Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(model.RealName, Encoding.GetEncoding("UTF-8"));
                    Response.Cookies["SysUserPwd"].Value = model.UserPwd;
                    SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + model.RealName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统【微信客户端切换帐号登录】", model.UID);
                    new SysLogDAL().Edit(log);
                    string url = "";
                    if (model.UserType == (int)CommonEnum.UserType.老师)
                        url = "APPMain.aspx";
                    else if (model.UserType == (int)CommonEnum.UserType.学生)
                        url = "../appstu/Stu_AppMain.aspx";
                    else
                        url = "RepairTransfer.aspx";
                    ShowMessage("切换成功");
                    Response.Redirect(url, false);
                    //if (!string.IsNullOrEmpty(id))
                    //    Response.Redirect("AppRepair.aspx?id=1", false);
                    //else
                    //    Response.Redirect("APPMain.aspx", false);
                }
                else
                {
                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", "登录名:" + model.UserName + "--" +DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+ "\t\n", false);
                    Response.Redirect("Test.html", false);
                }
            }
            else 
            {
                ShowMessage("请选择帐号");
            }
        }
    }
}