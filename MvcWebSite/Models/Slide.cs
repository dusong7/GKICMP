using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MvcWebSite.Models
{
    /// <summary>
    /// 显示用FriendLink
    /// </summary>
    public class Slide
    {
        public Slide() { }
        public int SliID { get; set; }
        public string SType { get; set; }
        public string SlideName { get; set; }
        public string SlideUrl { get; set; }
        public string SImage { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="r"></param>
        public Slide(SqlDataReader r)
        {
            this.SliID = Convert.ToInt32(r["SliID"].ToString());
            this.SType = r["SType"].ToString();
            this.SlideName = r["SlideName"].ToString();
            this.SlideUrl = r["SlideUrl"].ToString();
            this.SImage = r["SImage"].ToString();
        }
    }


}