/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2016年11月24日
** 描 述:       资产报废编辑页面
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


namespace ICMP.assetmanage
{
    public partial class ScrapEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetDAL assetDAL = new AssetDAL();
        public SupplierDAL supplierDAL = new SupplierDAL();
        public Asset_ScrapDAL asset_ScrapDAL = new Asset_ScrapDAL();

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
                    this.lbl_PMen.Text = "校产报废信息";
                }
                else
                {
                    this.lbl_PMen.Text = "耗材报废信息";
                }
                this.txt_ASDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            AssetEntity model = assetDAL.GetObjByID(AID);
            if (model != null)
            {
                this.txt_Name.Text = model.AssetName.Trim();
                this.txt_Num.Text = Convert.ToString(model.AssetNum);

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
                Asset_ScrapEntity model = new Asset_ScrapEntity();
                model.ASID = "";
                model.AID = AID;
                model.ASNum = Convert.ToInt32(this.txt_ASNum.Text.Trim());//
                model.ASDate = Convert.ToDateTime(this.txt_ASDate.Text.Trim());
                model.ASMark = this.txt_ASMark.Text.Trim();//班长
                model.CreaterUser = UserID;
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                int result = asset_ScrapDAL.Edit(model);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该资产数量为0，不可报废！");
                    return;
                }
                else if (result == -3)
                {
                    ShowMessage("报废数量大于原有数量，请重新操作！");
                    return;
                }
                else
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "报废为【" + this.txt_Name.Text + "】的资产", UserID));
                    ShowMessage();
                }

            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
            }

        }
        #endregion


    }
}