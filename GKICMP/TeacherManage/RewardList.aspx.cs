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

namespace GKICMP.teachermanage
{
    public partial class RewardList : PageBase
    {
        public Teacher_RewardDAL teacher_RewardDAL = new Teacher_RewardDAL();
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

            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;
        }
        #endregion

        public void InfoBind()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = teacher_RewardDAL.GetRewardList(Convert.ToDateTime(ViewState["begin"].ToString()), Convert.ToDateTime(ViewState["end"].ToString()));
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
                sb.Append("text: '教师获奖统计'");
                sb.Append("},");
                sb.Append("subtitle: {");
                sb.Append("text: '数据截止 " +( this.txt_EDate.Text == "" ? DateTime.Now.ToString("yyyy-MM-dd") : this.txt_EDate.Text )+ "'");
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
                sb.Append("                 ['特等', "+dt.Rows[0]["TD"]+"],");
                sb.Append("                 ['一等', " + dt.Rows[0]["YD"] + "],");
                sb.Append("                 ['二等', " + dt.Rows[0]["ED"] + "],");
                sb.Append("                 ['三等', " + dt.Rows[0]["SD"] + "],");
                sb.Append("                 ['四等', " + dt.Rows[0]["SID"] + "],");
                sb.Append("                 ['未评等级', " + dt.Rows[0]["WP"] + "],");
                sb.Append("                 ['其他', " + dt.Rows[0]["QT"] + "],");
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
    }
   
}