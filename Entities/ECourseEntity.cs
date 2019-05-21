/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2018年01月03日 09点10分
** 描   述:      课程实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ECourseEntity
    {

        /// <summary>
        /// ECourse表实体
        ///</summary>
        public ECourseEntity()
        {
        }


        /// <summary>
        /// ECourse表实体
        /// </summary>
        /// <param name="cid">课程ID</param>
        /// <param name="courseother">课程编码</param>
        /// <param name="coursename">课程名称</param>
        /// <param name="coursedesc">课程简介</param>
        /// <param name="coursegrade">课程等级</param>
        /// <param name="coursetype">课程类别</param>
        /// <param name="createdate">创建时间</param>
        /// <param name="isdel">是否删除</param>
        public ECourseEntity(int cid, string courseother, string coursename, string coursedesc, int coursegrade, int coursetype, DateTime createdate, int isdel)
        {
            this.CID = cid;
            this.CourseOther = courseother;
            this.CourseName = coursename;
            this.CourseDesc = coursedesc;
            this.CourseGrade = coursegrade;
            this.CourseType = coursetype;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private int cid;//课程ID
        private string courseother;//课程编码
        private string coursename;//课程名称
        private string coursedesc;//课程简介
        private int coursegrade;//课程等级
        private int coursetype;//课程类别
        private DateTime createdate;//创建时间
        private int isdel;//是否删除
        private string courseGradeName;
        private string courseTypeName;

        public string CourseTypeName
        {
            get { return courseTypeName; }
            set { courseTypeName = value; }
        }

        public string CourseGradeName
        {
            get { return courseGradeName; }
            set { courseGradeName = value; }
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
        ///课程编码
        ///</summary>
        public string CourseOther
        {
            get
            {
                return courseother;
            }
            set
            {
                courseother = value;
            }
        }

        ///<summary>
        ///课程名称
        ///</summary>
        public string CourseName
        {
            get
            {
                return coursename;
            }
            set
            {
                coursename = value;
            }
        }

        ///<summary>
        ///课程简介
        ///</summary>
        public string CourseDesc
        {
            get
            {
                return coursedesc;
            }
            set
            {
                coursedesc = value;
            }
        }

        ///<summary>
        ///课程等级
        ///</summary>
        public int CourseGrade
        {
            get
            {
                return coursegrade;
            }
            set
            {
                coursegrade = value;
            }
        }

        ///<summary>
        ///课程类别
        ///</summary>
        public int CourseType
        {
            get
            {
                return coursetype;
            }
            set
            {
                coursetype = value;
            }
        }

        ///<summary>
        ///创建时间
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

