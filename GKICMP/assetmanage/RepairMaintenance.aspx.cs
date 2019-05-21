/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2017年06月07日 09点30分
** 描   述:      学生选课名单
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

namespace GKICMP.assetmanage
{
    public partial class RepairMaintenance : PageBase
    {
        public Asset_RepairDAL asset_RepairDAL = new Asset_RepairDAL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCondition();
                InfoBind();
            }
        }

        #region 获取查询条件
        public void GetCondition()
        {

            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01 00:00:01" : this.txt_SDate.Text + " 00:00:01";
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31 23:59:59" : this.txt_EDate.Text + " 23:59:59";
        }
        #endregion

        public void InfoBind()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = asset_RepairDAL.GetMaintenanceList(Convert.ToDateTime(ViewState["begin"].ToString()), Convert.ToDateTime(ViewState["end"].ToString()));
            // DataTable dtsum = asset_RepairDAL.GetListSum(Convert.ToDateTime(ViewState["begin"].ToString()), Convert.ToDateTime(ViewState["end"].ToString()));

            //统计报修记录总数
            DataTable dtsum = asset_RepairDAL.GetListSum(Convert.ToDateTime(ViewState["begin"].ToString()), Convert.ToDateTime(ViewState["end"].ToString()));
            if (dtsum != null && dtsum.Rows.Count > 0)
            {
                this.ltl_Sum.Text = "总共：" + dtsum.Rows[0]["zg"] + "  条报修记录";
            }
            else
            {
                this.ltl_Sum.Text = "暂无报修记录";
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
                sb.Append("<script>");
                sb.Append("$(function () {");
                sb.Append("$('#container').highcharts({");
                sb.Append("chart: {");
                sb.Append("type: 'column'");
                sb.Append("},");
                sb.Append("title: {");
                sb.Append("text: '维修员统计'");
                sb.Append("},");
                sb.Append("subtitle: {");
                sb.Append("text: '数据截止 " + (this.txt_SDate.Text == "" ? "" : this.txt_SDate.Text) + "至" + (this.txt_EDate.Text == "" ? DateTime.Now.ToString("yyyy-MM-dd") : this.txt_EDate.Text) + "'");
                sb.Append("         },");
                sb.Append("         xAxis: {");
                sb.Append("             type: 'category',");
                sb.Append("             labels: {");
                sb.Append("                 rotation: -45,");
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
                sb.Append("                 ['总次数', " + dtsum.Rows[0]["zg"] + "],");
                sb.Append("                 ['未维修', " + dtsum.Rows[0]["yj"] + "],");
                //sb.Append("               ['已受理', " + dtsum.Rows[0]["sl"] + "],");
                sb.Append("                 ['已维修', " + dtsum.Rows[0]["wc"] + "],");
                sb.Append("                 ['待确认完成', " + dtsum.Rows[0]["qrwc"] + "],");
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
            }
            this.rp_List.DataSource = dt;
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
            DataTable dt = asset_RepairDAL.GetMaintenanceList(Convert.ToDateTime(ViewState["begin"].ToString()), Convert.ToDateTime(ViewState["end"].ToString()));
           
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>姓名</strong></th>
                                        <th><strong>次数</strong></th>
                                        <th><strong>未维修</strong></th>
                                        <th><strong>已维修</strong></th>
                                        <th><strong>待确认完成</strong></th>
                                     </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["CreaterUserName"]);
                    str.AppendFormat("<td>{0}</td>", row["zg"]);
                    str.AppendFormat("<td>{0}</td>", row["yj"]);
                    str.AppendFormat("<td>{0}</td>", row["wc"]);
                    str.AppendFormat("<td>{0}</td>", row["qrwc"]);
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("报修记录维修员统计", str.ToString());
        }
        #endregion

    }
}