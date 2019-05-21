/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2016年11月07日
** 描 述:       角色编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Configuration;


namespace ICMP.assetmanage
{
    public partial class AssetEdit : PageBase
    {
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetDAL assetDAL = new AssetDAL();
        public SupplierDAL supplierDAL = new SupplierDAL();
        public JZProjectManageDAL j = new JZProjectManageDAL();
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
                if (Flag == 1)
                {
                    this.lbl_Number.Text = this.lbl_Name.Text = this.lbl_Type.Text = this.ltl.Text = this.lbl_Sum.Text = "资产";

                    //DataTable DataType = assetTypeDAL.GetList((int)CommonEnum.Deleted.未删除, 1);
                    //this.ddl_DataType.Items.Add(new ListItem("--请选择--", "-2"));
                    //ModelParent(DataType, "-1", this.ddl_DataType, "");//递归栏目菜单
                    //  CommonFunction.DDlTypeBind(this.ddl_DataType, DataType, "SDID", "DataName", "-2"); //物品分类
                    DataTable assetGroupdt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.资产分组);
                    CommonFunction.DDlTypeBind(this.ddl_AssetGroup, assetGroupdt, "SDID", "DataName", "-2");
                }
                else
                {
                    this.AGroup.Visible = false;
                    this.lbl_Number.Text = this.lbl_Name.Text = this.lbl_Type.Text = this.ltl.Text = this.lbl_Sum.Text = "耗材";

                    //DataTable Type = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.耗材分类);
                    //ModelParent(Type, "-1", this.ddl_DataType, ""); //递归栏目菜单
                    //CommonFunction.DDlTypeBind(this.ddl_DataType, Type, "SDID", "DataName", "-2"); //物品分类
                }

