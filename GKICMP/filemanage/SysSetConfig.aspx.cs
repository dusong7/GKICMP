/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年02月27日
** 描 述:       水印设置编辑页面
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
using System.Text;
using System.Configuration;

namespace GKICMP.filemanage
{
    public partial class SysSetConfig : PageBase
    {
        public SysSetConfigDAL sysSetConfigDAL = new SysSetConfigDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();



        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SysSetConfigEntity model = sysSetConfigDAL.GetObjByID();
                if (model != null)
                {
                    if (model.WatermarkType == 2)
                    {
                        this.Image1.ImageUrl = model.WatermarkContent;
                        this.txt.Visible = false;
                        this.more.Visible = true;
                        this.Image1.Visible = true;
                    }
                    else
                    {
                        this.txt_LanIP.Text = model.WatermarkContent;
                        this.more.Visible = false;
                        this.txt.Visible = true;
                        this.Image1.Visible = false;
                    }
                    this.rbtn_WaterType.SelectedValue = model.WatermarkType.ToString();
                }
            }
        }
        #endregion


        #region 判断
        private void PD()
        {
            SysSetConfigEntity model = sysSetConfigDAL.GetObjByID();
            if (this.rbtn_WaterType.SelectedValue == "2")
            {
                this.txt.Visible = false;
                this.more.Visible = true;
                this.Image1.Visible = true;

                if (model != null)
                {
                    if (model.WatermarkType == 2)
                    {
                        this.txt_LanIP.Text = "";
                    }
                    else
                    {
                        this.Image1.ImageUrl = "";
                    }
                }
            }
            else
            {
                this.more.Visible = false;
                this.txt.Visible = true;
                this.Image1.Visible = false;
                if (model != null)
                {
                    if (model.WatermarkType == 1)
                    {
                        this.Image1.ImageUrl = "";
                    }
                    else
                    {
                        this.txt_LanIP.Text = "";
                    }
                }
            }
        }
        #endregion



        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                SysSetConfigEntity model = new SysSetConfigEntity();
                model.WatermarkType = Convert.ToInt32(this.rbtn_WaterType.SelectedValue);
                if (model.WatermarkType == 2)
                {
                    //上传图片
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
                        {
                            model.WatermarkContent = accessinfo.AccessUrl;
                        }
                        else
                        {
                            model.WatermarkContent = this.hf_UpFile.Value;
                        }
                    }
                }
                else
                {
                    model.WatermarkContent = this.txt_LanIP.Text.Trim();
                }
                int result = sysSetConfigDAL.Edit(model);
                if (result > 0)
                {
                    ShowMessage();
                    SysSetConfigEntity model1 = sysSetConfigDAL.GetObjByID();
                    if (model != null)
                    {
                        if (model.WatermarkType == 2)
                        {
                            this.Image1.ImageUrl = model1.WatermarkContent;
                            this.txt.Visible = false;
                            this.more.Visible = true;
                            this.Image1.Visible = true;
                        }
                        else
                        {
                            this.txt_LanIP.Text = model1.WatermarkContent;
                            this.more.Visible = false;
                            this.txt.Visible = true;
                            this.Image1.Visible = false;
                        }
                        this.rbtn_WaterType.SelectedValue = model.WatermarkType.ToString();
                    }
                    sysLogDAL.Edit(new SysLogEntity(((int)CommonEnum.LogType.操作日志_其他), "更新水印设置", UserID));
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity(((int)CommonEnum.LogType.系统日志), ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 判断是文字还是图片
        protected void rbtn_WaterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PD();
        }
        #endregion
    }
}