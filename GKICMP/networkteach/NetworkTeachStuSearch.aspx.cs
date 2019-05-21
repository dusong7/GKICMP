/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年11月23日 15：15
** 描 述:       学习统计页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;

namespace GKICMP.networkteach
{
    public partial class NetworkTeachStuSearch : PageBase
    {
        public NetworkTeach_LoginDAL loginDAL = new NetworkTeach_LoginDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetCondition();
                DataBindList();
            }
        } 
        #endregion


        #region 获取查询条件
        private void GetCondition()
        {
            ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_RealName.Text.ToString().Trim());
            ViewState["ClaID"] = this.txt_ClaID.Text;
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString();
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString();
        } 
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            int recordCount = -1;
            DataTable dt = loginDAL.GetDataTable(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, (string)ViewState["RealName"], (string)ViewState["ClaID"], (int)CommonEnum.UserType.学生, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));
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
        } 
        #endregion


        #region 查询事件
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GetCondition();
            DataBindList();
        } 
        #endregion


        #region 分页事件
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        } 
        #endregion
    }
}