using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MvcWebSite.Models
{
    /// <summary>
    /// 非显示用
    /// </summary>
    public class Details
    {
        public Details() { }
        //未读政务
        public int DZZW { get; set; }
        //教师请假
        public int JSQJ { get; set; }
        //学生请假
        public int XSQJ { get; set; }
        //代课记录
        public int DKJL { get; set; }
        //保修记录
        public int BXJL { get; set; }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="r"></param>
        public Details(SqlDataReader r)
        {
            this.DZZW = Convert.ToInt32(r["dzzw"].ToString());
            this.JSQJ = Convert.ToInt32(r["jsqj"].ToString());
            this.XSQJ = Convert.ToInt32(r["xsqj"].ToString());
            this.DKJL = Convert.ToInt32(r["dkjl"].ToString());
            this.BXJL = Convert.ToInt32(r["bxjl"].ToString());
        }
    }


}