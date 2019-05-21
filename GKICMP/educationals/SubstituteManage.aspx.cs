/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月7日 18时04分
** 描 述:       代课安排列表管理
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;

namespace GKICMP.educationals
{
    public partial class SubstituteManage : PageBase
    {

        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AbsentDAL absentDAL = new AbsentDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.PraState>(this.ddl_SubState, " -2");
                DataTable dtCourse = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_SubCoruse, dtCourse, "CID", "CourseName", "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["SubUserName"] = CommonFunction.GetCommoneString(this.txt_SubUser.Text.Trim());
            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;
            ViewState["SubCoruse"] = this.ddl_SubCoruse.SelectedValue;
            ViewState["SubState"] = this.ddl_SubState.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            AbsentEntity model = new AbsentEntity();
            model.SubState = Convert.ToInt32(ViewState["SubState"].ToString());
            model.SubCoruse = Convert.ToInt32(ViewState["SubCoruse"].ToString());
            model.SubUserName = ViewState["SubUserName"].ToString();
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            DataTable dt = absentDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end);
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
                int result = absentDAL.DeleteByID(ids, (int)CommonEnum.IsorNot.是);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除代课安排信息", UserID));
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


        #region 复选框是否选中
        public string Istrue(object sender)
        {
            if (sender.ToString() == "1")
            {
                return "disabled";
            }
            else
            {
                return "";
            }
        }
        #endregion


        #region 修改        
        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int abid = Convert.ToInt32(lbtn.CommandArgument.ToString());
            string aa = string.Format("<script language=javascript>window.open('SubstituteEdit.aspx?id={0}', '_self')</script>", abid);
            Response.Write(aa);
        }
        #endregion

        #region 导出
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                int recordCount = 0;
                
                AbsentEntity model = new AbsentEntity();
                model.SubState = Convert.ToInt32(ViewState["SubState"].ToString());
                model.SubCoruse = Convert.ToInt32(ViewState["SubCoruse"].ToString());
                model.SubUserName = ViewState["SubUserName"].ToString();
                DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
                DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
                DataTable dt = absentDAL.GetPaged(2000, 1, ref recordCount, model, begin, end);


                str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>代课人</strong></th>
                                        <th><strong>代课课程</strong></th>
                                        <th><strong>代课节次</strong></th>
                                        <th><strong>代课日期</strong></th>
                                        <th><strong>代课班级</strong></th>

                                        <th><strong>请假人</strong></th>
                                        <th><strong>请假节数</strong></th>
                                        <th><strong>课时系数</strong></th>
                                        <th><strong>安排人</strong></th>
                                        <th><strong>安排时间</strong></th>
                                        <th><strong>状态</strong></th>
                                        <th><strong>原因</strong></th>
                                     </tr>");
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["SubUserName"]);
                        str.AppendFormat("<td>{0}</td>", row["SubCoruseName"]);
                        str.AppendFormat("<td>{0}</td>", row["SubNum"]);
                        str.AppendFormat("<td>{0}</td>", row["SubDate"].ToString() == "" ? "" : Convert.ToDateTime(row["SubDate"]).ToString("yyyy-MM-dd"));
                        str.AppendFormat("<td>{0}</td>", row["OtherName"]);

                        str.AppendFormat("<td>{0}</td>", row["AbsentUserName"]);
                        str.AppendFormat("<td>{0}</td>", row["SubCount"]);
                        str.AppendFormat("<td>{0}</td>", row["Hourse"]);
                        str.AppendFormat("<td>{0}</td>", row["CreateUserName"]);
                        str.AppendFormat("<td>{0}</td>", row["CreateDate"].ToString() == "" ? "" : Convert.ToDateTime(row["CreateDate"]).ToString("yyyy-MM-dd"));
                        str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.PraState>(row["SubState"].ToString()));
                        str.AppendFormat("<td>{0}</td>", row["Reason"]);
                        str.Append("</tr>");
                    }
                    CommonFunction.ExportExcel("教师代课导出", str.ToString());
                }
                else
                {
                    ShowMessage("暂无数据导出");
                    return;
                }
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