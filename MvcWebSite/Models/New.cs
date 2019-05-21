using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MvcWebSite.Models
{
    /// <summary>
    /// 显示用New
    /// </summary>
    public class New
    {
        public New() { }
        public int NID { get; set; }
        public string NewsTitle { get; set; }
        //public int NOrder { get; set; }
        public string ImageUrl { get; set; }
        public string NContent { get; set; }
        public string FullNContent { get; set; }
        public int MID { get; set; }
        public int ReadCount { get; set; }
        public string NColor { get; set; }
        public int IsTop { get; set; }
        //是否头条
        public int IsRecommend { get; set; }
        public int IsImgNews { get; set; }
        public string NAuthor { get; set; }
        public string AduitUser { get; set; }
        public string NAuthorName { get; set; }
        public string AduitUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string NDescription { get; set; }

        public string MName { get; set; }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="r"></param>
        public New(SqlDataReader r)
        {
            this.NID = Convert.ToInt32(r["NID"].ToString());
            this.NewsTitle = r["NewsTitle"].ToString();
            this.ImageUrl = string.IsNullOrEmpty(r["ImageUrl"].ToString()) ? "/Resource/NoPic.png" : r["ImageUrl"].ToString();
            this.NContent = r["NContent"].ToString();
            this.FullNContent = r["NContent"].ToString();
            this.MID = Convert.ToInt32(r["MID"].ToString());
            this.ReadCount = Convert.ToInt32(r["ReadCount"].ToString());
            this.NColor = r["NColor"].ToString();
            this.IsTop = Convert.ToInt32(r["IsTop"].ToString());
            this.IsRecommend = Convert.ToInt32(r["IsRecommend"].ToString());
            this.IsImgNews = Convert.ToInt32(r["IsImgNews"].ToString());
            this.NAuthor = r["NAuthor"].ToString();
            this.AduitUser = r["AduitUser"].ToString();
            this.NAuthorName = r["NAuthorName"].ToString();
            this.AduitUserName = r["AduitUserName"].ToString();
            this.CreateDate = Convert.ToDateTime(r["CreateDate"].ToString());
            this.NDescription = r["NDescription"].ToString();
            this.MName = r["MName"].ToString();
        }
    }


}