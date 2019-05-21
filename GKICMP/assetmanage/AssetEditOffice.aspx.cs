/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年11月09日 8时15分
** 描 述:       办公用品编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.assetmanage
{
    public partial class AssetEditOffice : PageBase
    {
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetDAL assetDAL = new AssetDAL();
        public SupplierDAL supplierDAL = new SupplierDAL();
        public AssetTypeDAL assetTypeDAL = new AssetTypeDAL();
        public CampusDAL campusDAL = new CampusDAL();


        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public string AID
        {
            get
            {
                return GetQueryString<string>("id", "");

            }
        }
        /// <summary>
        /// 1代表校产管理 2 代表耗材管理
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
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
                this.txt_BuyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                DataTable dt = campusDAL.GetList((int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_CID, dt, "CID", "CampusName", dt.Rows.Count > 1 ? "-2" : "-999");

                DataTable AUnit = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.计量单位);
                CommonFunction.DDlTypeBind(this.ddl_AUnit, AUnit, "SDID", "DataName", "-2"); //计量单位

                DataTable Brand = supplierDAL.GetList((int)CommonEnum.Deleted.未删除, "");
                CommonFunction.DDlTypeBind(this.ddl_Suppliers, Brand, "SDID", "SupplierName", "-2");//供应商
                if (AID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            try
            {
                AssetEntity model = assetDAL.GetObjByID(AID);
                if (model != null)
                {
                    this.txt_AssetName.Text = model.AssetName.Trim();
                    this.txt_SpecificationModel.Text = model.SpecificationModel.Trim();
                    this.txt_Brand.Text = model.Brand;
                    this.txt_APrice.Text = Convert.ToString(model.APrice);
                    this.txt_BuyDate.Text = Convert.ToString(model.BuyDate.ToString("yyyy-MM-dd"));

                    this.txt_PlanYear.Text = Convert.ToString(model.PlanYear);
                    this.txt_BuyUser.Text = model.BuyUser;
                    this.txt_AssetMark.Text = model.AssetMark;
                    this.txt_AssetNum.Text = model.AssetNum.ToString();
                    this.hf_DataDesc.Value = model.DataDesc.ToString();
                    //if (Flag == 1)
                    //    this.txt_DataType1.Text = model.DataType.ToString();
                    //else
                    this.txt_DataType2.Text = model.DataType.ToString();
                    this.ddl_Suppliers.SelectedValue = model.Suppliers != null ? model.Suppliers.ToString() : "-2";
                    this.ddl_AUnit.SelectedValue = model.AUnit.ToString();
                    this.ddl_CID.SelectedValue = model.CID.ToString();
                }
            }
            catch (Exception ex)
            {
                ShowMessage("查询出错，请稍候重试");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion


        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                AssetEntity model = new AssetEntity();
                model.AID = AID;
                model.DataDesc = this.hf_DataDesc.Value.ToString();//资产编号
                model.AssetName = this.txt_AssetName.Text.Trim();//物品名称
                //if (Flag == 1)
                //{
                //    if (this.txt_DataType1.Text == "")
                //    {
                //        ShowMessage("请选择分类");
                //        return;
                //    }
                //}
                //else
                //{
                if (this.txt_DataType2.Text == "")
                {
                    ShowMessage("请选择分类");
                    return;
                }
                //}
                model.DataType = Convert.ToInt32(this.txt_DataType2.Text.ToString());
                model.SpecificationModel = this.txt_SpecificationModel.Text.ToString().Trim();//规格型号
                model.Brand = this.txt_Brand.Text.Trim();//品牌
                model.Suppliers = this.ddl_Suppliers.SelectedValue.ToString();//供应商  
                model.APrice = Convert.ToDecimal(this.txt_APrice.Text.Trim());//单价
                model.AUnit = Convert.ToInt32(ddl_AUnit.SelectedValue.ToString());//单位
                model.BuyDate = Convert.ToDateTime(this.txt_BuyDate.Text.Trim());//购置时间
                try
                {
                    if (this.txt_PlanYear.Text.ToString().Trim() != "")
                    {
                        model.PlanYear = Convert.ToInt32(this.txt_PlanYear.Text.Trim());//计划使用年限
                    }
                }
                catch
                {
                    ShowMessage("计划使用年限信息填写有误，请修改后重新提交");
                    return;
                }

                model.BuyUser = this.txt_BuyUser.Text.Trim();//采购人
                //model.CreateDate = Convert.ToDateTime(this.txt_CreateDate.Text.Trim());//添加时间
                model.CreateDate = DateTime.Now;
                model.AssetMark = this.txt_AssetMark.Text.Trim();//物品描述
                model.AssetNum = int.Parse(this.txt_AssetNum.Text);
                model.CreateUser = UserID;
                model.PID = "-2";//所属项目
                model.Flag = Flag;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.IsReport = (int)CommonEnum.IsorNot.否;
                model.IsChecked = 1; //是否验收：0否 ，1 是
                model.CID = int.Parse(this.ddl_CID.SelectedValue);
                model.AImage = "";

                int result = assetDAL.Edit(model);

                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该办公用品名称已存在，请重新输入");
                    return;
                }
                else
                {
                    int log = AID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (AID == "" ? "添加" : "修改") + "名称为【" + this.txt_AssetName.Text + "】的办公用品信息", UserID));
                    ShowMessage();
                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
            }
        }
        #endregion
    }
}