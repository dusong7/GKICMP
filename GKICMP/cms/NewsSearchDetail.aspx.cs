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

namespace GKICMP.cms
{
    public partial class NewsSearchDetail : PageBase
    {
        public Web_NewsDAL newsDAL = new Web_NewsDAL();

        public string UID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindList();
            }
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            DataTable dt = newsDAL.GetSearchDetail(UID);
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
    }
}