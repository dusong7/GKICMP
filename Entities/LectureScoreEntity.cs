/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月24日 08点09分
** 描   述:      评分实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Lecture_ScoreEntity
    {

        /// <summary>
        /// Lecture_Score表实体
        ///</summary>
        public Lecture_ScoreEntity()
        {
        }


        /// <summary>
        /// Lecture_Score表实体
        /// </summary>
        /// <param name="sid">ID</param>
        /// <param name="lsid">班级</param>
        /// <param name="score">科目</param>
        /// <param name="lid">时间</param>
        /// <param name="createuser">结束时间</param>
        /// <param name="createdate">授课教师</param>
        public Lecture_ScoreEntity(string sid, int lsid, int score, string lid, string createuser, DateTime createdate)
        {
            this.SID = sid;
            this.LSID = lsid;
            this.Score = score;
            this.LID = lid;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
        }

        private string sid;//ID
        private int lsid;//班级
        private int score;//科目
        private string lid;//时间
        private string createuser;//结束时间
        private DateTime createdate;//授课教师


        ///<summary>
        ///ID
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
        ///班级
        ///</summary>
        public int LSID
        {
            get
            {
                return lsid;
            }
            set
            {
                lsid = value;
            }
        }

        ///<summary>
        ///科目
        ///</summary>
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        ///<summary>
        ///时间
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
        ///结束时间
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
        ///授课教师
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
    }
}

