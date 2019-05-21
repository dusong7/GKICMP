/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2018年01月02日 01点42分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Purchase_BillEntity
    {

        /// <summary>
        /// Purchase_Bill表实体
        ///</summary>
        public Purchase_BillEntity()
        {
        }


        /// <summary>
        /// Purchase_Bill表实体
        /// </summary>
        /// <param name="bid"></param>
        /// <param name="pid"></param>
        /// <param name="bname"></param>
        /// <param name="bmodel"></param>
        /// <param name="bcount"></param>
        /// <param name="bprice"></param>
        /// <param name="breason"></param>
        /// <param name="createdate"></param>
        public Purchase_BillEntity(int bid, string pid, string bname, string bmodel, int bcount, decimal bprice, string breason, DateTime createdate)
        {
            this.BID = bid;
            this.PID = pid;
            this.BName = bname;
            this.BModel = bmodel;
            this.BCount = bcount;
            this.BPrice = bprice;
            this.BReason = breason;
            this.CreateDate = createdate;
        }

        private int bid;//
        private string pid;//
        private string bname;//
        private string bmodel;//
        private int bcount;//
        private decimal bprice;//
        private string breason;//
        private DateTime createdate;//


        ///<summary>
        ///
        ///</summary>
        public int BID
        {
            get
            {
                return bid;
            }
            set
            {
                bid = value;
            }
        }

        ///<summary>
        ///
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
        ///
        ///</summary>
        public string BName
        {
            get
            {
                return bname;
            }
            set
            {
                bname = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string BModel
        {
            get
            {
                return bmodel;
            }
            set
            {
                bmodel = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int BCount
        {
            get
            {
                return bcount;
            }
            set
            {
                bcount = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal BPrice
        {
            get
            {
                return bprice;
            }
            set
            {
                bprice = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string BReason
        {
            get
            {
                return breason;
            }
            set
            {
                breason = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime CreateDate
        {
            get
            {
                return createdate;
            }
            set
            {
                createdate = value;
            }
        }
    }
}

