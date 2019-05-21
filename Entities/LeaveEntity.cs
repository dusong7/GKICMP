/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年07月06日 02点46分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class LeaveEntity
    {

        /// <summary>
        /// Leave表实体
        ///</summary>
        public LeaveEntity()
        {
        }


        /// <summary>
        /// Leave表实体
        /// </summary>
        /// <param name="lid">ID</param>
        /// <param name="leaveuser">请假人</param>
        /// <param name="leavedate">请假时间</param>
        /// <param name="begindate">请假开始时间</param>
        /// <param name="enddate">请假结束时间</param>
        /// <param name="leavedays">请假天数</param>
        /// <param name="leavemark">请假说明</param>
        /// <param name="leavestate">状态</param>
        /// <param name="leavefile">附件</param>
        /// <param name="lflag">标示  1:请假    2：外出登记</param>
        /// <param name="ltype">请假类型</param>
        /// <param name="isok">课程是否已安排</param>
        /// <param name="isteacher">是否是老师</param>
        /// <param name="isdel">是否删除</param>
        public LeaveEntity(string lid, string leaveuser, DateTime leavedate, DateTime begindate, DateTime enddate, decimal leavedays, string leavemark, int leavestate, string leavefile, int lflag, int ltype, int isok, int isteacher, int isdel)
        {
            this.LID = lid;
            this.LeaveUser = leaveuser;
            this.LeaveDate = leavedate;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.LeaveDays = leavedays;
            this.LeaveMark = leavemark;
            this.LeaveState = leavestate;
            this.LeaveFile = leavefile;
            this.LFlag = lflag;
            this.LType = ltype;
            this.IsOK = isok;
            this.IsTeacher = isteacher;
            this.Isdel = isdel;
        }

        private string lid;//ID
        private string leaveuser;//请假人
        private DateTime leavedate;//请假时间
        private DateTime begindate;//请假开始时间
        private DateTime enddate;//请假结束时间
        private decimal leavedays;//请假天数
        private string leavemark;//请假说明
        private int leavestate;//状态
        private string leavefile;//附件
        private int lflag;//标示  1:请假    2：外出登记
        private int ltype;//请假类型
        private int isok;//课程是否已安排
        private int isteacher;//是否是老师
        private int isdel;//是否删除
        private string lTypeName;

        public string LTypeName
        {
            get { return lTypeName; }
            set { lTypeName = value; }
        }

        public string LeaveUserName{ get; set; }
        public string AuditMark { get; set; }
        public DateTime AuditDate { get; set; }
        public string AuditUser { get; set; }
        ///<summary>
        ///ID
        ///</summary>
        public string LID
        {
            get
            {
                return lid;
            }
            set
            {
                lid = value;
            }
        }

        ///<summary>
        ///请假人
        ///</summary>
        public string LeaveUser
        {
            get
            {
                return leaveuser;
            }
            set
            {
                leaveuser = value;
            }
        }

        ///<summary>
        ///请假时间
        ///</summary>
        public DateTime LeaveDate
        {
            get
            {
                return leavedate;
            }
            set
            {
                leavedate = value;
            }
        }

        ///<summary>
        ///请假开始时间
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
        ///请假结束时间
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
        ///请假天数
        ///</summary>
        public decimal LeaveDays
        {
            get
            {
                return leavedays;
            }
            set
            {
                leavedays = value;
            }
        }

        ///<summary>
        ///请假说明
        ///</summary>
        public string LeaveMark
        {
            get
            {
                return leavemark;
            }
            set
            {
                leavemark = value;
            }
        }

        ///<summary>
        ///状态
        ///</summary>
        public int LeaveState
        {
            get
            {
                return leavestate;
            }
            set
            {
                leavestate = value;
            }
        }

        ///<summary>
        ///附件
        ///</summary>
        public string LeaveFile
        {
            get
            {
                return leavefile;
            }
            set
            {
                leavefile = value;
            }
        }

        ///<summary>
        ///标示  1:请假    2：外出登记
        ///</summary>
        public int LFlag
        {
            get
            {
                return lflag;
            }
            set
            {
                lflag = value;
            }
        }

        ///<summary>
        ///请假类型
        ///</summary>
        public int LType
        {
            get
            {
                return ltype;
            }
            set
            {
                ltype = value;
            }
        }

        ///<summary>
        ///课程是否已安排
        ///</summary>
        public int IsOK
        {
            get
            {
                return isok;
            }
            set
            {
                isok = value;
            }
        }

        ///<summary>
        ///是否是老师
        ///</summary>
        public int IsTeacher
        {
            get
            {
                return isteacher;
            }
            set
            {
                isteacher = value;
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

