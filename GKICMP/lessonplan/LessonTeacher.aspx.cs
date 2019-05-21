
/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师合同管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.lessonplan
{
    public partial class LessonTeacher : PageBase
    {
        public LessonDAL lessonDAL = new LessonDAL();
        public LessonPlanDAL lessonPlanDAL = new LessonPlanDAL();
        public SysSetConfigEntity model = new SysSetConfigDAL().GetObjByID();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-99");
                this.ddl_Term.SelectedValue = model.NowTerm.ToString();
                GetCondition();
                DataBindList();
            }
        }
        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            ViewState["TName"] = CommonFunction.GetCommoneString(this.txt_TName.Text.ToString().Trim());
            ViewState["Year"] = this.txt_Year.Text == "" ? model.EYear : this.txt_Year.Text;
           
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            LessonPlanEntity model = new LessonPlanEntity();
            model.TID =int.Parse(this.ddl_Term.SelectedValue);
            model.LYear = ViewState["Year"].ToString();
            model.LName = ViewState["TName"].ToString();
            DataTable dt = lessonPlanDAL.GetLessonTeacher(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
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

        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            Response.Redirect("LessonDetail.aspx?id=" + id + "&term=" + this.ddl_Term.SelectedValue + "&year=" + this.txt_Year.Text, false);
        }
    }
}