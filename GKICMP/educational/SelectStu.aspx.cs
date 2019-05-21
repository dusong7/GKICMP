/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月11日 13时55分15秒
** 描    述:      练习学生查询列表页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.educational
{
    public partial class SelectStu : PageBase
    {

        public ExamPaper_PracticeDAL practiceDAL = new ExamPaper_PracticeDAL();


        #region 参数集合
        public string EPPID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


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
        public void DataBindList()
        {
            string name = CommonFunction.GetCommoneString(this.txt_PaperName.Text.Trim());
            int recordCount = 0;
            DataTable dt = practiceDAL.GetPagedSelectStu(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, EPPID, name);
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
        }
        #endregion



        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
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