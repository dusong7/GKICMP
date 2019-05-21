/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2018年1月9日 14时24分
** 描 述:       工作计划管理页面
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

namespace GKICMP.electiver
{
    public partial class ElectiverScoreDetail : PageBase
    {
        public ECourseDAL ecourseDAL = new ECourseDAL();
        public Electiver_ScoreDAL scoreDAL = new Electiver_ScoreDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        /// <summary>
        /// 选课任务ID
        /// </summary>
        public int EleID
        {
            get
            {
                return GetQueryString<int>("eleid", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_TermID, "-2");
                DataTable dt = ecourseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_Course, dt, "CID", "CourseName", "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        private void GetCondition()
        {
            ViewState["ElectiverName"] = CommonFunction.GetCommoneString(this.txt_ElectiverName.Text.ToString());
            ViewState["EYear"] = CommonFunction.GetCommoneString(this.txt_EYear.Text.ToString());
            ViewState["TermID"] = this.ddl_TermID.SelectedValue.ToString();
            ViewState["CourseID"] = this.ddl_Course.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            int recordCount = -1;
            Electiver_ScoreEntity model = new Electiver_ScoreEntity(Convert.ToInt32(ViewState["CourseID"].ToString()),(string)ViewState["EYear"],Convert.ToInt32(ViewState["TermID"].ToString()));
            DataTable dt = scoreDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, (string)ViewState["ElectiverName"]);
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


        #region 删除事件
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value;
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = scoreDAL.DeleteBat(ids);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除选课成绩信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                this.hf_CheckIDS.Value = "";
                DataBindList();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion


        #region 查询事件
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GetCondition();
            DataBindList();
        } 
        #endregion


        #region 分页事件
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        } 
        #endregion


        #region 编辑事件
        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('ElectiverScoreEdit.aspx?id={0}&eleid={1}', '_self')</script>", id,EleID);
            Response.Write(aa);
        } 
        #endregion
    }
}