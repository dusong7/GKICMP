/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:     2017年03月03日
** 描 述:       基础数据编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.studentmanage
{
    public partial class StuEvaluateManage : PageBase
    {
        public Stu_EvaluateDAL stu_EvaluateDAL = new Stu_EvaluateDAL();
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
            ViewState["UserName"] = CommonFunction.GetCommoneString(this.txt_UserName.Text.ToString().Trim());
            ViewState["EYear"] = CommonFunction.GetCommoneString(this.txt_EYear.Text.ToString().Trim());
            //ViewState["SchoolName"] = CommonFunction.GetCommoneString(this.txt_SchoolName.Text.ToString().Trim());
            //ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString();
            //ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Stu_EvaluateEntity model = new Stu_EvaluateEntity();
            model.StuID = (string)ViewState["UserName"];
            model.EYear = (string)ViewState["EYear"];
            model.Term = int.Parse(this.ddl_Term.SelectedValue);
           // model.SysID = (string)ViewState["UserName"];
            DataTable dt = stu_EvaluateDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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

        protected void btn_OutPut_Click(object sender, EventArgs e)
        {

        }


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                //LinkButton lbtn = (LinkButton)sender;
                //string id = lbtn.CommandArgument.ToString();
                string id = this.hf_CheckIDS.Value;
                int result = stu_EvaluateDAL.DeleteBat(id);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除学生评语信息", UserID));
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
                return;
            }
        }
        #endregion

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("StuEvaluateEdit.aspx",false);
        }

        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            Response.Redirect("StuEvaluateEdit.aspx?id=" + id, false);
        }


        //#region 详情跳转
        ///// <summary>
        ///// 详情跳转
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lbtn_Detail_Click(object sender, EventArgs e)
        //{
        //    LinkButton lbtn = (LinkButton)sender;
        //    string id = lbtn.CommandArgument.ToString();
        //    string aa = string.Format("<script language=javascript>window.open('ComputerRegDetail.aspx?id={0}', '_self')</script>", id);
        //    Response.Write(aa);
        //}
        //#endregion
    }
}