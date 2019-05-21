/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      LFZ
** 创建日期:    2017年4月17日
** 描 述:       问卷答题页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.questionnaire
{
    public partial class SubjectDetail : PageBase
    {
        public Questionnaire_SubjectDAL subjectDAL = new Questionnaire_SubjectDAL();
        public Questionnaire_OptionDAL optionDAL = new Questionnaire_OptionDAL();
        public Questionnaire_AnswerDAL answerDAL = new Questionnaire_AnswerDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();



        #region 参数集合
        /// <summary>
        /// QID 问卷ID
        /// </summary>
        public string QID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion



        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = subjectDAL.GetPagedByQID(QID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.rpListQ.DataSource = dt;
                    this.rpListQ.DataBind();
                }
            }
        }
        #endregion


        #region 获取题目类型
        /// <summary>
        /// 获取题目类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string getType(object obj)
        {
            if ((int)obj == 0)
                return "单选题";
            else if ((int)obj == 1)
                return "多选题";
            else
                return "简答题";
        }
        #endregion


        #region 获取题目选项列表
        /// <summary>
        /// 获取题目选项列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpListQ_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hf_QSID = (HiddenField)e.Item.FindControl("hf_QSID");
                Repeater rp_List = (Repeater)e.Item.FindControl("rp_List");
                DataTable dt = optionDAL.GetPagedByQSID(Convert.ToInt32(hf_QSID.Value));
                if (dt != null && dt.Rows.Count > 0)
                {
                    rp_List.DataSource = dt;
                    rp_List.DataBind();
                }
            }
        }
        #endregion
    }
}