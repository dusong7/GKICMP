/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:     2017年11月25日
** 描 述:       学生评语详情页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.studentpage
{
    public partial class StuEvaluateDetail : PageBase
    {
        public Stu_EvaluateDAL evaluateDAL = new Stu_EvaluateDAL();

        #region 参数集合
        /// <summary>
        /// TEID
        /// </summary>
        public string SEID
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
                InfoBind();
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            Stu_EvaluateEntity model = evaluateDAL.GetObjByID(SEID);
            if (model != null)
            {
                this.ltl_StudentName.Text = model.StudentName.ToString();
                this.ltl_EYear.Text = model.EYear.ToString();
                this.ltl_Term.Text = GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(model.Term);
                this.ltl_Evaluate.Text = model.Evaluate.ToString();
            }
        } 
        #endregion
    }
}