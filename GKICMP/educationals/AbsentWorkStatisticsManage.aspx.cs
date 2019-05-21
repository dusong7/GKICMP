/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月7日 18时04分
** 描 述:       代课工作量统计管理
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
    public partial class AbsentWorkStatisticsManage : PageBase
    {
        public AbsentDAL absentDAL = new AbsentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();



        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["SubUser"] = CommonFunction.GetCommoneString(this.txt_SubUser.Text.Trim());
            ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
        }
        #endregion


        #region 绑定数据
        public void DataBindList()
        {
            this.hf_begin.Value = ViewState["begin"].ToString();
            this.hf_end.Value = ViewState["end"].ToString();
            int recordCount = 0;
            AbsentEntity model = new AbsentEntity();
            model.Isdel = (int)CommonEnum.IsorNot.否;
            model.SubState = (int)CommonEnum.PraState.通过;
            model.SubUserName = ViewState["SubUser"].ToString();
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            DataTable dt = absentDAL.GetAcount(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end);
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
                int recordCount = 0;
                AbsentEntity model = new AbsentEntity();
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.SubState = (int)CommonEnum.PraState.通过;
                model.SubUserName = ViewState["SubUser"].ToString();
                DataTable dt = absentDAL.GetAcount(int.MaxValue, 1, ref recordCount, model, Convert.ToDateTime(this.hf_begin.Value), Convert.ToDateTime(this.hf_end.Value));
                if (dt != null && dt.Rows.Count > 0)
                {
                    str.Append("<table border='1' cellpaccing='0' cellpadding='0'><tr><th>姓名</th><th>代课-</th><th>代课+</th><th>核计</th></tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["SubUserName"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["Allowance"].ToString() == "0.00" ? "0" : row["Allowance"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["Plus"].ToString() == "0.00" ? "0" : row["Plus"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["ACount"].ToString() == "0.00" ? "0" : row["ACount"].ToString());
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出代课工作量统计信息", UserID));
                    CommonFunction.ExportExcel("代课工作量统计", str.ToString());
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