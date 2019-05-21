/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年04月17日 15时49分17秒
** 描    述:      问卷详细页
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.questionnaire
{
    public partial class QuestionnaireDetail : PageBase
    {
        public QuestionnaireDAL questDAL = new QuestionnaireDAL();


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
                InfoBind();
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            QuestionnaireEntity model = questDAL.GetObjByID(QID);
            if (model != null)
            {
                this.ltl_QuestName.Text = model.QuestName.ToString();
                this.ltl_IsName.Text = GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(model.IsRealName);
                this.ltl_LastDate.Text = model.LastDate.ToString("yyyy-MM-dd");
                this.ltl_Questxplain.Text = model.Questxplain.ToString();
                this.ltl_Role.Text = model.QestCrowd.ToString();
                this.ltl_CreateUser.Text = model.CreateUserName.ToString();
                this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
            }
        }
        #endregion
    }
}