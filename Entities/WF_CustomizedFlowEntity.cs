/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      俞桂宝
** 创建日期:      2017年11月10日 10点40分
** 描   述:      自由流审批提交流程类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class WF_CustomizedFlowEntity
    {

        /// <summary>
        /// WF_CustomizedFlow表实体
        ///</summary>
        public WF_CustomizedFlowEntity()
        {
        }


        /// <summary>
        /// WF_CustomizedFlow表实体
        /// </summary>
        /// <param name="cfid">ID</param>
        /// <param name="cid">自由流审批提交ID</param>
        /// <param name="faid">自由流表单审批ID</param>
        /// <param name="cstauts">状态</param>
        /// <param name="remark">说明</param>
        /// <param name="auditdate">审批时间</param>
        public WF_CustomizedFlowEntity(int cfid, string cid, int faid, int cstauts, string remark, DateTime auditdate)
        {
            this.CFID = cfid;
            this.CID = cid;
            this.FAID = faid;
            this.CStauts = cstauts;
            this.Remark = remark;
            this.AuditDate = auditdate;
        }

        private int cfid;//ID
        private string cid;//自由流审批提交ID
        private int faid;//自由流表单审批ID
        private int cstauts;//状态
        private string uid;//说明
        private string remark;//说明
        private DateTime auditdate;//审批时间
        private int favid;//

        ///<summary>
        ///ID
        ///</summary>
        public int CFID
        {
            get
            {
                return cfid;
            }
            set
            {
                cfid = value;
            }
        }

        ///<summary>
        ///自由流审批提交ID
        ///</summary>
        public string CID
        {
            get
            {
                return cid;
            }
            set
            {
                cid = value;
            }
        }

        ///<summary>
        ///审核用户ID
        ///</summary>
        public string UID
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }

        ///<summary>
        ///自由流表单审批ID
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

        ///<summary>
        ///状态
        ///</summary>
        public int CStauts
        {
            get
            {
                return cstauts;
            }
            set
            {
                cstauts = value;
            }
        }

        ///<summary>
        ///说明
        ///</summary>
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }

        ///<summary>
        ///审批时间
        ///</summary>
        public DateTime AuditDate
        {
            get
            {
                return auditdate;
            }
            set
            {
                auditdate = value;
            }
        }

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

    }
}

