/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月11日 13时55分15秒
** 描    述:      试卷管理列表页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.educational
{
    public partial class ExamPaperManage : PageBase
    {
        public ExamPaperDAL examPaperDAL = new ExamPaperDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");
                CommonFunction.BindEnum<CommonEnum.NJ>(this.ddl_GradeID, "-2");
                DataTable dtCourse = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_CID, dtCourse, "CID", "CourseName", "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["CID"] = this.ddl_CID.SelectedValue;
            ViewState["PaperName"] = CommonFunction.GetCommoneString(this.txt_PaperName.Text.Trim());
            ViewState["GradeID"] = this.ddl_GradeID.SelectedValue;
            ViewState["Term"] = this.ddl_Term.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            ExamPaperEntity model = new ExamPaperEntity();
            model.CID = Convert.ToInt32(ViewState["CID"].ToString());
            model.PaperName = ViewState["PaperName"].ToString();
            model.GradeID = Convert.ToInt32(ViewState["GradeID"].ToString());
            model.Term = Convert.ToInt32(ViewState["Term"].ToString());
            DataTable dt = examPaperDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                int result = examPaperDAL.DeleteByID(ids);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除试卷信息", UserID));
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
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion


        #region 查看题目
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string epid = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language='javascript'>window.open('ExamAssemblyDetail.aspx?id={0}','_self')</script>", epid);
            Response.Write(aa);
        }
        #endregion

        #region 发布练习
        protected void lbtn_RelPractice_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument;
            int gid = Convert.ToInt32(lbtn.CommandName);
            string aa = string.Format("<script language='javascript'>window.open('ExamPaperPracticeEdit.aspx?id={0} &gid={1} ','_self')</script>", id, gid);
            Response.Write(aa);
        }
        #endregion
    }
}