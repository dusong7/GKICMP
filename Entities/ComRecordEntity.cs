/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2018年02月27日 04点55分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ComRecordEntity
    {

        /// <summary>
        /// ComRecord表实体
        ///</summary>
        public ComRecordEntity()
        {
        }


        /// <summary>
        /// ComRecord表实体
        /// </summary>
        /// <param name="crid">ID</param>
        /// <param name="ccid">登记ID</param>
        /// <param name="sysid">学生ID</param>
        /// <param name="regdate">登记日期</param>
        public ComRecordEntity(int crid, string ccid, string sysid, DateTime regdate)
        {
            this.CrID = crid;
            this.CCID = ccid;
            this.SysID = sysid;
            this.RegDate = regdate;
        }

        private int crid;//ID
        private string ccid;//登记ID
        private string sysid;//学生ID
        private DateTime regdate;//登记日期
        public string MAC { get; set; }

        ///<summary>
        ///ID
        ///</summary>
        public int CrID
        {
            get
            {
                return crid;
            }
            set
            {
                crid = value;
            }
        }

        ///<summary>
        ///登记ID
        ///</summary>
        public string CCID
        {
            get
            {
                return ccid;
            }
            set
            {
                ccid = value;
            }
        }

        ///<summary>
        ///学生ID
        ///</summary>
        public string SysID
        {
            get
            {
                return sysid;
            }
            set
            {
                sysid = value;
            }
        }

        ///<summary>
        ///登记日期
        ///</summary>
        public DateTime RegDate
        {
            get
            {
                return regdate;
            }
            set
            {
                regdate = value;
            }
        }
    }
}

