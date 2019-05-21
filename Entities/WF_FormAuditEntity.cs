/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      俞桂宝
** 创建日期:      2017年11月10日 10点23分
** 描   述:      自由流表单审批类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class WF_FormAuditEntity
    {

        /// <summary>
        /// WF_FormAudit表实体
        ///</summary>
        public WF_FormAuditEntity()
        {
        }


        /// <summary>
        /// WF_FormAudit表实体
        /// </summary>
        /// <param name="faid">ID</param>
        /// <param name="wffid">工作流ID</param>
        /// <param name="audittype">审核方式</param>
        /// <param name="pid">父级id</param>
        /// <param name="flowtype">审批类型</param>
        public WF_FormAuditEntity(int faid, string wffid, int audittype, int pid, int flowtype, int isdel)
        {
            this.FAID = faid;
            this.WFFID = wffid;
            this.AuditType = audittype;
            this.PID = pid;
            this.FlowType = flowtype;
            this.Isdel = isdel;
        }

        private int faid;//ID
        private string wffid;//工作流ID
        private int audittype;//审核方式
        private int pid;//父级id
        private int flowtype;//审批类型
        private int isdel;//是否被删除


        ///<summary>
        ///ID
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
        ///工作流ID
        ///</summary>
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
        ///审核方式
        ///</summary>
        public int AuditType
        {
            get
            {
                return audittype;
            }
            set
            {
                audittype = value;
            }
        }

        ///<summary>
        ///父级id
        ///</summary>
        public int PID
        {
            get
            {
                return pid;
            }
            set
            {
                pid = value;
            }
        }

        ///<summary>
        ///审批类型
        ///</summary>
        public int FlowType
        {
            get
            {
                return flowtype;
            }
            set
            {
                flowtype = value;
            }
        }

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

