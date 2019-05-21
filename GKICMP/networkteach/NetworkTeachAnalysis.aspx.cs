/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年11月22日 8:44
** 描 述:       网络课程分析页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Text;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;

namespace GKICMP.networkteach
{
    public partial class NetworkTeachAnalysis : PageBase
    {
        public NetworkTeachDAL teachDAL = new NetworkTeachDAL();
        public EduResourceDAL eduDAL = new EduResourceDAL();
        public CourseDAL courseDAL = new CourseDAL();

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString();
                ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString();
                ResourceDataBind();
                this.ltl_Content.Text = BindContent();
                //this.ltl_Year.Text = DateTime.Now.Year.ToString();
            }
        }
        #endregion


        #region 绑定教师排行榜
        private string BindContent()
        {
            StringBuilder sb = new StringBuilder("");
            string a = ViewState["BeginDate"].ToString();
            string b = ViewState["EndDate"].ToString();
            DataTable dtTopTeacher = teachDAL.GetTeachTop(Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));//获取网络课程表里教师，学科，总量信息
            string cids = "";//课程ID集合
            DataTable dt = null;
            sb.Append("<table width='100%' border='0' cellspacing='0' cellpadding='5'>");
            sb.Append("<tbody>");
            sb.Append("<tr><th style='color:#21aa64;'>教师</th>");
            sb.Append("<th align='center' colspan='20' style='color:#21aa64;'>上传情况</th></tr>");
            if (dtTopTeacher != null && dtTopTeacher.Rows.Count > 0)
            {
                string strcount = "";
                for (int i = 0; i < dtTopTeacher.Rows.Count; i++)
                {
                    cids = dtTopTeacher.Rows[i]["CIDS"].ToString();
                    string[] cid = cids.Split(',');
                    sb.Append("<tr>");
                    sb.Append("<td rowspan='2'><a href='#'><span>" + (i + 1) + "</span>【" + dtTopTeacher.Rows[i]["DepName"].ToString() + "】" + dtTopTeacher.Rows[i]["TeacherName"].ToString() + "</a></td>");
                    sb.Append("<td align='center' style='border-top:1px solid #f6fafd;'>上传总量</td>");
                    for (int j = 0; j < cid.Length; j++)
                    {
                        dt = teachDAL.GetCourseData(dtTopTeacher.Rows[i]["CreateUser"].ToString(), Convert.ToInt32(cid[j].ToString()));
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            sb.Append("<td align='center'>" + dt.Rows[0]["CourseName"].ToString() + "</td>");
                            strcount += "<td align='center'>" + dt.Rows[0]["NCount"].ToString() + "</td>";
                        }
                    }
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td align='center'>" + dtTopTeacher.Rows[i]["NCount"].ToString() + "</td>");
                    sb.Append(strcount.ToString());
                    sb.Append("</tr>");
                    strcount = "";
                }
            }
            else
            {
                sb.Append("<tr><td align='center' colspan='2'>暂无记录</td></tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            return sb.ToString();
        }
        #endregion


        #region 绑定资源总量
        /// <summary>
        /// 绑定资源总量
        /// </summary>
        private void ResourceDataBind()
        {
            //学科
            StringBuilder sb1 = new StringBuilder("");
            DataTable dtCourse = teachDAL.GetData(Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));
            string str = " and Isdel=" + (int)CommonEnum.Deleted.未删除;
            string coursestr = "";
            string strcou = "";
            DataTable dt = courseDAL.GetCourseByWhere(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    coursestr += "'" + dt.Rows[i]["CourseName"].ToString() + "',";
                }
            }

            if (dtCourse != null && dtCourse.Rows.Count > 0)
            {
                for (int i = 0; i < dtCourse.Rows.Count; i++)
                {
                    strcou += "{ value: " + dtCourse.Rows[i]["RCount"] + ", name: '" + dtCourse.Rows[i]["CourseName"].ToString() + "' },";
                }
            }
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("var myChart2 = echarts.init(document.getElementById('main2'));");
            sb1.Append("option2 = {");
            sb1.Append("    title: {");
            sb1.Append("        text: '学科分布情况',");
            sb1.Append("        subtext: '',");
            sb1.Append("        left: 'left'");
            sb1.Append("    },");
            sb1.Append("    tooltip: {");
            sb1.Append("        trigger: 'item',");
            sb1.Append("        formatter: '{a} <br/>{b} : {c} ({d}%)'");
            sb1.Append("    },");
            sb1.Append("    legend: {");
            sb1.Append("        bottom: 10,");
            sb1.Append("        left: 'center',");
            sb1.Append("         data:[");
            sb1.Append(coursestr);
            sb1.Append("]");
            sb1.Append("    }, color:['#339966','#666666','#FFCC33','#99CCFF','#003366','#666699'],");
            sb1.Append("    series: [");
            sb1.Append("        {");
            sb1.Append("            type: 'pie',");
            sb1.Append("            radius: '65%',");
            sb1.Append("            center: ['50%', '50%'],");
            sb1.Append("            selectedMode: 'single',");
            sb1.Append("            data: [");
            sb1.Append(strcou.TrimEnd(',').TrimStart(','));
            sb1.Append("            ],");
            sb1.Append("            itemStyle: {");
            sb1.Append("                emphasis: {");
            sb1.Append("                    shadowBlur: 10,");
            sb1.Append("                    shadowOffsetX: 0,");
            sb1.Append("                    shadowColor: 'rgba(0, 0, 0, 0.5)'");
            sb1.Append("               }");
            sb1.Append("            }");
            sb1.Append("        }");
            sb1.Append("    ]");
            sb1.Append("};");
            sb1.Append("if (option2 && typeof option2 === 'object') {");
            sb1.Append("    myChart2.setOption(option2, true);");
            sb1.Append("}");
            sb1.Append("</script>");
            this.ltl_Subject.Text = sb1.ToString();
        }
        #endregion


        #region 查询事件
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString();
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString();
            this.ltl_Content.Text = BindContent();
            ResourceDataBind();
        }
        #endregion
    }
}