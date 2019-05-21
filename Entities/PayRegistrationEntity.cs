/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年08月18日 11点06分
** 描   述:      缴费登记实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class PayRegistrationEntity
    {

        /// <summary>
        /// PayRegistration表实体
        ///</summary>
        public PayRegistrationEntity()
        {
        }

        public PayRegistrationEntity(DateTime begin, DateTime end)
        {
            this.Begin = begin;
            this.End = end;
           
        }

        /// <summary>
        /// PayRegistration表实体
        /// </summary>
        /// <param name="prid">ID</param>
        /// <param name="stid">缴费学生</param>
        /// <param name="piid">缴费项目</param>
        /// <param name="regdate">缴费日期</param>
        /// <param name="createuser">登记人</param>
        /// <param name="regcount">缴费金额</param>
        /// <param name="backcount">退费金额</param>
        /// <param name="isdel"></param>
        public PayRegistrationEntity(string prid, string stid, string piid, DateTime regdate, string createuser, decimal regcount, decimal backcount, int isdel)
        {
            this.PRID = prid;
            this.StID = stid;
            this.PIID = piid;
            this.RegDate = regdate;
            this.CreateUser = createuser;
            this.RegCount = regcount;
            this.BackCount = backcount;
            this.Isdel = isdel;
        }

        private string prid;//ID
        private string stid;//缴费学生
        private string piid;//缴费项目
        private DateTime regdate;//缴费日期
        private string createuser;//登记人
        private decimal regcount;//缴费金额
        private decimal backcount;//退费金额
        private int isdel;//
        private string stuname;
        private string pname;

        private DateTime begin;
        private DateTime end;

        public string PName
        {
            get
            {
                return pname;
            }
            set
            {
                pname = value;
            }
        }

        public string StuName
        {
            get
            {
                return stuname;
            }
            set
            {
                stuname = value;
            }
        }

        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }

        public DateTime Begin
        {
            get { return begin; }
            set { begin = value; }
        }

        ///<summary>
        ///ID
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
        ///缴费学生
        ///</summary>
        public string StID
        {
            get
            {
                return stid;
            }
            set
            {
                stid = value;
            }
        }

        ///<summary>
        ///缴费项目
        ///</summary>
        public string PIID
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
        ///缴费日期
        ///</summary>
        public DateTime RegDate
        {
            get
            {
                return regdate;
            }
            set
            {
                regdate = value;
            }
        }

        ///<summary>
        ///登记人
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
        ///缴费金额
        ///</summary>
        public decimal RegCount
        {
            get
            {
                return regcount;
            }
            set
            {
                regcount = value;
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
        ///
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

