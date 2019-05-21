/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月21日 02点16分
** 描   述:      选课管理实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class CourseSelectionEntity
    {

        /// <summary>
        /// CourseSelection表实体
        ///</summary>
        public CourseSelectionEntity()
        {
        }


        /// <summary>
        /// CourseSelection表实体
        /// </summary>
        /// <param name="csid">ID</param>
        /// <param name="coursenames">所选课程名称</param>
        /// <param name="uid">学生iD</param>
        /// <param name="eyear">学年度</param>
        /// <param name="term">学期</param>
        /// <param name="issubmit">是否提交</param>
        /// <param name="selectdate">选课日期</param>
        /// <param name="isdel">是否删除</param>
        public CourseSelectionEntity(string csid, string coursenames, string uid, string eyear, int term, int issubmit, DateTime selectdate, int isdel)
        {
            this.CSID = csid;
            this.CourseNames = coursenames;
            this.UID = uid;
            this.EYear = eyear;
            this.Term = term;
            this.IsSubmit = issubmit;
            this.SelectDate = selectdate;
            this.Isdel = isdel;
        }

        private string csid;//ID
        private string coursenames;//所选课程名称
        private string uid;//学生iD
        private string eyear;//学年度
        private int term;//学期
        private int issubmit;//是否提交
        private DateTime selectdate;//选课日期
        private int isdel;//是否删除
        private string uIDName;
        private string courseID;

        public string CourseID
        {
            get { return courseID; }
            set { courseID = value; }
        }

        public string UIDName
        {
            get { return uIDName; }
            set { uIDName = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public string CSID
        {
            get
            {
                return csid;
            }
            set
            {
                csid = value;
            }
        }

        ///<summary>
        ///所选课程名称
        ///</summary>
        public string CourseNames
        {
            get
            {
                return coursenames;
            }
            set
            {
                coursenames = value;
            }
        }

        ///<summary>
        ///学生iD
        ///</summary>
        public string UID
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }

        ///<summary>
        ///学年度
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
        ///是否提交
        ///</summary>
        public int IsSubmit
        {
            get
            {
                return issubmit;
            }
            set
            {
                issubmit = value;
            }
        }

        ///<summary>
        ///选课日期
        ///</summary>
        public DateTime SelectDate
        {
            get
            {
                return selectdate;
            }
            set
            {
                selectdate = value;
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

