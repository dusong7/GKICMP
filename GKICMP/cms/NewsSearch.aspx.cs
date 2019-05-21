/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年12月20日 16时34分
** 描 述:       新闻综合查询页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using System.Text;
using GK.GKICMP.Entities;

namespace GKICMP.cms
{
    public partial class NewsSearch : PageBase
    {
        public Web_NewsDAL newsDAL = new Web_NewsDAL();

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
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString();
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString();
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            DataTable dt = newsDAL.GetNewsSearch(ViewState["RealName"].ToString(), Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()), (int)CommonEnum.Deleted.未删除);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
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

        #region 导出事件
        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            StringBuilder str = new StringBuilder();
           
            string name = UserRealName;
            DataTable dt = newsDAL.GetNewsSearch(ViewState["RealName"].ToString(), Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()), (int)CommonEnum.Deleted.未删除);
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>姓名</strong></th>
                                        <th><strong>发布次数</strong></th>
                                     </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["RealName"]);
                    str.AppendFormat("<td>{0}</td>", row["NCount"]);
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("新闻发布次数导出", str.ToString());


        }
        #endregion

    }
}