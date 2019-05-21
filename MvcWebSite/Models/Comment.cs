using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MvcWebSite.Models
{
    /// <summary>
    /// 显示用Comment
    /// </summary>
    public class Comment
    {
        public Comment() { }
        public int CID { get; set; }
        public int NID { get; set; }
        public string ComTitle { get; set; }
        public string ComContent { get; set; }
        public string LinkUser { get; set; }
        public string ReplyContent { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="r"></param>
        public Comment(SqlDataReader r)
        {
            this.CID = Convert.ToInt32(r["CID"].ToString());
            this.NID = Convert.ToInt32(r["NID"].ToString());
            this.ComTitle = r["ComTitle"].ToString();
            this.ComContent = r["ComContent"].ToString();
            this.LinkUser = r["LinkUser"].ToString();
            this.ReplyContent = r["ReplyContent"].ToString();
        }
    }


}