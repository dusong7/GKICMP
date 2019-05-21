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
    public class EduResource
    {
        public EduResource() { }
        public int Erid { get; set; }
        public string ResourseName { get; set; }
        public int GID { get; set; }
        public int TID { get; set; }
        public int EType { get; set; }
        public DateTime CreateDate { get; set; }
        public int DownLoadNum { get; set; }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="r"></param>
        public EduResource(SqlDataReader r)
        {
            this.Erid = Convert.ToInt32(r["Erid"].ToString());
            this.ResourseName = r["ResourseName"].ToString();
            this.GID = Convert.ToInt32(r["GID"].ToString());
            this.TID = Convert.ToInt32(r["TID"].ToString());
            this.EType = Convert.ToInt32(r["EType"].ToString());
            this.CreateDate = Convert.ToDateTime(r["CreateDate"].ToString());
            this.DownLoadNum = Convert.ToInt32(r["DownLoadNum"].ToString());
        }
    }


}