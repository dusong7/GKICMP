/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月24日 10点42分
** 描   述:      退费实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class PayBackEntity
    {

        /// <summary>
        /// PayBack表实体
        ///</summary>
        public PayBackEntity()
        {
        }


        /// <summary>
        /// PayBack表实体
        /// </summary>
        /// <param name="pbid">ID</param>
        /// <param name="prid">缴费ID</param>
        /// <param name="backuser">退费人</param>
        /// <param name="backcount">退费金额</param>
        /// <param name="backdate">退费日期</param>
        /// <param name="isaudit">审核状态</param>
        /// <param name="aduituser">审核人</param>
        /// <param name="auditdate">审核日期</param>
        /// <param name="createuser">退费登记人</param>
        /// <param name="isdel">是否删除</param>
        public PayBackEntity(int pbid, string prid, string backuser, decimal backcount, DateTime backdate, int isaudit, string aduituser, DateTime auditdate, string createuser, int isdel)
        {
            this.PBID = pbid;
            this.PRID = prid;
            this.BackUser = backuser;
            this.BackCount = backcount;
            this.BackDate = backdate;
            this.IsAudit = isaudit;
            this.AduitUser = aduituser;
            this.AuditDate = auditdate;
            this.CreateUser = createuser;
            this.Isdel = isdel;
        }

        private int pbid;//ID
        private string prid;//缴费ID
        private string backuser;//退费人
        private decimal backcount;//退费金额
        private DateTime backdate;//退费日期
        private int isaudit;//审核状态
        private string aduituser;//审核人
        private DateTime auditdate;//审核日期
        private string createuser;//退费登记人
        private int isdel;//是否删除
        private string aduitUserName;//
        private string stuName;
        private string pName;

        public string PName
        {
            get { return pName; }
            set { pName = value; }
        }

        public string StuName
        {
            get { return stuName; }
            set { stuName = value; }
        }

        public string AduitUserName
        {
            get { return aduitUserName; }
            set { aduitUserName = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public int PBID
        {
            get
            {
                return pbid;
            }
            set
            {
                pbid = value;
            }
        }

        ///<summary>
        ///缴费ID
        ///</summary>
        public string PRID
        {
            get
            {
                return prid;
            }
            set
            {
                prid = value;
            }
        }

        ///<summary>
        ///退费人
        ///</summary>
        public string BackUser
        {
            get
            {
                return backuser;
            }
            set
            {
                backuser = value;
            }
        }

        ///<summary>
        ///退费金额
        ///</summary>
        public decimal BackCount
        {
            get
            {
                return backcount;
            }
            set
            {
                backcount = value;
            }
        }

        ///<summary>
        ///退费日期
        ///</summary>
        public DateTime BackDate
        {
            get
            {
                return backdate;
            }
            set
            {
                backdate = value;
            }
        }

        ///<summary>
        ///审核状态
        ///</summary>
        public int IsAudit
        {
            get
            {
                return isaudit;
            }
            set
            {
                isaudit = value;
            }
        }

        ///<summary>
        ///审核人
        ///</summary>
        public string AduitUser
        {
            get
            {
                return aduituser;
            }
            set
            {
                aduituser = value;
            }
        }

        ///<summary>
        ///审核日期
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
        ///退费登记人
        ///</summary>
        public string CreateUser
        {
            get
            {
                return createuser;
            }
            set
            {
                createuser = value;
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

