/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年3月29日 13时46分17秒
** 描    述:      问卷管理页
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;

namespace GKICMP.questionnaire
{
    public partial class AnswerQuestionList : PageBase
    {
        public QuestionnaireDAL questionnaireDAL = new QuestionnaireDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
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
            ViewState["QuestName"] = CommonFunction.GetCommoneString(this.txt_QuestName.Text.Trim());
            ViewState["Begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["End"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            QuestionnaireEntity model = new QuestionnaireEntity();
            model.QuestName = ViewState["QuestName"].ToString();
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            model.IsPublish = (int)CommonEnum.IsorNot.是;
            DataTable dt = questionnaireDAL.GetPagedByRoleid(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["Begin"].ToString()), Convert.ToDateTime(ViewState["End"].ToString()), UserID);
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