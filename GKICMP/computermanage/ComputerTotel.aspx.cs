/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:     2017年03月03日
** 描 述:       基础数据编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Text;
using System.Data;


namespace GKICMP.computermanage
{
    public partial class ComputerTotel : PageBase
    {
        public ComputerRegDAL computerRegDAL = new ComputerRegDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Begin"] = this.txt_SDate.Text.Trim() == "" ? DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss") : this.txt_SDate.Text.Trim() + " 00:00:00";
                ViewState["End"] = this.txt_EDate.Text.Trim() == "" ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : this.txt_EDate.Text.Trim() + " 23:59:59";
                GetResult();
            }
        }
        public void GetResult()
        {
            StringBuilder sb = new StringBuilder("");
            int result = 0;
            ComputerRegEntity model = new ComputerRegEntity();
            DataTable dt = computerRegDAL.GetResult(Convert.ToDateTime(ViewState["Begin"]), Convert.ToDateTime(ViewState["End"]));
            string str = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    str += "['" + dt.Rows[i]["ClassName"].ToString() + "'," + dt.Rows[i]["TJ"] + ",],";
            }
            str = str.TrimEnd(',');
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append("  $('#container').highcharts({");
            sb.Append(" chart: { type: 'column' },");
            sb.Append(" title: {text: '");
            sb.Append(Convert.ToDateTime(ViewState["Begin"]).ToString("yyyy-MM-dd"));
            sb.Append("至");
            sb.Append(Convert.ToDateTime(ViewState["End"]).ToString("yyyy-MM-dd"));
            sb.Append("'},");
            sb.Append(" subtitle: {text: '班班通使用情况统计表'},");
            sb.Append("xAxis: { type: 'category', labels: { rotation: -45, style: { fontSize: '13px',  fontFamily: 'Verdana, sans-serif'}} },");
            sb.Append("yAxis: { min: 0, title: { text: '节数' } },");
            sb.Append("legend: { enabled: false },");
            sb.Append("tooltip: {pointFormat: '在在这段时间内共: <b>{point.y:.0f} 节</b>'},");
            sb.Append(" series: [{name: 'Population',");
            sb.Append(" data: [ ");
            sb.Append(str.ToString());
            sb.Append("],");
            sb.Append(" dataLabels: { enabled: true, rotation: -90, color: '#FFFFFF',align: 'right', format: '{point.y:.0f}',  y: 10, ");
            sb.Append("style:{fontSize: '13px',fontFamily: 'Verdana, sans-serif' }}");
            sb.Append(" }] }); }); </script>");
            this.ltl_Content.Text = sb.ToString();
        }
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            ViewState["Begin"] = this.txt_SDate.Text.Trim() == "" ? DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss") : this.txt_SDate.Text.Trim() + " 00:00:00";
            ViewState["End"] = this.txt_EDate.Text.Trim() == "" ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : this.txt_EDate.Text.Trim() + " 23:59:59";
            GetResult();
        }
    }
}