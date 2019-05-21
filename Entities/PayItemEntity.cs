/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月17日 04点24分
** 描   述:      缴费项实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class PayItemEntity
    {

        /// <summary>
        /// PayItem表实体
        ///</summary>
        public PayItemEntity()
        {
        }


        /// <summary>
        /// PayItem表实体
        /// </summary>
        /// <param name="piid">ID</param>
        /// <param name="payname">缴费项</param>
        /// <param name="paycount">缴费金额</param>
        /// <param name="begindate">启用日期</param>
        /// <param name="enddate">停用日期</param>
        /// <param name="isdisable">是否停用</param>
        /// <param name="isdel">是否删除</param>
        public PayItemEntity(int piid, string payname, decimal paycount, DateTime begindate, DateTime enddate, int isdisable, int isdel)
        {
            this.PIID = piid;
            this.PayName = payname;
            this.PayCount = paycount;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.IsDisable = isdisable;
            this.Isdel = isdel;
        }

        private int piid;//ID
        private string payname;//缴费项
        private decimal paycount;//缴费金额
        private DateTime begindate;//启用日期
        private DateTime enddate;//停用日期
        private int isdisable;//是否停用
        private int isdel;//是否删除


        ///<summary>
        ///ID
        ///</summary>
        public int PIID
        {
            get
            {
                return piid;
            }
            set
            {
                piid = value;
            }
        }

        ///<summary>
        ///缴费项
        ///</summary>
        public string PayName
        {
            get
            {
                return payname;
            }
            set
            {
                payname = value;
            }
        }

        ///<summary>
        ///缴费金额
        ///</summary>
        public decimal PayCount
        {
            get
            {
                return paycount;
            }
            set
            {
                paycount = value;
            }
        }

        ///<summary>
        ///启用日期
        ///</summary>
        public DateTime BeginDate
        {
            get
            {
                return begindate;
            }
            set
            {
                begindate = value;
            }
        }

        ///<summary>
        ///停用日期
        ///</summary>
        public DateTime EndDate
        {
            get
            {
                return enddate;
            }
            set
            {
                enddate = value;
            }
        }

        ///<summary>
        ///是否停用
        ///</summary>
        public int IsDisable
        {
            get
            {
                return isdisable;
            }
            set
            {
                isdisable = value;
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