                DataTable dt = campusDAL.GetList((int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_CID, dt, "CID", "CampusName", dt.Rows.Count > 1 ? "-2" : "-999");

                DataTable AUnit = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.计量单位);
                CommonFunction.DDlTypeBind(this.ddl_AUnit, AUnit, "SDID", "DataName", "-2"); //计量单位
                DataTable Brand = supplierDAL.GetList((int)CommonEnum.Deleted.未删除, "");
                CommonFunction.DDlTypeBind(this.ddl_Suppliers, Brand, "SDID", "SupplierName", "-2");//供应商
                DataTable Pro = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.计量单位);
                CommonFunction.DDlTypeBind(this.ddl_AUnit, AUnit, "SDID", "DataName", "-2"); //计量单位
                DataTable proname = new JZProjectManageDAL().GetProList();
                CommonFunction.DDlTypeBind(this.ddl_ProName, proname, "PID", "ProName", "-2"); //项目绑定


                this.txt_CreateDate.Enabled = false;
                this.txt_CreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//添加时间
                if (AID != "")
                {
                    this.ltl_AE.Text = "修改";
                    InfoBind();
                }
                else
                {
                    this.ltl_AE.Text = "添加";
                    this.txt_DataDesc.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
                    this.txt_DataDesc.Enabled = false;
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
                    this.ddl_ProName.SelectedValue = model.PID;//所属项目
                    this.txt_AssetName.Text = model.AssetName.Trim();
                    this.txt_DataDesc.Text = model.DataDesc;
                    this.txt_SpecificationModel.Text = model.SpecificationModel.Trim();
                    this.txt_Brand.Text = model.Brand;
                    this.txt_APrice.Text = Convert.ToString(model.APrice);
                    //this.txt_AUnit.Text = Convert.ToString(model.AUnit);
                    this.txt_BuyDate.Text = Convert.ToString(model.BuyDate.ToString("yyyy-MM-dd"));
                    this.txt_CreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //this.txt_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd") == "9999-12-31" ? "" : model.CreateDate.ToString("yyyy-MM-dd");
                    this.txt_PlanYear.Text = Convert.ToString(model.PlanYear);
                    this.txt_BuyUser.Text = model.BuyUser;
                    this.txt_AssetMark.Text = model.AssetMark;
                    this.txt_AssetNum.Text = model.AssetNum.ToString();
                    if (model.AImage != null && model.AImage != "")//图片
                    {
                        this.img_SImage.ImageUrl = this.hf_SImage.Value = model.AImage;
                    }

                    //this.ddl_DataType.SelectedValue = model.DataType.ToString();
                    //this.Series.Text = model.DataType.ToString();
                    if (Flag == 1)
                        this.txt_DataType1.Text = model.DataType.ToString();
                    else
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

        #region 递归栏目菜单
        private void ModelParent(DataTable dt, string parentid, DropDownList ddl, string str)
        {
            string str_;
            string slt;
            slt = string.Format("PID='{0}'", parentid);
            DataRow[] drarr = dt.Select(slt);
            foreach (DataRow dr in drarr)
            {
                if (parentid == "-1")
                {
                    str_ = "";
                }
                else
                {
                    str_ = "├";
                }
                ListItem item = new ListItem();
                item.Text = str + str_ + dr["DataName"].ToString();     //Bind text
                item.Value = dr["SDID"].ToString();                                //Bind value
                string parent_id = item.Value;
                ddl.Items.Add(item);

                ModelParent(dt, parent_id, ddl, str + "..          ");
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
                model.DataDesc = this.txt_DataDesc.Text.Trim();//资产编号
                model.AssetName = this.txt_AssetName.Text.Trim();//物品名称
                //model.DataType = Convert.ToInt32(ddl_DataType.SelectedValue.ToString());//物品分类
                if (Flag == 1)
                {
                    if (this.txt_DataType1.Text == "")
                    {
                        ShowMessage("请选择分类");
                        return;
                    }
                }
                else 
                {
                    if (this.txt_DataType2.Text == "")
                    {
                        ShowMessage("请选择分类");
                        return;
                    }
                }
                model.DataType = Convert.ToInt32(Flag == 1 ? this.txt_DataType1.Text.ToString() : this.txt_DataType2.Text.ToString());
                model.SpecificationModel = this.txt_SpecificationModel.Text.ToString().Trim();//规格型号
                model.Brand = this.txt_Brand.Text.Trim();//品牌
                model.Suppliers = this.ddl_Suppliers.SelectedValue.ToString();//供应商  
                model.APrice = Convert.ToDecimal(this.txt_APrice.Text.Trim());//单价
                //model.AUnit = Convert.ToInt32(this.txt_AUnit.Text.Trim());//单位
                model.AUnit = Convert.ToInt32(ddl_AUnit.SelectedValue.ToString());//单位
                model.BuyDate = Convert.ToDateTime(this.txt_BuyDate.Text.Trim());//购置时间
                model.PlanYear = Convert.ToInt32(this.txt_PlanYear.Text.Trim());//计划使用年限
                model.BuyUser = this.txt_BuyUser.Text.Trim();//采购人
                model.CreateDate = Convert.ToDateTime(this.txt_CreateDate.Text.Trim());//添加时间
                model.AssetMark = this.txt_AssetMark.Text.Trim();//物品描述
                model.AssetNum = int.Parse(this.txt_AssetNum.Text);
                //model.CreateUser = UserID;
                model.CreateUser = UserID;
                model.PID = this.ddl_ProName.SelectedValue;//所属项目
                // model.Flag = 1;
                model.Flag = Flag;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.IsReport = (int)CommonEnum.IsorNot.否;
                model.IsChecked = 1; //是否验收：0否 ，1 是
                model.CID = int.Parse(this.ddl_CID.SelectedValue);
                if (Flag == 1) 
                {
                    model.AssetGroup = int.Parse(this.ddl_AssetGroup.SelectedValue);
                }
                // model.DataDesc=DateTime.Now.ToString("yyyyMMddHHmmss");
                //上传图片
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_SImage, "ImageUrl");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_SImage.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_SImage.HasFile)
                        model.AImage = accessinfo.AccessUrl;
                    else
                        model.AImage = this.hf_SImage.Value;
                }
                int result = assetDAL.Edit(model);

                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该资产名称已存在，请重新输入");
                    return;
                }
                else
                {
                    if (AID == "")
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加资产【" + this.txt_AssetName.Text + "】信息", UserID));
                    else
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改资产【" + this.txt_AssetName.Text + "】信息", UserID));
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