using System;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Data;


namespace GKICMP.oamanage
{
    public partial class AfficheSchoolAudit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AfficheDAL afficheDAL = new AfficheDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();


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
            ViewState["AfficheTitle"] = CommonFunction.GetCommoneString(this.txt_AfficheTitle.Text.Trim());
            // ViewState["AType"] = this.ddl_AType.SelectedValue;
            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            AfficheEntity model = new AfficheEntity();
            model.AfficheTitle = ViewState["AfficheTitle"].ToString();
            //model.AType = Convert.ToInt32(ViewState["AType"].ToString());
            //model.IsRead = -2;
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            DataTable dt = afficheDAL.GetPagedSchool(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end,1);
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
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            //this.hf_Page.Value = "";
            Pager.CurrentPageIndex = 1;

            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        


        #region 通知公告查看
        /// <summary>
        /// 公告查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_View_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string users = lbtn.CommandName.ToString();
            string aa = string.Format("<script language=javascript>window.open('AfficheDetail.aspx?id={0}&flag=4&users={1}', '_self')</script>", id, users);
            Response.Write(aa);
        }
        #endregion


        
    }
}