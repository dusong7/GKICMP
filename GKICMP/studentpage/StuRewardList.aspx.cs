
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.studentpage
{
    public partial class StuRewardList : PageBase
    {
        public Stu_RewardDAL stu_RewardDAL = new Stu_RewardDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
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
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");
                CommonFunction.BindEnum<CommonEnum.RGrade>(this.ddl_RewardGrade, "-2");
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
            ViewState["RewardName"] = CommonFunction.GetCommoneString(this.txt_RewardName.Text.ToString().Trim());
            ViewState["EYear"] = CommonFunction.GetCommoneString(this.txt_EYear.Text.ToString().Trim());
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Stu_RewardEntity model = new Stu_RewardEntity();
            model.RewardName = (string)ViewState["RewardName"];
            model.StuID = UserID;
            model.EYear = (string)ViewState["EYear"];
            model.Term = int.Parse(this.ddl_Term.SelectedValue);
            model.RewardGrade = int.Parse(this.ddl_RewardGrade.SelectedValue);
            DataTable dt = stu_RewardDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model,1);
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
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Query_Click(object sender, EventArgs e)
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