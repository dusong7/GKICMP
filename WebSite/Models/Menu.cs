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
        public string MName { get; set; }
        public int PID { get; set; }
        public string MContent { get; set; }
        public string MNanner { get; set; }
        public string LinkUrl { get; set; }
        public string MDescription { get; set; }
        public string EngName { get; set; }

        public List<Menu> ChildMenu { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="r"></param>
        public Menu(SqlDataReader r)
        {
            this.MID = Convert.ToInt32(r["MID"].ToString());
            this.MName = r["MName"].ToString();
            this.PID = Convert.ToInt32(r["PID"].ToString());
            this.MContent = r["MContent"].ToString();
            this.MNanner = r["MNanner"].ToString();
            this.LinkUrl = r["LinkUrl"].ToString();
            this.MDescription = r["MDescription"].ToString();
            this.EngName = r["EngName"].ToString();
            this.ChildMenu = new List<Menu>();
        }
    }


}