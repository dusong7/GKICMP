/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2017年06月07日 09点30分
** 描   述:      按月份来统计班班通
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
using System.Text;

namespace GKICMP.computermanage
{
    public partial class ComputerDep : System.Web.UI.Page
    {

        public ComputerRegDAL computerRegDAL = new ComputerRegDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txt_SDate.Text = DateTime.Now.AddMonths(-6).AddDays(1).ToString("yyyy-MM-dd");
                //this.txt_EDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.txt_EDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

                GetCondition();
                InfoBind();
            }
        }

        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01 00:00:01" : this.txt_SDate.Text ;
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31 23:59:59" : this.txt_EDate.Text ;

            //ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01 00:00:01" : this.txt_SDate.Text + " 00:00:01";
            //ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31 23:59:59" : this.txt_EDate.Text + " 23:59:59";
        }
        #endregion

        public void InfoBind()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dtsum = computerRegDAL.Counts(Convert.ToDateTime(ViewState["begin"].ToString()), Convert.ToDateTime(ViewState["end"].ToString()));

            //统计班班通记录总数
            DataTable sum = computerRegDAL.GetListSum(Convert.ToDateTime(ViewState["begin"].ToString()), Convert.ToDateTime(ViewState["end"].ToString()));
            this.ltl_Sum.Text = "总共：" + sum.Rows[0]["zg"] + "  条登记记录";
            
            if (dtsum != null && dtsum.Rows.Count > 0)
            {
                string a = "";
                foreach (DataRow dr in dtsum.Rows)
                {
                    a += "['" + dr["ComputerName"].ToString() + "'," + dr["zg"].ToString() + "],";
                }
                this.tr_null.Visible = false;
                sb.Append("<script>");
                sb.Append("$(function () {");
                sb.Append("$('#container').highcharts({");
                sb.Append("chart: {");
                sb.Append("type: 'column'");
                sb.Append("},");
                sb.Append("title: {");
                sb.Append("text: '设备班班通统计'");
                sb.Append("},");
                sb.Append("subtitle: {");
                //sb.Append("text: '数据截止至" + ( DateTime.Now.ToString("yyyy-MM-dd") ) + "'");
                sb.Append("text: '数据截止 " + (this.txt_SDate.Text == "" ? "" : this.txt_SDate.Text) + "至" + (this.txt_EDate.Text == "" ? DateTime.Now.ToString("yyyy-MM-dd") : this.txt_EDate.Text) + "'");
                sb.Append("         },");
                sb.Append("         xAxis: {");
                sb.Append("             type: 'category',");
                sb.Append("             labels: {");
                sb.Append("                 rotation: 90,");
                sb.Append("                 style: {");
                sb.Append("                     fontSize: '13px',");
                sb.Append("                     fontFamily: 'Verdana, sans-serif'");
                sb.Append("                 }");
                sb.Append("             }");
                sb.Append("         },");
                sb.Append("         yAxis: {");
                sb.Append("             min: 0,");
                sb.Append("             title: {");
                sb.Append("                 text: '次数'");
                sb.Append("             }");
                sb.Append("         },");
                sb.Append("         legend: {");
                sb.Append("             enabled: false");
                sb.Append("         },");
                sb.Append("         tooltip: {");
                sb.Append("             pointFormat: '共: <b>{point.y:1f} 次</b>'");
                sb.Append("         },");
                sb.Append("         series: [{");
                sb.Append("             name: '总次数',");
                sb.Append("             data: [");
                sb.Append(a);
                sb.Append("             ],");
                sb.Append("             dataLabels: {");
                sb.Append("                 enabled: true,");
                sb.Append("                 rotation: -90,");
                sb.Append("                 color: '#FFFFFF',");
                sb.Append("                 align: 'right',");
                sb.Append("                 format: '{point.y:1f}',");
                sb.Append("                 y: 10, ");
                sb.Append("                 style: {");
                sb.Append("                     fontSize: '13px',");
                sb.Append("                     fontFamily: 'Verdana, sans-serif'");
                sb.Append("                 }");
                sb.Append("             }");
                sb.Append("         }]");
                sb.Append("     });");
                sb.Append(" });");
                sb.Append("</script>");
                this.ltl_RewardList.Text = sb.ToString();
            }
            else
            {
                this.tr_null.Visible = true;
                this.ltl_RewardList.Text = "";
            }
            this.rp_List.DataSource = dtsum;
            this.rp_List.DataBind();


        }


        protected void btn_Query_Click(object sender, EventArgs e)
        {
            GetCondition();
            InfoBind();
        }

        #region 导出事件
        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            ComputerRegEntity model = new ComputerRegEntity();
            DataTable dt = computerRegDAL.Counts(Convert.ToDateTime(ViewState["begin"].ToString()), Convert.ToDateTime(ViewState["end"].ToString()));

            //if (dt == null || dt.Rows.Count == 0)
            //{
            //    ShowMessage("暂无数据导出！");
            //    return;
            //}
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>设备</strong></th>
                                        <th><strong>登记次数</strong></th>
                                     </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["ComputerName"]);
                    str.AppendFormat("<td>{0}</td>", row["zg"]);
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("教装项目申报", str.ToString());
            //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出教装项目申报", UserID));

        }
        #endregion

    }
}