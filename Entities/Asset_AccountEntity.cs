/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月20日 02点50分
** 描   述:      资产盘点实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Asset_AccountEntity
    {

        /// <summary>
        /// Asset_Account表实体
        ///</summary>
        public Asset_AccountEntity()
        {
        }


        /// <summary>
        /// Asset_Account表实体
        /// </summary>
        /// <param name="aaid">ID</param>
        /// <param name="accbegin">盘点开始日期</param>
        /// <param name="accend">盘点结束日期</param>
        /// <param name="accduty">负责人</param>
        /// <param name="accgroup">主要成员</param>
        /// <param name="accdesc">固定资产清查情况说明</param>
        /// <param name="createruser">录入人</param>
        /// <param name="createdate">录入日期</param>
        /// <param name="isdel">是否删除</param>
        public Asset_AccountEntity(string aaid, DateTime accbegin, DateTime accend, string accduty, string accgroup, string accdesc, string createruser, DateTime createdate, int isdel)
        {
            this.AAID = aaid;
            this.AccBegin = accbegin;
            this.AccEnd = accend;
            this.AccDuty = accduty;
            this.AccGroup = accgroup;
            this.AccDesc = accdesc;
            this.CreaterUser = createruser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private string aaid;//ID
        private DateTime accbegin;//盘点开始日期
        private DateTime accend;//盘点结束日期
        private string accduty;//负责人
        private string accgroup;//主要成员
        private string accdesc;//固定资产清查情况说明
        private string createruser;//录入人
        private DateTime createdate;//录入日期
        private int isdel;//是否删除
        private int depid;//盘点部门
        private int aaflag;//类型 1：全部盘点 2：部门盘点
        private string departname;//部门名称
        private string accdutyName;
        private string createruserName;

        public string CreateruserName
        {
            get { return createruserName; }
            set { createruserName = value; }
        }

        public string AccdutyName
        {
            get { return accdutyName; }
            set { accdutyName = value; }
        }


        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartName
        {
            get { return departname; }
            set { departname = value; }
        }

        /// <summary>
        /// 盘点部门
        /// </summary>
        public int DepID
        {
            get { return depid; }
            set { depid = value; }
        }


        /// <summary>
        /// 类型 1：全部盘点 2：部门盘点
        /// </summary>
        public int AAFlag
        {
            get { return aaflag; }
            set { aaflag = value; }
        }

        ///<summary>
        ///ID
        ///</summary>
        public string AAID
        {
            get
            {
                return aaid;
            }
            set
            {
                aaid = value;
            }
        }

        ///<summary>
        ///盘点开始日期
        ///</summary>
        public DateTime AccBegin
        {
            get
            {
                return accbegin;
            }
            set
            {
                accbegin = value;
            }
        }

        ///<summary>
        ///盘点结束日期
        ///</summary>
        public DateTime AccEnd
        {
            get
            {
                return accend;
            }
            set
            {
                accend = value;
            }
        }

        ///<summary>
        ///负责人
        ///</summary>
        public string AccDuty
        {
            get
            {
                return accduty;
            }
            set
            {
                accduty = value;
            }
        }

        ///<summary>
        ///主要成员
        ///</summary>
        public string AccGroup
        {
            get
            {
                return accgroup;
            }
            set
            {
                accgroup = value;
            }
        }

        ///<summary>
        ///固定资产清查情况说明
        ///</summary>
        public string AccDesc
        {
            get
            {
                return accdesc;
            }
            set
            {
                accdesc = value;
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

