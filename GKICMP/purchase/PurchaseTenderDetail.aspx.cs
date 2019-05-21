/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月17日 09点30分
** 描   述:      招标详情
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

namespace GKICMP.purchase
{
    public partial class PurchaseTenderDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Project_TenderDAL project_TenderDAL = new Project_TenderDAL();
        public SupplierDAL supplierDAL = new SupplierDAL();
        //public JZProjectManageDAL jZProjectManageDAL = new JZProjectManageDAL();
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

                if (PTID != "")
                {
                    BindInfo();
                }

            }
        }
        #endregion
        #region 信息绑定
        public void BindInfo()
        {
            try
            {
                Project_TenderEntity model = project_TenderDAL.GetPurchaseByID(PTID);
                this.ltl_BidNumber.Text = model.BidNumber;
                this.ltl_ProName.Text = model.ProName;
                this.ltl_SName.Text = model.SupplierName;
                this.ltl_BDate.Text = model.BDate.ToString("yyyy-MM-dd");
                this.ltl_BAmount.Text = model.BAmount.ToString();
                this.ltl_BSDate.Text = model.BSDate.ToString("yyyy-MM-dd");
                this.ltl_BEDate.Text = model.BEDate.ToString("yyyy-MM-dd");
                this.ltl_BondDate.Text = model.BondDate.ToShortDateString();
                this.ltl_Bond.Text = model.Bond.ToString();
                this.ltl_PTDesc.Text = model.PTDesc;
                this.ltl_IsReturn.Text = model.IsReturn == 0 ? "否" : "是";
                this.ltl_IsReturnDate.Text = model.IsReturn == 0 ? "" : model.ReturnDate.ToString("yyyy-MM-dd");
                AccessBind(rp_File, model.FileID, (int)CommonEnum.AccessoryType.Tb_Tender);
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