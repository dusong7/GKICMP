/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年11月1日 8时25分01秒
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
    public partial class InvoiceTotelDetail : PageBase
    {
        public InvoiceDAL invoiceDAL = new InvoiceDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        /// <summary>
        /// 报销类型
        /// </summary>
        public int IType
        {
            get
            {
                return GetQueryString<int>("type", -2);
            }
        }
        /// <summary>
        /// 报销方式
        /// </summary>
        public int IModel
        {
            get
            {
                return GetQueryString<int>("model", -2);
            }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string Begin
        {
            get
            {
                return GetQueryString<string>("begin", "1900-01-01");
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string End
        {
            get
            {
                return GetQueryString<string>("end", "9999-12-31");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindList();
            }
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            int recordCount = -1;
            InvoiceEntity model = new InvoiceEntity();
            model.InvType = IType;
            model.InvModel = IModel;
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.IState = (int)CommonEnum.AduitState.通过;
            DataTable dt = invoiceDAL.GetTotelPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(Begin), Convert.ToDateTime(End));
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
        }
        #endregion


        #region 分页事件
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 导出事件
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                int recordCount = -1;
                InvoiceEntity model = new InvoiceEntity();
                model.InvType = IType;
                model.InvModel = IModel;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.IState = (int)CommonEnum.AduitState.通过;
                DataTable dt = invoiceDAL.GetTotelPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(Begin), Convert.ToDateTime(End));
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append("<table border='1' cellpadding='0' cellspaccing='0'><tr><th>报销单位</th><th>报销金额</th><th>报销类别</th><th>报销方式</th><th>报销人</th><th>报销日期</th>");
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["AccountUnit"].ToString());
                        str.AppendFormat("<td style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["TotelCash"].ToString()));
                        str.AppendFormat("<td>{0}</td>", row["TypeName"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["ModelName"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["CreateUserName"].ToString());
                        str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["CreateDate"].ToString()).ToString("yyyy-MM-dd"));
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    CommonFunction.ExportExcel("报销统计报表详细信息", str.ToString());
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出报销统计报表详细信息", UserID));
                }
                else
                {
                    ShowMessage("暂无数据导出");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "导出报销统计报表详细信息", UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}