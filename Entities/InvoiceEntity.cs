/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月27日 10点51分
** 描   述:      报销实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class InvoiceEntity
    {

        /// <summary>
        /// Invoice表实体
        ///</summary>
        public InvoiceEntity()
        {
        }


        /// <summary>
        /// Invoice表实体
        /// </summary>
        /// <param name="invtype">报销类别</param>
        /// <param name="invmodel">报销方式</param>
        /// <param name="isdel">是否删除</param>
        public InvoiceEntity(int invtype, int invmodel, int isdel)
        {
            this.InvType = invtype;
            this.InvModel = invmodel;
            this.Isdel = isdel;
        }

        private string iid;//报销ID
        private string accountunit;//报销单位
        private string createuser;//报销人
        private DateTime createdate;//报销日期
        private string aduituser;//审批人
        private decimal totelcash;//合计金额
        private string invoicedesc;//备注
        private string picurl;//报销单照片
        private int issign;//是否签字
        private int istate;//办理状态
        private int invtype;//报销类别
        private int invmodel;//报销方式
        private int isdel;//是否删除

        public string TypeName
        {
            get;
            set;
        }

        public string ModelName
        {
            get;
            set;
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
        ///报销单位
        ///</summary>
        public string AccountUnit
        {
            get
            {
                return accountunit;
            }
            set
            {
                accountunit = value;
            }
        }

        ///<summary>
        ///报销人
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
        ///报销日期
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

        ///<summary>
        ///审批人
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
        ///合计金额
        ///</summary>
        public decimal TotelCash
        {
            get
            {
                return totelcash;
            }
            set
            {
                totelcash = value;
            }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string InvoiceDesc
        {
            get
            {
                return invoicedesc;
            }
            set
            {
                invoicedesc = value;
            }
        }

        ///<summary>
        ///报销单照片
        ///</summary>
        public string PicUrl
        {
            get
            {
                return picurl;
            }
            set
            {
                picurl = value;
            }
        }

        ///<summary>
        ///是否签字
        ///</summary>
        public int IsSign
        {
            get
            {
                return issign;
            }
            set
            {
                issign = value;
            }
        }

        ///<summary>
        ///办理状态
        ///</summary>
        public int IState
        {
            get
            {
                return istate;
            }
            set
            {
                istate = value;
            }
        }

        ///<summary>
        ///报销类别
        ///</summary>
        public int InvType
        {
            get
            {
                return invtype;
            }
            set
            {
                invtype = value;
            }
        }

        ///<summary>
        ///报销方式
        ///</summary>
        public int InvModel
        {
            get
            {
                return invmodel;
            }
            set
            {
                invmodel = value;
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

