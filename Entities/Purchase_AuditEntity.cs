/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2018年01月02日 01点41分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Purchase_AuditEntity
    {

        /// <summary>
        /// Purchase_Audit表实体
        ///</summary>
        public Purchase_AuditEntity()
        {
        }


        /// <summary>
        /// Purchase_Audit表实体
        /// </summary>
        /// <param name="paid"></param>
        /// <param name="pid">采购id</param>
        /// <param name="audituser">审核人</param>
        /// <param name="auditdate">审核时间</param>
        /// <param name="auditmark">审核意见</param>
        /// <param name="auditresult">结果</param>
        /// <param name="auditorder">审核顺序</param>
        /// <param name="isdisplay">是否开启</param>
        public Purchase_AuditEntity(int paid, string pid, string audituser, DateTime auditdate, string auditmark, int auditresult, int auditorder, int isdisplay)
        {
            this.PAID = paid;
            this.PID = pid;
            this.AuditUser = audituser;
            this.AuditDate = auditdate;
            this.AuditMark = auditmark;
            this.AuditResult = auditresult;
            this.AuditOrder = auditorder;
            this.IsDisplay = isdisplay;
        }

        private int paid;//
        private string pid;//采购id
        private string audituser;//审核人
        private DateTime auditdate;//审核时间
        private string auditmark;//审核意见
        private int auditresult;//结果
        private int auditorder;//审核顺序
        private int isdisplay;//是否开启


        ///<summary>
        ///
        ///</summary>
        public int PAID
        {
            get
            {
                return paid;
            }
            set
            {
                paid = value;
            }
        }

        ///<summary>
        ///采购id
        ///</summary>
        public string PID
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
        ///审核人
        ///</summary>
        public string AuditUser
        {
            get
            {
                return audituser;
            }
            set
            {
                audituser = value;
            }
        }

        ///<summary>
        ///审核时间
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

        ///<summary>
        ///审核意见
        ///</summary>
        public string AuditMark
        {
            get
            {
                return auditmark;
            }
            set
            {
                auditmark = value;
            }
        }

        ///<summary>
        ///结果
        ///</summary>
        public int AuditResult
        {
            get
            {
                return auditresult;
            }
            set
            {
                auditresult = value;
            }
        }

        ///<summary>
        ///审核顺序
        ///</summary>
        public int AuditOrder
        {
            get
            {
                return auditorder;
            }
            set
            {
                auditorder = value;
            }
        }

        ///<summary>
        ///是否开启
        ///</summary>
        public int IsDisplay
        {
            get
            {
                return isdisplay;
            }
            set
            {
                isdisplay = value;
            }
        }
    }
}

