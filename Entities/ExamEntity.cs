/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月08日 09点52分
** 描   述:      考试管理实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ExamEntity
    {

        /// <summary>
        /// Exam表实体
        ///</summary>
        public ExamEntity()
        {
        }


        /// <summary>
        /// Exam表实体
        /// </summary>
        /// <param name="eid">考试ID</param>
        /// <param name="examname">考试名称</param>
        /// <param name="gid">年级</param>
        /// <param name="term">学期</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="createuser">录入人</param>
        /// <param name="begindate">考试开始时间</param>
        /// <param name="enddate">考试结束时间</param>
        /// <param name="peonum">每个考场最多人数</param>
        /// <param name="seattype">1：分班考试   2：分考场考试</param>
        /// <param name="seatmodel">1:不排序   2：随机排序</param>
        /// <param name="eyear">学年</param>
        /// <param name="isdel">是否删除</param>
        public ExamEntity(int eid, string examname, int gid, int term, DateTime createdate, string createuser, DateTime begindate, DateTime enddate, int peonum, int seattype, int seatmodel, string eyear, int isdel)
        {
            this.EID = eid;
            this.ExamName = examname;
            this.GID = gid;
            this.Term = term;
            this.CreateDate = createdate;
            this.CreateUser = createuser;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.PeoNum = peonum;
            this.SeatType = seattype;
            this.SeatModel = seatmodel;
            this.EYear = eyear;
            this.Isdel = isdel;
        }

        private int eid;//考试ID
        private string examname;//考试名称
        private int gid;//年级
        private int term;//学期
        private DateTime createdate;//录入时间
        private string createuser;//录入人
        private DateTime begindate;//考试开始时间
        private DateTime enddate;//考试结束时间
        private int peonum;//每个考场最多人数
        private int seattype;//1：分班考试   2：分考场考试
        private int seatmodel;//1:不排序   2：随机排序
        private string eyear;//学年
        private int isdel;//是否删除
        private string gIDName;//年级名称
        public string ClassRoom { get; set; }//考场id
        public string GIDName
        {
            get { return gIDName; }
            set { gIDName = value; }
        }


        ///<summary>
        ///考试ID
        ///</summary>
        public int EID
        {
            get
            {
                return eid;
            }
            set
            {
                eid = value;
            }
        }

        ///<summary>
        ///考试名称
        ///</summary>
        public string ExamName
        {
            get
            {
                return examname;
            }
            set
            {
                examname = value;
            }
        }

        ///<summary>
        ///年级
        ///</summary>
        public int GID
        {
            get
            {
                return gid;
            }
            set
            {
                gid = value;
            }
        }

        ///<summary>
        ///学期
        ///</summary>
        public int Term
        {
            get
            {
                return term;
            }
            set
            {
                term = value;
            }
        }

        ///<summary>
        ///录入时间
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
        ///录入人
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
        ///考试开始时间
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
        ///考试结束时间
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
        ///每个考场最多人数
        ///</summary>
        public int PeoNum
        {
            get
            {
                return peonum;
            }
            set
            {
                peonum = value;
            }
        }

        ///<summary>
        ///1：分班考试   2：分考场考试
        ///</summary>
        public int SeatType
        {
            get
            {
                return seattype;
            }
            set
            {
                seattype = value;
            }
        }

        ///<summary>
        ///1:不排序   2：随机排序
        ///</summary>
        public int SeatModel
        {
            get
            {
                return seatmodel;
            }
            set
            {
                seatmodel = value;
            }
        }

        ///<summary>
        ///学年
        ///</summary>
        public string EYear
        {
            get
            {
                return eyear;
            }
            set
            {
                eyear = value;
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

