/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年8月25日 14时04分
** 描 述:       我的日志管理页面
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

namespace GKICMP.spacemanage
{
    public partial class SpaceLogAuditManage : PageBase
    {
        public SpaceLogDAL spaceLogDAL = new SpaceLogDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["LogTitle"] = CommonFunction.GetCommoneString(this.txt_LogTitle.Text.Trim());
            ViewState["begin"] = this.txt_SDate.Text.Trim() == "" ? "1900-01-01" : this.txt_SDate.Text;
            ViewState["end"] = this.txt_EDate.Text.Trim() == "" ? "9999-12-31" : this.txt_EDate.Text;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            SpaceLogEntity model = new SpaceLogEntity();
            model.LogTitle = ViewState["LogTitle"].ToString();
            model.IsPublish = (int)CommonEnum.IsorNot.是;
            model.AduitState = (int)CommonEnum.AduitState.未审核;
            model.SysID = "";
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            DataTable dt = spaceLogDAL.GetAuditPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end, 1);
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
            this.rp_List.DataBind();
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
    }
}