/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年05月31日 03点19分
** 描   述:      网站站点实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Web_SiteEntity
    {

        /// <summary>
        /// Web_Site表实体
        ///</summary>
        public Web_SiteEntity()
        {
        }


        /// <summary>
        /// Web_Site表实体
        /// </summary>
        /// <param name="sid">站点ID</param>
        /// <param name="companyname">单位名称</param>
        /// <param name="webttitle">网站标题</param>
        /// <param name="attachttile">附加标题</param>
        /// <param name="logourl">logo地址</param>
        /// <param name="icourl">ico</param>
        /// <param name="dwebsite">网址</param>
        /// <param name="sitepath">站点路径</param>
        /// <param name="linkuser">联系人</param>
        /// <param name="tellphone">联系电话</param>
        /// <param name="cellphone">手机号码</param>
        /// <param name="fax">传真</param>
        /// <param name="emailcode">邮箱</param>
        /// <param name="postcode">邮编</param>
        /// <param name="recordcode">备案号</param>
        /// <param name="address">地址</param>
        /// <param name="totelcode">统计代码</param>
        /// <param name="copyright">版权信息</param>
        /// <param name="sitekey">站点关键字</param>
        /// <param name="sitedesc">站点描述</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="thrcode">第三方代码</param>
        /// <param name="isdel">是否删除</param>
        public Web_SiteEntity(int sid, string companyname, string webttitle, string attachttile, string logourl, string icourl, string dwebsite, string sitepath, string linkuser, string tellphone, string cellphone, string fax, string emailcode, string postcode, string recordcode, string address, string totelcode, string copyright, string sitekey, string sitedesc, DateTime createdate, string thrcode, int isdel)
        {
            this.SID = sid;
            this.CompanyName = companyname;
            this.WebTtitle = webttitle;
            this.AttachTtile = attachttile;
            this.LogoUrl = logourl;
            this.IcoUrl = icourl;
            this.DWebsite = dwebsite;
            this.SitePath = sitepath;
            this.LinkUser = linkuser;
            this.TellPhone = tellphone;
            this.CellPhone = cellphone;
            this.Fax = fax;
            this.EmailCode = emailcode;
            this.PostCode = postcode;
            this.RecordCode = recordcode;
            this.Address = address;
            this.TotelCode = totelcode;
            this.Copyright = copyright;
            this.SiteKey = sitekey;
            this.SiteDesc = sitedesc;
            this.CreateDate = createdate;
            this.ThrCode = thrcode;
            this.Isdel = isdel;
        }

        private int sid;//站点ID
        private string companyname;//单位名称
        private string webttitle;//网站标题
        private string attachttile;//附加标题
        private string logourl;//logo地址
        private string icourl;//ico
        private string dwebsite;//网址
        private string sitepath;//站点路径
        private string linkuser;//联系人
        private string tellphone;//联系电话
        private string cellphone;//手机号码
        private string fax;//传真
        private string emailcode;//邮箱
        private string postcode;//邮编
        private string recordcode;//备案号
        private string address;//地址
        private string totelcode;//统计代码
        private string copyright;//版权信息
        private string sitekey;//站点关键字
        private string sitedesc;//站点描述
        private DateTime createdate;//录入时间
        private string thrcode;//第三方代码
        private int isdel;//是否删除


        ///<summary>
        ///站点ID
        ///</summary>
        public int SID
        {
            get
            {
                return sid;
            }
            set
            {
                sid = value;
            }
        }

        ///<summary>
        ///单位名称
        ///</summary>
        public string CompanyName
        {
            get
            {
                return companyname;
            }
            set
            {
                companyname = value;
            }
        }

        ///<summary>
        ///网站标题
        ///</summary>
        public string WebTtitle
        {
            get
            {
                return webttitle;
            }
            set
            {
                webttitle = value;
            }
        }

        ///<summary>
        ///附加标题
        ///</summary>
        public string AttachTtile
        {
            get
            {
                return attachttile;
            }
            set
            {
                attachttile = value;
            }
        }

        ///<summary>
        ///logo地址
        ///</summary>
        public string LogoUrl
        {
            get
            {
                return logourl;
            }
            set
            {
                logourl = value;
            }
        }

        ///<summary>
        ///ico
        ///</summary>
        public string IcoUrl
        {
            get
            {
                return icourl;
            }
            set
            {
                icourl = value;
            }
        }

        ///<summary>
        ///网址
        ///</summary>
        public string DWebsite
        {
            get
            {
                return dwebsite;
            }
            set
            {
                dwebsite = value;
            }
        }

        ///<summary>
        ///站点路径
        ///</summary>
        public string SitePath
        {
            get
            {
                return sitepath;
            }
            set
            {
                sitepath = value;
            }
        }

        ///<summary>
        ///联系人
        ///</summary>
        public string LinkUser
        {
            get
            {
                return linkuser;
            }
            set
            {
                linkuser = value;
            }
        }

        ///<summary>
        ///联系电话
        ///</summary>
        public string TellPhone
        {
            get
            {
                return tellphone;
            }
            set
            {
                tellphone = value;
            }
        }

        ///<summary>
        ///手机号码
        ///</summary>
        public string CellPhone
        {
            get
            {
                return cellphone;
            }
            set
            {
                cellphone = value;
            }
        }

        ///<summary>
        ///传真
        ///</summary>
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }

        ///<summary>
        ///邮箱
        ///</summary>
        public string EmailCode
        {
            get
            {
                return emailcode;
            }
            set
            {
                emailcode = value;
            }
        }

        ///<summary>
        ///邮编
        ///</summary>
        public string PostCode
        {
            get
            {
                return postcode;
            }
            set
            {
                postcode = value;
            }
        }

        ///<summary>
        ///备案号
        ///</summary>
        public string RecordCode
        {
            get
            {
                return recordcode;
            }
            set
            {
                recordcode = value;
            }
        }

        ///<summary>
        ///地址
        ///</summary>
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        ///<summary>
        ///统计代码
        ///</summary>
        public string TotelCode
        {
            get
            {
                return totelcode;
            }
            set
            {
                totelcode = value;
            }
        }

        ///<summary>
        ///版权信息
        ///</summary>
        public string Copyright
        {
            get
            {
                return copyright;
            }
            set
            {
                copyright = value;
            }
        }

        ///<summary>
        ///站点关键字
        ///</summary>
        public string SiteKey
        {
            get
            {
                return sitekey;
            }
            set
            {
                sitekey = value;
            }
        }

        ///<summary>
        ///站点描述
        ///</summary>
        public string SiteDesc
        {
            get
            {
                return sitedesc;
            }
            set
            {
                sitedesc = value;
            }
        }

        ///<summary>
        ///录入时间
        ///</summary>
        public DateTime CreateDate
        {
            get
            {
                return createdate;
            }
            set
            {
                createdate = value;
            }
        }

        ///<summary>
        ///第三方代码
        ///</summary>
        public string ThrCode
        {
            get
            {
                return thrcode;
            }
            set
            {
                thrcode = value;
            }
        }

        ///<summary>
        ///是否删除
        ///</summary>
        public int Isdel
        {
            get
            {
                return isdel;
            }
            set
            {
                isdel = value;
            }
        }
    }
}

