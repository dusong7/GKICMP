/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年04月26日 04点34分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Project_TenderEntity
    {

        /// <summary>
        /// Project_Tender表实体
        ///</summary>
        public Project_TenderEntity()
        {
        }


        /// <summary>
        /// Project_Tender表实体
        /// </summary>
        /// <param name="ptid"></param>
        /// <param name="pid">项目id</param>
        /// <param name="sid">供应商id</param>
        /// <param name="bamount">中标金额</param>
        /// <param name="bdate">中标日期</param>
        /// <param name="bsdate">开始实施时间</param>
        /// <param name="bedate">结束时间</param>
        /// <param name="bond">保证金</param>
        /// <param name="bonddate">保证金日期</param>
        /// <param name="isreturn">保证金是否退还</param>
        /// <param name="createuser">创建人</param>
        /// <param name="createdate">创建时间</param>
        /// <param name="ptdesc">备注</param>
        /// <param name="isdel">是否删除</param>
        /// <param name="bidnumber">标书编号</param>
        public Project_TenderEntity(string ptid, string pid, string sid, decimal bamount, DateTime bdate, DateTime bsdate, DateTime bedate, decimal bond, DateTime bonddate, int isreturn, string createuser, DateTime createdate, string ptdesc, int isdel, string bidnumber)
        {
            this.PTID = ptid;
            this.PID = pid;
            this.SID = sid;
            this.BAmount = bamount;
            this.BDate = bdate;
            this.BSDate = bsdate;
            this.BEDate = bedate;
            this.Bond = bond;
            this.BondDate = bonddate;
            this.IsReturn = isreturn;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.PTDesc = ptdesc;
            this.Isdel = isdel;
            this.BidNumber = bidnumber;
        }

        private string ptid;//
        private string pid;//项目id
        private string sid;//供应商id
        private decimal bamount;//中标金额
        private DateTime bdate;//中标日期
        private DateTime bsdate;//开始实施时间
        private DateTime bedate;//结束时间
        private decimal bond;//保证金
        private DateTime bonddate;//保证金日期
        private int isreturn;//保证金是否退还
        private string createuser;//创建人
        private DateTime createdate;//创建时间
        private string ptdesc;//备注
        private int isdel;//是否删除
        private string bidnumber;//标书编号
        public string FileID { get; set; }
        public string CreateUserName { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ProName { get; set; }
        public string SupplierName { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string PTID
        {
            get
            {
                return ptid;
            }
            set
            {
                ptid = value;
            }
        }

        ///<summary>
        ///项目id
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
        ///供应商id
        ///</summary>
        public string SID
        {
            get
            {
                return sid;
            }
            set
            {
                sid = value;
            }
        }

        ///<summary>
        ///中标金额
        ///</summary>
        public decimal BAmount
        {
            get
            {
                return bamount;
            }
            set
            {
                bamount = value;
            }
        }

        ///<summary>
        ///中标日期
        ///</summary>
        public DateTime BDate
        {
            get
            {
                return bdate;
            }
            set
            {
                bdate = value;
            }
        }

        ///<summary>
        ///开始实施时间
        ///</summary>
        public DateTime BSDate
        {
            get
            {
                return bsdate;
            }
            set
            {
                bsdate = value;
            }
        }

        ///<summary>
        ///结束时间
        ///</summary>
        public DateTime BEDate
        {
            get
            {
                return bedate;
            }
            set
            {
                bedate = value;
            }
        }

        ///<summary>
        ///保证金
        ///</summary>
        public decimal Bond
        {
            get
            {
                return bond;
            }
            set
            {
                bond = value;
            }
        }

        ///<summary>
        ///保证金日期
        ///</summary>
        public DateTime BondDate
        {
            get
            {
                return bonddate;
            }
            set
            {
                bonddate = value;
            }
        }

        ///<summary>
        ///保证金是否退还
        ///</summary>
        public int IsReturn
        {
            get
            {
                return isreturn;
            }
            set
            {
                isreturn = value;
            }
        }
        public DateTime BondBackDate { get; set; }
        ///<summary>
        ///创建人
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
        ///创建时间
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
        ///备注
        ///</summary>
        public string PTDesc
        {
            get
            {
                return ptdesc;
            }
            set
            {
                ptdesc = value;
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

        ///<summary>
        ///标书编号
        ///</summary>
        public string BidNumber
        {
            get
            {
                return bidnumber;
            }
            set
            {
                bidnumber = value;
            }
        }
    }
}

