/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年11月13日 9时14分
** 描 述:       资产折旧管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.assetmanage
{
    public partial class AssetDepreciation : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetDAL assetDAL = new AssetDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public AssetTypeDAL assetTypeDAL = new AssetTypeDAL();

        #region 参数集合
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
                DataTable DataType = assetTypeDAL.GetList((int)CommonEnum.Deleted.未删除, 1);

                this.hf_Flag.Value = Flag.ToString();

                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        private void GetCondition()
        {
            ViewState["AssetName"] = CommonFunction.GetCommoneString(this.txt_AssetName.Text.ToString().Trim());
            ViewState["DataType"] = this.txt_DataType1.Text == "" ? "-2" : this.txt_DataType1.Text.ToString();
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString();
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            AssetEntity model = new AssetEntity();
            model.DataType = Convert.ToInt32(ViewState["DataType"].ToString());
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.AssetName = ViewState["AssetName"].ToString();
            model.Flag = 1; //1代表校产管理 2 代表耗材管理
            DataTable dt = assetDAL.GetPagedDepre(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));
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
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 获取折旧率
        public string GetAssRate(object sender)
        {
            if (sender.ToString() == "")
            {
                return "";
            }
            else
            {
                return sender.ToString() + "%";
            }
        }
        #endregion


        #region 停止折旧事件
        protected void lbtn_StopRate_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                int result = assetDAL.StopRate(id, (int)CommonEnum.IsorNot.是);
                if (result == 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "停止折旧", UserID));
                }
                else if(result==-2)
                {
                    ShowMessage("当前资产未设置折旧率");
                    return;
                }
                else
                {
                    ShowMessage("停止折旧失败");
                    return;
                }
                DataBindList();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}