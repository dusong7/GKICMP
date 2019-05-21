/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    20177214日
** 描 述:       作业布置管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

using System;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.office
{
    public partial class HomeWorkManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public HomeWorkDAL homeWorkDAL = new HomeWorkDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = courseDAL.GetCourseAll(UserID);
                CommonFunction.DDlTypeBind(this.ddl_CID, dt, "CID", "CourseName", "-2");
                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSend, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["CID"] = this.ddl_CID.SelectedValue;
            ViewState["IsSend"] = this.ddl_IsSend.SelectedValue;
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01 00:00" : this.txt_BeginDate.Text + " 00:00";
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31 23:59" : this.txt_EndDate.Text + " 23:59";
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            HomeWorkEntity model = new HomeWorkEntity();
            model.CID = Convert.ToInt32(ViewState["CID"].ToString());
            model.IsSend = Convert.ToInt32(ViewState["IsSend"].ToString());
            model.CreateUser = UserID;
            DataTable dt = homeWorkDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()),1);
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


        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = homeWorkDAL.DeleteBat(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除作业布置信息", UserID));
                    ShowMessage("删除成功");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion

       
    }
}