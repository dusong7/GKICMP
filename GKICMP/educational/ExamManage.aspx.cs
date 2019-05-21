/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月08日 09点30分
** 描   述:       考试管理
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;

namespace GKICMP.educational
{
    public partial class ExamManage : PageBase
    {
        public ExamDAL examDAL = new ExamDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
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
                CommonFunction.DDlTypeBind(this.ddl_GID, dtGrade, "GID", "GradeName", "-2");
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
            ViewState["GID"] = this.ddl_GID.SelectedValue.ToString();
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
            model.GID = Convert.ToInt32(ViewState["GID"].ToString());
            model.EYear = ViewState["EYear"].ToString();
            model.Term = Convert.ToInt32(ViewState["Term"].ToString());
            model.ExamName = ViewState["ExamName"].ToString();
            model.BeginDate = Convert.ToDateTime(ViewState["BeginDate"].ToString());
            model.EndDate = Convert.ToDateTime(ViewState["EndDate"].ToString());
            DataTable dt = examDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string ids = lbtn.CommandArgument.ToString();
                int result = examDAL.DeleteByID(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除考试信息", UserID));
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

        protected void lbtn_Set_Click(object sender, EventArgs e)
        {
            int result = -1;
            LinkButton lbtn = (LinkButton)sender;
            string eid = lbtn.CommandArgument.ToString();
            string op = lbtn.CommandName.ToString();
            //if (op == "set")
            //    Response.Redirect("ExamSubjectManage.aspx?eid=" + eid, true);
            //else 
            if (op == "add")
                Response.Redirect("ScoreManage.aspx?eid=" + eid, true);
            else if (op == "view")
                Response.Redirect("ScoreDetail.aspx?eid=" + eid, true);
            else if (op == "ExamP")
            {
                result = examDAL.SetAudit(eid, 2);
                if (result > 0)
                {
                    GetCondition();
                    DataBindList();
                    ShowMessage("发布考试成功");
                }
            }
            else if (op == "ScoreP")
            {
                result = examDAL.SetAudit(eid, 3);
                if (result > 0)
                {
                    GetCondition();
                    DataBindList();
                    ShowMessage("发布考试成绩成功");
                }
            }
        }

        #region 考试设置页面跳转
        protected void lbtn_SeatSequence_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string eid = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('ExamEdit.aspx?id={0}','_self')</script>", eid);
            Response.Write(aa);
        }
        #endregion

        #region 添加事件
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string aa = string.Format("<script language=javascript>window.open('ExamEdit.aspx','_self')</script>");
            Response.Write(aa);
        } 
        #endregion

        //#region 考试科目安排页面跳转
        ///// <summary>
        ///// 考试科目安排页面跳转
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lbtn_SubjectSet_Click(object sender, EventArgs e)
        //{
        //    LinkButton lbtn = (LinkButton)sender;
        //    string eid = lbtn.CommandArgument.ToString();
        //    string aa = string.Format("<script language=javascript>window.open('SubjectSet.aspx?eid={0}', '_self')</script>", eid);
        //    Response.Write(aa);
        //}
        //#endregion
    }
}