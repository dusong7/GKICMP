/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月27日 10点51分
** 描   述:      报销发票实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Invoice_InfoEntity
    {

        /// <summary>
        /// Invoice_Info表实体
        ///</summary>
        public Invoice_InfoEntity()
        {
        }


        /// <summary>
        /// Invoice_Info表实体
        /// </summary>
        /// <param name="infoid"></param>
        /// <param name="iid">报销ID</param>
        /// <param name="inum">序号</param>
        /// <param name="invdesc">摘要</param>
        /// <param name="invoicecount">张数</param>
        /// <param name="invoicecash">金额</param>
        /// <param name="isdel">是否删除</param>
        public Invoice_InfoEntity(int infoid, string iid, int inum, string invdesc, int invoicecount, decimal invoicecash, int isdel)
        {
            this.InfoID = infoid;
            this.IID = iid;
            this.INum = inum;
            this.InvDesc = invdesc;
            this.InvoiceCount = invoicecount;
            this.InvoiceCash = invoicecash;
            this.Isdel = isdel;
        }

        private int infoid;//
        private string iid;//报销ID
        private int inum;//序号
        private string invdesc;//摘要
        private int invoicecount;//张数
        private decimal invoicecash;//金额
        private int isdel;//是否删除


        ///<summary>
        ///
        ///</summary>
        public int InfoID
        {
            get
            {
                return infoid;
            }
            set
            {
                infoid = value;
            }
        }

        ///<summary>
        ///报销ID
        ///</summary>
        public string IID
        {
            get
            {
                return iid;
            }
            set
            {
                iid = value;
            }
        }

        ///<summary>
        ///序号
        ///</summary>
        public int INum
        {
            get
            {
                return inum;
            }
            set
            {
                inum = value;
            }
        }

        ///<summary>
        ///摘要
        ///</summary>
        public string InvDesc
        {
            get
            {
                return invdesc;
            }
            set
            {
                invdesc = value;
            }
        }

        ///<summary>
        ///张数
        ///</summary>
        public int InvoiceCount
        {
            get
            {
                return invoicecount;
            }
            set
            {
                invoicecount = value;
            }
        }

        ///<summary>
        ///金额
        ///</summary>
        public decimal InvoiceCash
        {
            get
            {
                return invoicecash;
            }
            set
            {
                invoicecash = value;
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

