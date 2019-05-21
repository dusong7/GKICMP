/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月8日 14点59分
** 描   述:       选课成绩管理
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;


namespace GKICMP.electiver
{
    public partial class ElectiverScoreManage : PageBase
    {
        public Electiver_ScoreDAL scoreDAL = new Electiver_ScoreDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_TermID, "-2");

                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        private void GetCondition()
        {
            ViewState["ElectiverName"] = CommonFunction.GetCommoneString(this.txt_ElectiverName.Text.ToString());
            ViewState["EYear"] = CommonFunction.GetCommoneString(this.txt_EYear.Text.ToString());
            ViewState["TermID"] = this.ddl_TermID.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            int recordCount = -1;
            ElectiverEntity model = new ElectiverEntity();
            model.EYear = (string)ViewState["EYear"];
            model.TermID = Convert.ToInt32(ViewState["TermID"]);
            model.ElectiverName = (string)ViewState["ElectiverName"];
            DataTable dt = scoreDAL.GetScorePaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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


        #region 添加成绩
        protected void lbtn_Add_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('ElectiverScoreEdit.aspx?eleid={0}', '_self')</script>", id);
            Response.Write(aa);
        }
        #endregion

        #region 详情
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('ElectiverScoreDetail.aspx?eleid={0}', '_self')</script>", id);
            Response.Write(aa);
        } 
        #endregion
    }
}