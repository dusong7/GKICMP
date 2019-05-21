/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2016年11月10日
** 描 述:       资产盘点管理页面
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
    public partial class AssetAccountMange : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_AccountDAL accountDAL = new Asset_AccountDAL();

        #region 参数集合
        /// <summary>
        /// 1：全部盘点 2：部门盘点
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_Flag.Value = Flag.ToString();
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["AccDuty"] = CommonFunction.GetCommoneString(this.txt_AccDuty.Text.Trim());
            ViewState["AccBegin"] = this.txt_AccBegin.Text == "" ? "1900-01-01" : this.txt_AccBegin.Text;
            ViewState["AccEnd"] = this.txt_AccEnd.Text == "" ? "9999-12-31" : this.txt_AccEnd.Text;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            Asset_AccountEntity model = new Asset_AccountEntity();
            model.AccDuty = ViewState["AccDuty"].ToString();
            model.AccBegin = Convert.ToDateTime(ViewState["AccBegin"].ToString());
            model.AccEnd = Convert.ToDateTime(ViewState["AccEnd"].ToString());
            model.Isdel = Convert.ToInt32(CommonEnum.IsorNot.否);
            model.AAFlag = Flag;
            DataTable dt = accountDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = accountDAL.DeleteByID(ids, (int)CommonEnum.Deleted.删除);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除资产盘点信息", UserID));
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("要删除资产盘点信息，请先删除资产盘点信息下的资产明细数据");
                    return;
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}