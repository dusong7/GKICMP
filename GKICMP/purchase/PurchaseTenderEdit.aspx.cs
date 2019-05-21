/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月17日 09点30分
** 描   述:      招标信息添加修改
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Data;
using System.IO;
using System.Configuration;

namespace GKICMP.purchase
{
    public partial class PurchaseTenderEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Project_TenderDAL project_TenderDAL = new Project_TenderDAL();
        public SupplierDAL supplierDAL = new SupplierDAL();
        public PurchaseDAL purchaseDAL = new PurchaseDAL();
        public AccessoryDAL accessoryDAL = new AccessoryDAL();
        #region 参数
        public string PTID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = supplierDAL.GetList((int)CommonEnum.IsorNot.否, "");
                CommonFunction.DDlTypeBind(this.ddl_SName, dt, "SDID", "SupplierName", "-2");

                // DataTable dtp = jZProjectManageDAL.GetList((int)CommonEnum.IsorNot.否);
                PurchaseEntity model = new PurchaseEntity();
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.PLState = (int)CommonEnum.AduitState.通过;
                model.IsChecked = (int)CommonEnum.Deleted.未删除;
                DataTable dtp = purchaseDAL.List(model);//获取验收状态为0的项目名称
                CommonFunction.DDlTypeBind(this.ddl_ProName, dtp, "PID", "PTitle", "-2");
                if (PTID != "")
                {
                    BindInfo();
                }
                else
                {
                    this.hf_FileID.Value = Guid.NewGuid().ToString();
                }

            }
        }
        #endregion
        #region 信息绑定
        public void BindInfo()
        {
            try
            {
                Project_TenderEntity model = project_TenderDAL.GetObjByID(PTID);
                this.ddl_ProName.SelectedValue = model.PID;
                this.txt_BidNumber.Text = model.BidNumber;
                this.ddl_ProName.SelectedValue = model.PID;
                this.ddl_SName.SelectedValue = model.SID;
                this.txt_BDate.Text = model.BDate.ToString("yyyy-MM-dd");
                this.txt_BAmount.Text = model.BAmount.ToString();
                this.txt_BSDate.Text = model.BSDate.ToString("yyyy-MM-dd");
                this.txt_BEDate.Text = model.BEDate.ToString("yyyy-MM-dd");
                this.txt_BondDate.Text = model.BondDate.ToString("yyyy-MM-dd");
                this.txt_Bond.Text = model.Bond.ToString();
                this.txt_PTDesc.Text = model.PTDesc;
                this.hf_FileID.Value = model.FileID;
                AccessBind(rp_File, model.FileID, (int)CommonEnum.AccessoryType.Tb_Tender);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion

        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Project_TenderEntity model = new Project_TenderEntity();
                model.PTID = PTID;//id
                model.BidNumber = this.txt_BidNumber.Text;//招标编号
                model.PID = this.ddl_ProName.SelectedValue;//
                model.SID = this.ddl_SName.SelectedValue;//
                model.BDate = Convert.ToDateTime(this.txt_BDate.Text);//
                model.BAmount = decimal.Parse(this.txt_BAmount.Text);///
                model.BSDate = Convert.ToDateTime(this.txt_BSDate.Text);//
                model.BEDate = Convert.ToDateTime(this.txt_BEDate.Text);//
                model.BondDate = Convert.ToDateTime(this.txt_BondDate.Text);//
                model.Bond = decimal.Parse(this.txt_Bond.Text);//
                model.PTDesc = this.txt_PTDesc.Text;//
                model.CreateDate = DateTime.Now;//
                model.CreateUser = UserID;//
                model.Isdel = (int)CommonEnum.IsorNot.否;//
                model.FileID = this.hf_FileID.Value;
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, Convert.ToInt32(hf_UpFile.Value.Trim()), hf_UpFile, "profile");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_UpFile.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    accessinfo.AccessFlag = (int)CommonEnum.AccessoryType.Tb_Tender;
                    accessinfo.AccessObjID = this.hf_FileID.Value;
                    accessinfo.ObjID = "";
                }


                int result = project_TenderDAL.Edit(model, accessinfo);
                if (result == 0)
                {
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("标书编号不能重复，请修改后重新提交");
                    return;
                }
                else { ShowMessage("提交失败"); }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion

        #region 附件下载、删除
        /// <summary>
        /// 附件下载、删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string accessid = e.CommandArgument.ToString().Trim();
            AccessoryEntity attainfo = accessoryDAL.GetObjByID(accessid);
            string path = attainfo.AccessUrl;

            if (e.CommandName.ToString() == "del")
            {
                path = HttpContext.Current.Server.MapPath(path);
                int istrue = accessoryDAL.DeleteBat(accessid);
                if (istrue > 0)
                {
                    ShowMessage("删除成功！");
                    //物理路径的文件删除
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    AccessBind(rp_File, this.hf_FileID.Value, (int)CommonEnum.AccessoryType.Tb_Tender);
                }
                else
                {
                    ShowMessage("删除失败！");
                    return;
                }
            }
            else
            {
                if (!CommonFunction.UpLoadFunciotn(attainfo.AccessUrl, attainfo.AccessName))
                {
                    ShowMessage("下载文件不存在，请联系系统管理员！");
                    return;
                }
            }
        }
        #endregion

        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind(Repeater rpcontr, string objid, int flag)
        {
            DataTable ds = accessoryDAL.GetList(flag, objid);
            rpcontr.DataSource = ds;
            rpcontr.DataBind();
        }
        #endregion
    }
}