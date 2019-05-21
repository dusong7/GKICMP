/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2016年11月10日
** 描 述:       按场室查询资产管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.assetmanage
{
    public partial class YardRoomManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetDAL assetDAL = new AssetDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public AssetTypeDAL assetTypeDAL = new AssetTypeDAL();



        #region 参数集合

        public string ParmID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// 0校区 1教学楼 2楼层 3场室
        /// </summary>
        public int deep
        {
            get
            {
                return GetQueryString<int>("deep", -1);
            }
        }
        #endregion

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["DataDesc"] = CommonFunction.GetCommoneString(this.txt_DataDesc.Text.Trim());//资产编号
                ViewState["AssetName"] = CommonFunction.GetCommoneString(this.txt_AssetName.Text.Trim());//物品名称
                if (deep != -1)
                {
                    DataBindList();
                }
            }

        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            decimal Sum = 0;
            AssetEntity model = new AssetEntity();
            model.DataType = int.Parse(this.txt_DataType1.Text == "" ? "-2" : this.txt_DataType1.Text);
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.DataDesc = ViewState["DataDesc"].ToString();
            model.AssetName = ViewState["AssetName"].ToString();
            model.Flag = 1;
            //model.CRID = CRID;
            DataTable dt = assetDAL.GetPagedS(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, ref Sum, deep, ParmID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
            string a = string.Format("{0:0,00.00}", Sum);
            this.ltl_Sum.Text = "当前资产的总价值为：￥" + a;
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            ViewState["DataDesc"] = CommonFunction.GetCommoneString(this.txt_DataDesc.Text.Trim());//资产编号
            ViewState["AssetName"] = CommonFunction.GetCommoneString(this.txt_AssetName.Text.Trim());//物品名称
            if (deep != 0 && deep != -1)
            {
                DataBindList();
            }
        }
        #endregion


        public bool GetAcceptName(object isreport, object flag)
        {
            int report = Convert.ToInt32(isreport);
            int flags = Convert.ToInt32(flag);
            if (flags == 2)
            {
                return false;
            }
            else if (flags == 1 && report == 1)
            {
                return false;
            }
            else if (flags == 1 && report == 0)
            {
                return true;
            }
            else
            {
                return true;
            }

        }
    }
}