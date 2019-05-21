/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2018年04月08日 11点02分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class OverTime_UserEntity
    {

        /// <summary>
        /// OverTime_User表实体
        ///</summary>
        public OverTime_UserEntity()
        {
        }


        /// <summary>
        /// OverTime_User表实体
        /// </summary>
        /// <param name="nttcid">ID</param>
        /// <param name="oid">加班ID</param>
        /// <param name="sysuserid">加班人</param>
        public OverTime_UserEntity(int nttcid, string oid, string sysuserid)
        {
            this.NTTCID = nttcid;
            this.OID = oid;
            this.SysUserID = sysuserid;
        }

        private int nttcid;//ID
        private string oid;//加班ID
        private string sysuserid;//加班人


        ///<summary>
        ///ID
        ///</summary>
        public int NTTCID
        {
            get
            {
                return nttcid;
            }
            set
            {
                nttcid = value;
            }
        }

        ///<summary>
        ///加班ID
        ///</summary>
        public string OID
        {
            get
            {
                return oid;
            }
            set
            {
                oid = value;
            }
        }

        ///<summary>
        ///加班人
        ///</summary>
        public string SysUserID
        {
            get
            {
                return sysuserid;
            }
            set
            {
                sysuserid = value;
            }
        }
    }
}

