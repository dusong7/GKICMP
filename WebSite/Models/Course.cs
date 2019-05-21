using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MvcWebSite.Models
{
    /// <summary>
    /// 显示用Course
    /// </summary>
    public class Course
    {
        public Course() { }
        public int CID { get; set; }
        public string CourseName { get; set; }
        public string CourseOther { get; set; }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="r"></param>
        public Course(SqlDataReader r)
        {
            this.CID = Convert.ToInt32(r["CID"].ToString());
            this.CourseName = r["CourseName"].ToString();
            this.CourseOther = r["CourseOther"].ToString();
        }
    }


}