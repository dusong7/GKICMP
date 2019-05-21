/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月31日 14时48分01秒
** 描    述:      报销编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.invoice
{
    public partial class InvoiceTotel : PageBase
    {
        public InvoiceDAL invoiceDAL = new InvoiceDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.报销方式);
                CommonFunction.DDlTypeBind(this.ddl_InvModel, dt, "SDID", "DataName", "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        private void GetCondition()
        {
            ViewState["InvModel"] = this.ddl_InvModel.SelectedValue.ToString();
            ViewState["BeginDate"] = this.txt_Begin.Text.ToString() == "" ? "1900-01-01" : this.txt_Begin.Text.ToString().Trim();
            ViewState["EndDate"] = this.txt_End.Text.ToString() == "" ? "9999-12-31" : this.txt_End.Text.ToString().Trim();
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            InvoiceEntity model = new InvoiceEntity();
            model.IState = (int)CommonEnum.AduitState.通过;
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.InvModel = Convert.ToInt32(ViewState["InvModel"].ToString());
            DataTable dt = invoiceDAL.GetTotel(model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();
        }
        #endregion


        #region 查询事件
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 导出事件
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                InvoiceEntity model = new InvoiceEntity();
                model.IState = (int)CommonEnum.AduitState.通过;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.InvModel = Convert.ToInt32(ViewState["InvModel"].ToString());
                DataTable dt = invoiceDAL.GetTotel(model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append("<table border='1' cellpadding='0' cellspaccing='0'><tr><th>报销类别</th><th>报销金额</th>");
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["TypeName"].ToString());
                        str.AppendFormat("<td style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["SumCount"].ToString()));
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    CommonFunction.ExportExcel("报销统计报表", str.ToString());
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出报销统计报表", UserID));
                }
                else
                {
                    ShowMessage("暂无数据导出");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "导出报销统计报表", UserID));
                ShowMessage(ex.Message);
            }
        } 
        #endregion
    }
}