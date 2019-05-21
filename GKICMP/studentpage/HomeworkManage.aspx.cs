/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年11月24日 10时29分
** 描 述:       我的作业管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.studentpage
{
    public partial class HomeworkManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public HomeWorkDAL homeWorkDAL = new HomeWorkDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable dt = courseDAL.GetCourseAll(UserID);
                DataTable dt = courseDAL.GetCourse(UserID);
                CommonFunction.DDlTypeBind(this.ddl_CID, dt, "CID", "CourseName", "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        private void GetCondition()
        {
            ViewState["CID"] = this.ddl_CID.SelectedValue;
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01 00:00" : this.txt_BeginDate.Text + " 00:00";
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31 23:59" : this.txt_EndDate.Text + " 23:59";
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            int recordCount = 0;
            HomeWorkEntity model = new HomeWorkEntity();
            model.CID = Convert.ToInt32(ViewState["CID"].ToString());
            model.IsSend = 1;
            model.CreateUser = UserID;
            DataTable dt = homeWorkDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()),2);
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