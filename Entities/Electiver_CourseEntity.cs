/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2018年01月03日 09点10分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Electiver_CourseEntity
    {

        /// <summary>
        /// Electiver_Course表实体
        ///</summary>
        public Electiver_CourseEntity()
        {
        }


        /// <summary>
        /// Electiver_Course表实体
        /// </summary>
        /// <param name="ecid">选课课程ID</param>
        /// <param name="eleid">任务ID</param>
        /// <param name="courseid">课程ID</param>
        /// <param name="clevel">课程级别</param>
        /// <param name="maxcount">报名限制人数</param>
        public Electiver_CourseEntity(int ecid, int eleid, int courseid, int clevel, int maxcount)
        {
            this.ECID = ecid;
            this.EleID = eleid;
            this.CourseID = courseid;
            this.Clevel = clevel;
            this.MaxCount = maxcount;
        }

        private int ecid;//选课课程ID
        private int eleid;//任务ID
        private int courseid;//课程ID
        private int clevel;//课程级别
        private int maxcount;//报名限制人数


        ///<summary>
        ///选课课程ID
        ///</summary>
        public int ECID
        {
            get
            {
                return ecid;
            }
            set
            {
                ecid = value;
            }
        }

        ///<summary>
        ///任务ID
        ///</summary>
        public int EleID
        {
            get
            {
                return eleid;
            }
            set
            {
                eleid = value;
            }
        }

        ///<summary>
        ///课程ID
        ///</summary>
        public int CourseID
        {
            get
            {
                return courseid;
            }
            set
            {
                courseid = value;
            }
        }

        ///<summary>
        ///课程级别
        ///</summary>
        public int Clevel
        {
            get
            {
                return clevel;
            }
            set
            {
                clevel = value;
            }
        }

        ///<summary>
        ///报名限制人数
        ///</summary>
        public int MaxCount
        {
            get
            {
                return maxcount;
            }
            set
            {
                maxcount = value;
            }
        }
    }
}

