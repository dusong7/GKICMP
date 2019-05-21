/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月11日 13时55分15秒
** 描    述:      题目管理列表页面
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
    public partial class ExerciseManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ExerciseDAL exerciseDAL = new ExerciseDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.ExerciseType>(this.ddl_EType, "-2");
                CommonFunction.BindEnum<CommonEnum.DifficultyType>(this.ddl_Difficulty, "-2");
                CommonFunction.BindEnum<CommonEnum.NJ>(this.ddl_GradeID, "-2");
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");
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
            ViewState["Difficulty"] = this.ddl_Difficulty.SelectedValue;
            ViewState["EType"] = this.ddl_EType.SelectedValue;
            ViewState["GradeID"] = this.ddl_GradeID.SelectedValue;
            ViewState["Term"] = this.ddl_Term.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            ExerciseEntity model = new ExerciseEntity();
            model.CID =Convert .ToInt32( ViewState["CID"].ToString());
            model.Difficulty = Convert.ToInt32(ViewState["Difficulty"].ToString());
            model.EType = Convert.ToInt32(ViewState["EType"].ToString());
            model.GradeID = Convert.ToInt32(ViewState["GradeID"].ToString());
            model.Term = Convert.ToInt32(ViewState["Term"].ToString());
            model.Isdel = (int)CommonEnum.IsorNot.否;
            DataTable dt = exerciseDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                int result = exerciseDAL.DeleteByID(ids,(int)CommonEnum .Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除题目信息", UserID));
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


        #region 添加
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string aa = string.Format("<script language='javascript'>window.open('ExerciseEdit.aspx','_self')</script>");
            Response.Write(aa);
        }
        #endregion


        #region 编辑
        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int eid = Convert.ToInt32(lbtn.CommandArgument.ToString());
            string aa = string.Format("<script language='javascript'>window.open('ExerciseEdit.aspx?id={0}','_self')</script>", eid);
            Response.Write(aa);
        }
        #endregion


        #region 详情
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int eid = Convert.ToInt32(lbtn.CommandArgument.ToString());
            string aa = string.Format("<script language='javascript'>window.open('ExerciseDetail.aspx?id={0}','_self')</script>", eid);
            Response.Write(aa);
        }
        #endregion


        #region 自动组卷
        protected void btn_Assembly_Click(object sender, EventArgs e)
        {
            string aa = string.Format("<script language='javascript'>window.open('ExamAssemblyEdit.aspx','_self')</script>");
            Response.Write(aa);
        }
        #endregion
    }
}