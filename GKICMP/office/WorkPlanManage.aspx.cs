using System;
/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    20177214日
** 描 述:       工作计划管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System.Data;
using System.Web.UI.WebControls;
using System.Text;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.office
{
    public partial class WorkPlanManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public WorkPlanDAL workPlanDAL = new WorkPlanDAL();
        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable dt = courseDAL.GetCourseAll(UserID);
                //CommonFunction.DDlTypeBind(this.ddl_CID, dt, "CID", "CourseName", "-2");
                //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSend, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["DutyUser"] = this.txt_DutyUser.Text;
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01 00:00" : this.txt_BeginDate.Text + " 00:00";
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31 23:59" : this.txt_EndDate.Text + " 23:59";
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            WorkPlanEntity  model = new WorkPlanEntity();
            model.CreateUser = UserID;
            model.Isdel = (int)CommonEnum.IsorNot.否;
            model.DutyUser = (string)ViewState["DutyUser"];
            DataTable dt = workPlanDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));
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
            this.Pager.CurrentPageIndex = 1;
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
                int result = workPlanDAL.DeleteBat(ids,(int)CommonEnum.IsorNot.是);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除工作计划信息", UserID));
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

        protected void lbtn_Complete_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string name = lbtn.CommandName.ToString();
            if (name == "Comp")
            {
                try
                {
                    int result = workPlanDAL.CompLete(id, (int)CommonEnum.IsorNot.是);
                    if (result > 0)
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "完成工作计划", UserID));
                        ShowMessage("提交成功");
                    }
                    else
                    {
                        ShowMessage("提交失败");
                    }
                    DataBindList();
                }
                catch (Exception error)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
                    ShowMessage("提交失败");
                }
                //Response.Write("<script language=javascript>window.open('EgovernmentDetail.aspx?flag=1&ID=" + id + "', '_self')</script>");
            }
        }

        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument;
            Response.Write("<script language=javascript>window.open('WorkPlanEdit.aspx?ID=" + id + "', '_self')</script>");
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Response.Write("<script language=javascript>window.open('WorkPlanEdit.aspx?ID=', '_self')</script>");
        }


        #region 导出事件
        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            int recordCount = 0;
            StringBuilder str = new StringBuilder();
            WorkPlanEntity model = new WorkPlanEntity();
            model.CreateUser = UserID;
            model.Isdel = (int)CommonEnum.IsorNot.否;
            model.DutyUser = (string)ViewState["DutyUser"];
            DataTable dt = workPlanDAL.GetPaged(2000, 1, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));


            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>周号</strong></th>
                                        <th><strong>内容</strong></th>
                                        <th><strong>责任人</strong></th>
                                        <th><strong>部门</strong></th>
                                        <th><strong>时间</strong></th>
                                     </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["WeekNum"]);
                    str.AppendFormat("<td>{0}</td>", row["ExamName"]);
                    str.AppendFormat("<td>{0}</td>", row["DutyUserName"]);
                    str.AppendFormat("<td>{0}</td>", row["DepName"]);
                    str.AppendFormat("<td>{0}</td>", row["BeginDate"].ToString() == "" ? "" : Convert.ToDateTime(row["BeginDate"]).ToString("yyyy-MM-dd"));



                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("工作计划导出", str.ToString());


        }
        #endregion
    }
}