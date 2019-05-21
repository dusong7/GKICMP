/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2018年01月05日 04点19分
** 描   述:      学生考勤实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class StuLeaveEntity
    {

        /// <summary>
        /// StuLeave表实体
        ///</summary>
        public StuLeaveEntity()
        {
        }


        /// <summary>
        /// StuLeave表实体
        /// </summary>
        /// <param name="lid">ID</param>
        /// <param name="leaveuser">请假人</param>
        /// <param name="did">班级ID</param>
        /// <param name="leavedate">请假时间</param>
        /// <param name="leavedays">请假天数</param>
        /// <param name="leavemark">备注</param>
        /// <param name="attendstate">状态</param>
        public StuLeaveEntity(string lid, string leaveuser, int did, DateTime leavedate, decimal leavedays, string leavemark, int attendstate)
        {
            this.LID = lid;
            this.LeaveUser = leaveuser;
            this.DID = did;
            this.LeaveDate = leavedate;
            this.LeaveDays = leavedays;
            this.LeaveMark = leavemark;
            this.AttendState = attendstate;
        }

        private string lid;//ID
        private string leaveuser;//请假人
        private int did;//班级ID
        private DateTime leavedate;//请假时间
        private decimal leavedays;//请假天数
        private string leavemark;//备注
        private int attendstate;//状态
        private string leaveUserName;//请假人
        private string dIDName;//班级

        public string DIDName
        {
            get { return dIDName; }
            set { dIDName = value; }
        }

        public string LeaveUserName
        {
            get { return leaveUserName; }
            set { leaveUserName = value; }
        }


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
        ///班级ID
        ///</summary>
        public int DID
        {
            get
            {
                return did;
            }
            set
            {
                did = value;
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
        ///备注
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
        public int AttendState
        {
            get
            {
                return attendstate;
            }
            set
            {
                attendstate = value;
            }
        }
    }
}

