/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月20日 02点52分
** 描   述:      资产详细实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Asset_Account_InfoEntity
    {

        /// <summary>
        /// Asset_Account_Info表实体
        ///</summary>
        public Asset_Account_InfoEntity()
        {
        }


        /// <summary>
        /// Asset_Account_Info表实体
        /// </summary>
        /// <param name="aaiid">ID</param>
        /// <param name="aaid">盘点ID</param>
        /// <param name="accname">资产名称</param>
        /// <param name="accnum">数量</param>
        /// <param name="accunit">计量单位</param>
        /// <param name="accountcash">评估净值（元）</param>
        /// <param name="aitype">类别</param>
        public Asset_Account_InfoEntity(int aaiid, string aaid, string accname, decimal accnum, string accunit, decimal accountcash, int aitype)
        {
            this.AAIID = aaiid;
            this.AAID = aaid;
            this.AccName = accname;
            this.AccNum = accnum;
            this.AccUnit = accunit;
            this.AccountCash = accountcash;
            this.AIType = aitype;
        }

        private int aaiid;//ID
        private string aaid;//盘点ID
        private string accname;//资产名称
        private decimal accnum;//数量
        private string accunit;//计量单位
        private decimal accountcash;//评估净值（元）
        private int aitype;//类别


        ///<summary>
        ///ID
        ///</summary>
        public int AAIID
        {
            get
            {
                return aaiid;
            }
            set
            {
                aaiid = value;
            }
        }

        ///<summary>
        ///盘点ID
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
        ///资产名称
        ///</summary>
        public string AccName
        {
            get
            {
                return accname;
            }
            set
            {
                accname = value;
            }
        }

        ///<summary>
        ///数量
        ///</summary>
        public decimal AccNum
        {
            get
            {
                return accnum;
            }
            set
            {
                accnum = value;
            }
        }

        ///<summary>
        ///计量单位
        ///</summary>
        public string AccUnit
        {
            get
            {
                return accunit;
            }
            set
            {
                accunit = value;
            }
        }

        ///<summary>
        ///评估净值（元）
        ///</summary>
        public decimal AccountCash
        {
            get
            {
                return accountcash;
            }
            set
            {
                accountcash = value;
            }
        }

        ///<summary>
        ///类别
        ///</summary>
        public int AIType
        {
            get
            {
                return aitype;
            }
            set
            {
                aitype = value;
            }
        }
    }
}

