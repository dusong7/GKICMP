/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      网站站点管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.cms
{
    public partial class SiteEdit : PageBase
    {
        public Web_SiteDAL web_SiteDAL = new Web_SiteDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// SID 站点ID
        /// </summary>
        public int SID
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
                InfoBind();
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            Web_SiteEntity model = web_SiteDAL.GetObjByID(1);
            if (model != null)
            {
                this.txt_CompanyName.Text = model.CompanyName.ToString();
                this.txt_WebTtitle.Text = model.WebTtitle.ToString();
                this.txt_AttachTtile.Text = model.AttachTtile.ToString();
                this.txt_DWebsite.Text = model.DWebsite.ToString();
                this.txt_LinkUser.Text = model.LinkUser.ToString();
                this.txt_TellPhone.Text = model.TellPhone.ToString();
                this.txt_CellPhone.Text = model.CellPhone.ToString();
                this.txt_Fax.Text = model.Fax.ToString();
                this.txt_EmailCode.Text = model.EmailCode.ToString();
                this.txt_PostCode.Text = model.PostCode.ToString();
                this.txt_RecordCode.Text = model.RecordCode.ToString();
                this.txt_Address.Text = model.Address.ToString();
                this.txt_TotelCode.Text = model.TotelCode.ToString();
                this.txt_Copyright.Text = model.Copyright.ToString();
                this.txt_SiteKey.Text = model.SiteKey.ToString();
                this.txt_SitePath.Text = model.SitePath.ToString();
                this.txt_SiteDesc.Text = model.SiteDesc.ToString();
                if (model.LogoUrl != "")
                {
                    this.img_Logo.ImageUrl = this.hf_Logo.Value = model.LogoUrl.ToString();
                }
                if (model.IcoUrl != "")
                {
                    this.img_Icon.ImageUrl = this.hf_UpFile.Value = model.IcoUrl.ToString();
                }
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
                Web_SiteEntity model = new Web_SiteEntity();
                model.SID = SID;
                model.CompanyName = this.txt_CompanyName.Text.ToString().Trim();
                model.WebTtitle = this.txt_WebTtitle.Text.ToString().Trim();
                model.AttachTtile = this.txt_AttachTtile.Text.ToString().Trim();
                model.DWebsite = this.txt_DWebsite.Text.ToString().Trim();
                model.SitePath = this.txt_SitePath.Text.ToString().Trim();
                model.LinkUser = this.txt_LinkUser.Text.ToString().Trim();
                model.TellPhone = this.txt_TellPhone.Text.ToString().Trim();
                model.CellPhone = this.txt_CellPhone.Text.ToString().Trim();
                model.Fax = this.txt_Fax.Text.ToString().Trim();
                model.EmailCode = this.txt_EmailCode.Text.ToString().Trim();
                model.PostCode = this.txt_PostCode.Text.ToString().Trim();
                model.RecordCode = this.txt_RecordCode.Text.ToString().Trim();
                model.Address = this.txt_Address.Text.ToString().Trim();
                model.TotelCode = this.txt_TotelCode.Text.ToString().Trim();
                model.Copyright = this.txt_Copyright.Text.ToString().Trim();
                model.SiteKey = this.txt_SiteKey.Text.ToString().Trim();
                model.SiteDesc = this.txt_SiteDesc.Text.ToString().Trim();
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                //上传图片
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) 
                { 

                }
                int start = Convert.ToInt32(this.hf_Logo.Value.Trim());
                AccessoryEntity logo = CommonFunction.upfile(0, start, hf_Logo, "ImageUrl");
                AccessoryEntity icon = CommonFunction.upfile(start, start + Convert.ToInt32(hf_UpFile.Value.Trim()), hf_UpFile, "ImageUrl");

                if (logo.AccessID == "-2" && logo.AccessUrl != "")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(this.hf_Logo.Value.ToString());
                    ShowMessage(logo.AccessName);
                    return;
                }
                else
                {
                    model.LogoUrl = logo.AccessUrl == "" ? img_Logo.ImageUrl : logo.AccessUrl;
                }
                if (icon.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_UpFile.Value.ToString());
                    ShowMessage(icon.AccessName);
                    return;
                }
                else
                {
                    model.IcoUrl = icon.AccessUrl == "" ? img_Icon.ImageUrl : icon.AccessUrl;
                }

                int result = web_SiteDAL.Edit(model);
                if (result > 0)
                {

                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改单位名称为：" + this.txt_CompanyName.Text.ToString(), UserID));
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');</script>");
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion

    }
}