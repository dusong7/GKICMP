/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2016年12月05日 01点35分
** 描   述:      请假审核信息实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Leave_AuditEntity
    {

        /// <summary>
        /// Leave_Audit表实体
        ///</summary>
        public Leave_AuditEntity()
        {
        }


        /// <summary>
        /// Leave_Audit表实体
        /// </summary>
        /// <param name="laid">ID</param>
        /// <param name="lid">请假ID</param>
        /// <param name="audituser">审核人</param>
        /// <param name="auditdate">审核时间</param>
        /// <param name="auditmark">审核意见</param>
        /// <param name="auditresult">结果</param>
        public Leave_AuditEntity(string laid, string lid, string audituser, DateTime auditdate, string auditmark, int auditresult, int auditorder)
        {
            this.LAID = laid;
            this.LID = lid;
            this.AuditUser = audituser;
            this.AuditDate = auditdate;
            this.AuditMark = auditmark;
            this.AuditResult = auditresult;
            this.AuditOrder = auditorder;
        }

        private string laid;//ID
        private string lid;//请假ID
        private string audituser;//审核人
        private DateTime auditdate;//审核时间
        private string auditmark;//审核意见
        private int auditresult;//结果
        private int auditorder; //审核顺序
        private int isdisplay;
        /// <summary>
        /// 是否并发
        /// </summary>
        public int IsCurrent { get; set; }
        public int IsDisplay
        {
            get { return isdisplay; }
            set { isdisplay = value; }
        }

        /// <summary>
        /// 审核顺序
        /// </summary>
        public int AuditOrder
        {
            get { return auditorder; }
            set { auditorder = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public string LAID
        {
            get
            {
                return laid;
            }
            set
            {
                laid = value;
            }
        }

        ///<summary>
        ///请假ID
        ///</summary>
        public string LID
        {
            get
            {
                return lid;
            }
            set
            {
                lid = value;
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
    }
}

