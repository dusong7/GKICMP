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

namespace GKICMP.purchase
{
    public partial class PurchaseContractDetail : PageBase
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
            if (PCID != "")
            {
                BindInfo();
            }
        }
        #region 信息绑定
        public void BindInfo()
        {
            try
            {
                Project_ContractEntity model = project_ContractDAL.GetObjByID(PCID);
                this.ltl_PID.Text = model.PName.ToString();
                this.ltl_Name.Text = model.Name;
                this.ltl_BidNumber.Text = model.BidNumber;
                this.ltl_PartyA.Text = model.PartyA;
                this.ltl_PartyB.Text = model.PartyBName;
                this.ltl_SignDate.Text = model.SignDate.ToString("yyyy-MM-dd");
                this.ltl_Price.Text = model.Price.ToString();
                this.ltl_StartTime.Text = model.StartTime.ToString();
                this.ltl_PCDesc.Text = model.PCDesc;
                this.ltl_ServerYears.Text = model.ServerYears.ToString();
                this.ltl_ServerDate.Text = model.ServerDate.ToString("yyyy-MM-dd");
                this.ltl_ServerLinkUser.Text = model.ServerLinkUser;
                this.ltl_ServerPhone.Text = model.ServerPhone;
                AccessBind(rp_File, model.FileID, (int)CommonEnum.AccessoryType.Tb_Contract);
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

            if (!CommonFunction.UpLoadFunciotn(attainfo.AccessUrl, attainfo.AccessName))
            {
                ShowMessage("下载文件不存在，请联系系统管理员！");
                return;
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