
/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师合同管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GKICMP.lessonplan
{
    public partial class LessonDetail : PageBase
    {
        public LessonDAL lessonDAL = new LessonDAL();
        #region 参数集合
        /// <summary>
        /// TCID 合同ID
        /// </summary>
        public string TID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public int Term
        {
            get
            {
                return GetQueryString<int>("term", (DateTime.Now.Month > 9 || DateTime.Now.Month < 3) ? (int)CommonEnum.XQ.上学期 : (int)CommonEnum.XQ.下学期);
            }
        }
        public string Year
        {
            get
            {
                return GetQueryString<string>("year", (DateTime.Now.Month > 9 || DateTime.Now.Month < 3) ? DateTime.Now.Year.ToString() + "-" + DateTime.Now.AddYears(1).Year.ToString() : DateTime.Now.AddYears(-1).Year.ToString() + "-" + DateTime.Now.Year.ToString());
            }
        }
        public string SchoolName = ConfigurationManager.AppSettings["SchoolName"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                DataBindList();
            }
        }
        public void DataBindList() 
        {
            DataTable dt = lessonDAL.GetList(TID, Term, Year);
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    this.tr_null.Visible = false;
            //}
            //else
            //{
            //    this.tr_null.Visible = true;
            //}
            this.rp_List.DataSource = dt;
            rp_List.DataBind();
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            //string filename = "记录册";
            string url = Request.Url.Authority;
            ////Word
            //HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename + ".doc", System.Text.Encoding.UTF8));
            //HttpContext.Current.Response.ContentType = "application/ms-word";
            ////HttpContext.Current.Response.Write("<style>");
            ////HttpContext.Current.Response.Write(cssName);
            ////HttpContext.Current.Response.Write("</style>");

            //HttpContext.Current.Response.Charset = "UTF-8";
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;

            ////关闭控件的视图状态
            ////  this.divpage.Page.EnableViewState = false;

            ////初始化HtmlWriter
            //System.IO.StringWriter writer = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(writer);

            //this.jspjinfo.RenderControl(htmlWriter);

            ////输出
            //HttpContext.Current.Response.Write(writer.ToString());
            //HttpContext.Current.Response.End();
            DataTable dt = lessonDAL.GetList(TID, Term, Year);
            DataTable source = new DataTable("All");
            //source.Columns.Add("")
            source.Columns.Add("id", typeof(string));
            source.Columns.Add("pdate", typeof(string));
            source.Columns.Add("ActivityAddress", typeof(string));
            source.Columns.Add("AContent", typeof(string));
            source.Columns.Add("ActivityTarget", typeof(string));
            source.Columns.Add("ActivityPre", typeof(string));
            source.Columns.Add("AContent1", typeof(string));
            source.Columns.Add("ActivityContent", typeof(string));
            source.Columns.Add("SchoolName", typeof(string));

            source.Columns.Add("Year", typeof(string));
            source.Columns.Add("Term", typeof(string));
            source.Columns.Add("DateType", typeof(string));
            source.Columns.Add("Addr", typeof(string));
            source.Columns.Add("AddrText", typeof(string));
            source.Columns.Add("Tid", typeof(string));
            source.Columns.Add("TidText", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                List<string> list = new List<string>();
                list.Add(dr["LesID"].ToString());
                list.Add(dr["pdate"].ToString());
                list.Add(dr["ActivityAddress"].ToString());
                list.Add(dr["AContent"].ToString());
                list.Add(dr["ActivityTarget"].ToString());
                list.Add(dr["ActivityPre"].ToString());
                list.Add(dr["AContent"].ToString());
                //list.Add(NoHTML(dr["ActivityContent"].ToString()));
                //list.Add((dr["ActivityContent"].ToString().Replace("img src=\"","img src=\"http://"+url+"")));
                list.Add((dr["ActivityContent"].ToString().Replace("img src=\"", "img src=\"http://" + url + "")));
                list.Add(SchoolName);
                list.Add(Year);
                list.Add(Term.ToString());
                list.Add(dr["LType"].ToString() == "370" ? "社团活动" : "体验课程");
                list.Add(dr["LType"].ToString() == "370" ? "主讲人:" : "班级:");
                list.Add(dr["LType"].ToString() == "370" ? dr["SpeakerNames"].ToString() : dr["ClaIDName"].ToString());
                list.Add(dr["LType"].ToString() == "370" ? "助教:" : "执教教师:");
                list.Add(dr["LType"].ToString() == "370" ? dr["AssistantNames"].ToString() : dr["SpeakerNames"].ToString().Trim(','));

                source.Rows.Add(list.ToArray());
            }
            //DataTable img = new DataTable("Item");
            //img.Columns.Add("id", typeof(string));
            //img.Columns.Add("URL", typeof(string));
            //foreach (DataRow dr in dt.Rows)
            //{
            //    string[] imglist = GetHtmlImageUrlList(dr["ActivityContent"].ToString());
            //    if (imglist != null && imglist.Length > 0)
            //    {
            //        foreach (string l in imglist)
            //        {
            //            List<string> list = new List<string>();
            //            list.Add(dr["LesID"].ToString());
            //            list.Add(l);
            //            img.Rows.Add(list.ToArray());
            //        }
            //    }
            //}
            //DataSet dataSet = new DataSet();
            ////var userTable = GetUserDataTable();
            ////var userScoreTable = GetUserScoreDataTable();
            //dataSet.Tables.Add(source);
            //dataSet.Tables.Add(img);
            //dataSet.Relations.Add(new DataRelation("ScoreListForUser", source.Columns["id"], img.Columns["id"]));
            CommonFunction.ImportWord(source, "../Template/Temp1.docx", "教师备课详情"+DateTime.Now.ToString("yyyyMMddHHmmss")+".docx");
          

        }
        public static string[] GetHtmlImageUrlList(string sHtmlText)
        {
            // 定义正则表达式用来匹配 img 标签   
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串   
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表   
            foreach (Match match in matches)
                sUrlList[i++] = match.Groups["imgUrl"].Value;
            return sUrlList;
        }  
       public  string NoHTML(string Htmlstring)
         {
             if (Htmlstring.Length > 0)
             {
                 //删除脚本
                 Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                 //删除HTML
                 Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
                 Htmlstring = Regex.Replace(Htmlstring, @"&ldquo;", "\"", RegexOptions.IgnoreCase);//保留【 “ 】的标点符合
                 Htmlstring = Regex.Replace(Htmlstring, @"&rdquo;", "\"", RegexOptions.IgnoreCase);//保留【 ” 】的标点符合
                 Htmlstring.Replace("<", "");
                 Htmlstring.Replace(">", "");
                // Htmlstring.Replace("\r\n", "");
                 Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
             }
             return Htmlstring;
         }

       protected void btn_Return_Click(object sender, EventArgs e)
       {
           Response.Redirect("LessonTeacher.aspx", false);
       }
    }
}