/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年11月24日 02点06分
** 描   述:      报废实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Asset_ScrapEntity
    {

        /// <summary>
        /// Asset_Scrap表实体
        ///</summary>
        public Asset_ScrapEntity()
        {
        }

        public Asset_ScrapEntity(DateTime begindate, DateTime enddate, int isdel)
        {
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.Isdel = isdel;
        }


        /// <summary>
        /// Asset_Scrap表实体
        /// </summary>
        /// <param name="asid">ID</param>
        /// <param name="aid">资产ID</param>
        /// <param name="asnum">报废数量</param>
        /// <param name="asmark">报废说明</param>
        /// <param name="asdate">报废日期</param>
        /// <param name="createruser">录入人</param>
        /// <param name="createdate">录入日期</param>
        /// <param name="isdel">是否删除</param>
        public Asset_ScrapEntity(string asid, string aid, int asnum, string asmark, DateTime asdate, string createruser, DateTime createdate, int isdel)
        {
            this.ASID = asid;
            this.AID = aid;
            this.ASNum = asnum;
            this.ASMark = asmark;
            this.ASDate = asdate;
            this.CreaterUser = createruser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private string asid;//ID
        private string aid;//资产ID
        private int asnum;//报废数量
        private string asmark;//报废说明
        private DateTime asdate;//报废日期
        private string createruser;//录入人
        private DateTime createdate;//录入日期
        private int isdel;//是否删除

        private DateTime begindate;
        private DateTime enddate;


        public DateTime EndDate
        {
            get { return enddate; }
            set { enddate = value; }
        }

        public DateTime BeginDate
        {
            get { return begindate; }
            set { begindate = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public string ASID
        {
            get
            {
                return asid;
            }
            set
            {
                asid = value;
            }
        }

        ///<summary>
        ///资产ID
        ///</summary>
        public string AID
        {
            get
            {
                return aid;
            }
            set
            {
                aid = value;
            }
        }

        ///<summary>
        ///报废数量
        ///</summary>
        public int ASNum
        {
            get
            {
                return asnum;
            }
            set
            {
                asnum = value;
            }
        }

        ///<summary>
        ///报废说明
        ///</summary>
        public string ASMark
        {
            get
            {
                return asmark;
            }
            set
            {
                asmark = value;
            }
        }

        ///<summary>
        ///报废日期
        ///</summary>
        public DateTime ASDate
        {
            get
            {
                return asdate;
            }
            set
            {
                asdate = value;
            }
        }

        ///<summary>
        ///录入人
        ///</summary>
        public string CreaterUser
        {
            get
            {
                return createruser;
            }
            set
            {
                createruser = value;
            }
        }

        ///<summary>
        ///录入日期
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
