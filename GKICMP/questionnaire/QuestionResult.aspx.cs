/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      LFZ
** 创建日期:    2017年7月12日
** 描 述:       问卷答题页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;

namespace GKICMP.questionnaire
{
    public partial class QuestionResult : PageBase
    {
        public Questionnaire_SubjectDAL subjectDAL = new Questionnaire_SubjectDAL();
        public Questionnaire_OptionDAL optionDAL = new Questionnaire_OptionDAL();
        public Questionnaire_AnswerDAL answerDAL = new Questionnaire_AnswerDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        #region 参数集合
        public string QID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(QID))
                {
                    DataBindList();
                }
            }
        }
        public string getType(object obj)
        {
            if ((int)obj == 0)
                return "单选题";
            if ((int)obj == 1)
                return "多选题";
            else
                return "简答题";
        }
        public string GetWidth(object obj)
        {

            return "style='width:" + obj.ToString() + "'";
        }
        public void DataBindList()
        {
            DataTable dt = subjectDAL.GetPagedByQID(QID);

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
        protected void rpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hfModuleID = (HiddenField)e.Item.FindControl("hf_uid");
                Repeater rp_ListResult = (Repeater)e.Item.FindControl("rp_ListResult");
                Repeater rp_ListAnswer = (Repeater)e.Item.FindControl("rp_ListAnswer");

                DataTable dt = answerDAL.GetResult(int.Parse(hfModuleID.Value));//

                if (dt != null && dt.Rows.Count > 0)
                {
                    rp_ListResult.DataSource = dt;
                    rp_ListResult.DataBind();
                    ((Literal)rp_ListResult.Controls[rp_ListResult.Controls.Count - 1].FindControl("ltl_Count")).Text = dt.Rows[0]["总数"].ToString() == "" ? "0" : dt.Rows[0]["总数"].ToString();
                }
                else
                {
                    DataTable dt1 = answerDAL.GetPagedByQSID(int.Parse(hfModuleID.Value));//
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        rp_ListAnswer.DataSource = dt1;
                        rp_ListAnswer.DataBind();
                    }
                }
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuestionnaireList.aspx");
        }
    }
}