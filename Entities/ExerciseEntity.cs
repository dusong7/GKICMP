/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年09月02日 08点34分
** 描   述:      题目实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ExerciseEntity
    {

        /// <summary>
        /// Exercise表实体
        ///</summary>
        public ExerciseEntity()
        {
        }


        /// <summary>
        /// Exercise表实体
        /// </summary>
        /// <param name="eid">题目ID</param>
        /// <param name="cid">课程ID</param>
        /// <param name="gradeid">年级ID</param>
        /// <param name="term">学期ID</param>
        /// <param name="etype">题型</param>
        /// <param name="ttile">题目</param>
        /// <param name="difficulty">难易程度</param>
        /// <param name="options">选项</param>
        /// <param name="answer">答案</param>
        /// <param name="score">分数</param>
        public ExerciseEntity(int eid, int cid, int gradeid, int term, int etype, string ttile, int difficulty, string options, string answer, int score)
        {
            this.EID = eid;
            this.CID = cid;
            this.GradeID = gradeid;
            this.Term = term;
            this.EType = etype;
            this.Ttile = ttile;
            this.Difficulty = difficulty;
            this.Options = options;
            this.Answer = answer;
            this.Score = score;
        }

        private int eid;//题目ID
        private int cid;//课程ID
        private int gradeid;//年级ID
        private int term;//学期ID
        private int etype;//题型
        private string ttile;//题目
        private int difficulty;//难易程度
        private string options;//选项
        private string answer;//答案
        private int score;//分数
        private string cIDName;//课程名称
        private int isdel;

        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        public string CIDName
        {
            get { return cIDName; }
            set { cIDName = value; }
        }


        ///<summary>
        ///题目ID
        ///</summary>
        public int EID
        {
            get
            {
                return eid;
            }
            set
            {
                eid = value;
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
        ///年级ID
        ///</summary>
        public int GradeID
        {
            get
            {
                return gradeid;
            }
            set
            {
                gradeid = value;
            }
        }

        ///<summary>
        ///学期ID
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
        ///题型
        ///</summary>
        public int EType
        {
            get
            {
                return etype;
            }
            set
            {
                etype = value;
            }
        }

        ///<summary>
        ///题目
        ///</summary>
        public string Ttile
        {
            get
            {
                return ttile;
            }
            set
            {
                ttile = value;
            }
        }

        ///<summary>
        ///难易程度
        ///</summary>
        public int Difficulty
        {
            get
            {
                return difficulty;
            }
            set
            {
                difficulty = value;
            }
        }

        ///<summary>
        ///选项
        ///</summary>
        public string Options
        {
            get
            {
                return options;
            }
            set
            {
                options = value;
            }
        }

        ///<summary>
        ///答案
        ///</summary>
        public string Answer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
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
    }
}

