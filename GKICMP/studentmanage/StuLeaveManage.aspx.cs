/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月16日 08时30分53秒
** 描    述:      学生考勤列表页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;

namespace GKICMP.studentmanage
{
    public partial class StuLeaveManage : PageBase
    {
        public StuLeaveDAL stuLeaveDAL = new StuLeaveDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.AttendState>(this.ddl_AttendState, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["DIDName"] = CommonFunction.GetCommoneString(this.txt_DIDName.Text.Trim());
            ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
            ViewState["User"] = CommonFunction.GetCommoneString(this.txt_User.Text);
            ViewState["AttendState"] = this.ddl_AttendState.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            StuLeaveEntity model = new StuLeaveEntity();
            model.AttendState = Convert.ToInt32(ViewState["AttendState"].ToString());
            int recordCount = 0;
            DataTable dt = stuLeaveDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, ViewState["User"].ToString(), Convert.ToDateTime(ViewState["begin"].ToString()), Convert.ToDateTime(ViewState["end"].ToString()), ViewState["DIDName"].ToString());
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


        #region 导出
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                StuLeaveEntity model = new StuLeaveEntity();
                model.AttendState = Convert.ToInt32(ViewState["AttendState"].ToString());
                int recordCount = 0;
                DataTable dt = stuLeaveDAL.GetPaged(int.MaxValue, 1, ref recordCount, model, ViewState["User"].ToString(), Convert.ToDateTime(ViewState["begin"].ToString()), Convert.ToDateTime(ViewState["end"].ToString()), ViewState["DIDName"].ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    str.Append("<table border='1' cellpadding='0' cellspaccing='0'><tr><th>学生姓名</th><th>班级名称</th><th>日期</th><th>考勤状态</th><th>天数</th><th>备注</th></tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["LeaveUserName"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["DIDName"].ToString());
                        str.AppendFormat("<td style='vnd.ms-excel.numberformat:yyyy-mm-dd'>{0}</td>", row["LeaveDate"].ToString());
                        str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.AttendState>(row["AttendState"].ToString()));
                        str.AppendFormat("<td style='vnd.ms-excel.numberformat:#,##0.0'>{0}</td>", row["LeaveDays"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["LeaveMark"].ToString());
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出学生考勤", UserID));
                    CommonFunction.ExportExcel("学生考勤", str.ToString());
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