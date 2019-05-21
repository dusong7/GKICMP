/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月15日 10点00分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_ContractEntity
    {

        /// <summary>
        /// Teacher_Contract表实体
        ///</summary>
        public Teacher_ContractEntity()
        {
        }

        /// <summary>
        /// Teacher_Contract表实体
        /// </summary>
        /// <param name="tcid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="depid">名称</param>
        /// <param name="tcycle">合同周期</param>
        /// <param name="tstartdate">合同开始日期</param>
        /// <param name="tenddate">合同结束日期</param>
        /// <param name="isdel">是否删除</param>
        public Teacher_ContractEntity(string tid, DateTime begindate, DateTime enddate, int isdel)
        {
            this.TID = tid;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.Isdel = isdel;
        }

        /// <summary>
        /// Teacher_Contract表实体
        /// </summary>
        /// <param name="tcid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="ctype">合同类型</param>
        /// <param name="depid">名称</param>
        /// <param name="tcycle">合同周期</param>
        /// <param name="tstartdate">合同开始日期</param>
        /// <param name="tenddate">合同结束日期</param>
        /// <param name="tcfile">附件</param>
        /// <param name="tstate">状态</param>
        /// <param name="createdate">创建日期</param>
        /// <param name="overdate">解除日期</param>
        /// <param name="isdel">是否删除</param>
        public Teacher_ContractEntity(string tcid, string tid, int ctype, int depid, int tcycle, DateTime tstartdate, DateTime tenddate, string tcfile, int tstate, DateTime createdate, DateTime overdate, int isdel)
        {
            this.TCID = tcid;
            this.TID = tid;
            this.CType = ctype;
            this.DepID = depid;
            this.TCycle = tcycle;
            this.TStartDate = tstartdate;
            this.TEndDate = tenddate;
            this.TCFile = tcfile;
            this.TState = tstate;
            this.CreateDate = createdate;
            this.OverDate = overdate;
            this.Isdel = isdel;
        }

        private string tcid;//ID
        private string tid;//教师ID
        private int ctype;//合同类型
        private int depid;//名称
        private int tcycle;//合同周期
        private DateTime tstartdate;//合同开始日期
        private DateTime tenddate;//合同结束日期
        private string tcfile;//附件
        private int tstate;//状态
        private DateTime createdate;//创建日期
        private DateTime overdate;//解除日期
        private int isdel;//是否删除
        private DateTime begindate;
        private DateTime enddate;
        private string realname;
        private string idcard;//身份证号码
        private int isreport;//是否上报

        private string ctypename;//合同类型名称
        public string CTypeName
        {
            get { return ctypename; }
            set { ctypename = value; }
        }

        public int IsReport
        {
            get
            {
                return isreport;
            }
            set
            {
                isreport = value;
            }
        }
        public string IDCard
        {
            get { return idcard; }
            set { idcard = value; }
        }
        public string RealName
        {
            get { return realname; }
            set { realname = value; }
        }
        public DateTime BeginDate
        {
            get { return begindate; }
            set { begindate = value; }
        }

        public DateTime EndDate
        {
            get { return enddate; }
            set { enddate = value; }
        }
        ///<summary>
        ///ID
        ///</summary>
        public string TCID
        {
            get
            {
                return tcid;
            }
            set
            {
                tcid = value;
            }
        }

        ///<summary>
        ///教师ID
        ///</summary>
        public string TID
        {
            get
            {
                return tid;
            }
            set
            {
                tid = value;
            }
        }

        ///<summary>
        ///合同类型
        ///</summary>
        public int CType
        {
            get
            {
                return ctype;
            }
            set
            {
                ctype = value;
            }
        }

        ///<summary>
        ///名称
        ///</summary>
        public int DepID
        {
            get
            {
                return depid;
            }
            set
            {
                depid = value;
            }
        }

        ///<summary>
        ///合同周期
        ///</summary>
        public int TCycle
        {
            get
            {
                return tcycle;
            }
            set
            {
                tcycle = value;
            }
        }

        ///<summary>
        ///合同开始日期
        ///</summary>
        public DateTime TStartDate
        {
            get
            {
                return tstartdate;
            }
            set
            {
                tstartdate = value;
            }
        }

        ///<summary>
        ///合同结束日期
        ///</summary>
        public DateTime TEndDate
        {
            get
            {
                return tenddate;
            }
            set
            {
                tenddate = value;
            }
        }

        ///<summary>
        ///附件
        ///</summary>
        public string TCFile
        {
            get
            {
                return tcfile;
            }
            set
            {
                tcfile = value;
            }
        }

        ///<summary>
        ///状态
        ///</summary>
        public int TState
        {
            get
            {
                return tstate;
            }
            set
            {
                tstate = value;
            }
        }

        ///<summary>
        ///创建日期
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
        ///解除日期
        ///</summary>
        public DateTime OverDate
        {
            get
            {
                return overdate;
            }
            set
            {
                overdate = value;
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

