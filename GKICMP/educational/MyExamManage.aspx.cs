/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年11月09日 15点15分
** 描   述:       考试管理
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

namespace GKICMP.educational
{
    public partial class MyExamManage : PageBase
    {
        public ExamDAL examDAL = new ExamDAL();
        public GradeDAL gradeDAL = new GradeDAL();

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
                DataTable dtGrade = gradeDAL.GetListAll((int)CommonEnum.IsorNot.否);
                //CommonFunction.DDlTypeBind(this.ddl_GID, dtGrade, "GID", "GradeName", "-2");
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            ViewState["EYear"] = this.txt_EYear.Text.Trim();
            ViewState["Term"] = this.ddl_Term.SelectedValue.ToString();
            ViewState["ExamName"] = CommonFunction.GetCommoneString(this.txt_ExamName.Text.ToString().Trim());
            ViewState["BeginDate"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text.ToString();
            ViewState["EndDate"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            ExamEntity model = new ExamEntity();
            model.EYear = ViewState["EYear"].ToString();
            model.Term = Convert.ToInt32(ViewState["Term"].ToString());
            model.ExamName = ViewState["ExamName"].ToString();
            model.BeginDate = Convert.ToDateTime(ViewState["BeginDate"].ToString());
            model.EndDate = Convert.ToDateTime(ViewState["EndDate"].ToString());
            DataTable dt = examDAL.GetPersonPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, UserID);
            if (dt.Rows.Count > 0 && dt != null)
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
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion
    }
}