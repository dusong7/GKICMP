/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月19日 10点02分
** 描   述:      排课基础设置实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ScheduleSetEntity
    {

        /// <summary>
        /// ScheduleSet表实体
        ///</summary>
        public ScheduleSetEntity()
        {
        }


        /// <summary>
        /// ScheduleSet表实体
        /// </summary>
        /// <param name="sid">SID</param>
        /// <param name="courseday">每周上课天数</param>
        /// <param name="morningpitch">上午节数</param>
        /// <param name="afterpitch">下午节数</param>
        /// <param name="eveningpitch">晚上节数</param>
        /// <param name="ismorningread">是否安排早自习</param>
        /// <param name="issingle">是否有单双周课程</param>
        /// <param name="isoptional">是否有自主选修课程</param>
        /// <param name="isweekly">是否有按周授课课程</param>
        public ScheduleSetEntity(string sid, int courseday, int morningpitch, int afterpitch, int eveningpitch, int ismorningread, int issingle, int isoptional, int isweekly)
        {
            this.SID = sid;
            this.CourseDay = courseday;
            this.MorningPitch = morningpitch;
            this.AfterPitch = afterpitch;
            this.EveningPitch = eveningpitch;
            this.IsMorningRead = ismorningread;
            this.IsSingle = issingle;
            this.IsOptional = isoptional;
            this.IsWeekly = isweekly;
        }

        private string sid;//SID
        private int courseday;//每周上课天数
        private int morningpitch;//上午节数
        private int afterpitch;//下午节数
        private int eveningpitch;//晚上节数
        private int ismorningread;//是否安排早自习
        private int issingle;//是否有单双周课程
        private int isoptional;//是否有自主选修课程
        private int isweekly;//是否有按周授课课程
        private string noTimetable;//不排课

        public string NoTimetable
        {
            get { return noTimetable; }
            set { noTimetable = value; }
        }


        ///<summary>
        ///SID
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
        ///每周上课天数
        ///</summary>
        public int CourseDay
        {
            get
            {
                return courseday;
            }
            set
            {
                courseday = value;
            }
        }

        ///<summary>
        ///上午节数
        ///</summary>
        public int MorningPitch
        {
            get
            {
                return morningpitch;
            }
            set
            {
                morningpitch = value;
            }
        }

        ///<summary>
        ///下午节数
        ///</summary>
        public int AfterPitch
        {
            get
            {
                return afterpitch;
            }
            set
            {
                afterpitch = value;
            }
        }

        ///<summary>
        ///晚上节数
        ///</summary>
        public int EveningPitch
        {
            get
            {
                return eveningpitch;
            }
            set
            {
                eveningpitch = value;
            }
        }

        ///<summary>
        ///是否安排早自习
        ///</summary>
        public int IsMorningRead
        {
            get
            {
                return ismorningread;
            }
            set
            {
                ismorningread = value;
            }
        }

        ///<summary>
        ///是否有单双周课程
        ///</summary>
        public int IsSingle
        {
            get
            {
                return issingle;
            }
            set
            {
                issingle = value;
            }
        }

        ///<summary>
        ///是否有自主选修课程
        ///</summary>
        public int IsOptional
        {
            get
            {
                return isoptional;
            }
            set
            {
                isoptional = value;
            }
        }

        ///<summary>
        ///是否有按周授课课程
        ///</summary>
        public int IsWeekly
        {
            get
            {
                return isweekly;
            }
            set
            {
                isweekly = value;
            }
        }
    }
}

