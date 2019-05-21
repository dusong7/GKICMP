using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MvcWebSite.Models
{
    /// <summary>
    /// 显示用Site
    /// </summary>
    public class Site
    {
        public Site() { }
        public int SID { get; set; }
        public string CompanyName { get; set; }
        public string WebTtitle { get; set; }
        public string AttachTtile { get; set; }
        public string LogoUrl { get; set; }
        public string IcoUrl { get; set; }
        public string DWebsite { get; set; }
        public string SitePath { get; set; }
        public string LinkUser { get; set; }
        public string TellPhone { get; set; }
        public string CellPhone { get; set; }
        public string Fax { get; set; }
        public string EmailCode { get; set; }
        public string PostCode { get; set; }
        public string RecordCode { get; set; }
        public string Address { get; set; }
        public string TotelCode { get; set; }
        public string Copyright { get; set; }
        public string SiteKey { get; set; }
        public string SiteDesc { get; set; }
        public string ThrCode { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="r"></param>
        public Site(SqlDataReader r)
        {
            this.SID = Convert.ToInt32(r["SID"].ToString());
            this.CompanyName = r["CompanyName"].ToString();
            this.WebTtitle = r["WebTtitle"].ToString();
            this.AttachTtile = r["AttachTtile"].ToString();
            this.LogoUrl = r["LogoUrl"].ToString();
            this.IcoUrl = r["IcoUrl"].ToString();
            this.DWebsite = r["DWebsite"].ToString();
            this.SitePath = r["SitePath"].ToString();
            this.LinkUser = r["LinkUser"].ToString();
            this.TellPhone = r["TellPhone"].ToString();
            this.CellPhone = r["CellPhone"].ToString();
            this.Fax = r["Fax"].ToString();
            this.EmailCode = r["EmailCode"].ToString();
            this.PostCode = r["PostCode"].ToString();
            this.RecordCode = r["RecordCode"].ToString();
            this.Address = r["Address"].ToString();
            this.TotelCode = r["TotelCode"].ToString();
            this.Copyright = r["Copyright"].ToString();
            this.SiteKey = r["SiteKey"].ToString();
            this.SiteDesc = r["SiteDesc"].ToString();
            this.ThrCode = r["ThrCode"].ToString();
        }
    }


}