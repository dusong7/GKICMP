using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.rlsb
{
    public partial class Tj : System.Web.UI.Page
    {
        public EduResourceDAL eduDAL = new EduResourceDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public AttendSetDAL attendSetDAL = new AttendSetDAL();
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txt_MBegin.Text = DateTime.Now.ToString("yyyy-MM-dd ");
                this.txt_MEnd.Text = DateTime.Now.ToString("yyyy-MM-dd ");
                DataTable dt = attendSetDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_Attend, dt, "ASID", "AName", "-2");
                ResourceDataBind();
                DataBindList();
            }
        }
        #region 绑定资源总量
        /// <summary>
        /// 绑定资源总量
        /// </summary>
        private void ResourceDataBind()
        {
            int ss=0;
            //类型
            StringBuilder sb = new StringBuilder("");
            string strtype = "";
            DataTable dtType = attendRecordDAL.AbnormalStatistics(Pager.PageSize, Pager.CurrentPageIndex, Convert.ToDateTime(this.txt_MBegin.Text == "" ? DateTime.Now.ToString("yyyy-MM-dd") : this.txt_MBegin.Text), Convert.ToDateTime(this.txt_MEnd.Text == "" ? DateTime.Now.ToString("yyyy-MM-dd") : this.txt_MEnd.Text), int.Parse(this.rbl_OutType.SelectedValue), this.ddl_Attend.SelectedValue, ref ss);
            if (dtType != null && dtType.Rows.Count > 0)
            {

                strtype += "{ value: " + dtType.Rows[0]["yd"] + ", name: '已到' },{ value: " + dtType.Rows[0]["wd"] + ", name: '未到' }";
               
            }

            sb.Append("<script type='text/javascript'>");
            sb.Append("var myChart1 = echarts.init(document.getElementById('main1'));");
            sb.Append("option1 = {");
            sb.Append("    title: {");
            sb.Append("        text: '类型分布情况',");
            sb.Append("        subtext: '',");
            sb.Append("        left: 'center'");
            sb.Append("    },");
            sb.Append("    tooltip: {");
            sb.Append("        trigger: 'item',");
            sb.Append("        formatter: '{a} <br/>{b} : {c} ({d}%)'");
            sb.Append("    },");
            sb.Append("    legend: {");
            sb.Append("        bottom: 10,");
            sb.Append("        left: 'center',");
            sb.Append("        data: ['已到','未到']");
            sb.Append("    }, color:['#CCCCCC','#666699'],");
            sb.Append("    series: [");
            sb.Append("        {name:'考勤情况统计',");
            sb.Append("            type: 'pie',");
            sb.Append("            radius: '65%',");
            sb.Append("            center: ['50%', '50%'],");
            sb.Append("            selectedMode: 'single',");
            sb.Append("            data: [");
            sb.Append(strtype.TrimEnd(',').TrimStart(','));
            sb.Append("            ],");
            sb.Append("            itemStyle: {");
            sb.Append("                emphasis: {");
            sb.Append("                    shadowBlur: 10,");
            sb.Append("                    shadowOffsetX: 0,");
            sb.Append("                    shadowColor: 'rgba(0, 0, 0, 0.5)'");
            sb.Append("                }");
            sb.Append("            }");
            sb.Append("        }");
            sb.Append("    ]");
            sb.Append("};");
            sb.Append("if (option1 && typeof option1 === 'object') {");
            sb.Append("    myChart1.setOption(option1, true);");
            sb.Append("}");
            sb.Append("</script>");
            this.ltl_EType.Text = sb.ToString();
           // string strtype = "";
           //// DataTable dtType = eduDAL.GetResourceData(1);
           // if (dtType != null && dtType.Rows.Count > 0)
           // {
           //     for (int i = 0; i < dtType.Rows.Count; i++)
           //     {
           //         strtype += "{ value: " + dtType.Rows[i]["RCount"] + ", name: '" + GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.EType>(dtType.Rows[i]["RType"].ToString()) + "' },";
           //     }
           // }

            //sb.Append("<script type='text/javascript'>");
            //sb.Append("var myChart1 = echarts.init(document.getElementById('main1'));");
            //sb.Append("option1 = {");
            //sb.Append("    title: {");
            //sb.Append("        text: '类型分布情况',");
            //sb.Append("        subtext: '',");
            //sb.Append("        left: 'left'");
            //sb.Append("    },calculable: true,");
            //sb.Append("    tooltip: {");
            //sb.Append("        trigger: 'item',");
            //sb.Append("        formatter: '{a} <br/>{b} : {c} ({d}%)'");
            //sb.Append("xAxis: [{type: 'category',axisTick: {show: false}, data: ['2012', '2013', '2014', '2015', '2016']} ],");
            //sb.Append("yAxis: [ { type: 'value' }],");
            //sb.Append("series: [{ name: 'Forest',type: 'bar',barGap: 0, label: labelOption, data: [320, 332, 301, 334, 390] },]");
            //sb.Append("    legend: {data: ['课件', '教案', '试卷', '素材', '微课程', '在线课堂', '其他']}, ");
            
            //sb.Append("};");
            //sb.Append("if (option1 && typeof option1 === 'object') {");
            //sb.Append("    myChart1.setOption(option1, true);");
            //sb.Append("}");
            //this.ltl_EType.Text = sb.ToString();

            //学科
           // StringBuilder sb1 = new StringBuilder("");
           //// DataTable dtCourse = eduDAL.GetResourceData(2);
           // string str = " and Isdel=" + (int)CommonEnum.Deleted.未删除;
           // string coursestr = "";
           // string strcou = "";
           // //DataTable dt = courseDAL.GetCourseByWhere(str);
           // if (dt != null && dt.Rows.Count > 0)
           // {
           //     for (int i = 0; i < dt.Rows.Count; i++)
           //     {
           //         coursestr += "'" + dt.Rows[i]["CourseName"].ToString() + "',";
           //     }
           // }

           // if (dtCourse != null && dtCourse.Rows.Count > 0)
           // {
           //     for (int i = 0; i < dtCourse.Rows.Count; i++)
           //     {
           //         strcou += "{ value: " + dtCourse.Rows[i]["RCount"] + ", name: '" + dtCourse.Rows[i]["CourseName"].ToString() + "' },";
           //     }
           // }
           // sb1.Append("var myChart2 = echarts.init(document.getElementById('main2'));");
           // sb1.Append("option2 = {");
           // sb1.Append("    title: {");
           // sb1.Append("        text: '学科分布情况',");
           // sb1.Append("        subtext: '',");
           // sb1.Append("        left: 'left'");
           // sb1.Append("    },");
           // sb1.Append("    tooltip: {");
           // sb1.Append("        trigger: 'item',");
           // sb1.Append("        formatter: '{a} <br/>{b} : {c} ({d}%)'");
           // sb1.Append("    },");
           // sb1.Append("    legend: {");
           // sb1.Append("        bottom: 10,");
           // sb1.Append("        left: 'center',");
           // sb1.Append("         data:[");
           // sb1.Append(coursestr);
           // sb1.Append("]");
           // sb1.Append("    }, color:['#339966','#666666','#FFCC33','#99CCFF','#003366','#666699'],");
           // sb1.Append("    series: [");
           // sb1.Append("        {");
           // sb1.Append("            type: 'pie',");
           // sb1.Append("            radius: '65%',");
           // sb1.Append("            center: ['50%', '50%'],");
           // sb1.Append("            selectedMode: 'single',");
           // sb1.Append("            data: [");
           // sb1.Append(strcou.TrimEnd(',').TrimStart(','));
           // sb1.Append("            ],");
           // sb1.Append("            itemStyle: {");
           // sb1.Append("                emphasis: {");
           // sb1.Append("                    shadowBlur: 10,");
           // sb1.Append("                    shadowOffsetX: 0,");
           // sb1.Append("                    shadowColor: 'rgba(0, 0, 0, 0.5)'");
           // sb1.Append("               }");
           // sb1.Append("            }");
           // sb1.Append("        }");
           // sb1.Append("    ]");
           // sb1.Append("};");
           // sb1.Append("if (option2 && typeof option2 === 'object') {");
           // sb1.Append("    myChart2.setOption(option2, true);");
           // sb1.Append("}");
           // sb1.Append("</script>");
           // this.ltl_Subject.Text = sb1.ToString();
        }
        #endregion
        public void DataBindList()
        {
            int recordCount = 0;
            DataTable dtType = attendRecordDAL.AbnormalStatistics(Pager.PageSize, Pager.CurrentPageIndex, Convert.ToDateTime(this.txt_MBegin.Text == "" ? DateTime.Now.ToString("yyyy-MM-dd HH") : this.txt_MBegin.Text), Convert.ToDateTime(this.txt_MEnd.Text == "" ? DateTime.Now.AddHours(1).ToString("yyyy-MM-dd HH") : this.txt_MEnd.Text), int.Parse(this.rbl_OutType.SelectedValue), this.ddl_Attend.SelectedValue, ref recordCount);
            if (dtType != null && dtType.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            rp_List.DataSource = dtType;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
        }
        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            ResourceDataBind();
            DataBindList();
        }
    }
}