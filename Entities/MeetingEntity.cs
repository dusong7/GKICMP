/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月15日 08点18分
** 描   述:      会议实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{
    public class MeetingEntity
    {
        /// <summary>
        /// Meeting表实体
        ///</summary>
        public MeetingEntity()
        {
        }


        /// <summary>
        /// Meeting表实体
        /// </summary>
        /// <param name="mid">会议ID</param>
        /// <param name="mtitle">会议主题</param>
        /// <param name="mcontent">会议内容</param>
        /// <param name="meetingroom">会议室</param>
        /// <param name="mbegin">会议开始时间</param>
        /// <param name="mend">会议结束时间</param>
        /// <param name="linkuser">联系人</param>
        /// <param name="linknum">联系电话</param>
        /// <param name="meetinghost">会议主持人</param>
        /// <param name="minutes">会议纪要</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="userlist">外来人员</param>
        /// <param name="isdel">是否删除</param>
        public MeetingEntity(string mtitle, int meetingroom, int isdel)
        {
            this.MTitle = mtitle;
            this.MeetingRoom = meetingroom;
            this.Isdel = isdel;
        }

        private string mid;//会议ID
        private string mtitle;//会议主题
        private string mcontent;//会议内容
        private int meetingroom;//会议室
        private DateTime mbegin;//会议开始时间
        private DateTime mend;//会议结束时间
        private string linkuser;//联系人
        private string linknum;//联系电话
        private string meetinghost;//会议主持人
        private string minutes;//会议纪要
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private string userlist;//外来人员
        private int isdel;//是否删除
        private int auditstate;//审核状态
        private string audituser;//审核人
        private DateTime auditdate;//审核时间
        private string mrname;//会议室名称
        private string meetingHostName;
        private string meetingusers;//参会人员
        private string linkusername;//联系人

        public string LinkUserName
        {
            get { return linkusername; }
            set { linkusername = value; }
        }

        public string MeetingUsers
        {
            get { return meetingusers; }
            set { meetingusers = value; }
        }

        public string MeetingHostName
        {
            get { return meetingHostName; }
            set { meetingHostName = value; }
        }

        public string MRName
        {
            get { return mrname; }
            set { mrname = value; }
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int AuditState
        {
            get { return auditstate; }
            set { auditstate = value; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string AuditUser
        {
            get { return audituser; }
            set { audituser = value; }
        }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime AuditDate
        {
            get { return auditdate; }
            set { auditdate = value; }
        }

        ///<summary>
        ///会议ID
        ///</summary>
        public string MID
        {
            get
            {
                return mid;
            }
            set
            {
                mid = value;
            }
        }

        ///<summary>
        ///会议主题
        ///</summary>
        public string MTitle
        {
            get
            {
                return mtitle;
            }
            set
            {
                mtitle = value;
            }
        }

        ///<summary>
        ///会议内容
        ///</summary>
        public string MContent
        {
            get
            {
                return mcontent;
            }
            set
            {
                mcontent = value;
            }
        }

        ///<summary>
        ///会议室
        ///</summary>
        public int MeetingRoom
        {
            get
            {
                return meetingroom;
            }
            set
            {
                meetingroom = value;
            }
        }

        ///<summary>
        ///会议开始时间
        ///</summary>
        public DateTime MBegin
        {
            get
            {
                return mbegin;
            }
            set
            {
                mbegin = value;
            }
        }

        ///<summary>
        ///会议结束时间
        ///</summary>
        public DateTime MEnd
        {
            get
            {
                return mend;
            }
            set
            {
                mend = value;
            }
        }

        ///<summary>
        ///联系人
        ///</summary>
        public string LinkUser
        {
            get
            {
                return linkuser;
            }
            set
            {
                linkuser = value;
            }
        }

        ///<summary>
        ///联系电话
        ///</summary>
        public string LinkNum
        {
            get
            {
                return linknum;
            }
            set
            {
                linknum = value;
            }
        }

        ///<summary>
        ///会议主持人
        ///</summary>
        public string MeetingHost
        {
            get
            {
                return meetinghost;
            }
            set
            {
                meetinghost = value;
            }
        }

        ///<summary>
        ///会议纪要
        ///</summary>
        public string Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                minutes = value;
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
        ///外来人员
        ///</summary>
        public string UserList
        {
            get
            {
                return userlist;
            }
            set
            {
                userlist = value;
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