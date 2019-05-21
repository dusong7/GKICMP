/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月22日 09点02分
** 描   述:      教师听课实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class LectureEntity
    {

        /// <summary>
        /// Lecture表实体
        ///</summary>
        public LectureEntity()
        {
        }


        /// <summary>
        /// Lecture表实体
        /// </summary>
        /// <param name="lid">ID</param>
        /// <param name="claid">班级</param>
        /// <param name="cid">科目</param>
        /// <param name="cnum">第几节课</param>
        /// <param name="begindate">时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="tid">授课教师</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="lscore">得分</param>
        /// <param name="isdel">是否删除</param>
        public LectureEntity(string lid, int claid, int cid, int cnum, DateTime begindate, DateTime enddate, string tid, string createuser, DateTime createdate, int lscore, int isdel)
        {
            this.LID = lid;
            this.ClaID = claid;
            this.CID = cid;
            this.CNum = cnum;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.TID = tid;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.LScore = lscore;
            this.Isdel = isdel;
        }

        private string lid;//ID
        private int claid;//班级
        private int cid;//科目
        private int cnum;//第几节课
        private DateTime begindate;//时间
        private DateTime enddate;//结束时间
        private string tid;//授课教师
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private int lscore;//得分
        private int isdel;//是否删除
        private string classname;
        private string coursename;
        private string teachername;

        public string TeacherName
        {
            get { return teachername; }
            set { teachername = value; }
        }

        public string CourseName
        {
            get { return coursename; }
            set { coursename = value; }
        }

        public string ClassName
        {
            get { return classname; }
            set { classname = value; }
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
        ///班级
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
        ///科目
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
        ///第几节课
        ///</summary>
        public int CNum
        {
            get
            {
                return cnum;
            }
            set
            {
                cnum = value;
            }
        }

        ///<summary>
        ///时间
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
        ///结束时间
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
        ///授课教师
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
        ///得分
        ///</summary>
        public int LScore
        {
            get
            {
                return lscore;
            }
            set
            {
                lscore = value;
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

