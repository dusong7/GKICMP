/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年08月11日 01点36分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Exam_StudentEntity
    {

        /// <summary>
        /// Exam_Student表实体
        ///</summary>
        public Exam_StudentEntity()
        {
        }


        /// <summary>
        /// Exam_Student表实体
        /// </summary>
        /// <param name="esid">考试科目ID</param>
        /// <param name="eid">考试ID</param>
        /// <param name="erid">考场ID</param>
        /// <param name="stid">学生</param>
        /// <param name="score1">成绩1</param>
        /// <param name="score2">成绩2</param>
        /// <param name="score3">成绩3</param>
        /// <param name="score4">成绩4</param>
        /// <param name="score5">成绩5</param>
        /// <param name="score6">成绩6</param>
        /// <param name="score7">成绩7</param>
        /// <param name="score8">成绩8</param>
        /// <param name="score9">成绩9</param>
        /// <param name="score10">成绩10</param>
        /// <param name="score11">成绩11</param>
        /// <param name="score12">成绩12</param>
        public Exam_StudentEntity(int esid, string eid, int erid, string stid, decimal score1, decimal score2, decimal score3, decimal score4, decimal score5, decimal score6, decimal score7, decimal score8, decimal score9, decimal score10, decimal score11, decimal score12)
        {
            this.ESID = esid;
            this.EID = eid;
            this.ERID = erid;
            this.StID = stid;
            this.Score1 = score1;
            this.Score2 = score2;
            this.Score3 = score3;
            this.Score4 = score4;
            this.Score5 = score5;
            this.Score6 = score6;
            this.Score7 = score7;
            this.Score8 = score8;
            this.Score9 = score9;
            this.Score10 = score10;
            this.Score11 = score11;
            this.Score12 = score12;
        }

        private int esid;//考试科目ID
        private string eid;//考试ID
        private int erid;//考场ID
        private string stid;//学生
        private decimal score1;//成绩1
        private decimal score2;//成绩2
        private decimal score3;//成绩3
        private decimal score4;//成绩4
        private decimal score5;//成绩5
        private decimal score6;//成绩6
        private decimal score7;//成绩7
        private decimal score8;//成绩8
        private decimal score9;//成绩9
        private decimal score10;//成绩10
        private decimal score11;//成绩11
        private decimal score12;//成绩12


        ///<summary>
        ///考试科目ID
        ///</summary>
        public int ESID
        {
            get
            {
                return esid;
            }
            set
            {
                esid = value;
            }
        }

        ///<summary>
        ///考试ID
        ///</summary>
        public string EID
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
        ///考场ID
        ///</summary>
        public int ERID
        {
            get
            {
                return erid;
            }
            set
            {
                erid = value;
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
        ///成绩1
        ///</summary>
        public decimal Score1
        {
            get
            {
                return score1;
            }
            set
            {
                score1 = value;
            }
        }

        ///<summary>
        ///成绩2
        ///</summary>
        public decimal Score2
        {
            get
            {
                return score2;
            }
            set
            {
                score2 = value;
            }
        }

        ///<summary>
        ///成绩3
        ///</summary>
        public decimal Score3
        {
            get
            {
                return score3;
            }
            set
            {
                score3 = value;
            }
        }

        ///<summary>
        ///成绩4
        ///</summary>
        public decimal Score4
        {
            get
            {
                return score4;
            }
            set
            {
                score4 = value;
            }
        }

        ///<summary>
        ///成绩5
        ///</summary>
        public decimal Score5
        {
            get
            {
                return score5;
            }
            set
            {
                score5 = value;
            }
        }

        ///<summary>
        ///成绩6
        ///</summary>
        public decimal Score6
        {
            get
            {
                return score6;
            }
            set
            {
                score6 = value;
            }
        }

        ///<summary>
        ///成绩7
        ///</summary>
        public decimal Score7
        {
            get
            {
                return score7;
            }
            set
            {
                score7 = value;
            }
        }

        ///<summary>
        ///成绩8
        ///</summary>
        public decimal Score8
        {
            get
            {
                return score8;
            }
            set
            {
                score8 = value;
            }
        }

        ///<summary>
        ///成绩9
        ///</summary>
        public decimal Score9
        {
            get
            {
                return score9;
            }
            set
            {
                score9 = value;
            }
        }

        ///<summary>
        ///成绩10
        ///</summary>
        public decimal Score10
        {
            get
            {
                return score10;
            }
            set
            {
                score10 = value;
            }
        }

        ///<summary>
        ///成绩11
        ///</summary>
        public decimal Score11
        {
            get
            {
                return score11;
            }
            set
            {
                score11 = value;
            }
        }

        ///<summary>
        ///成绩12
        ///</summary>
        public decimal Score12
        {
            get
            {
                return score12;
            }
            set
            {
                score12 = value;
            }
        }
    }
}

