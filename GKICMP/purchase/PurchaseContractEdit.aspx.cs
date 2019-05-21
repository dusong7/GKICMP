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
using System.Configuration;
using System.IO;

namespace GKICMP.purchase
{
    public partial class PurchaseContractEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Project_ContractDAL project_ContractDAL = new Project_ContractDAL();
        public SupplierDAL supplierDAL = new SupplierDAL();
        public PurchaseDAL purchaseDAL = new PurchaseDAL();
        public AccessoryDAL accessoryDAL = new AccessoryDAL();

        #region 参数
        public string PCID
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
                DataTable dt = supplierDAL.GetList((int)CommonEnum.IsorNot.否, "");
                CommonFunction.DDlTypeBind(this.ddl_PartyB, dt, "SDID", "SupplierName", "-2");

                PurchaseEntity model = new PurchaseEntity();
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.PLState = (int)CommonEnum.AduitState.通过;
                model.IsChecked = (int)CommonEnum.Deleted.未删除;
                DataTable dtp = purchaseDAL.List(model);//获取验收状态为0的项目名称
                CommonFunction.DDlTypeBind(this.ddl_PID, dtp, "PID", "PTitle", "-2");
                this.txt_PartyA.Text = ConfigurationManager.AppSettings["SchoolName"];
                if (PCID != "")
                {
                    BindInfo();
                }
                else
                {
                    this.hf_FileID.Value = Guid.NewGuid().ToString();
                }
            }
        }
        #region 信息绑定
        public void BindInfo()
        {
            try
            {
                Project_ContractEntity model = project_ContractDAL.GetObjByID(PCID);
                this.ddl_PID.SelectedValue = model.PID.ToString();
                this.txt_Name.Text = model.Name;
                this.txt_BidNumber.Text = model.BidNumber;
                this.txt_PartyA.Text = model.PartyA;
                this.ddl_PartyB.SelectedValue = model.PartyB;
                this.txt_SignDate.Text = model.SignDate.ToString("yyyy-MM-dd");
                this.txt_Price.Text = model.Price.ToString();
                this.txt_StartTime.Text = model.StartTime.ToString();
                this.txt_PCDesc.Text = model.PCDesc;
                this.txt_ServerYears.Text = model.ServerYears.ToString();
                this.txt_ServerDate.Text = model.ServerDate.ToString("yyyy-MM-dd");
                this.txt_ServerLinkUser.Text = model.ServerLinkUser;
                this.txt_ServerPhone.Text = model.ServerPhone;

                this.hf_FileID.Value = model.FileID;

                AccessBind(rp_File, model.FileID, (int)CommonEnum.AccessoryType.Tb_Contract);
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
                Project_ContractEntity model = new Project_ContractEntity();
                model.ID = PCID;
                model.PID = this.ddl_PID.SelectedValue;
                model.Name = this.txt_Name.Text;
                model.BidNumber = this.txt_BidNumber.Text;
                model.PartyA = this.txt_PartyA.Text;
                model.PartyB = this.ddl_PartyB.SelectedValue;
                model.SignDate = Convert.ToDateTime(this.txt_SignDate.Text);
                model.Price = decimal.Parse(this.txt_Price.Text);
                model.StartTime = int.Parse(this.txt_StartTime.Text);
                model.PCDesc = this.txt_PCDesc.Text;
                model.CreateUser = UserID;
                model.CreateDate = DateTime.Now;
                model.Isdel = (int)CommonEnum.IsorNot.否;//
                model.IsReport = (int)CommonEnum.IsorNot.否;//
                model.ServerYears = this.txt_ServerYears.Text;
                model.ServerDate = Convert.ToDateTime(this.txt_ServerDate.Text);
                model.ServerLinkUser = this.txt_ServerLinkUser.Text;
                model.ServerPhone = this.txt_ServerPhone.Text;

                model.FileID = this.hf_FileID.Value;
                //附件上传
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
                    accessinfo.AccessFlag = (int)CommonEnum.AccessoryType.Tb_Contract;
                    accessinfo.AccessObjID = this.hf_FileID.Value;
                    accessinfo.ObjID = "";
                }

                int result = project_ContractDAL.Edit(model, accessinfo);
                if (result == 0)
                {
                    ShowMessage();
                    int log = PCID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (PCID == "" ? "添加" : "修改") + "采购合同信息", UserID));
                }
                else if (result == -1)
                {
                    ShowMessage("系统已有此项目合同信息");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("合同编号已存在，请修改后重新提交");
                    return;
                }
                else
                {
                    ShowMessage("提交失败");
                }
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

                    AccessBind(rp_File, this.hf_FileID.Value, (int)CommonEnum.AccessoryType.Tb_Contract);
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