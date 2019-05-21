/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      俞桂宝
** 创建日期:      2017年11月10日 10点28分
** 描   述:      自由流表单审批数据类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class WF_FormAuditValueEntity
    {

        /// <summary>
        /// WF_FormAuditValue表实体
        ///</summary>
        public WF_FormAuditValueEntity()
        {
        }


        /// <summary>
        /// WF_FormAuditValue表实体
        /// </summary>
        /// <param name="favid">ID</param>
        /// <param name="faid">审批ID</param>
        /// <param name="urid">审核用户id或审核角色id</param>
        /// <param name="favtype">类型</param>
        public WF_FormAuditValueEntity(int favid, int faid, string urid, int favtype)
        {
            this.FAVID = favid;
            this.FAID = faid;
            this.URID = urid;
            this.FAVType = favtype;
        }

        private int favid;//ID
        private int faid;//审批ID
        private string wffid;//表单ID
        private string urid;//审核用户id或审核角色id
        private int favtype;//类型


        ///<summary>
        ///ID
        ///</summary>
        public int FAVID
        {
            get
            {
                return favid;
            }
            set
            {
                favid = value;
            }
        }

        ///<summary>
        ///审批ID
        ///</summary>
        public int FAID
        {
            get
            {
                return faid;
            }
            set
            {
                faid = value;
            }
        }

        public string WFFID
        {
            get
            {
                return wffid;
            }
            set
            {
                wffid = value;
            }
        }


        ///<summary>
        ///审核用户id或审核角色id
        ///</summary>
        public string URID
        {
            get
            {
                return urid;
            }
            set
            {
                urid = value;
            }
        }

        ///<summary>
        ///类型
        ///</summary>
        public int FAVType
        {
            get
            {
                return favtype;
            }
            set
            {
                favtype = value;
            }
        }
    }
}

