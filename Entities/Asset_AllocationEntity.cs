/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年10月27日 02点56分
** 描   述:      资产调拨实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Asset_AllocationEntity
    {

        /// <summary>
        /// Asset_Allocation表实体
        ///</summary>
        public Asset_AllocationEntity()
        {
        }


        /// <summary>
        /// Asset_Allocation表实体
        /// </summary>
        /// <param name="aaid">ID</param>
        /// <param name="outdep">调出单位</param>
        /// <param name="indep">调入单位</param>
        /// <param name="allocationdate">日期</param>
        /// <param name="outuser">移交人</param>
        /// <param name="acceptuser">接收人</param>
        /// <param name="createruser">录入人</param>
        /// <param name="createdate">录入日期</param>
        /// <param name="isdel">是否删除</param>
        public Asset_AllocationEntity(string aaid, string outdep, string indep, DateTime allocationdate, string outuser, string acceptuser, string createruser, DateTime createdate, int isdel)
        {
            this.AAID = aaid;
            this.OutDep = outdep;
            this.InDep = indep;
            this.AllocationDate = allocationdate;
            this.OutUser = outuser;
            this.AcceptUser = acceptuser;
            this.CreaterUser = createruser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private string aaid;//ID
        private string outdep;//调出单位
        private string indep;//调入单位
        private DateTime allocationdate;//日期
        private string outuser;//移交人
        private string acceptuser;//接收人
        private string createruser;//录入人
        private DateTime createdate;//录入日期
        private int isdel;//是否删除
        private string createUserName;//录入人名称
        private int aFlag;//类型
        private string allDesc;//说明

        public string AllDesc
        {
            get { return allDesc; }
            set { allDesc = value; }
        }


        public int AFlag
        {
            get { return aFlag; }
            set { aFlag = value; }
        }



        public string CreateUserName
        {
            get { return createUserName; }
            set { createUserName = value; }
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
        ///调出单位
        ///</summary>
        public string OutDep
        {
            get
            {
                return outdep;
            }
            set
            {
                outdep = value;
            }
        }

        ///<summary>
        ///调入单位
        ///</summary>
        public string InDep
        {
            get
            {
                return indep;
            }
            set
            {
                indep = value;
            }
        }

        ///<summary>
        ///日期
        ///</summary>
        public DateTime AllocationDate
        {
            get
            {
                return allocationdate;
            }
            set
            {
                allocationdate = value;
            }
        }

        ///<summary>
        ///移交人
        ///</summary>
        public string OutUser
        {
            get
            {
                return outuser;
            }
            set
            {
                outuser = value;
            }
        }

        ///<summary>
        ///接收人
        ///</summary>
        public string AcceptUser
        {
            get
            {
                return acceptuser;
            }
            set
            {
                acceptuser = value;
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

