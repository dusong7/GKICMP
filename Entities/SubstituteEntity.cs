/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年08月18日 04点13分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SubstituteEntity
    {

        /// <summary>
        /// Substitute表实体
        ///</summary>
        public SubstituteEntity()
        {
        }


        /// <summary>
        /// Substitute表实体
        /// </summary>
        /// <param name="subid">代课ID</param>
        /// <param name="applyuser">申请人</param>
        /// <param name="applydate">申请时间</param>
        /// <param name="applyreason">申请原因</param>
        /// <param name="subbegin">代课开始日期</param>
        /// <param name="subbegin1">代课开始日期</param>
        /// <param name="subend">代课结束日期</param>
        /// <param name="subend1">代课结束日期</param>
        /// <param name="subuser">代课人</param>
        /// <param name="subcount">节数</param>
        /// <param name="substate">状态</param>
        /// <param name="subcoruse">代课课程</param>
        /// <param name="subcoruse1">代课课程1</param>
        /// <param name="subname">节次</param>
        /// <param name="subname1">节次1</param>
        /// <param name="subtype">类别  1：调课  2：代课</param>
        /// <param name="audituser">审核人</param>
        /// <param name="auditdate">审核时间</param>
        /// <param name="isdel">是否删除</param>
        public SubstituteEntity(int subid, string applyuser, DateTime applydate, string applyreason, DateTime subbegin, DateTime subbegin1, DateTime subend, DateTime subend1, string subuser, int subcount, int substate, int subcoruse, int subcoruse1, string subname, string subname1, int subtype, string audituser, DateTime auditdate, int isdel)
        {
            this.SubID = subid;
            this.ApplyUser = applyuser;
            this.ApplyDate = applydate;
            this.ApplyReason = applyreason;
            this.SubBegin = subbegin;
            this.SubBegin1 = subbegin1;
            this.SubEnd = subend;
            this.SubEnd1 = subend1;
            this.SubUser = subuser;
            this.SubCount = subcount;
            this.SubState = substate;
            this.SubCoruse = subcoruse;
            this.SubCoruse1 = subcoruse1;
            this.SubName = subname;
            this.SubName1 = subname1;
            this.SubType = subtype;
            this.AuditUser = audituser;
            this.AuditDate = auditdate;
            this.Isdel = isdel;
        }

        private int subid;//代课ID
        private string applyuser;//申请人
        private DateTime applydate;//申请时间
        private string applyreason;//申请原因
        private DateTime subbegin;//代课开始日期
        private DateTime subbegin1;//代课开始日期
        private DateTime subend;//代课结束日期
        private DateTime subend1;//代课结束日期
        private string subuser;//代课人
        private int subcount;//节数
        private int substate;//状态
        private int subcoruse;//代课课程
        private int subcoruse1;//代课课程1
        private string subname;//节次
        private string subname1;//节次1
        private int subtype;//类别  1：调课  2：代课
        private string audituser;//审核人
        private DateTime auditdate;//审核时间
        private int isdel;//是否删除

        public string ApplyuserName { get; set; }
        public string SubuserName { get; set; }
        public string SubcoruseName { get; set; }
        public string Subcoruse1Name { get; set; }
        public string AudituserName { get; set; }

        ///<summary>
        ///代课ID
        ///</summary>
        public int SubID
        {
            get
            {
                return subid;
            }
            set
            {
                subid = value;
            }
        }

        ///<summary>
        ///申请人
        ///</summary>
        public string ApplyUser
        {
            get
            {
                return applyuser;
            }
            set
            {
                applyuser = value;
            }
        }

        ///<summary>
        ///申请时间
        ///</summary>
        public DateTime ApplyDate
        {
            get
            {
                return applydate;
            }
            set
            {
                applydate = value;
            }
        }

        ///<summary>
        ///申请原因
        ///</summary>
        public string ApplyReason
        {
            get
            {
                return applyreason;
            }
            set
            {
                applyreason = value;
            }
        }

        ///<summary>
        ///代课开始日期
        ///</summary>
        public DateTime SubBegin
        {
            get
            {
                return subbegin;
            }
            set
            {
                subbegin = value;
            }
        }

        ///<summary>
        ///代课开始日期
        ///</summary>
        public DateTime SubBegin1
        {
            get
            {
                return subbegin1;
            }
            set
            {
                subbegin1 = value;
            }
        }

        ///<summary>
        ///代课结束日期
        ///</summary>
        public DateTime SubEnd
        {
            get
            {
                return subend;
            }
            set
            {
                subend = value;
            }
        }

        ///<summary>
        ///代课结束日期
        ///</summary>
        public DateTime SubEnd1
        {
            get
            {
                return subend1;
            }
            set
            {
                subend1 = value;
            }
        }

        ///<summary>
        ///代课人
        ///</summary>
        public string SubUser
        {
            get
            {
                return subuser;
            }
            set
            {
                subuser = value;
            }
        }

        ///<summary>
        ///节数
        ///</summary>
        public int SubCount
        {
            get
            {
                return subcount;
            }
            set
            {
                subcount = value;
            }
        }

        ///<summary>
        ///状态
        ///</summary>
        public int SubState
        {
            get
            {
                return substate;
            }
            set
            {
                substate = value;
            }
        }

        ///<summary>
        ///代课课程
        ///</summary>
        public int SubCoruse
        {
            get
            {
                return subcoruse;
            }
            set
            {
                subcoruse = value;
            }
        }

        ///<summary>
        ///代课课程1
        ///</summary>
        public int SubCoruse1
        {
            get
            {
                return subcoruse1;
            }
            set
            {
                subcoruse1 = value;
            }
        }

        ///<summary>
        ///节次
        ///</summary>
        public string SubName
        {
            get
            {
                return subname;
            }
            set
            {
                subname = value;
            }
        }

        ///<summary>
        ///节次1
        ///</summary>
        public string SubName1
        {
            get
            {
                return subname1;
            }
            set
            {
                subname1 = value;
            }
        }

        ///<summary>
        ///类别  1：调课  2：代课
        ///</summary>
        public int SubType
        {
            get
            {
                return subtype;
            }
            set
            {
                subtype = value;
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

