/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月08日 05点53分
** 描   述:      选课成绩实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Electiver_ScoreEntity
    {

        /// <summary>
        /// Electiver_Score表实体
        ///</summary>
        public Electiver_ScoreEntity()
        {
        }


        /// <summary>
        /// Electiver_Score表实体
        /// </summary>
        /// <param name="ssid">成绩ID</param>
        /// <param name="eleid">任务ID</param>
        /// <param name="stid">学生</param>
        /// <param name="score">分数</param>
        /// <param name="courseid">科目</param>
        /// <param name="eyear">学年</param>
        /// <param name="termid">学期</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate"></param>
        public Electiver_ScoreEntity( int courseid, string eyear, int termid)
        {
            this.CourseID = courseid;
            this.EYear = eyear;
            this.TermID = termid;
        }

        private int ssid;//成绩ID
        private int eleid;//任务ID
        private string stid;//学生
        private int score;//分数
        private int courseid;//科目
        private string eyear;//学年
        private int termid;//学期
        private string createuser;//录入人
        private DateTime createdate;//


        ///<summary>
        ///成绩ID
        ///</summary>
        public int SSID
        {
            get
            {
                return ssid;
            }
            set
            {
                ssid = value;
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
        ///学生
        ///</summary>
        public string StID
        {
            get
            {
                return stid;
            }
            set
            {
                stid = value;
            }
        }

        ///<summary>
        ///分数
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
        ///科目
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
        ///学年
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
        public int TermID
        {
            get
            {
                return termid;
            }
            set
            {
                termid = value;
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
        ///
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

