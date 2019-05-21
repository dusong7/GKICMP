/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年03月02日 10点52分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class CourseEntity
    {

        /// <summary>
        /// Course表实体
        ///</summary>
        public CourseEntity()
        {
        }


        /// <summary>
        /// Course表实体
        /// </summary>
        /// <param name="cid">课程ID</param>
        /// <param name="coursename">课程名称</param>
        /// <param name="courseother">课程别名</param>
        /// <param name="materialnum">教材数</param>
        /// <param name="editionnum">教材版本数</param>
        /// <param name="isopen"></param>
        /// <param name="isstanard">是否国标</param>
        /// <param name="createdate">创建时间</param>
        /// <param name="coursegrade">课程等级</param>
        /// <param name="ismain">是否主课</param>
        /// <param name="isdel">是否删除</param>
        public CourseEntity(int cid, string coursename, string courseother, int materialnum, int editionnum, int isopen, int isstanard, DateTime createdate, int coursegrade, int ismain, int isdel)
        {
            this.CID = cid;
            this.CourseName = coursename;
            this.CourseOther = courseother;
            this.MaterialNum = materialnum;
            this.EditionNum = editionnum;
            this.IsOpen = isopen;
            this.IsStanard = isstanard;
            this.CreateDate = createdate;
            this.CourseGrade = coursegrade;
            this.IsMain = ismain;
            this.Isdel = isdel;
        }

        private int cid;//课程ID
        private string coursename;//课程名称
        private string courseother;//课程别名
        private int materialnum;//教材数
        private int editionnum;//教材版本数
        private int isopen;//是否开设
        private int isstanard;//是否国标
        private DateTime createdate;//创建时间
        private int coursegrade;//课程等级
        private int ismain;//是否主课
        private int isdel;//是否删除
        private int isElective; //是否选修课程

        public int IsElective
        {
            get { return isElective; }
            set { isElective = value; }
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
        ///课程别名
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
        ///教材数
        ///</summary>
        public int MaterialNum
        {
            get
            {
                return materialnum;
            }
            set
            {
                materialnum = value;
            }
        }

        ///<summary>
        ///教材版本数
        ///</summary>
        public int EditionNum
        {
            get
            {
                return editionnum;
            }
            set
            {
                editionnum = value;
            }
        }

        ///<summary>
        ///是否开设
        ///</summary>
        public int IsOpen
        {
            get
            {
                return isopen;
            }
            set
            {
                isopen = value;
            }
        }

        ///<summary>
        ///是否国标
        ///</summary>
        public int IsStanard
        {
            get
            {
                return isstanard;
            }
            set
            {
                isstanard = value;
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
        ///是否主课
        ///</summary>
        public int IsMain
        {
            get
            {
                return ismain;
            }
            set
            {
                ismain = value;
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
