using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MvcWebSite.Models
{
    /// <summary>
    /// 显示用SysUser
    /// </summary>
    public class SysUser
    {
        public SysUser() { }
        public string UserType { get; set; }
        public string UserID { get; set; }
        public string SysUserName { get; set; }
        public string RealName { get; set; }
        //public string SysUserPwd { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="r"></param>
        public SysUser(SqlDataReader r)
        {
            this.UserType = r["UserType"].ToString();
            this.UserID = r["UID"].ToString();
            this.SysUserName = r["UserName"].ToString();
            this.RealName = r["RealName"].ToString();
            //this.SysUserPwd = r["UserPwd"].ToString();

        }
    }


}