
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using GK.GKICMP.Common;

namespace GKICMP.app
{
    public partial class AssetDetail : PageBaseApp
    {
        public AssetDAL assetDAL = new AssetDAL();
        protected string AID
        {
            get { return  Request.QueryString["id"] == null ? string.Empty : Request.QueryString["id"] ; }
         
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AID != "") 
            {
                BindInfo();
            }
        }
        public void BindInfo()
        {
           
                AssetEntity model = assetDAL.GetObjByID(AID);
                if (model != null)
                {
                   // this.ltl_ProName.Text = model.ProName == "-2" ? "" : model.ProName;

                    this.ltl_AssetName.Text = model.AssetName;
                    this.ltl_DataDesc.Text = model.DataDesc;
                    this.ltl_SpecificationModel.Text = model.SpecificationModel;
                    this.ltl_Brand.Text = model.Brand;
                    this.ltl_BuyDate.Text = model.BuyDate.ToString("yyyy-MM-dd");
                  //  this.ltl_APrice.Text = Convert.ToString(model.APrice);
                    this.ltl_PlanYear.Text = Convert.ToString(model.PlanYear);
                    this.ltl_BuyUser.Text = model.BuyUserName;
                    this.ltl_AssetMark.Text = model.AssetMark;
                  //  this.ltl_AssetNum.Text = Convert.ToString(model.AssetNum);
                    // this.ltl_AImage = model.AImage;
                    if (model.AImage!=null&&model.AImage != "")//图片
                    {
                        //this.ltl_AImage = "../" + model.AImage;
                        this.imgs.ImageUrl =  "../" + model.AImage;
                        this.imgs.Visible = true;
                    }

                    this.ltl_DataType.Text = Convert.ToString(model.DataType);
                    this.ltl_Suppliers.Text = model.Suppliers;
                    //this.ltl_AUnit.Text = Convert.ToString(model.AUnit);

                    //SysDataEntity dmodel = SysDataDAL.GetList(model.DataType);
                    //this.ltl_DataType.Text = dmodel.DataDesc;//资产分类
                    this.ltl_DataType.Text = model.DataTypeName;

                    //SysDataEntity amodel = SysDataDAL.GetList(model.AUnit);
                    //this.ltl_AUnit.Text = amodel.DataName;//计量单位
                    this.ltl_AUnit.Text = model.AUnitName;

                    //SupplierEntity smodel = SupplierDAL.GetList(model.Suppliers);
                    this.ltl_Suppliers.Text = model.SuppliersName;//供应商
                    this.ltl_CID.Text = model.CName;

                }
            

        }
    }
}