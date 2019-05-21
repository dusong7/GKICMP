/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年10月7日 8:48
** 描 述:       资源平台管理详细页面
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


namespace GKICMP.resourcesite
{
    public partial class Res_NewMain : PageBase
    {
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
                GetData();
                GetTop();
                DataBindListByZy();
                ResourceDataBind();

                this.ltl_Year.Text = DateTime.Now.Year.ToString();
            }
        }
        #endregion


        #region 获取数据top
        /// <summary>
        /// 获取数据top
        /// </summary>
        private void GetData()
        {
            DataTable dt = eduDAL.GetData();
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["RSize"] != null && dt.Rows[0]["RSize"].ToString() != "")
                {
                    this.ltl_RSize.Text = GK.GKICMP.Common.CommonFunction.CountSize(int.Parse(dt.Rows[0]["RSize"].ToString()));
                }
                else
                {
                    this.ltl_RSize.Text = "0";
                }
                //this.ltl_RSize.Text = GK.GKICMP.Common.CommonFunction.CountSize(int.Parse(size.ToString()));
                this.ltl_RCount.Text = dt.Rows[0]["RCount"].ToString();
                this.ltl_RUser.Text = dt.Rows[0]["RUser"].ToString();
            }
        }
        #endregion


        #region 获取数据top
        /// <summary>
        /// 获取数据top
        /// </summary>
        private void GetTop()
        {
            string firstdate = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "TFristDate");//根据系统设置中的本学期第一周查询资源信息
            DataTable dt = eduDAL.GetTop(Convert.ToDateTime(firstdate));
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_TopList.DataSource = dt;
            this.rp_TopList.DataBind();
        }
        #endregion


        #region 最新热门资源绑定
        /// <summary>
        /// 最新热门资源绑定
        /// </summary>
        public void DataBindListByZy()
        {
            DataTable dt = eduDAL.GetPagedZyptByFlag(1);//1 精品资源
            if (dt != null && dt.Rows.Count > 0)
            {
                this.li_null1.Visible = false;
            }
            else
            {
                this.li_null1.Visible = true;
            }
            this.rp_GoodList.DataSource = dt;
            this.rp_GoodList.DataBind();

            DataTable dt1 = eduDAL.GetPagedZyptByFlag(2);//最新资源
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                this.li_null.Visible = false;
            }
            else
            {
                this.li_null.Visible = true;
            }
            this.rp_NewList.DataSource = dt1;
            this.rp_NewList.DataBind();
        }
        #endregion


        #region 绑定资源总量
        /// <summary>
        /// 绑定资源总量
        /// </summary>
        private void ResourceDataBind()
        {
            //类型
            StringBuilder sb = new StringBuilder("");
            string strtype = "";
            DataTable dtType = eduDAL.GetResourceData(1);
            if (dtType != null && dtType.Rows.Count > 0)
            {
                for (int i = 0; i < dtType.Rows.Count; i++)
                {
                    strtype += "{ value: " + dtType.Rows[i]["RCount"] + ", name: '" + GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.EType>(dtType.Rows[i]["RType"].ToString()) + "' },";
                }
            }

            sb.Append("<script type='text/javascript'>");
            sb.Append("var myChart1 = echarts.init(document.getElementById('main1'));");
            sb.Append("option1 = {");
            sb.Append("    title: {");
            sb.Append("        text: '类型分布情况',");
            sb.Append("        subtext: '',");
            sb.Append("        left: 'left'");
            sb.Append("    },");
            sb.Append("    tooltip: {");
            sb.Append("        trigger: 'item',");
            sb.Append("        formatter: '{a} <br/>{b} : {c} ({d}%)'");
            sb.Append("    },");
            sb.Append("    legend: {");
            sb.Append("        bottom: 10,");
            sb.Append("        left: 'center',");
            sb.Append("        data: ['课件', '教案', '试卷', '素材', '微课程', '在线课堂', '其他']");
            sb.Append("    }, color:['#CCCCCC','#666699','#99CCFF','#339966','#336699','#99CC99'],");
            sb.Append("    series: [");
            sb.Append("        {");
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
            this.ltl_EType.Text = sb.ToString();

            //学科
            StringBuilder sb1 = new StringBuilder("");
            DataTable dtCourse = eduDAL.GetResourceData(2);
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
    }
}