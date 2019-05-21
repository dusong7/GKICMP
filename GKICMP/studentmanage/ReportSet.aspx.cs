
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using System.Text;
using System.Configuration;
namespace GKICMP.studentmanage
{
    public partial class ReportSet : PageBase
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public StudentDAL studentDAL = new StudentDAL();
        public Stu_EvaluateDAL stu_EvaluateDAL = new Stu_EvaluateDAL();
        public Stu_QualityDAL stu_QualityDAL = new Stu_QualityDAL();
        public Stu_PhysicalDAL stu_PhysicalDAL = new Stu_PhysicalDAL();
        public Stu_RewardDAL stu_RewardDAL = new Stu_RewardDAL();
        public ExamDAL examDAL = new ExamDAL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
               // this.txt_EYear.Text = DateTime.Now.Month > 9 || DateTime.Now.Month < 3 ? DateTime.Now.Year.ToString() + "-" + DateTime.Now.AddYears(1).Year.ToString() : DateTime.Now.AddYears(-1).Year.ToString() + "-" + DateTime.Now.Year.ToString();

                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-99");

                if (DateTime.Now.Month > 9 || DateTime.Now.Month < 3)
                {
                    //this.txt_EYear.Text = DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
                    this.txt_EYear.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.AddYears(1).Year.ToString();

                    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.上学期).ToString();
                }
                else 
                {
                    //this.txt_EYear.Text = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
                    this.txt_EYear.Text = DateTime.Now.AddYears(-1).Year.ToString() + "-" + DateTime.Now.Year.ToString();
                    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.下学期).ToString();
                }

              

                DataTable dt = departmentDAL.GetClassByBZR(UserID,(int)CommonEnum.DepType.普通班级,(int)CommonEnum.IsorNot.否);
                CommonFunction.DDlTypeBind(this.ddl_Dep,dt,"DID","OtherName","-2");

            }
        }

        protected void ddl_Dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = examDAL.GetExamListByDID(int.Parse(this.ddl_Dep.SelectedValue));
            CommonFunction.DDlTypeBind(this.ddl_ScoureByPS, dt, "EID", "EName", "-2");
            CommonFunction.DDlTypeBind(this.ddl_ScoureByQZ, dt, "EID", "EName", "-2");
            CommonFunction.DDlTypeBind(this.ddl_ScoureByZH, dt, "EID", "EName", "-2");
        }


        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("xnb", typeof(string));
            dtReport.Columns.Add("xne", typeof(string));
            dtReport.Columns.Add("term", typeof(string));
            dtReport.Columns.Add("school", typeof(string));
            dtReport.Columns.Add("grade", typeof(string));
            dtReport.Columns.Add("class", typeof(string));
            dtReport.Columns.Add("stid", typeof(string));
            dtReport.Columns.Add("name", typeof(string));
            dtReport.Columns.Add("num", typeof(string));
            dtReport.Columns.Add("bmouth", typeof(string));
            dtReport.Columns.Add("emouth", typeof(string));
            DataTable stu = studentDAL.GetStuByClass(int.Parse(this.ddl_Dep.SelectedValue));
            if (stu != null && stu.Rows.Count > 0) 
            {
                foreach (DataRow dr in stu.Rows) 
                {
                    List<string> list = new List<string>();
                    list.Add(this.txt_EYear.Text.Split('-')[0]);
                    list.Add(this.txt_EYear.Text.Split('-')[1]);
                    list.Add(this.ddl_Term.SelectedValue == "1" ? "一" : "二");
                    list.Add(ConfigurationManager.AppSettings["SchoolName"]);

                    list.Add(dr["GName"].ToString());
                    list.Add(this.ddl_Dep.SelectedItem.Text);
                    list.Add(dr["uid"].ToString());
                    list.Add(dr["RealName"].ToString());
                    list.Add(dr["uid"].ToString());
                    list.Add(this.txt_BDate.Text);
                    list.Add(this.txt_EDate.Text);
                    dtReport.Rows.Add(list.ToArray());
                }

                //班主任寄语
                DataTable dtpy = stu_EvaluateDAL.GetStu(this.txt_EYear.Text.Trim().Replace(" ", ""), int.Parse(this.ddl_Term.SelectedValue), int.Parse(this.ddl_Dep.SelectedValue));
                //综合考核项目
                DataTable dtzh = stu_QualityDAL.GetStu(this.txt_EYear.Text.Trim().Replace(" ", ""), int.Parse(this.ddl_Term.SelectedValue), int.Parse(this.ddl_Dep.SelectedValue));
                //身体状况
                DataTable dtst = stu_PhysicalDAL.GetStu(this.txt_EYear.Text.Trim().Replace(" ", ""), int.Parse(this.ddl_Term.SelectedValue), int.Parse(this.ddl_Dep.SelectedValue));
                //奖惩情况
                DataTable dtjc = stu_RewardDAL.GetStu(this.txt_EYear.Text.Trim().Replace(" ", ""), int.Parse(this.ddl_Term.SelectedValue), int.Parse(this.ddl_Dep.SelectedValue));

                //学科课程学习情况
                //平时

                DataTable dtkcxx = stu_PhysicalDAL.GetToCountStu(this.txt_EYear.Text.Trim().Replace(" ", ""), int.Parse(this.ddl_Term.SelectedValue), int.Parse(this.ddl_Dep.SelectedValue), int.Parse(this.ddl_ScoureByPS.SelectedValue), int.Parse(this.ddl_ScoureByQZ.SelectedValue), int.Parse(this.ddl_ScoureByZH.SelectedValue));


                CommonFunction.ImportWordBGD(dtReport, dtpy, dtzh, dtst, dtjc, dtkcxx, "../Template/BGD.doc", this.ddl_Dep.SelectedItem.Text + "学生报告单" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".docx", int.Parse(this.ddl_ScoureByPS.SelectedValue), int.Parse(this.ddl_ScoureByQZ.SelectedValue), int.Parse(this.ddl_ScoureByZH.SelectedValue));
               
               



            }


            #region 导出

            //           string filename = ConfigurationManager.AppSettings[""] + this.txt_EYear.Text + "学年度第" + (this.ddl_Term.SelectedValue == "1" ? "一" : "二") + this.ddl_Dep.SelectedItem.Text + "成绩报告单";

 //           //Word
 //           HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename + ".doc", System.Text.Encoding.UTF8));
 //           HttpContext.Current.Response.ContentType = "application/ms-word";
 //           //HttpContext.Current.Response.Write("<style>");
 //           //HttpContext.Current.Response.Write(cssName);
 //           //HttpContext.Current.Response.Write("</style>");

 //           HttpContext.Current.Response.Charset = "UTF-8";
 //           HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;

 //           //关闭控件的视图状态
 //           //  this.divpage.Page.EnableViewState = false;

 //           //初始化HtmlWriter
 //           //System.IO.StringWriter writer = new System.IO.StringWriter();
 //           //System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(writer);

 //           //this.divpage.RenderControl(htmlWriter);                                                                                                                                                                                              
 //           StringBuilder sb = new StringBuilder();                                                                                                                                                                                                
 //           sb.Append("<div style='width: 1000px; height: 625px; overflow: hidden; margin: auto; margin-top: 60px; font-size: 16px;'><table width='1000' border='0' cellspacing='0' cellpadding='0'>    ");
 // sb.Append("  <tbody>  <tr><td><table width='480' border='0' cellspacing='0' cellpadding='0'> <tbody>  <tr>  <td bgcolor='#000'><table width='100%' border='0' cellspacing='1' cellpadding='0'>  <tbody> <tr>   ");
 // sb.Append("              <td width='9%' align='center' bgcolor='#FFFFFF' style='line-height:1.3; font-family: '黑体';'><strong>学<br>  生<br>   自<br>  评</strong></td> <td colspan='5' bgcolor='#FFFFFF'>&nbsp;</td>  </tr> <tr> ");
 // sb.Append("              <td align='center' bgcolor='#FFFFFF' style='line-height:1.5; font-family: '黑体';'><strong>班<br>主<br>任<br>寄<br>语 </strong></td>  <td colspan='5' bgcolor='#FFFFFF'>&nbsp;</td>   </tr>  ");
 // sb.Append("          <tr><td align='center' bgcolor='#FFFFFF' style='line-height: 1.3; font-family: '黑体';'><strong>校<br>  长<br> 签<br>章</strong></td>  <td width='24%' bgcolor='#FFFFFF'>&nbsp;</td>  ");
 // sb.Append("              <td width='10%' align='center' bgcolor='#FFFFFF' style='font-family: '黑体';'><strong>教签<br>   导　<br>  主　<br> 任章</strong></td>    <td width='24%' bgcolor='#FFFFFF'>&nbsp;</td>  ");
 // sb.Append("              <td width='10%' align='center' bgcolor='#FFFFFF' style='line-height:1.9; font-family: '黑体';'><strong>班签<br> 主　<br>  任章</strong></td>  ");
 // sb.Append("              <td width='24%' bgcolor='#FFFFFF'>&nbsp;</td> </tr>  <tr>  <td align='center' bgcolor='#FFFFFF'>附<br>  知</td>");
 // sb.Append("              <td colspan='5' bgcolor='#FFFFFF' style=' line-height:2.2; padding:10px'>　　本学期<span class='leftspan'>12</span>月<span class='leftspan'>12</span>日假期开始，下学期定于<span class='leftspan'>12</span>月");
 //sb.Append(" <span class='leftspan'>12</span>日正式上课。学生须在<span class='leftspan'>12</span>月<span class='leftspan'>12</span>日上午9:00-11:00携带假期作业、本报告单等有关材料来校报到注册。</td>  ");
 // sb.Append("              </tr>   </tbody>   </table></td>   </tr>  </tbody> </table> <table width='480' border='0' cellspacing='0' cellpadding='0'>     <tbody> <tr> </tr>  </tbody>  </table> </td>  ");
 // sb.Append("      <td><table width='480' border='0' align='right' cellpadding='0' cellspacing='0'><tbody><tr>");
 // sb.Append("      <td align='center' bgcolor='#FFFFFF'><strong style='font-size: 24px; line-height: 60px; font-family: '黑体';'>芜湖市小学生素质发展报告单</strong></td></tr><tr>");
 // sb.Append("      <td height='40' align='center' bgcolor='#FFFFFF' style='line-height: 20px; font-size: 18px;'>（<span class='spantime'>2015</span>年－<span class='spantime'></span>年学年度第<span class='spantime'></span>学期）</td>");
 // sb.Append("    </tr>  <tr><td align='center' bgcolor='#FFFFFF' class='auto-style1'></td></tr><tr>");
 // sb.Append("      <td height='50' align='center' bgcolor='#FFFFFF' style='font-size:18px'>学校（盖章）<span style='border-bottom: 1px solid #000000; padding-bottom: 2px; font-family: '华文新魏';'>芜湖市凤凰城小学</span></td></tr><tr>");
 // sb.Append("      <td height='50' align='center' bgcolor='#FFFFFF' style='font-size:18px'>年级<span class='spanright'></span>班级<span class='spanright'></span></td></tr> <tr>");
 // sb.Append("      <td height='50' align='center' bgcolor='#FFFFFF' style='font-size:18px'>姓名<span class='spanright'></span>学号<span class='spanright'></span></td>");
 // sb.Append("    </tr><tr><td height='50' align='center' bgcolor='#FFFFFF'>&nbsp;</td></tr><tr>");
 // sb.Append("      <td height='50' align='right' bgcolor='#FFFFFF' style='font-size: 24px'>芜湖市教育局监制</td></tr><tr>");
 // sb.Append("      <td height='50' align='right' bgcolor='#FFFFFF' style='font-size: 24px'><span class='spantime'></span>年<span class='spantime'></span>月<span class='spantime'></span>日</td>");
 // sb.Append("    </tr></tbody></table></td></tr><tr>");
 // sb.Append("<td colspan='2'><hr style=' height:1px;border:none;border-top:1px dashed #000; margin:15px 0px'></td>");
 // sb.Append("</tr><tr><td colspan='2'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tbody><tr>");
 // sb.Append("<td bgcolor='#000'><table width='100%' border='0' cellspacing='1' cellpadding='0'>");
 // sb.Append("<tbody><tr><td width='9%' align='center' bgcolor='#FFFFFF'>家　长<br>意　见<br>（回执）<br>可另附页</td>");
 // sb.Append("<td width='19%' bgcolor='#FFFFFF' style='padding-left:10px'><p>孩子姓名：</p><p>所在班级：</p><p>家长签名：</p></td>");
 // sb.Append("   <td width='72%' bgcolor='#FFFFFF'>&nbsp;</td></tr></tbody> </table></td> </tr></tbody></table></td></tr></tbody></table></div>");                                                                                              
 //           //输出
 //           HttpContext.Current.Response.Write(sb.ToString());
            //           HttpContext.Current.Response.End();

            #endregion


        }

       
    }
}