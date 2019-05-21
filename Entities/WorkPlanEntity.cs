/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年07月10日 05点17分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class WorkPlanEntity
    {

        /// <summary>
        /// WorkPlan表实体
        ///</summary>
        public WorkPlanEntity()
        {
        }


        /// <summary>
        /// WorkPlan表实体
        /// </summary>
        /// <param name="planid">计划ID</param>
        /// <param name="eyear">学年</param>
        /// <param name="term">学期</param>
        /// <param name="weeknum">周号</param>
        /// <param name="examname">内容</param>
        /// <param name="allusers">参与人</param>
        /// <param name="dutyuser">责任人</param>
        /// <param name="begindate">实施时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="depid">部门</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="createuser">录入人</param>
        /// <param name="iscomplete"></param>
        /// <param name="issendmess">是否发提示消息</param>
        /// <param name="isdel">是否删除</param>
        public WorkPlanEntity(string planid, string eyear, int term, int weeknum, string examname, string allusers, string dutyuser, DateTime begindate, DateTime enddate, int depid, DateTime createdate, string createuser, int iscomplete, int issendmess, int isdel)
        {
            this.PlanID = planid;
            this.EYear = eyear;
            this.Term = term;
            this.WeekNum = weeknum;
            this.ExamName = examname;
            this.AllUsers = allusers;
            this.DutyUser = dutyuser;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.DepID = depid;
            this.CreateDate = createdate;
            this.CreateUser = createuser;
            this.IsComplete = iscomplete;
            this.IsSendMess = issendmess;
            this.Isdel = isdel;
        }

        private string planid;//计划ID
        private string eyear;//学年
        private int term;//学期
        private int weeknum;//周号
        private string examname;//内容
        private string allusers;//参与人
        private string dutyuser;//责任人
        private DateTime begindate;//实施时间
        private DateTime enddate;//结束时间
        private int depid;//部门
        private DateTime createdate;//录入时间
        private string createuser;//录入人
        private int iscomplete;//
        private int issendmess;//是否发提示消息
        private int isdel;//是否删除
        /// <summary>
        /// 新闻id
        /// </summary>
        public int NID { get; set; }
        /// <summary>
        /// 栏目id
        /// </summary>
        public int Menu { get; set; }
        public string DutyUserName { get; set; }
        public string DepIDName { get; set; }
        public string AlluserID { get; set; }//参与人id

        public string CreateUserName { get; set; }
        ///<summary>
        ///计划ID
        ///</summary>
        public string PlanID
        {
            get
            {
                return planid;
            }
            set
            {
                planid = value;
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
        ///周号
        ///</summary>
        public int WeekNum
        {
            get
            {
                return weeknum;
            }
            set
            {
                weeknum = value;
            }
        }

        ///<summary>
        ///内容
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
        ///参与人
        ///</summary>
        public string AllUsers
        {
            get
            {
                return allusers;
            }
            set
            {
                allusers = value;
            }
        }

        ///<summary>
        ///责任人
        ///</summary>
        public string DutyUser
        {
            get
            {
                return dutyuser;
            }
            set
            {
                dutyuser = value;
            }
        }

        ///<summary>
        ///实施时间
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
        ///结束时间
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
        ///部门
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
        ///
        ///</summary>
        public int IsComplete
        {
            get
            {
                return iscomplete;
            }
            set
            {
                iscomplete = value;
            }
        }

        ///<summary>
        ///是否发提示消息
        ///</summary>
        public int IsSendMess
        {
            get
            {
                return issendmess;
            }
            set
            {
                issendmess = value;
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

