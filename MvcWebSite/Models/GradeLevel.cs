using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MvcWebSite.Models
{
    /// <summary>
    /// 显示用GradeLevel
    /// </summary>
    public class GradeLevel
    {
        public GradeLevel() { }
        public int GLID { get; set; }
        public string GradeLevelName { get; set; }
        public string ShortName { get; set; }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="r"></param>
        public GradeLevel(SqlDataReader r)
        {
            this.GLID = Convert.ToInt32(r["GLID"].ToString());
            this.GradeLevelName = r["GradeLevelName"].ToString();
            this.ShortName = r["ShortName"].ToString();
        }
    }


}