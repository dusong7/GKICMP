/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      201611月11日 9时55分47秒
** 描    述:     资产调拨详细页面
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
    public partial class AssetAllocationDetail : PageBase
    {
        public Asset_Account_InfoDAL infoDAL = new Asset_Account_InfoDAL();
        public Asset_AllocationDAL assetAllocationDAL = new Asset_AllocationDAL();


        #region 参数集合
        public string AAID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ltl_bt.Text = Flag == 1 ? "资产调拨详细信息" : "资产退回详细信息";
                if (AAID != "")
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 获取资产详细信息数据
        public void BindInfo()
        {
            Asset_AllocationEntity model = assetAllocationDAL.GetObjByID(AAID);
            if (model != null)
            {
                if (Flag == 1)
                {
                    this.ltl_AcceptUser.Text = model.AcceptUser;
                    this.ltl_AllDesc.Text = model.AllDesc;
                    this.ltl_AllocationDate.Text = model.AllocationDate.ToString("yyyy-MM-dd");
                    this.ltl_InDep.Text = model.InDep;
                    this.ltl_OutDep.Text = model.OutDep;
                    this.ltl_OutUser.Text = model.OutUser;
                    this.div2.Visible = false;
                }
                else
                {
                    this.ltl_AcceptDep.Text = model.InDep;
                    this.ltl_Data.Text = model.AllocationDate.ToString("yyyy-MM-dd");
                    this.div1.Visible = false;
                }
                this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
                this.ltl_CreaterUser.Text = model.CreateUserName;
            }
            DataTable dt = infoDAL.GetPaged(AAID, Flag == 1 ? (int)CommonEnum.AIType.调拨 : (int)CommonEnum.AIType.退回);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            rp_List.DataSource = dt;
            rp_List.DataBind();
        }
        #endregion
    }
}