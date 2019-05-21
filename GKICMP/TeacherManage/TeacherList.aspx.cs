using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;

namespace GKICMP.teachermanage
{
    public partial class TeacherList : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ViewState["SAge25"] = ViewState["SAge26"] = ViewState["SAge31"] = ViewState["SAge36"] = ViewState["SAge41"] = ViewState["SAge46"] = ViewState["SAge51"] = ViewState["SAge56"] = "1";
                DataBindList();
            }
        }


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            string roles = "";
            if (roles.Length > 0)
            {
                roles = roles.Substring(0, roles.Length);
            }
            DataTable dt = teacherDAL.GetTStatistics(int.Parse(this.ddl_TState.SelectedValue));
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
                StringBuilder sb = new StringBuilder();
                sb.Append("<script >");
                sb.Append(" $(function () { ");
                sb.Append("    var options = {");
                sb.Append("        series: {");
                sb.Append("            pie: {");
                sb.Append("                show: true,");
                sb.Append("                innerRadius: 0.55,");
                sb.Append("                highlight: {");
                sb.Append("                    opacity: 0");
                sb.Append("                },");
                sb.Append("                radius: 1,");
                sb.Append("                stroke: {");
                sb.Append("                    width: 10");
                sb.Append("                },");
                sb.Append("                startAngle: 2.15");
                sb.Append("            }");
                sb.Append("        },");
                sb.Append("        legend: {");
                sb.Append("            show: true,");
                sb.Append("            labelFormatter: function (label, series) {");
                sb.Append("                return '<div style=\"font-weight:bold;font-size:13px;\">'+label+'</div>'");
                sb.Append("            },");
                sb.Append("            labelBoxBorderColor: null,");
                sb.Append("            margin: 50,");
                sb.Append("            width: 20,");
                sb.Append("            padding: 1");
                sb.Append("        },");
                sb.Append("        grid: {");
                sb.Append("            hoverable: true,");
                sb.Append("            clickable: true,");
                sb.Append("        },");
                sb.Append("        tooltip: true, ");
                sb.Append("        tooltipOpts: {");
                sb.Append("            content: \"%s : %y.0人\" ,");
                sb.Append("shifts: {");
                sb.Append("x: -30,");
                sb.Append("y: -50");
                sb.Append("},");
                sb.Append("theme: 'dark',");
                sb.Append("defaultTheme: false");
                sb.Append("}");
                sb.Append("};");
                sb.Append("var data = [");
                sb.Append("     { label: \"25岁以下\", data: " + dt.Rows[0]["S25"].ToString() + ", color: \"#5A5AAD\" },");
                sb.Append("     { label: \"26-30岁\", data: " + dt.Rows[0]["S26"].ToString() + ", color: \"#009966\" },");
                sb.Append("     { label: \"31-35岁\", data: " + dt.Rows[0]["S31"].ToString() + ", color: \"#FF6600\" },");
                sb.Append("     { label: \"36-40岁\", data:" + dt.Rows[0]["S36"].ToString() + ", color: \"#666666\" },");
                sb.Append("     { label: \"41-45岁\", data: " + dt.Rows[0]["S41"].ToString() + ", color: \"#EAC100\" },");
                sb.Append("     { label: \"46-50岁\", data: " + dt.Rows[0]["S46"].ToString() + ", color: \"#336699\" },");
                sb.Append("     { label: \"51-55岁\", data: " + dt.Rows[0]["S51"].ToString() + ", color: \"#FF6666\" },");
                sb.Append("     { label: \"56-60岁\", data: " + dt.Rows[0]["S56"].ToString() + ", color: \"#2894FF\" }");
                sb.Append("        ];");
                sb.Append("        $.plot($(\"#donut-chart\"), data, options);");
                sb.Append("});");




                sb.Append("$(function () {");
                //sb.Append("    var d1 = [" + dt.Rows[0]["YJS"].ToString() + "];");
                //sb.Append("    var d2 = [" + dt.Rows[0]["BK"].ToString() + "];");
                //sb.Append("    var d3 = [" + dt.Rows[0]["DZ"].ToString() + "]; var d4 = [" + dt.Rows[0]["ZS"].ToString() + "]; ");
                //sb.Append("    var d5=[" + dt.Rows[0]["DW"].ToString() + "];");
                sb.Append("    var ds = new Array();");
                sb.Append("    ds.push({ ");
                sb.Append("        label: \"研究生\",");
                sb.Append("        data: [[0," + dt.Rows[0]["YJS"].ToString() + "]],");
                sb.Append("        bars: { order: 1 }");
                sb.Append("    });");
                sb.Append("    ds.push({");
                sb.Append("        label: \"本科\",");
                sb.Append("        data: [[0," + dt.Rows[0]["BK"].ToString() + "]],");
                sb.Append("        bars: { order: 2 }");
                sb.Append("    });");
                sb.Append("    ds.push({");
                sb.Append("        label: \"大专\",");
                sb.Append("        data: [[0," + dt.Rows[0]["DZ"].ToString() + "]],");
                sb.Append("        bars: { order: 3 }");
                sb.Append("    });");
                sb.Append("    ds.push({");
                sb.Append("        label: \"中师\",");
                sb.Append("        data: [[0," + dt.Rows[0]["ZS"].ToString() + "]],");
                sb.Append("        bars: { order: 4 }");
                sb.Append("    });");
                sb.Append("    var options = {");
                sb.Append("        bars: {");
                sb.Append("            show: true,");
                sb.Append("            barWidth: 0.2,");
                sb.Append("            fill: 1");
                sb.Append("        },");
                sb.Append("        xaxis: {");
                sb.Append("            tickFormatter:\"string\",");
                sb.Append("            ticks: [[0,\"" + dt.Rows[0]["DW"].ToString() + "\"]],");
                sb.Append("            tickLength: 0,");
                sb.Append("        },");
                sb.Append("        grid: {");
                sb.Append("            show: true,");
                sb.Append("            aboveData: false,");
                sb.Append("            color: \"#5a5e63\",");
                sb.Append("            labelMargin: 5,");
                sb.Append("            axisMargin: 0,");
                sb.Append("            borderWidth: 0,");
                sb.Append("            borderColor: null,");
                sb.Append("            minBorderMargin: 5,");
                sb.Append("            clickable: true,");
                sb.Append("            hoverable: true,");
                sb.Append("            autoHighlight: false,");
                sb.Append("            mouseActiveRadius: 20");
                sb.Append("        },");
                sb.Append("        series: {");
                sb.Append("            stack: null");
                sb.Append("        },");
                sb.Append("        legend: { position: \"ne\" },");
                sb.Append("        colors: [\"#339999\", \"#46A3FF\", \"#009966\", \"#FF9966\"],");
                sb.Append("        tooltip: true, ");
                sb.Append("        tooltipOpts: { ");
                sb.Append("            content: \"%s : %y.0\",");
                sb.Append("            shifts: { ");
                sb.Append("                x: -30,");
                sb.Append("                y: -50");
                sb.Append("            }");
                sb.Append("        }");
                sb.Append("    }; ");
                sb.Append("    $.plot($(\"#ordered-bars-chart\"), ds, options);");
                sb.Append("});");

                sb.Append(" $(function () { ");
                string score = "";
                if (dt.Rows[0]["SYZB"].ToString() == "0")
                    score = "0.000";
                else if (dt.Rows[0]["SYZB"].ToString() == (Convert.ToInt32(dt.Rows[0]["SYZB"]) + Convert.ToInt32(dt.Rows[0]["QP"])).ToString())
                    score = "100.0";
                else
                {
                    score = Math.Round(Convert.ToInt32(dt.Rows[0]["SYZB"]) * 100.0 / (Convert.ToInt32(dt.Rows[0]["SYZB"]) + Convert.ToInt32(dt.Rows[0]["QP"])), 2).ToString();
                }
                sb.Append("        $(\"#tstate\").append(\" <li>" + dt.Rows[0]["DW"].ToString() + " <span class='pull-right'>" + score + "%</span>");
                sb.Append("        <div class='progress progress-striped active progress-right'>");
                sb.Append(" <div class='bar green' style='width:" + score + "%;'></div></div> </li>\");");
                sb.Append("    });");


                sb.Append("</script >");
                this.ltl_JQuery.Text = sb.ToString();
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();

           
        }
        #endregion

        protected void btn_Query_Click(object sender, EventArgs e)
        {
            //string[] ages = this.hf_Age.Value.Trim(',').Split(',');
            string[] ages = this.txt_Age.Text.Trim(',').Split(',');
            if (this.txt_Age.Text == "")
            {
                ViewState["SAge25"] = ViewState["SAge26"] = ViewState["SAge31"] = ViewState["SAge36"] = ViewState["SAge41"] = ViewState["SAge46"] = ViewState["SAge51"] = ViewState["SAge56"] = "1";
            }
            else
            {
                ViewState["SAge25"] = ViewState["SAge26"] = ViewState["SAge31"] = ViewState["SAge36"] = ViewState["SAge41"] = ViewState["SAge46"] = ViewState["SAge51"] = ViewState["SAge56"] = "";
                for (int i = 0; i < ages.Length; i++)
                {
                    if (ages[i] == "1")
                        ViewState["SAge25"] = "1";
                    if (ages[i] == "2")
                        ViewState["SAge26"] = "1";
                    if (ages[i] == "3")
                        ViewState["SAge31"] = "1";
                    if (ages[i] == "4")
                        ViewState["SAge36"] = "1";
                    if (ages[i] == "5")
                        ViewState["SAge41"] = "1";
                    if (ages[i] == "6")
                        ViewState["SAge46"] = "1";
                    if (ages[i] == "7")
                        ViewState["SAge51"] = "1";
                    if (ages[i] == "8")
                        ViewState["SAge56"] = "1";
                }

                if (ages[0] == "")
                    this.td_Age.Visible = false;
                else
                {
                    this.td_Age.Visible = true;
                    this.td_Age.ColSpan = ages.Length;
                }
            }
            DataBindList();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<script type='text/javascript'>");
            //sb.Append("$(function () {$('#DepartList').combotree('setValues', [");
            //sb.Append(this.hf_SelectedValue.Value);
            //sb.Append("]);})</script>");
            //StringBuilder sb1 = new StringBuilder();
            //sb1.Append("<script type='text/javascript'>");
            //sb1.Append("$(function () {$('#drpAge').combotree('setValues', [");

            //sb1.Append(this.hf_Age.Value);
            //sb1.Append("]);})</script>");
            //this.ltl_xz.Text = sb.ToString();
            //this.ltl_NL.Text = sb1.ToString();
        }


        #region 导出
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            this.excel.RenderControl(htw);
            CommonFunction.ExportExcel("教师信息管理表", sb.ToString().Replace("border='0'", "border='1'"));
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出教师信息", UserID));
        }
        #endregion
    }
}