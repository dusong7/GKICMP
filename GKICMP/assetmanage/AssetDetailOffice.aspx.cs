/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      201611月11日 9时55分47秒
** 描    述:     供应商详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;

namespace GKICMP.assetmanage
{
    public partial class AssetDetailOffice : PageBase
    {
        public AssetDAL assetDAL = new AssetDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SupplierDAL SupplierDAL = new SupplierDAL();


        #region 参数集合
        public string AID
        {
            get
            {
                return GetQueryString<string>("id", "");
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
                if (AID != "")
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 数据绑定
        public void BindInfo()
        {
            AssetEntity model = assetDAL.GetObjByID(AID);
            if (model != null)
            {
                this.lbl_AssetName.Text = model.AssetName;
                this.lbl_SpecificationModel.Text = model.SpecificationModel;
                this.lbl_Brand.Text = model.Brand;
                this.lbl_BuyDate.Text = model.BuyDate.ToString("yyyy-MM-dd");
                this.lbl_APrice.Text = Convert.ToString(model.APrice);
                this.lbl_PlanYear.Text = Convert.ToString(model.PlanYear);
                this.lbl_BuyUser.Text = model.BuyUser;
                this.lbl_AssetMark.Text = model.AssetMark;
                this.lbl_AssetNum.Text = Convert.ToString(model.AssetNum);
                //this.lbl_DataType.Text = Convert.ToString(model.DataType);
                this.lbl_Suppliers.Text = model.Suppliers;
                this.lbl_DataType.Text = model.OfficeTypeName;
                this.lbl_AUnit.Text = model.AUnitName;
                this.lbl_Suppliers.Text = model.SuppliersName;//供应商
                this.lbl_CID.Text = model.CName;
            }
        }
        #endregion
    }
}