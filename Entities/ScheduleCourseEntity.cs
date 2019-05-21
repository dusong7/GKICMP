/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月19日 02点01分
** 描   述:      排课课程表实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ScheduleCourseEntity
    {

        /// <summary>
        /// ScheduleCourse表实体
        ///</summary>
        public ScheduleCourseEntity()
        {
        }


        /// <summary>
        /// ScheduleCourse表实体
        /// </summary>
        /// <param name="scid">排课ID</param>
        /// <param name="claid">班级ID</param>
        /// <param name="cid">课程ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="crid">教室ID</param>
        /// <param name="position">课表位置</param>
        /// <param name="shoukezhou">授课周数</param>
        /// <param name="courseid">课表ID</param>
        /// <param name="courserepeat">课程连续重复</param>
        /// <param name="teacherrepeat">教师连续重复</param>
        public ScheduleCourseEntity(string scid, int claid, int cid, string tid, int crid, int position, string shoukezhou, int courseid, string courserepeat, string teacherrepeat)
        {
            this.SCID = scid;
            this.ClaID = claid;
            this.CID = cid;
            this.TID = tid;
            this.CRID = crid;
            this.Position = position;
            this.ShouKeZhou = shoukezhou;
            this.CourseID = courseid;
            this.CourseRepeat = courserepeat;
            this.TeacherRepeat = teacherrepeat;
        }

        private string scid;//排课ID
        private int claid;//班级ID
        private int cid;//课程ID
        private string tid;//教师ID
        private int crid;//教室ID
        private int position;//课表位置
        private string shoukezhou;//授课周数
        private int courseid;//课表ID
        private string courserepeat;//课程连续重复
        private string teacherrepeat;//教师连续重复
        private int term;//学期
        private int isdel;//是否删除
        private string eYear;//学年度
        public int Term
        {
            get { return term; }
            set { term = value; }
        }


        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }


        public string EYear
        {
            get { return eYear; }
            set { eYear = value; }
        }


        ///<summary>
        ///排课ID
        ///</summary>
        public string SCID
        {
            get
            {
                return scid;
            }
            set
            {
                scid = value;
            }
        }

        ///<summary>
        ///班级ID
        ///</summary>
        public int ClaID
        {
            get
            {
                return claid;
            }
            set
            {
                claid = value;
            }
        }

        ///<summary>
        ///课程ID
        ///</summary>
        public int CID
        {
            get
            {
                return cid;
            }
            set
            {
                cid = value;
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
        ///教室ID
        ///</summary>
        public int CRID
        {
            get
            {
                return crid;
            }
            set
            {
                crid = value;
            }
        }

        ///<summary>
        ///课表位置
        ///</summary>
        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        ///<summary>
        ///授课周数
        ///</summary>
        public string ShouKeZhou
        {
            get
            {
                return shoukezhou;
            }
            set
            {
                shoukezhou = value;
            }
        }

        ///<summary>
        ///课表ID
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
        ///课程连续重复
        ///</summary>
        public string CourseRepeat
        {
            get
            {
                return courserepeat;
            }
            set
            {
                courserepeat = value;
            }
        }

        ///<summary>
        ///教师连续重复
        ///</summary>
        public string TeacherRepeat
        {
            get
            {
                return teacherrepeat;
            }
            set
            {
                teacherrepeat = value;
            }
        }
    }
}

