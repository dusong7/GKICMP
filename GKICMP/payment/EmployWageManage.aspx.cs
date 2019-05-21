/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年08月15日 08时30分
** 描 述:       聘用工资管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;
using System.Text;

namespace GKICMP.payment
{
    public partial class EmployWageManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public WageDAL wageDAL = new WageDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DdlBind();
                this.ddl_WYear.SelectedIndex = 1;
                this.ddl_WMonth.SelectedValue = Convert.ToInt32(DateTime.Now.ToString("MM")).ToString();
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 下拉框绑定
        public void DdlBind()
        {
            for (int i = 0; i < 12; i++)
            {
                if (i < 9)
                {
                    this.ddl_WMonth.Items.Add(new ListItem("0" + (i + 1).ToString(), (i + 1).ToString()));
                }
                else
                {
                    this.ddl_WMonth.Items.Add(new ListItem((i + 1).ToString(), (i + 1).ToString()));
                }
            }
            for (int i = 0; i < 3; i++)
            {
                this.ddl_WYear.Items.Add(new ListItem((Convert.ToInt32(DateTime.Now.ToString("yyyy")) + i - 1).ToString(), (Convert.ToInt32(DateTime.Now.ToString("yyyy")) + i - 1).ToString()));
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["TIDName"] = CommonFunction.GetCommoneString(this.txt_TIDName.Text.Trim());
            ViewState["WMonth"] = this.ddl_WMonth.SelectedValue;
            ViewState["WYear"] = this.ddl_WYear.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount;
            WageEntity model;
            dts(out recordCount, out model);
            DataTable dt = wageDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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

        private void dts(out int recordCount, out WageEntity model)
        {
            recordCount = 0;
            model = new WageEntity();
            model.TIDName = ViewState["TIDName"].ToString();
            model.WMonth = Convert.ToInt32(ViewState["WMonth"].ToString());
            model.WYear = Convert.ToInt32(ViewState["WYear"].ToString());
            model.Isdel = (int)CommonEnum.IsorNot.否;
            model.WFlag = (int)CommonEnum.WFlag.聘用;
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


        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = wageDAL.DeleteByID(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除聘用工资信息", UserID));
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
                int recordCount;
                WageEntity model;
                dts(out recordCount, out model);
                DataTable dt = wageDAL.GetPaged(int.MaxValue, 1, ref recordCount, model);
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append("<table border='1' cellpadding='0' cellspaccing='0'><tr><th rowspan='2'>年份</th><th rowspan='2'>月份</th><th rowspan='2'>姓名</th><th colspan='4'>工资部分</th><th rowspan='2'>应发工资</th><th colspan='6'>代扣部分</th><th rowspan='2'>工会扣除0.5%</th><th rowspan='2'>实发工资</th></tr><tr><th>基本工资</th><th>岗位工资</th><th>学历工资</th><th>上月绩效工资</th><th>养老保险8%</th><th>住房公积金12%</th><th>失业保险0.5%</th><th>大病救助</th><th>医保2%</th><th>小计</th></tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["WYear"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["WMonth"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["TIDName"].ToString());
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["Allowance"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["PostWage"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["SalaryScale"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["BasicPay"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["ShouldWage"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["Insurance"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["Accumulation"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["Unemployment"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["Serious"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["MedicalFee"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["Withhold"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["Union"].ToString()));
                        str.AppendFormat("<td  style='vnd.ms-excel.numberformat:0.00'>{0}</td>", Convert.ToDecimal(row["ActualWages"].ToString()));
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    CommonFunction.ExportExcel("聘用工资信息", str.ToString());
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出聘用工资信息", UserID));
                }
                else
                {
                    ShowMessage("暂无数据导出");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "导出聘用工资信息", UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}