/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月11日 13时55分15秒
** 描    述:      我的练习管理列表页面
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
    public partial class PersonPracticeManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ExamPaper_PractStuDAL practstuDAL = new ExamPaper_PractStuDAL();


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
            ViewState["PaperName"] = CommonFunction.GetCommoneString(this.txt_PaperName.Text.Trim());
            ViewState["begin"] = this.txt_BeginDate.Text == "" ? "1900-01-01 00:00:00" : this.txt_BeginDate.Text;
            ViewState["end"] = this.txt_EndDate.Text == "" ? "9999-12-31 23:59:59" : this.txt_EndDate.Text;
            ViewState["createbegin"] = this.txt_createbegin.Text == "" ? "1900-01-01" : this.txt_createbegin.Text;
            ViewState["createend"] = this.txt_createend.Text == "" ? "9999-12-31" : this.txt_createend.Text;
            ViewState["createuser"] = CommonFunction.GetCommoneString(this.txt_createuser.Text.Trim());
        }
        #endregion

        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            DateTime createbegin = Convert.ToDateTime(ViewState["createbegin"].ToString());
            DateTime createend = Convert.ToDateTime(ViewState["createend"].ToString());
            string createuser = ViewState["createuser"].ToString();
            string name = ViewState["PaperName"].ToString();
            DataTable dt = practstuDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, begin, end, name, createbegin, createend, createuser, (int)CommonEnum.IsorNot.否, UserID);
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


        #region 开始答题
        protected void lbtn_AddScore_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string ppsid = lbtn.CommandArgument;
            string aa = string.Format("<script language='javascript'>window.open('../educational/PersonPracticeEdit.aspx?id={0}','_self')</script>", ppsid);
            Response.Write(aa);
        }
        #endregion
    }
}