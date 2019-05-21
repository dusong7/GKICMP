/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2018年01月03日 09点27分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Electiver_CourseGradeEntity
    {

        /// <summary>
        /// Electiver_CourseGrade表实体
        ///</summary>
        public Electiver_CourseGradeEntity()
        {
        }


        /// <summary>
        /// Electiver_CourseGrade表实体
        /// </summary>
        /// <param name="ecgid">ID</param>
        /// <param name="ecid">选课课程ID</param>
        /// <param name="eleid">任务ID</param>
        /// <param name="gid">年级ID</param>
        public Electiver_CourseGradeEntity(int ecgid, int ecid, int eleid, int gid)
        {
            this.ECGID = ecgid;
            this.ECID = ecid;
            this.EleID = eleid;
            this.GID = gid;
        }

        private int ecgid;//ID
        private int ecid;//选课课程ID
        private int eleid;//任务ID
        private int gid;//年级ID


        ///<summary>
        ///ID
        ///</summary>
        public int ECGID
        {
            get
            {
                return ecgid;
            }
            set
            {
                ecgid = value;
            }
        }

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
        ///年级ID
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
    }
}

