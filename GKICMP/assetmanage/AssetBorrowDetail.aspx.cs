/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年11月11日 9时55分47秒
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
    public partial class AssetBorrowDetail : PageBase
    {
        public AssetDAL assetDAL = new AssetDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public AssetBorrowDAL borrowDAL = new AssetBorrowDAL();

        #region 参数集合
        public int ABID
        {
            get
            {
                return GetQueryString<int>("id", -1);
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
                    //this.lbl_Number.Text = this.lbl_Name.Text = this.lbl_Type.Text = "耗材";
                    this.lbl_Type1.Text = "借出";
                    this.lbl_Make.Text = this.lbl_Date.Text = this.lbl_Num.Text = this.lbl_ABUserName.Text = "借出";

                    this.back.Visible = true;
                    this.lbl_Back.Text = "归还";
                }
                else
                {
                    //this.lbl_Number.Text = this.lbl_Name.Text = this.lbl_Type.Text = "办公用品";
                    this.lbl_Type1.Text = "领用";
                    this.lbl_Make .Text= this.lbl_Date.Text = this.lbl_Num.Text = this.lbl_ABUserName.Text = "领用";

                    this.back.Visible = false;
                }
                if (ABID != -1)
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 数据绑定
        public void BindInfo()
        {
           Asset_BorrowEntity model = borrowDAL.GetObjByID(ABID);
            if (model != null)
            {
                this.lbl_AssetName.Text = model.AssetName;
                this.lbl_DataDesc.Text = model.DataDesc;
                this.lbl_DataType.Text = model.TypeName;

                this.lbl_ABUser.Text = model.ABUserName;//领用人名称
                this.lbl_UserDate.Text = Convert.ToString(model.UserDate.ToString("yyyy-MM-dd"));
                this.lbl_AssetNum.Text = Convert.ToString(model.AssetNum);

                this.lbl_ABMak.Text = model.ABMak;
                string aa = model.BackDate.ToString();//0001/1/1 0:00:00
                DateTime tt = model.BackDate;
                if (Flag == 1)
                {
                    this.lbl_BackDate.Text = model.BackDate.ToString() == "0001/1/1 0:00:00" ? "" : Convert.ToString(model.BackDate.ToString("yyyy-MM-dd"));
                }
            }
        }
        #endregion
    }
}