using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MvcWebSite.Models
{
    /// <summary>
    /// 显示用Menu
    /// </summary>
    public class Menu
    {
        public Menu() { }
        public int MID { get; set; }
        public int MType { get; set; }
        public int MOrder { get; set; }
        public string MName { get; set; }
        public int PID { get; set; }
        public string MContent { get; set; }
        public string MNanner { get; set; }
        public string LinkUrl { get; set; }
        public string MDescription { get; set; }
        public string EngName { get; set; }

        public string ImageUrl { get; set; }

        public List<Menu> ChildMenu { get; set; }

        public string MenuTemplate { get; set; }

        public string DetailTemplate { get; set; }

        public int IsAudit { get; set; }

        public int IsComment { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="r"></param>
        public Menu(SqlDataReader r)
        {
            this.MID = Convert.ToInt32(r["MID"].ToString());
            this.MType = Convert.ToInt32(r["MType"].ToString());
            this.MOrder = Convert.ToInt32(r["MOrder"].ToString());
            this.MName = r["MName"].ToString();
            this.PID = Convert.ToInt32(r["PID"].ToString());
            this.MContent = r["MContent"].ToString();
            this.MNanner = r["MNanner"].ToString();
            this.LinkUrl = r["LinkUrl"].ToString();
            this.MDescription = r["MDescription"].ToString();
            this.EngName = r["EngName"].ToString();
            this.ImageUrl = r["ImageUrl"].ToString();
            this.MenuTemplate = r["MenuTemplate"].ToString();
            this.DetailTemplate = r["DetailTemplate"].ToString();
            this.IsAudit = Convert.ToInt32(r["IsAudit"].ToString());
            this.IsComment = Convert.ToInt32(r["IsComment"].ToString());
            this.ChildMenu = new List<Menu>();
        }
    }


}